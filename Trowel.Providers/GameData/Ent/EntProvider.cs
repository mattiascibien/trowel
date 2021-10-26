using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Trowel.DataStructures.GameData;

namespace Trowel.Providers.GameData
{
    internal class EntProvider
    {
        public DataStructures.GameData.GameData OpenFile(string filename)
        {
            var gameData = new DataStructures.GameData.GameData();
            if (!File.Exists(filename)) throw new ProviderException("File does not exist: " + filename);

            XElement entElement = XElement.Load(filename);

            foreach (var element in entElement.Elements())
            {
                if (element.Name == "point")
                    gameData.Classes.Add(ParseEntity(element, DataStructures.GameData.ClassType.Point));
                else if (element.Name == "group")
                    gameData.Classes.Add(ParseEntity(element, DataStructures.GameData.ClassType.Solid));
                else
                    throw new ProviderException($"Tag {element.Name} not recognized");
            }

            return gameData;
        }

        private DataStructures.GameData.GameDataObject ParseEntity(XElement element, DataStructures.GameData.ClassType classType)
        {
            var gdo = new DataStructures.GameData.GameDataObject(element.Attribute("name").Value, BuildEntityDescription(element.Value), classType);

            foreach (var attribute in element.Attributes().Where(a => a.Name != "name"))
            {
                Behaviour behaviour;
                switch (attribute.Name.LocalName)
                {
                    case "color":
                        behaviour = new Behaviour(attribute.Name.LocalName, 
                            string.Join(" ", attribute.Value.Split(" ")
                                .Select(float.Parse)
                                .Select(f => (int)MathF.Round(f * 255))
                                .Select(i => i.ToString())
                                ));
                        break;
                    case "box":
                        string[] values = attribute.Value.Split();

                        string first = string.Join(" ", values.Take(3).ToArray());
                        string second = string.Join(" ", values.Skip(3).Take(3).ToArray());

                        behaviour = new Behaviour("size", first, second);
                        break;
                    default:
                        throw new ProviderException($"Unknown behavior {attribute.Name.LocalName}");
                }
                gdo.Behaviours.Add(behaviour);
            }

            foreach (var item in element.Elements())
            {
                VariableType variableType = StringToVariableType(item.Name.LocalName);
                Property prop = new Property(item.Attribute("key").Value, variableType)
                {
                    Description = item.Value,
                };

                gdo.Properties.Add(prop);
            }

            return gdo;
        }

        private static string BuildEntityDescription(string value)
        {
            StringBuilder builder = new StringBuilder();

            using (StringReader reader = new StringReader(value))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!line.StartsWith("--------"))
                        builder.AppendLine(line);

                    line = reader.ReadLine();
                }    
            }

            return builder.ToString();
        }

        private static VariableType StringToVariableType(string name)
        {
            switch (name)
            {
                case "direction":
                    return VariableType.String;
                case "angles":
                    return VariableType.Angle;
                case "target":
                    return VariableType.TargetDestination;
                case "targetname":
                    return VariableType.TargetSource;
                case "string":
                    return VariableType.String;
                case "real":
                    return VariableType.Float;
                case "real3":
                    return VariableType.String;
                case "sound":
                    return VariableType.Sound;
                case "model":
                    return VariableType.Studio;
                // TODO: other cases?
                case "flag":
                    return VariableType.Flags;
                default:
                    return VariableType.String;
            }
        }
    }
}