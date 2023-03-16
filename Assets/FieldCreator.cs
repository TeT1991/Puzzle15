using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class FieldCreator : MonoBehaviour
{
    [SerializeField] private Chip _chipPrefab;

    private Vector3 _emptyCell;

    private const int _SIZE = 4;
    
    public void CreateField(ref Vector3[,] coordinates, ref List<Chip> chips, ref Vector3 emptyCell)
    {
        coordinates = CreateCells();
        chips = CreateChips(coordinates);
        emptyCell = _emptyCell;
    }

    public List<Chip> CreateChips(Vector3[,] coordinates)
    {
        List<Chip> chips = new List<Chip>();
        List<int> chipValues = Shuffle();
        while (!CheckIsSovlable(chipValues))
        {
            chipValues = Shuffle();
        }

        for (int x = 0; x < _SIZE; x++)
        {
            for (int y = 0; y < _SIZE; y++)
            {
                var chip = Instantiate(_chipPrefab, coordinates[x,y], Quaternion.identity);
                chip.SetValue(chipValues[0]);
                chips.Add(chip);    
                chipValues.RemoveAt(0);

                if (chip.Value == _SIZE * _SIZE)
                {
                    _emptyCell = chip.transform.position;
                    chips.Remove(chip);
                    Destroy(chip.gameObject);
                }
            }
        }

        return chips;
    }
    public Vector3[,] CreateCells()
    {
        Vector3[,] _coordinates = new Vector3[_SIZE, _SIZE];

        for (int x = 0; x < _SIZE; x++)
        {
            for (int y = 0; y < _SIZE; y++)
            {
                _coordinates[x, y] = new Vector3(x, y, 0);
            }
        }

        return _coordinates;
    }

    private bool CheckIsSovlable(List<int> list)
    {
        int inversionsCount = 0;

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i; j < list.Count; j++)
            {
                if (list[j] > list[i])
                {
                    inversionsCount++;
                }
            }
        }
        return inversionsCount > 0 && inversionsCount % 2 == 0;
    }

    private List<int> Shuffle()
    {
        List<int> numbers = Enumerable.Range(1, _SIZE * _SIZE).ToList();
        int index;

        for (int i = 0; i < numbers.Count; i++)
        {
            index = Random.Range(0, numbers.Count);
            var temp = numbers[index];
            numbers[index] = numbers[i];
            numbers[i] = temp;
        }
        return numbers;
    }
}
