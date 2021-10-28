using UnityEngine;

namespace _Code.Toolbox.ValueHolders
{
    [CreateAssetMenu(fileName = "IntValue", menuName = "CustomScriptables/SimpleValue/Int")]
    public class IntValue : SimpleValue<int>
    {
        public void IncrementValue()
        {
            Value++;
        }
    }
}