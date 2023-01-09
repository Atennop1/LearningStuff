using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityAddressables = UnityEngine.AddressableAssets.Addressables;

namespace LearningStuff.Addressables
{
    public class AssetLoader
    {
        public async Task<AsyncOperationHandle> LoadAsset(AssetReference assetReference)
        {
            if (assetReference.IsValid())
                return assetReference.OperationHandle;

            var asyncOperationHandler = assetReference.LoadAssetAsync<object>();
            await asyncOperationHandler.Task;

            if (asyncOperationHandler.Status != AsyncOperationStatus.Succeeded)
                throw new ArgumentException("Something went wrong while loading asset");

            return asyncOperationHandler;
        }
    }
}