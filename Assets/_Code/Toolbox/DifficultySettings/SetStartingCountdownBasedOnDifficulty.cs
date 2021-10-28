using _Code.Observer;
using _Code.Toolbox.ValueHolders.TimeAttackDifficulty;
using UnityEngine;

namespace _Code.Toolbox.DifficultySettings
{
    public class SetStartingCountdownBasedOnDifficulty : MonoBehaviour
    {
        [SerializeField] private CountdownTimer _countdownTimer;
        [SerializeField] private DifficultyHolder _difficultyHolder;

        public void SetStartingTimeBasedOnDifficulty()
        {
            _countdownTimer.SetStartingTime(_difficultyHolder.GetDifficulty().StartingTime);
        }
    }
}
