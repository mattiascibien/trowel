using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Editing.Properties;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Selection;
using Trowel.BspEditor.Modification.Operations.Tree;
using Trowel.BspEditor.Primitives.MapObjects;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using Trowel.Common.Shell.Hotkeys;
using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands
{
    [AutoTranslate]
    [Export(typeof(ICommand))]
    [MenuItem("Tools", "", "Entity", "D")]
    [CommandID("BspEditor:Tools:MoveToWorld")]
    [MenuImage(typeof(Resources), nameof(Resources.Menu_TieToWorld))]
    [DefaultHotkey("Ctrl+Shift+W")]
    public class MoveToWorld : BaseCommand
    {
        public override string Name { get; set; } = "Move to world";
        public override string Details { get; set; } = "Delete all selected solid entities and move their brushes back to the world.";

        protected override bool IsInContext(IContext context, MapDocument document)
        {
            return base.IsInContext(context, document) && document.Selection.Any(x => x is Entity);
        }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var entities = document.Selection.OfType<Entity>().ToList();

            if (!entities.Any()) return;

            // Deselect the entities we're about to delete
            var ops = new List<IOperation>
            {
                new Deselect(entities)
            };

            // Remove the children
            foreach (var entity in entities)
            {
                var children = entity.Hierarchy.Where(x => !(x is Entity)).ToList();

                if (children.Any())
                {
                    // Make sure we don't try and attach the solids back to an entity
                    var newParentId = entities.Contains(entity.Hierarchy.Parent)
                        ? document.Map.Root.ID
                        : entity.Hierarchy.Parent.ID;

                    // Move the entity's children to the new parent before removing the entity
                    ops.Add(new Detatch(entity.ID, children));
                    ops.Add(new Attach(newParentId, children));
                }
            }

            // Remove the parents
            foreach (var entity in entities)
            {
                // If the parent is a selected entity then we don't need to detach this one as the parent will be detatched
                if (!entities.Contains(entity.Hierarchy.Parent))
                {
                    ops.Add(new Detatch(entity.Hierarchy.Parent.ID, entity));
                }
            }

            await MapDocumentOperation.Perform(document, new Transaction(ops));
        }
    }
}