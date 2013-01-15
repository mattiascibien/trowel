﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;
using Sledge.Common;
using Sledge.DataStructures.MapObjects;
using Sledge.Graphics.Arrays;
using Sledge.Graphics.Shaders;

namespace Sledge.DataStructures.Rendering
{
    public class ArrayManager
    {
        public Dictionary<Solid, SolidVertexArray> Arrays { get; private set; }
        public List<IGrouping<ITexture, TextureSubset>> Cache;
        
        public ArrayManager(Map map)
        {
            Arrays = new Dictionary<Solid, SolidVertexArray>();
            Update(map);
        }

        public void Update(Map map)
        {
            foreach (Solid solid in map.WorldSpawn.Find(x => x is Solid))
            {
                if (!Arrays.ContainsKey(solid)) Arrays.Add(solid, new SolidVertexArray(solid));
                else Arrays[solid].Update();
            }
            Cache = Arrays.Values.SelectMany(x => x.Subsets).GroupBy(x => x.Texture).ToList();
        }

        public void Draw(ShaderProgram program)
        {
            GL.ActiveTexture(TextureUnit.Texture0);
            program.Set("currentTexture", 0);
            foreach (var group in Cache)
            {
                var tex = group.Key;
                if (tex != null) tex.Bind();
                program.Set("isTextured", tex != null);
                foreach (var ts in group)
                {
                    ts.Draw(program);
                }
            }
            return;
            foreach (var kv in Arrays)
            {
                kv.Value.Draw(program);
                //return;
            }
        }
    }

    public class TextureSubset
    {
        public int Start { get; private set; }
        public int Count { get; private set; }
        private SolidVertexArray _array;

        public ITexture Texture { get; set; }

        public TextureSubset(SolidVertexArray array, int start, int count, ITexture texture)
        {
            _array = array;
            Start = start;
            Count = count;
            Texture = texture;
        }

        public void Draw(ShaderProgram program)
        {
            _array.DrawSubset(this, program);
        }
    }

    public class SolidVertexArray
    {

        private static readonly ArraySpecification Specification;
        private const int SpecSize = 11;

        static SolidVertexArray()
        {
            Specification = new ArraySpecification(
                ArrayIndex.Vector3("Position"),
                ArrayIndex.Vector3("Normal"),
                ArrayIndex.Vector2("Texture"),
                ArrayIndex.Vector3("Colour"));
        }

        private const int BytesPerVertex = sizeof(float);
        private VertexArrayFloat _array;
        private Solid _solid;
        public List<TextureSubset> Subsets { get; private set; } 

        public SolidVertexArray(Solid solid)
        {
            _solid = solid;
            float[] array;
            short[] indices;
            int count;
            Subsets = new List<TextureSubset>();
            GetArrayData(out count, out array, out indices, Subsets);

            _array = new VertexArrayFloat(Specification, BeginMode.Triangles, count, array, indices);
        }

        public void DrawSubset(TextureSubset ts, ShaderProgram program)
        {
            _array.Bind();
            _array.DrawElements(ts.Start, ts.Count);
            _array.Unbind();
        }

        public void Draw(ShaderProgram program)
        {
            //_array.DrawElements(); //todo texturey stuff and so on
            _array.Bind();
            //_array.DrawElements(); //todo missing subset faces
            //_array.DrawElements(0, 6);
            //_array.DrawElements(6, 6);
            //_array.DrawElements(12, 6);
            //_array.DrawElements(18, 6);
            //_array.DrawElements(24, 6);
            //_array.DrawElements(30, 6);
            foreach (var ts in Subsets)
            {
                if (ts.Texture != null)
                {
                    ts.Texture.Bind();
                }
                else
                {
                    int i = 1;
                }
                program.Set("isTextured", ts.Texture != null);
               // break;
                _array.DrawElements(ts.Start, ts.Count);
                //break;
            }
            _array.Unbind();
        }

        public void Update()
        {
            float[] array;
            short[] indices;
            int count;
            Subsets.Clear();
            GetArrayData(out count, out array, out indices, Subsets);
            _array.Update(count, array, indices);
        }

        private void GetArrayData(out int count, out float[] array, out short[] indices, List<TextureSubset> subsets)
        {
            var indexList = new List<short>();
            var index = 0;
            var idx = 0;
            array = new float[SpecSize * _solid.Faces.Sum(x => x.Vertices.Count)];
            var subsetStart = 0;
            ITexture currentTexture = null;
            foreach (var face in _solid.Faces.OrderBy(x => x.Texture == null ? 0 : 1).ThenBy(x => x.Texture.Name))
            {
                if (indexList.Count > 0 && face.Texture.Texture != currentTexture)
                {
                    subsets.Add(new TextureSubset(this, subsetStart, indexList.Count - subsetStart, currentTexture));
                    subsetStart = indexList.Count;
                }
                currentTexture = face.Texture.Texture;
                float nx = (float) face.Plane.Normal.DX,
                        ny = (float) face.Plane.Normal.DY,
                        nz = (float) face.Plane.Normal.DZ;
                float r = face.Colour.R / 255f,
                        g = face.Colour.G / 255f,
                        b = face.Colour.B / 255f;
                foreach (var vert in face.Vertices)
                {
                    array[idx++] = ((float)vert.Location.DX);
                    array[idx++] = ((float)vert.Location.DY);
                    array[idx++] = ((float)vert.Location.DZ);
                    array[idx++] = (nx);
                    array[idx++] = (ny);
                    array[idx++] = (nz);
                    array[idx++] = ((float)vert.TextureU);
                    array[idx++] = ((float)vert.TextureV);
                    array[idx++] = (r);
                    array[idx++] = (g);
                    array[idx++] = (b);
                }
                for (short i = 1; i < face.Vertices.Count - 1; i++)
                {
                    indexList.Add((short) index);
                    indexList.Add((short) (index + i));
                    indexList.Add((short) (index + i + 1));
                }
                index += face.Vertices.Count;
            }
            subsets.Add(new TextureSubset(this, subsetStart, indexList.Count - subsetStart, currentTexture));
            indices = indexList.ToArray();
            count = indices.Length;
        }
    }
}
