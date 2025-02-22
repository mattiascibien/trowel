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
    public class SolidWithChildren : IProblemCheck
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Uri Url => null;
        public bool CanFix => true;

        public Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter)
        {
            var parents = document.Map.Root.FindAll()
                .OfType<Entity>()
                .Where(x => x.Hierarchy.HasChildren)
                .Where(x => filter(x))
                .Where(x => x.Find(f => !ReferenceEquals(f, x) && f is Entity).Any())
                .Select(x => new Problem().Add(x))
                .ToList();

            return Task.FromResult(parents);
        }

        public Task Fix(MapDocument document, Problem problem)
        {
            var transaction = new Transaction();

            foreach (var obj in problem.Objects.SelectMany(x => x.Find(f => f is Entity)).Distinct())
            {
                transaction.Add(new Detatch(obj.Hierarchy.Parent.ID, obj));
                transaction.Add(new Attach(document.Map.Root.ID, obj));
            }

            return MapDocumentOperation.Perform(document, transaction);
        }
    }
}