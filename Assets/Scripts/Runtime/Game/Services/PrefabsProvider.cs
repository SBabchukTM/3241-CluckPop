using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.Core.Infrastructure;
using UnityEngine;

namespace Runtime.Game.Services
{
    public class PrefabsProvider
    {
        private readonly IAssetProvider _assetProvider;
        
        private readonly Dictionary<string, GameObject> _prefabsLoaded = new ();

        public PrefabsProvider(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {
            var loadedPrefabs = await _assetProvider.LoadPrefabsByLabel(new List<string> { ConstLabels.PrefabLabel });

            foreach (var kvp in loadedPrefabs)
                _prefabsLoaded.TryAdd(kvp.Key, kvp.Value);
        }

        public GameObject Get(string addressableName)
        {
            if (_prefabsLoaded.TryGetValue(addressableName, out var prefab))
                return prefab;

            throw new Exception("No setting found");
        }
    }
}