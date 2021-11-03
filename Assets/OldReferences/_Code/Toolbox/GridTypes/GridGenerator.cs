using _Code.Toolbox.CellTypes;
using _Code.Toolbox.ValueHolders;
using UnityEngine;

namespace _Code.Toolbox.GridTypes
{
    [System.Serializable]
    public abstract class GridGenerator<T> : MonoBehaviour
    {
        [SerializeField] protected int _gridWidth;
        [SerializeField] protected int _gridHeight;
        [SerializeField] protected FloatValue _cellScaleSize;
        protected Cell<T>[,] _grid;

        public void SetGridWidth(int value)
        {
            _gridWidth = value;
        }

        public void SetGridHeight(int value)
        {
            _gridHeight = value;
        }

        protected void RecenterGenerator()
        {
            var offsetPosition = new Vector3(-_gridWidth, -_gridHeight, 0.0f);
            var extraOffset = new Vector3(0, -1.5f, 0);
            this.transform.position = (offsetPosition + extraOffset) * _cellScaleSize.Value * 0.5f;
        }

        protected void CreateEmptyCells()
        {
            for (int i = 0; i < _gridWidth; i++)
            {
                for (int j = 0; j < _gridHeight; j++)
                {
                    var basePos = new Vector3(i * _cellScaleSize.Value, j * _cellScaleSize.Value, 0);
                    var cellPos = basePos + this.transform.position;
                    var cellPrefab = GetRegisteredPrefab();
                    _grid[i, j] = Instantiate(cellPrefab, cellPos, Quaternion.identity);
                    _grid[i, j].transform.SetParent(this.transform);
                    _grid[i, j].SetCellScale(_cellScaleSize.Value);
                    _grid[i, j].gameObject.name = "( " + i + ", " + j + " )";
                }
            }
        }

        protected void SetAll(T value)
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j].SetCellValue(value);
                }
            }
        }

        public void EditorCallRandomizeAll()
        {
            RandomizeAll();
        }

        public abstract void RandomizeAll();
        protected abstract Cell<T> GetRegisteredPrefab();
    }
}