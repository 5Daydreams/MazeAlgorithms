using UnityEngine;

namespace _Code.Toolbox.ValueHolders
{
    [CreateAssetMenu(fileName = "FloatValue",menuName = "CustomScriptables/SimpleValue/Float")]
    public class FloatValue : SimpleValue<float>
    {
        public void AddToValue(float increment)
        {
            Value += increment;
        }
    }
}
