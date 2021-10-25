﻿using Trowel.BspEditor.Primitives.MapObjectData;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Transport;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Trowel.BspEditor.Primitives
{
    [Export]
    public class MapElementFactory
    {
        private readonly IEnumerable<Lazy<IMapElementFormatter>> _imports;

        [ImportingConstructor]
        public MapElementFactory([ImportMany] IEnumerable<Lazy<IMapElementFormatter>> imports)
        {
            _imports = imports;
        }

        public IMapElement Deserialise(SerialisedObject obj)
        {
            var elem = _imports.Select(x => x.Value).FirstOrDefault(x => x.IsSupported(obj))?.Deserialise(obj);

            if (elem is IMapObject mo)
            {
                foreach (var so in obj.Children)
                {
                    var data = Deserialise(so);
                    if (data is IMapObject o) o.Hierarchy.Parent = mo;
                    else if (data is IMapObjectData od) mo.Data.Add(od);
                }
            }

            return elem;
        }

        public SerialisedObject Serialise(IMapElement element)
        {
            return _imports.Select(x => x.Value).FirstOrDefault(x => x.IsSupported(element))?.Serialise(element);
        }
    }
}
