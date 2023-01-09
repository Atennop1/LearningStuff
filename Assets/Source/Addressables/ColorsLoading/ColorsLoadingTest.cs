using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace LearningStuff.Addressables
{
    public class ColorsLoadingTest : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private List<Button> _buttons;
        [SerializeField] private List<AssetReference> _colorAssetReferences;

        private void Awake()
        {
            var assetLoader = new AssetLoader();
            var assetReleaser = new AssetReleaser();
            
            for (var i = 0; i < _colorAssetReferences.Count; i++)
            {
                var index = i;
                
                _buttons[i].onClick.AddListener(async () =>
                {
                    var colorDataOperationHandler = await assetLoader.LoadAsset(_colorAssetReferences[index]);
                    _camera.backgroundColor = ((ColorData)colorDataOperationHandler.Result).Color;
                    assetReleaser.ReleaseAsset(colorDataOperationHandler, 1000);
                });
            }
        }
    }
}