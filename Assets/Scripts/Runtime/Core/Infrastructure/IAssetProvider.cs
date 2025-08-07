using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.Core.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runtime.Core.Infrastructure
{
    public interface IAssetProvider : ICustomInitializer
    {
        UniTask<T> Load<T>(string address) where T : class;
        UniTask<List<Object>> LoadByLabel(List<string> labels, Addressables.MergeMode mergeMode = Addressables.MergeMode.Union);
        UniTask<Dictionary<string, GameObject>> LoadPrefabsByLabel(List<string> labels, Addressables.MergeMode mergeMode = Addressables.MergeMode.Union);
        UniTask<GameObject> Instantiate(string address, Transform under);
        UniTask<GameObject> Instantiate(string address, Vector3 at);
        UniTask<GameObject> Instantiate(string address);
        void Dispose();
    }
}