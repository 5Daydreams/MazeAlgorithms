using UnityEngine;
using UnityEngine.Events;

namespace _Code.Toolbox.CellTypes
{
    public class ExitCell : MonoBehaviour
    {
        private BoxCollider2D _collider;
        [SerializeField] private UnityEvent _onLevelCleared;

        private void OnEnable()
        {
            if (_collider == null)
                _collider = this.GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _onLevelCleared.Invoke();
        }
    }
}
