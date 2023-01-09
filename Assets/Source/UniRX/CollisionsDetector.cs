using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace LearningStuff.UniRX
{
    public class CollisionsDetector : MonoBehaviour
    {
        [SerializeField] private Collider2D _ballCollider;

        private void Awake()
        {
            _ballCollider.OnCollisionEnter2DAsObservable()
                .Where(collision => collision.gameObject.TryGetComponent<GroundTrigger>(out _))
                .Subscribe(_ =>
                {
                    Debug.Log("Ball collided with ground");
                });
        }
    }
}
