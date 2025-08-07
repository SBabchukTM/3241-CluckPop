using System.Collections.Generic;
using Runtime.Core.Factory;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData;
using Runtime.Game.UI;
using UnityEngine;

namespace Runtime.Game
{
    public class ChickenCollectionProvider
    {
        private readonly SavedDataRetrieveService _savedDataRetrieveService;
        private readonly ConfigsProvider _configsProvider;

        public ChickenCollectionProvider(SavedDataRetrieveService savedDataRetrieveService, ConfigsProvider configsProvider)
        {
            _savedDataRetrieveService = savedDataRetrieveService;
            _configsProvider = configsProvider;
        }

        public void SetUnlockData(List<ChickenColectionDisplay> list, ChickenType chickenType)
        {
            var config = _configsProvider.Get<ChickensConfig>();
            var chickensConfig = config.ChickenGrowConfigs;
            
            int index = GetSpriteIndex(chickenType);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SetImage(chickensConfig[i].Sprites[index], !IsUnlocked(index, i));
            }
        }

        private bool IsUnlocked(int growIndex, int chickenId)
        {
            var data = _savedDataRetrieveService.GetUserData().UserProgramsData;

            if (data.UpperProgramData.ChickenId == chickenId)
                return data.UpperProgramData.IsActive && data.UpperProgramData.DaysTrained >= growIndex;
            
            if (data.CoreProgramData.ChickenId == chickenId)
                return data.CoreProgramData.IsActive && data.CoreProgramData.DaysTrained >= growIndex;
            
            if (data.LowerProgramData.ChickenId == chickenId)
                return data.LowerProgramData.IsActive && data.LowerProgramData.DaysTrained >= growIndex;

            return false;
        }
        
        private int GetSpriteIndex(ChickenType type)
        {
            switch (type)
            {
                case ChickenType.Egg:
                    return 0;
                case ChickenType.Chicken:
                    return 2;
                case ChickenType.SuperHen:
                    return 4;
            }

            return 0;
        }

        public Sprite GetSprite(int chicken, int growPhase)
        {
            if(chicken < 0)
                return null;
            
            return _configsProvider.Get<ChickensConfig>().ChickenGrowConfigs[chicken].Sprites[growPhase];
        }
    }

    public enum ChickenType
    {
        Egg,
        Chicken,
        SuperHen
    }
}