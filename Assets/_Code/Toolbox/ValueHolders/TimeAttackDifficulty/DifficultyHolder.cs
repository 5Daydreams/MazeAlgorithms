using UnityEngine;

namespace _Code.Toolbox.ValueHolders.TimeAttackDifficulty
{
    [CreateAssetMenu(fileName = "DifficultyHolder", menuName = "CustomScriptables/StructValue/DifficultyHolder")]
    public class DifficultyHolder : ScriptableObject
    {
        [SerializeField] private DifficultySettings _difficulty;

        public void SetChosenDifficulty(DifficultySettings setting)
        {
            _difficulty = setting;
        }

        public DifficultySettings GetDifficulty()
        {
            return _difficulty;
        }
    }
}
