using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityAddressables = UnityEngine.AddressableAssets.Addressables;

namespace LearningStuff.Addressables
{
    public class AssetLoader
    {
        public async Task<AsyncOperationHandle<T>> LoadAsset<T>(AssetReference assetReference)
        {
            if (assetReference.IsValid())
                return assetReference.OperationHandle.Convert<T>();

            var asyncOperationHandle = assetReference.LoadAssetAsync<T>();
            await asyncOperationHandle.Task;
            
            if (!assetReference.IsValid())
                throw new ArgumentException("Too many load requests");

            if (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
                throw new ArgumentException("Something went wrong while loading asset");

            return asyncOperationHandle;
        }
    }
}