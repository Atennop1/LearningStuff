using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityAddressables = UnityEngine.AddressableAssets.Addressables;

namespace LearningStuff.Addressables
{
    public class AssetReleaser
    {
        public async void ReleaseAsset(AssetReference assetReference, int timeInMilliseconds)
        {
            try
            {
                await UniTask.Delay(timeInMilliseconds);
                UnityAddressables.Release(assetReference.OperationHandle);
                Debug.Log("Released");
            }
            catch { /*ignored cause it means that asset is already released*/ }
        }
    }
}