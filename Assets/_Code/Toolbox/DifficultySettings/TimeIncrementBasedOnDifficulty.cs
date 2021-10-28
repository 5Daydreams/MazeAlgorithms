using _Code.Toolbox.ValueHolders;
using _Code.Toolbox.ValueHolders.TimeAttackDifficulty;
using UnityEngine;

namespace _Code.Toolbox.DifficultySettings
{
    [CreateAssetMenu(fileName = "IncrBasedOnDifficulty", menuName = "CustomScriptables/StructValue/IncrBasedOnDifficulty")]
    public class TimeIncrementBasedOnDifficulty : ScriptableObject
    {
        [SerializeField] private DifficultyHolder _difficultyHolder;
        [SerializeField] private FloatValue _remainingTimeScriptable;

        public void AddTimeBasedOnDifficulty()
        {
            _remainingTimeScriptable.AddToValue(_difficultyHolder.GetDifficulty().Increment);
        }
    }
}
