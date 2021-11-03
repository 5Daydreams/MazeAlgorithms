using System;
using _Code.Observer.Event;
using _Code.Toolbox.ValueHolders;
using UnityEngine;

namespace _Code.Observer
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private float startingTime;
        [SerializeField] private FloatValue _timeRemaining;
        [SerializeField] private VoidEvent _onTimerFinished;
        private bool _isRunning = false;

        public void SetStartingTime(float time)
        {
            startingTime = time;
        }

        private void FixedUpdate()
        {
            if (_timeRemaining.Value <= 0)
            {
                _timeRemaining.Value = 0;
                _isRunning = false;
                _onTimerFinished.Raise();
            }
            
            if (!_isRunning)
                return;
            _timeRemaining.Value -= Time.deltaTime;
        }

        public void StopTimer()
        {
            _isRunning = false;
        }

        public void ResumeTimer()
        {
            _isRunning = true;
        }

        public void StartCountdown()
        {
            _timeRemaining.Value = startingTime;
            ResumeTimer();
        }
    }
}