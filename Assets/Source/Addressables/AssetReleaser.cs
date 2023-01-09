using System;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace LearningStuff.Addressables
{
    public class AssetReleaser
    {
        public async void ReleaseAsset(AsyncOperationHandle asyncOperationHandle, int timeInMilliseconds)
        {
            try
            {
                await UniTask.Delay(timeInMilliseconds);
                UnityEngine.AddressableAssets.Addressables.Release(asyncOperationHandle);
            }
            catch (Exception)
            {
                // ignored cause it means that asset is already released
            }
        }
    }
}