using _Code.Toolbox.ValueHolders;
using UnityEngine.UI;

namespace _Code.Toolbox.TextboxStringConversion
{
    public interface ITranslateValueToTextbox<T>
    {
        Text Textbox { get; }
        SimpleValue<T> SimpleValue { get; }
        void TranslateValueToString();
    }
}