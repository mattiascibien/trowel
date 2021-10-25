using Trowel.Common.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;

namespace Trowel.BspEditor.Environment.Goldsource
{
    [Export(typeof(IEnvironmentFactory))]
    [AutoTranslate]
    public class GoldsourceEnvironmentFactory : IEnvironmentFactory
    {
        public Type Type => typeof(GoldsourceEnvironment);
        public string TypeName => Type.Name;
        public string Description { get; set; } = "Goldsource";
               
        public IEnvironment Deserialise(SerialisedEnvironment environment)
        {
            var gse = new GoldsourceEnvironment()
            {
                ID = environment.ID,
                Name = environment.Name,
                BaseDirectory = this.GetVal(environment.Properties, "BaseDirectory", ""),
                GameDirectory = this.GetVal(environment.Properties, "GameDirectory", ""),
                ModDirectory = this.GetVal(environment.Properties, "ModDirectory", ""),
                GameExe = this.GetVal(environment.Properties, "GameExe", ""),
                LoadHdModels = this.GetVal(environment.Properties, "LoadHdModels", true),

                FgdFiles = this.GetVal(environment.Properties, "FgdFiles", "").Split(';').Where(x => !String.IsNullOrWhiteSpace(x)).ToList(),
                DefaultPointEntity = this.GetVal(environment.Properties, "DefaultPointEntity", ""),
                DefaultBrushEntity = this.GetVal(environment.Properties, "DefaultBrushEntity", ""),
                OverrideMapSize = this.GetVal(environment.Properties, "OverrideMapSize", false),
                MapSizeLow = this.GetVal(environment.Properties, "MapSizeLow", -4096m),
                MapSizeHigh = this.GetVal(environment.Properties, "MapSizeHigh", 4096m),
                IncludeFgdDirectoriesInEnvironment = this.GetVal(environment.Properties, "IncludeFgdDirectoriesInEnvironment", true),

                ToolsDirectory = this.GetVal(environment.Properties, "ToolsDirectory", ""),
                IncludeToolsDirectoryInEnvironment = this.GetVal(environment.Properties, "IncludeToolsDirectoryInEnvironment", true),
                BspExe = this.GetVal(environment.Properties, "BspExe", ""),
                CsgExe = this.GetVal(environment.Properties, "CsgExe", ""),
                VisExe = this.GetVal(environment.Properties, "VisExe", ""),
                RadExe = this.GetVal(environment.Properties, "RadExe", ""),

                GameCopyBsp = this.GetVal(environment.Properties, "GameCopyBsp", true),
                GameRun = this.GetVal(environment.Properties, "GameRun", true),
                GameAsk = this.GetVal(environment.Properties, "GameAsk", true),

                MapCopyBsp = this.GetVal(environment.Properties, "MapCopyBsp", false),
                MapCopyMap = this.GetVal(environment.Properties, "MapCopyMap", false),
                MapCopyLog = this.GetVal(environment.Properties, "MapCopyLog", false),
                MapCopyErr = this.GetVal(environment.Properties, "MapCopyErr", false),
                MapCopyRes = this.GetVal(environment.Properties, "MapCopyRes", false),

                DefaultTextureScale = this.GetVal(environment.Properties, "DefaultTextureScale", 1m),
                ExcludedWads = this.GetVal(environment.Properties, "ExcludedWads", "").Split(';').Where(x => !String.IsNullOrWhiteSpace(x)).ToList(),
                AdditionalTextureFiles = this.GetVal(environment.Properties, "AdditionalTextureFiles", "").Split(';').Where(x => !String.IsNullOrWhiteSpace(x)).ToList(),
            };
            return gse;
        }

        public SerialisedEnvironment Serialise(IEnvironment environment)
        {
            var env = (GoldsourceEnvironment)environment;
            var se = new SerialisedEnvironment
            {
                ID = environment.ID,
                Name = environment.Name,
                Type = TypeName,
                Properties =
                {
                    { "BaseDirectory", env.BaseDirectory },
                    { "GameDirectory", env.GameDirectory },
                    { "ModDirectory", env.ModDirectory },
                    { "GameExe", env.GameExe },
                    { "LoadHdModels", Convert.ToString(env.LoadHdModels, CultureInfo.InvariantCulture) },

                    { "FgdFiles", String.Join(";", env.FgdFiles) },
                    { "DefaultPointEntity", env.DefaultPointEntity },
                    { "DefaultBrushEntity", env.DefaultBrushEntity },
                    { "OverrideMapSize", Convert.ToString(env.OverrideMapSize, CultureInfo.InvariantCulture) },
                    { "MapSizeLow", Convert.ToString(env.MapSizeLow, CultureInfo.InvariantCulture) },
                    { "MapSizeHigh", Convert.ToString(env.MapSizeHigh, CultureInfo.InvariantCulture) },
                    { "IncludeFgdDirectoriesInEnvironment", Convert.ToString(env.IncludeFgdDirectoriesInEnvironment, CultureInfo.InvariantCulture) },

                    { "ToolsDirectory", env.ToolsDirectory },
                    { "IncludeToolsDirectoryInEnvironment", Convert.ToString(env.IncludeToolsDirectoryInEnvironment, CultureInfo.InvariantCulture) },
                    { "BspExe", env.BspExe },
                    { "CsgExe", env.CsgExe },
                    { "VisExe", env.VisExe },
                    { "RadExe", env.RadExe },

                    { "GameCopyBsp", Convert.ToString(env.GameCopyBsp, CultureInfo.InvariantCulture) },
                    { "GameRun", Convert.ToString(env.GameRun, CultureInfo.InvariantCulture) },
                    { "GameAsk", Convert.ToString(env.GameAsk, CultureInfo.InvariantCulture) },

                    { "MapCopyBsp", Convert.ToString(env.MapCopyBsp, CultureInfo.InvariantCulture) },
                    { "MapCopyMap", Convert.ToString(env.MapCopyMap, CultureInfo.InvariantCulture) },
                    { "MapCopyLog", Convert.ToString(env.MapCopyLog, CultureInfo.InvariantCulture) },
                    { "MapCopyErr", Convert.ToString(env.MapCopyErr, CultureInfo.InvariantCulture) },
                    { "MapCopyRes", Convert.ToString(env.MapCopyRes, CultureInfo.InvariantCulture) },

                    { "DefaultTextureScale", Convert.ToString(env.DefaultTextureScale, CultureInfo.InvariantCulture) },

                    { "ExcludedWads", String.Join(";", env.ExcludedWads) },
                    { "AdditionalTextureFiles", String.Join(";", env.AdditionalTextureFiles) }
                }
            };
            return se;
        }

        public IEnvironment CreateEnvironment()
        {
            return new GoldsourceEnvironment();
        }

        public IEnvironmentEditor CreateEditor()
        {
            return new GoldsourceEnvironmentEditor();
        }
    }
}