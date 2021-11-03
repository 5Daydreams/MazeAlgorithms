using UnityEngine;

namespace _Code.Toolbox.CellTypes
{
    public class BoolCell : Cell<bool>
    {
        [SerializeField] private Color32 _white = Color.white;
        [SerializeField] private Color32 _black = Color.black;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void SetColor(Color32 newColor)
        {
            _spriteRenderer.color = newColor;
        }

        public override void SetCellValue(bool value)
        {
            base.SetCellValue(value);
            SetColorOnOff(value);
        }

        private void SetColorOnOff(bool on)
        {
            if (on)
                SetColor(_white);

            else
                SetColor(_black);
        }

        public void DrawCell(int cellPathSize)
        {
            SetColorOnOff(this.isActiveAndEnabled);
        }
    }
}