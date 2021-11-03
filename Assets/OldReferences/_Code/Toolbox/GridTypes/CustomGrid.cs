using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Toolbox.CellTypes;
using UnityEngine;
using Random = System.Random;

namespace _Code.Toolbox.GridTypes
{
    public abstract class CustomGrid<T>
    {
        [SerializeField] protected int Width;
        [SerializeField] protected int Height;
        [SerializeField] protected float CellSize;
        [SerializeField] protected Random Random = new Random();
        public Cell<T>[,] GridArray;

        public CustomGrid(int width, int height, float size)
        {
            Width = width;
            Height = height;
            CellSize = size;
            GridArray = new Cell<T>[width, height];
        }

        protected Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, y) * CellSize;
        }

        public void SetCellValue(int x, int y, T value)
        {
            if (x < 0 || x >= Width || y < 0 || y > Height)
            {
                Debug.LogError("Invalid grid position, out of bounds exception");
                return;
            }

            GridArray[x, y].SetCellValue(value);
        }

        public abstract void RandomizeAll();
    }

    public class IntCustomGrid : CustomGrid<int>
    {
        public IntCustomGrid(int width, int height, float size) : base(width, height, size)
        {
            Width = width;
            Height = height;
            CellSize = size;
            GridArray = new Cell<int>[width, height];
        }

        public override void RandomizeAll()
        {
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    var newValue = Random.Next(0, Width * Height);
                    GridArray[i, j].SetCellValue(newValue);
                }
            }
        }
    }

    public class BoolCustomGrid : CustomGrid<bool>
    {
        public BoolCustomGrid(int width, int height, float size) : base(width, height, size)
        {
            Width = width;
            Height = height;
            CellSize = size;
            GridArray = new Cell<bool>[width, height];
        }

        public override void RandomizeAll()
        {
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    GridArray[i, j].SetCellValue(Random.Next(0, i + j + 2) % 2 == 0);
                }
            }
        }
    }

    public class FloatCustomGrid : CustomGrid<float>
    {
        public FloatCustomGrid(int width, int height, float size) : base(width, height, size)
        {
            Width = width;
            Height = height;
            CellSize = size;
            GridArray = new Cell<float>[width, height];
        }

        public override void RandomizeAll()
        {
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    var newValue = (float) Random.Next(0, Width * Height) / Random.Next(0, Width * Height);
                    GridArray[i, j].SetCellValue(newValue);
                }
            }
        }
    }

    public class BitArrayCustomGrid : CustomGrid<BitArray>
    {
        public BitArrayCustomGrid(int width, int height, float size) : base(width, height, size)
        {
            Width = width;
            Height = height;
            CellSize = size;
            GridArray = new Cell<BitArray>[width, height];
        }

        public override void RandomizeAll()
        {
            for (int i = 0; i < GridArray.GetLength(0); i++)
            {
                for (int j = 0; j < GridArray.GetLength(1); j++)
                {
                    for (int k = 0; k < GridArray[i,j].Value.Length; k++)
                    {
                        GridArray[i, j].Value[k] = Random.Next(0, i + j + 2) % 2 == 0;
                    }
                }
            }
        }
    }
}