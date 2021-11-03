using System;
using System.Collections;
using UnityEngine;

namespace _Code.Toolbox.CellTypes
{
    public class BitArrayCell : Cell<BitArray>
    {
        [SerializeField] private int _arraySize = 5;
        [SerializeField] private BoxCollider2D[] _walls = new BoxCollider2D[4];

        // Consistency check:
        // _value[0] = pathIsOpen;
        // _value[1] = NorthIsOpen;
        // _value[2] = EastIsOpen;
        // _value[3] = SouthIsOpen;
        // _value[4] = WestIsOpen;

        private void OnEnable()
        {
            EraseCellValues();
        }

        public void ResetCellValues()
        {
            EraseCellValues();
            DeactivateWalls();
        }

        private void EraseCellValues()
        {
            _value = new BitArray(_arraySize);
            _value.SetAll(false);
        }

        public void CellSetup(int cellPathSize)
        {
            DrawCell(cellPathSize);
            ActivateWalls();
        }

        public override void SetCellValue(BitArray value)
        {
            _value = value;
        }

        private void DrawCell(int cellPathSize)
        {
            if (cellPathSize < 3)
                throw new IndexOutOfRangeException("Cell must be at least 3 pixels wide");
            Texture2D texture = new Texture2D(cellPathSize, cellPathSize);

            for (int i = 0; i < cellPathSize; i++)
            {
                for (int j = 0; j < cellPathSize; j++)
                {
                    if (j == cellPathSize - 1 && !_value[1])
                    { texture.SetPixel(i, j, Color.black); continue; } // North CLOSED
                    if (i == cellPathSize - 1 && !_value[2])
                    { texture.SetPixel(i, j, Color.black); continue; } // East CLOSED
                    if (j == 0 && !_value[3])
                    { texture.SetPixel(i, j, Color.black); continue; } // South CLOSED
                    if (i == 0 && !_value[4])
                    { texture.SetPixel(i, j, Color.black); continue; } // West CLOSED

                    if ((i == 0 || i == cellPathSize - 1) && (j == 0 || j == cellPathSize - 1))
                    { texture.SetPixel(i, j, Color.black); continue; } // Corners are always closed!
            
                    texture.SetPixel(i, j, Color.white); // if not closed, it's open!
                }
            }

            texture.filterMode = FilterMode.Point;
            texture.Apply(); // MUST be executed after the for, otherwise changes dont get applied, smfh
            Rect textureRect = new Rect(0, 0, cellPathSize, cellPathSize);
            Sprite sprite = Sprite.Create(texture, textureRect, Vector2.zero, cellPathSize, 0, SpriteMeshType.FullRect);

            _spriteRenderer.sprite = sprite;
        }

        private void ActivateWalls()
        {
            for (int i = 1; i < _arraySize; i++)
            {
                if (_value[i])
                    continue;
                _walls[i - 1].gameObject.SetActive(true);
            }
        }

        private void DeactivateWalls()
        {
            for (int i = 1; i < _arraySize; i++)
            {
                _walls[i - 1].gameObject.SetActive(false);
            }
        }

        public void PaintCell(Color32 color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.filterMode = FilterMode.Point;
            texture.Apply();

            Rect textureRect = new Rect(0, 0, 1, 1);
            Sprite sprite = Sprite.Create(texture, textureRect, Vector2.zero, 1, 0, SpriteMeshType.FullRect);
            _spriteRenderer.sprite = sprite;
        }
    }
}