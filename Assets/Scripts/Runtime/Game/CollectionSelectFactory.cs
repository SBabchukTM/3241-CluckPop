using System.Collections.Generic;
using Runtime.Core.Factory;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData;
using Runtime.Game.UI;
using Runtime.Game.UI.Popup;
using UnityEngine;

namespace Runtime.Game
{
    public class CollectionSelectFactory
    {
        private readonly ConfigsProvider _configs;
        private readonly PrefabsProvider _prefabs;
        private readonly GameObjectFactory _gameObjectFactory;
        private readonly SavedDataRetrieveService _savedDataRetrieveService;

        public CollectionSelectFactory(ConfigsProvider configs, GameObjectFactory gameObjectFactory,
            SavedDataRetrieveService savedDataRetrieveService, PrefabsProvider prefabs)
        {
            _configs = configs;
            _gameObjectFactory = gameObjectFactory;
            _savedDataRetrieveService = savedDataRetrieveService;
            _prefabs = prefabs;
        }

        public List<CollectionSelectDisplay> GetCollectionSelectDisplays()
        {
            List<CollectionSelectDisplay> list = new();


            var data = _savedDataRetrieveService.GetUserData().UserProgramsData;

            if (data.UpperProgramData.IsActive)
            {
                list.Add(Create(data.UpperProgramData.ChickenId, 0));
                
                if(data.UpperProgramData.DaysTrained >= 2)
                    list.Add(Create(data.UpperProgramData.ChickenId, 2));
                
                if(data.UpperProgramData.DaysTrained >= 4)
                    list.Add(Create(data.UpperProgramData.ChickenId, 4));
            }
            
            if (data.CoreProgramData.IsActive)
            {
                list.Add(Create(data.CoreProgramData.ChickenId, 0));
                
                if(data.CoreProgramData.DaysTrained >= 2)
                    list.Add(Create(data.CoreProgramData.ChickenId, 2));
                
                if(data.CoreProgramData.DaysTrained >= 4)
                    list.Add(Create(data.CoreProgramData.ChickenId, 4));
            }
            
            if (data.LowerProgramData.IsActive)
            {
                list.Add(Create(data.LowerProgramData.ChickenId, 0));
                
                if(data.LowerProgramData.DaysTrained >= 2)
                    list.Add(Create(data.LowerProgramData.ChickenId, 2));
                
                if(data.LowerProgramData.DaysTrained >= 4)
                    list.Add(Create(data.LowerProgramData.ChickenId, 4));
            }
            
            return list;
        }

        private CollectionSelectDisplay Create(int chicken, int growPhase)
        {
            var display = _gameObjectFactory.Create<CollectionSelectDisplay>(_prefabs.Get(ConstPrefabNames.CollectionSelectPrefab));
            display.Initialize(GetSprite(chicken, growPhase), chicken, growPhase);

            return display;
        }

        private Sprite GetSprite(int chicken, int growPhase) => _configs.Get<ChickensConfig>().ChickenGrowConfigs[chicken].Sprites[growPhase];
    }
}