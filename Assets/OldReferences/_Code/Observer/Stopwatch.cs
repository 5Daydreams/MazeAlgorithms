using _Code.Toolbox.ValueHolders;
using UnityEngine;

namespace _Code.Observer
{
    public class Stopwatch : MonoBehaviour
    {
        [SerializeField] private FloatValue _timeElapsed;
        private bool _isRunning = false;

        private void FixedUpdate()
        {
            if (!_isRunning)
                return;
            _timeElapsed.Value += Time.deltaTime;
        }
    
        public void StopTimer()
        {
            _isRunning = false;
        }
    
        public void ResumeTimer()
        {
            _isRunning = true;
        }

        public void StartTimer()
        {
            _timeElapsed.SetValue(0);
            ResumeTimer();
        }
    }
}
