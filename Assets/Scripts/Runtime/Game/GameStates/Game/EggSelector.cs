using System.Collections.Generic;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData;
using Runtime.Game.UI;
using UnityEngine;

namespace Runtime.Game.GameStates.Game
{
    public class EggSelector
    {
        private readonly ConfigsProvider _configsProvider;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;

        public EggSelector(ConfigsProvider configsProvider, SavedDataRetrieveService savedDataRetrieveService)
        {
            _configsProvider = configsProvider;
            _savedDataRetrieveService = savedDataRetrieveService;
        }

        public int SelectUniqueEggIndex()
        {
            var chickensConfigs = _configsProvider.Get<ChickensConfig>().ChickenGrowConfigs;
            List<int> usedIndexes = new();

            var data = _savedDataRetrieveService.GetUserData().UserProgramsData;
            
            if(data.UpperProgramData.IsActive)
                usedIndexes.Add(data.UpperProgramData.ChickenId);
            
            if(data.CoreProgramData.IsActive)
                usedIndexes.Add(data.CoreProgramData.ChickenId);
            
            if(data.LowerProgramData.IsActive)
                usedIndexes.Add(data.LowerProgramData.ChickenId);

            int result = -1;
            do
            {
                result = Random.Range(0, chickensConfigs.Count);
            } while (usedIndexes.Contains(result));

            return result;
        }

        public Sprite GetChickenSprite(int chickenId, int growPhase)
        {
            var config = _configsProvider.Get<ChickensConfig>().ChickenGrowConfigs[chickenId];
            if(growPhase >= config.Sprites.Count - 1)
                growPhase = config.Sprites.Count - 1;
            
            return config.Sprites[growPhase];
        }
    }
}