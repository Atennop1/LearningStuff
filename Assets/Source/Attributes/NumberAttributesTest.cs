using UnityEngine;

namespace LearningStuff.Attributes
{
    public class NumberAttributesTest : MonoBehaviour
    {
        [SerializeField, Number] private int _intField;
        [SerializeField, Number] private float _floatField;
        
        [field: SerializeField, Number, Space] public int IntProperty { get; private set; }
        [field: SerializeField, Number] public float FloatProperty { get; private set; }

#pragma warning disable CS0414
        [Number] private static int _staticInt = 1;
        [Number] private static float _staticFloat = 2f;
#pragma warning restore CS0414
    }
}