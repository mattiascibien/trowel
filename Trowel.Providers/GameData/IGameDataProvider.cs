﻿using System.Collections.Generic;

namespace Trowel.Providers.GameData
{
    public interface IGameDataProvider
    {
        DataStructures.GameData.GameData GetGameDataFromFiles(IEnumerable<string> files);

        bool IsValidForFile(string filename);
    }
}
