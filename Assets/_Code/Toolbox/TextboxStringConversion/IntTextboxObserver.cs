using _Code.Toolbox.ValueHolders;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Toolbox.TextboxStringConversion
{
    public class IntTextboxObserver : MonoBehaviour, ITranslateValueToTextbox<int>
    {
        [SerializeField] private Text _textbox;
        [SerializeField] private SimpleValue<int> _simpleValue;
        public Text Textbox => _textbox;
        public SimpleValue<int> SimpleValue => _simpleValue;
        public void TranslateValueToString()
        {
            var text = SimpleValue.Value.ToString();
            Textbox.text = text;
        }
    }
}