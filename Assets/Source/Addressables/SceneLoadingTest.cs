using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace LearningStuff.Addressables
{
    public class SceneLoadingTest : MonoBehaviour
    {
        [SerializeField] private Button _loadButton;
        [SerializeField] private AssetReference _sceneReference;

        private void Awake()
        {
            var assetReleaser = new AssetReleaser();

            _loadButton.onClick.AddListener(() =>
            {
                _sceneReference.LoadSceneAsync();
                assetReleaser.ReleaseAsset(_sceneReference, 1000);
            });
        }
    }
}