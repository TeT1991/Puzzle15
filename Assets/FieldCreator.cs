using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;


public class FieldCreator : MonoBehaviour
{
    [SerializeField] private Chip _chipPrefab;
    [SerializeField] private Cell _cellPrefab;

    private const int _SIZE = 4;
    
    public void CreateField(ref Chip[,] chips)
    {
        chips = CreateChips();
    }

    public Chip[,] CreateChips()
    {
        Chip[,] chips = new Chip[_SIZE, _SIZE]; 
        List<int> chipValues = Shuffle();

        while (!CheckIsSovlable(chipValues))
        {
            chipValues = Shuffle();
        }

        for (int x = 0; x < _SIZE; x++)
        {
            for (int y = 0; y < _SIZE; y++)
            {
                var chip = Instantiate(_chipPrefab, new Vector3(x,y), Quaternion.identity);
                chip.SetValue(chipValues[0],x,y);
                chips[x,y] = chip;    
                chipValues.RemoveAt(0);

                if (chip.Value == _SIZE * _SIZE)
                {
                    chips[x, y] = null;
                    Destroy(chip.gameObject);
                }
            }
        }

        return chips;
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
