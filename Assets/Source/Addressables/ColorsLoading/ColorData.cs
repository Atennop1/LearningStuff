using UnityEngine;

namespace LearningStuff.Addressables
{
    [CreateAssetMenu(fileName = "ColorData", order = 0)]
    public class ColorData : ScriptableObject
    {
        [field: SerializeField] public Color Color { get; private set; }
    }
}