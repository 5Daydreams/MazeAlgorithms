using UnityEngine;

namespace _Code.Toolbox.ValueHolders
{
    public abstract class SimpleValue<T> : ScriptableObject
    {
        public T Value;

        public void SetValue(T overwrite)
        {
            Value = overwrite;
        }
    }
}