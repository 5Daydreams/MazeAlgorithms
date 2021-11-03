using System;
using _Code.Toolbox.Extensions;
using _Code.Toolbox.TextboxStringConversion;
using _Code.Toolbox.ValueHolders;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Observer
{
    public class FloatTextboxUpdater : MonoBehaviour, ITranslateValueToTextbox<float>
    {
        [SerializeField] private Text _textbox;
        [SerializeField] private SimpleValue<float> _simpleValue;
        public Text Textbox => _textbox;
        public SimpleValue<float> SimpleValue => _simpleValue;

        private void FixedUpdate()
        {
            TranslateValueToString();
        }
        public void TranslateValueToString()
        {
            var timerText = SimpleValue.Value.ConvertSecondsToTimer();
            Textbox.text = timerText;
        }
    }
}