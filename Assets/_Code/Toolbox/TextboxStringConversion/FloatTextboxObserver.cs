using _Code.Toolbox.Extensions;
using _Code.Toolbox.ValueHolders;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Toolbox.TextboxStringConversion
{
    public class FloatTextboxObserver : MonoBehaviour, ITranslateValueToTextbox<float>
    {
        [SerializeField] private Text _textbox;
        [SerializeField] private SimpleValue<float> _simpleValue;
        public Text Textbox => _textbox;
        public SimpleValue<float> SimpleValue => _simpleValue;
        
        public void TranslateValueToString()
        {
            var text = SimpleValue.Value.ToString();
            Textbox.text = text;
        }
        
        public void TranslateValueToTime()
        {
            var timerText = SimpleValue.Value.ConvertSecondsToTimer();
            Textbox.text = timerText;
        }
    }
}