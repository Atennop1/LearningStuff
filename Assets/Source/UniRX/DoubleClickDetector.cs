using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace LearningStuff.UniRX
{
    public class DoubleClickDetector : MonoBehaviour
    {
        private void Awake()
        {
            var clickStream = this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0));

            clickStream
                .Buffer(clickStream.Throttle(TimeSpan.FromSeconds(0.25f)))
                .Where(units => units.Count == 2)
                .Subscribe(_ => Debug.Log("Double Click"));
        }
    }
}
