using System;   
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trowel.BspEditor.Environment.Xonotic
{
    [Export(typeof(IEnvironmentFactory))]
    public class XonoticEnvironmentFactory : IEnvironmentFactory
    {
        public Type Type => typeof(XonoticEnvironment);
        public string TypeName => Type.Name;
        public string Description { get; set; } = "Xonotic";

        public IEnvironmentEditor CreateEditor() => new XonoticEnvironmentEditor();

        public IEnvironment CreateEnvironment() => new XonoticEnvironment();

        public IEnvironment Deserialise(SerialisedEnvironment environment)
        {
            return new XonoticEnvironment
            {
                ID = environment.ID,
                Name = environment.Name,
                BaseDirectory = this.GetVal(environment.Properties, "BaseDirectory", ""),
                GameExe = this.GetVal(environment.Properties, "GameExe", ""),
                EntFile = this.GetVal(environment.Properties, "EntFile", ""),
                DefaultPointEntity = this.GetVal(environment.Properties, "DefaultPointEntity", ""),
                DefaultBrushEntity = this.GetVal(environment.Properties, "DefaultBrushEntity", ""),
                // TODO: add other properties
            };
        }

        public SerialisedEnvironment Serialise(IEnvironment environment)
        {
            var env = (XonoticEnvironment)environment;
            var se = new SerialisedEnvironment
            {
                ID = env.ID,
                Name = env.Name,
                Type = TypeName,
                Properties =
                {
                    { "BaseDirectory", env.BaseDirectory },
                    { "GameExe", env.GameExe },
                    { "EntFile", env.EntFile },
                    { "DefaultPointEntity", env.DefaultPointEntity },
                    { "DefaultBrushEntity", env.DefaultBrushEntity },                    
                    // TODO: add other properties
                }
            };
            return se;
        }
    }
}
