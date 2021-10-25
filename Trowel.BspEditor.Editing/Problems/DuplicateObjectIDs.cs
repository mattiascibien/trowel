using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Tree;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Problems
{
    [Export(typeof(IProblemCheck))]
    [AutoTranslate]
    public class DuplicateObjectIDs : IProblemCheck
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Uri Url => null;
        public bool CanFix => true;

        public Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter)
        {
            var dupes = document.Map.Root.FindAll()
                .Where(x => filter(x))
                .GroupBy(x => x.ID)
                .Where(x => x.Count() > 1)
                .Select(x => new Problem().Add(x))
                .ToList();

            return Task.FromResult(dupes);
        }

        public Task Fix(MapDocument document, Problem problem)
        {
            var edit = new Transaction();

            foreach (var obj in problem.Objects)
            {
                var copy = (IMapObject)obj.Copy(document.Map.NumberGenerator);

                edit.Add(new Detatch(obj.Hierarchy.Parent.ID, obj));
                edit.Add(new Attach(obj.Hierarchy.Parent.ID, copy));
            }

            return MapDocumentOperation.Perform(document, edit);
        }
    }
}