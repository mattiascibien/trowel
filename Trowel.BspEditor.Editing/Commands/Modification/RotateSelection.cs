using Trowel.BspEditor.Commands;
using Trowel.BspEditor.Documents;
using Trowel.BspEditor.Modification;
using Trowel.BspEditor.Modification.Operations.Mutation;
using Trowel.BspEditor.Primitives.MapData;
using Trowel.Common;
using Trowel.Common.Shell.Commands;
using Trowel.Common.Shell.Context;
using System.ComponentModel.Composition;
using System.Numerics;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Editing.Commands.Modification
{
    [Export(typeof(ICommand))]
    [CommandID("BspEditor:Tools:Rotate")]
    public class RotateSelection : BaseCommand
    {
        public override string Name { get; set; } = "Rotate";
        public override string Details { get; set; } = "Rotate";

        protected override bool IsInContext(IContext context, MapDocument document)
        {
            return base.IsInContext(context, document) && !document.Selection.IsEmpty;
        }

        protected override async Task Invoke(MapDocument document, CommandParameters parameters)
        {
            var selBox = document.Selection.GetSelectionBoundingBox();

            var axis = parameters.Get<Vector3>("Axis");
            var amount = parameters.Get<float>("Angle");
            var radians = (float)MathHelper.DegreesToRadians(amount);

            var tl = document.Map.Data.GetOne<TransformationFlags>() ?? new TransformationFlags();

            var transaction = new Transaction();

            var tform = Matrix4x4.CreateTranslation(-selBox.Center)
                        * Matrix4x4.CreateFromAxisAngle(axis, radians)
                        * Matrix4x4.CreateTranslation(selBox.Center);

            var transformOperation = new BspEditor.Modification.Operations.Mutation.Transform(tform, document.Selection.GetSelectedParents());
            transaction.Add(transformOperation);

            // Check for texture transform
            if (tl.TextureLock) transaction.Add(new TransformTexturesUniform(tform, document.Selection));

            await MapDocumentOperation.Perform(document, transaction);
        }
    }
}
