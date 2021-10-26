using System;
using System.IO;
using System.Xml.Linq;

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
                if(element.Name == "point")
                    gameData.Classes.Add(ParsePointEntity(element));
                else if (element.Name == "group")
                    gameData.Classes.Add(ParseBrushEntity(element));
                else
                    throw new ProviderException($"Tag {element.Name} not recognized");
            }


            return gameData;
        }

        private DataStructures.GameData.GameDataObject ParseBrushEntity(XElement element)
        {
            var gdo = new DataStructures.GameData.GameDataObject(element.Attribute("name").Value, "", DataStructures.GameData.ClassType.Solid);

            return gdo;
        }

        private DataStructures.GameData.GameDataObject ParsePointEntity(XElement element)
        {
            var gdo = new DataStructures.GameData.GameDataObject(element.Attribute("name").Value, "", DataStructures.GameData.ClassType.Point);

            return gdo;
        }
    }
}