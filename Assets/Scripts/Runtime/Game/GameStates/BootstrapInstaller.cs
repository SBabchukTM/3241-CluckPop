using Runtime.Core.GameStateMachine;
using Runtime.Game.GameStates.Game;
using Runtime.Game.GameStates.Game.Controllers;
using UnityEngine;
using Zenject;

namespace Runtime.Game.GameStates
{
    [CreateAssetMenu(fileName = "BootstrapInstaller", menuName = "Installers/BootstrapInstaller")]
    public class BootstrapInstaller : ScriptableObjectInstaller<BootstrapInstaller>
    {
        public override void InstallBindings()
        {
            Add1();

            ADd2();
        }

        private void ADd2()
        {
            Container.Bind<AudioLoader>().AsSingle();
            Container.Bind<UserDataStateChangeController>().AsSingle();
        }

        private void Add1()
        {
            Container.BindInterfacesAndSelfTo<Bootstrapper>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameState>().AsSingle();
            Container.Bind<StateMachine>().AsTransient();
        }
    }
}