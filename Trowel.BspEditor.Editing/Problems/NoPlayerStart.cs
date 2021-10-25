using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Tree;
using Trowel.BspEditor.Primitives.MapObjectData;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common;
using Trowel.Common.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Problems
{
    [Export(typeof(IProblemCheck))]
    [AutoTranslate]
    public class NoPlayerStart : IProblemCheck
    {
        public string Name { get; set; }
        public string Details { get; set; }

        public Uri Url => null;
        public bool CanFix => true;

        public Task<List<Problem>> Check(MapDocument document, Predicate<IMapObject> filter)
        {
            var list = new List<Problem>();

            if (filter(document.Map.Root) && !document.Map.Root.Find(x => x is Entity && string.Equals(x.Data.GetOne<EntityData>()?.Name, "info_player_start", StringComparison.InvariantCultureIgnoreCase)).Any())
            {
                list.Add(new Problem());
            }

            return Task.FromResult(list);
        }

        public async Task Fix(MapDocument document, Problem problem)
        {
            var entity = new Entity(document.Map.NumberGenerator.Next("MapObject"))
            {
                Data =
                {
                    new EntityData { Name = "info_player_start" },
                    new ObjectColor(Colour.GetDefaultEntityColour()),
                    new Origin(Vector3.Zero),
                },
                IsSelected = false
            };

            var action = new Attach(document.Map.Root.ID, entity);
            await MapDocumentOperation.Perform(document, action);
        }
    }
}