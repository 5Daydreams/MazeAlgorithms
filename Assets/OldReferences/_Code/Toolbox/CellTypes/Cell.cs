using System;
using UnityEngine;

namespace _Code.Toolbox.CellTypes
{
    [Serializable] public abstract class Cell<T> : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        protected T _value;
        public T Value => _value;

        public virtual void SetCellValue(T value)
        {
            _value = value;
        }

        public void SetCellScale(float size)
        {
            transform.localScale = Vector3.one * size;
        }
    }
}
