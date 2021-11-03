using _Code.ConcreteGridGenerators;
using _Code.Toolbox.ValueHolders.TimeAttackDifficulty;
using UnityEngine;

namespace _Code.Toolbox.DifficultySettings
{
    public class SetTimeAttackMazeDimensions : MonoBehaviour
    {
        [SerializeField] private MazeGenerator _generator;
        [SerializeField] private DifficultyHolder _difficultyHolder;

        public void SetMazeDimensions()
        {
            var difficulty = _difficultyHolder.GetDifficulty();

            _generator.SetGridWidth(difficulty.MazeWidth);
            _generator.SetGridHeight(difficulty.MazeHeight);
        }
    }
}