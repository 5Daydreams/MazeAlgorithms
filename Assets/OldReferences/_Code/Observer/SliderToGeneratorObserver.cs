using _Code.ConcreteGridGenerators;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Observer
{
    public class SliderToGeneratorObserver : MonoBehaviour
    {
        [SerializeField] private Slider _sliderH;
        [SerializeField] private Slider _sliderV;
        [SerializeField] private MazeGenerator _generator;

        private void OnEnable()
        {
            _sliderH.onValueChanged.AddListener(SetMazeWidth);
            _sliderV.onValueChanged.AddListener(SetMazeHeight);
        }
    
        private void OnDisable()
        {
            _sliderH.onValueChanged.RemoveListener(SetMazeWidth);
            _sliderV.onValueChanged.RemoveListener(SetMazeHeight);
        }

        private void SetMazeHeight(float value)
        {
            _generator.SetGridHeight((int)value);
        }
    
        private void SetMazeWidth(float value)
        {
            _generator.SetGridWidth((int)value);
        }
    }
}
