using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace LearningStuff.Addressables
{
    public class SpriteLoadingTest : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private AssetReference _spriteReference;

        private async void Awake()
        { 
            var assetLoader = new AssetLoader(); 
            var assetReleaser = new AssetReleaser();

            var loadingOperation = await assetLoader.LoadAsset<Sprite>(_spriteReference);
            await loadingOperation.Task;
            
            var loadedSprite = loadingOperation.Result;
            _image.sprite = loadedSprite;
            
            assetReleaser.ReleaseAsset(_spriteReference, 1000);
        }
    }
}