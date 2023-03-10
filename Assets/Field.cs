using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    private int _size = 4;

    private Cell[,] _field;

    private void Start()
    {
        GenerateCells();    
    }

    private void Clear()
    {
        var cells = FindObjectsOfType<Cell>();  

        foreach (var cell in cells)
        {
            Destroy(cell.gameObject);
        }
        _field = new Cell[_size, _size];    
    }

    private int[,] GenerateValues()
    {
        int[,] values = new int[_size, _size];

        do
        {

            List<int> numbers = Enumerable.Range(1, 15).ToList();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    int index = Random.Range(0, numbers.Count-1);
                    values[i, j] = numbers[index];
                    numbers.RemoveAt(index);
                }
            }
        }
        while (CheckIsSovable(values.Cast<int>().ToArray()));

        return values;
    }

    private void GenerateCells()
    {
        int[,] values = GenerateValues();

        for (int x = 0; x < _size; x++)
        {
            for (int y = 0; y < _size; y++)
            {
                var cell = Instantiate(_cell);
                cell.transform.position = new Vector2(-x, y);
                cell.SetValue(values[x, y]);
                _field[x, y] = cell;
            }
        }
    }

    private bool CheckIsSovable(int[] numbers)
    {
        int inversionsCount = 0;

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    inversionsCount++;
                }
            }
        }

        return inversionsCount % 2 == 0;    
    }
}
