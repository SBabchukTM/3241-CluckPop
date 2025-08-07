using System.Collections.Generic;
using Runtime.Core.Factory;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData;
using UnityEngine;

namespace Runtime.Game.Achievements
{
    public class AchievementsFactory
    {
        private readonly SavedDataRetrieveService _savedDataRetrieveService;
        private readonly PrefabsProvider _prefabsProvider;
        private readonly GameObjectFactory _gameObjectFactory;

        public AchievementsFactory(SavedDataRetrieveService savedDataRetrieveService, PrefabsProvider prefabsProvider,
            GameObjectFactory gameObjectFactory)
        {
            _savedDataRetrieveService = savedDataRetrieveService;
            _prefabsProvider = prefabsProvider;
            _gameObjectFactory = gameObjectFactory;
        }

        public List<AchievementDisplay> GetAchievementDisplays()
        {
            List<AchievementDisplay> list = new List<AchievementDisplay>();
            
            var prefab = _prefabsProvider.Get(ConstPrefabNames.AchievementDisplayPrefab);
            var data = GetData();
            
            AddPrefab(list, prefab, data.StartProgram);
            AddPrefab(list, prefab, data.StartTwoProgram);
            AddPrefab(list, prefab, data.StartThreeProgram);
            AddPrefab(list, prefab, data.FirstExercise);
            AddPrefab(list, prefab, data.FirstTrainDay);
            AddPrefab(list, prefab, data.UnlockSecondProgram);
            AddPrefab(list, prefab, data.UnlockThirdProgram);
            AddPrefab(list, prefab, data.UpperThreeDaysTrainingProgram);
            AddPrefab(list, prefab, data.UpperFinishTrainingProgram);
            AddPrefab(list, prefab, data.CoreThreeDaysTrainingProgram);
            AddPrefab(list, prefab, data.CoreFinishTrainingProgram);
            AddPrefab(list, prefab, data.LowerThreeDaysTrainingProgram);
            AddPrefab(list, prefab, data.LowerFinishTrainingProgram);
            AddPrefab(list, prefab, data.FourExercises);
            AddPrefab(list, prefab, data.TenExercises);
            AddPrefab(list, prefab, data.TwentyExercises);
            AddPrefab(list, prefab, data.FiftyExercises);
            AddPrefab(list, prefab, data.ObtainTwoBackgrounds);
            AddPrefab(list, prefab, data.ObtainThreeBackgrounds);
            AddPrefab(list, prefab, data.ObtainAllBgs);
            
            return list;
        }

        private UserAchievementsData GetData() => _savedDataRetrieveService.GetUserData().UserAchievementsData;
        
        private void AddPrefab(List<AchievementDisplay> list, GameObject prefab, AchievementData achievementData)
        {
            var display = _gameObjectFactory.Create<AchievementDisplay>(prefab);
            display.Initialize(achievementData);
            list.Add(display);
        }
    }
}