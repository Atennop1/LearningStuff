using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LearningStuff.Addressables
{
    public class PrefabLoadingTest : MonoBehaviour
    {
        [SerializeField] private AssetReference _prefabReference;
        
        private async void Awake()
        {
            var assetLoader = new AssetLoader();
            var assetReleaser = new AssetReleaser();
            var instanceReleaser = new InstanceReleaser();
            
            var loadingOperation = await assetLoader.LoadAsset<GameObject>(_prefabReference);
            await loadingOperation.Task;

            var loadedPrefab = loadingOperation.Result;
            var spawnedObject = Instantiate(loadedPrefab);
            
            instanceReleaser.ReleaseInstance(spawnedObject, 1000);
            assetReleaser.ReleaseAsset(_prefabReference, 2000);
        }
    }
}