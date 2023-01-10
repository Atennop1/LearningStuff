using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityAddressables = UnityEngine.AddressableAssets.Addressables;

namespace LearningStuff.Addressables
{
    public class InstanceReleaser
    {
        public async void ReleaseInstance(GameObject instance, int timeInMilliseconds)
        {
            try
            {
                await UniTask.Delay(timeInMilliseconds);
                Object.Destroy(instance);
                UnityAddressables.ReleaseInstance(instance);
            }
            catch { /*ignored cause it means that asset is already released*/ }
        }
    }
}