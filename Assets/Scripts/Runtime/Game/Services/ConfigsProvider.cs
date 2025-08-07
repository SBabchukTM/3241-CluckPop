using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.Core.Infrastructure;

namespace Runtime.Game.Services
{
    public class ConfigsProvider
    {
        private readonly IAssetProvider _assetProvider;
        
        private readonly Dictionary<Type, BaseSettings> _configsLoaded = new ();

        public ConfigsProvider(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {
            var persistentConfigs = await _assetProvider.LoadByLabel(new List<string>{ConstLabels.ConfigLabel});

            foreach (var config in persistentConfigs) 
                Set(config);
        }

        public T Get<T>() where T : BaseSettings
        {
            if (_configsLoaded.ContainsKey(typeof(T)))
            {
                var config = _configsLoaded[typeof(T)];
                return config as T;
            }

            throw new Exception("No setting found");
        }

        private void Set(Object config)
        {
            if (_configsLoaded.ContainsKey(config.GetType()))
                return;

            _configsLoaded.Add(config.GetType(), config as BaseSettings);
        }
    }
}