using UnityEngine;

namespace _Code.Toolbox.ValueHolders.TimeAttackDifficulty
{
    [CreateAssetMenu(fileName = "TimeAttackDifficulty", menuName = "CustomScriptables/StructValue/TimeAttackDifficulty")]
    public class DifficultySettings : ScriptableObject
    {
        public float StartingTime;
        public float Increment;
        public int MazeWidth;
        public int MazeHeight;
    }
}