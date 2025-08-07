using Runtime.Game.Achievements;
using Runtime.Game.GameStates.Game.Controllers;
using Runtime.Game.GameStates.Game.Screens;
using Runtime.Game.Services;
using Runtime.Game.Services.UserData;
using Runtime.Game.Shop;
using UnityEngine;
using Zenject;

namespace Runtime.Game.GameStates.Game
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Load1();
            Container.Bind<ProfileScreenStateController>().AsSingle();
            Container.Bind<ShopScreenStateController>().AsSingle();
            Container.Bind<ExercisesScreenStateController>().AsSingle();
            Container.Bind<ProgramSelectScreenStateController>().AsSingle();
            Container.Bind<SettingsPopupController>().AsSingle();
            Container.Bind<UserBalanceService>().AsSingle();
            Container.Bind<ProgramsService>().AsSingle();
            Container.Bind<EggSelector>().AsSingle();
            Container.Bind<AchievementsFactory>().AsSingle();
            Container.Bind<AchievementUnlocker>().AsSingle();
            Container.Bind<BackgroundsService>().AsSingle();
            Container.Bind<ChickenCollectionProvider>().AsSingle();
            Container.Bind<CollectionSelectFactory>().AsSingle();
        }

        private void Load1()
        {
            Container.Bind<AchievementsScreenStateController>().AsSingle();
            Container.Bind<CollectionScreenStateController>().AsSingle();
            Container.Bind<MenuStateController>().AsSingle();
            Container.Bind<OnBoardingScreenStateController>().AsSingle();
        }
    }
}