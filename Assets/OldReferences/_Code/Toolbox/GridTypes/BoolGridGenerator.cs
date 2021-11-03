using System.Collections.Generic;
using _Code.Toolbox.CellTypes;
using UnityEngine;

namespace _Code.Toolbox.GridTypes
{
    public class BoolGridGenerator : MonoBehaviour
    {
        [SerializeField] private int _gridWidth;
        [SerializeField] private int _gridHeight;
        [SerializeField] private float _cellSize;
        [SerializeField] private BoolCell _cellPrefab;
        private BoolCustomGrid _boolCustomGrid;
        private List<BoolCell> _stack;

        private void Start()
        {
            RecenterThis();
            _boolCustomGrid = new BoolCustomGrid(_gridWidth, _gridHeight, _cellSize);
            CreateInScene();
            _boolCustomGrid.RandomizeAll();
        }

        private void RecenterThis()
        {
            var screenCenterPos = new Vector3(0.5f, 0.5f, 0.0f);
            var offsetPosition = new Vector3(-_gridWidth / 2.0f, -_gridHeight / 2.0f, 0.0f);
            this.transform.position = (screenCenterPos + offsetPosition) * _cellSize;
        }

        private void CreateInScene()
        {
            for (int i = 0; i < _gridWidth; i++)
            {
                for (int j = 0; j < _gridHeight; j++)
                {
                    var basePos = new Vector3(i * _cellSize, j * _cellSize, 0);
                    var cellPos = basePos + this.transform.position;
                    _boolCustomGrid.GridArray[i, j] = Instantiate(_cellPrefab, cellPos, Quaternion.identity);
                    _boolCustomGrid.GridArray[i, j].transform.SetParent(this.transform);
                    _boolCustomGrid.GridArray[i, j].gameObject.name = "( " + i + ", " + j + " )";
                }
            }
        }

        public void EditorCallRandomizeAll()
        {
            _boolCustomGrid.RandomizeAll();
        }

        private void SetAll(bool value)
        {
            for (int i = 0; i < _boolCustomGrid.GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < _boolCustomGrid.GridArray.GetLength(1); j++)
                {
                    _boolCustomGrid.GridArray[i, j].SetCellValue(value);
                }
            }
        }
    }
}