using _Code.Observer.Event;
using UnityEngine;

namespace _Code.Toolbox.EventInvokers
{
    public class TriggerOnUnityEvent : MonoBehaviour
    {
        [SerializeField] private VoidEvent _awake;
        [SerializeField] private VoidEvent _onEnable;
        [SerializeField] private VoidEvent _reset;
        [SerializeField] private VoidEvent _start;
        [SerializeField] private VoidEvent _onDisable;
        [SerializeField] private VoidEvent _onDestroy;

        private void Awake()
        {
            _awake?.Raise();
        }

        private void OnEnable()
        {
            _onEnable?.Raise();
        }

        private void Reset()
        {
            _reset?.Raise();
        }

        private void Start()
        {
            _start?.Raise();
        }

        private void OnDisable()
        {
            _onDisable?.Raise();
        }

        private void OnDestroy()
        {
            _onDestroy?.Raise();
        }
    }
}
