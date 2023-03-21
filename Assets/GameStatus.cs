using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private Field _field;

    public void CheckGameStatus(Chip [,] chips)
    {
        int chipInRightPositions = 0;

        List<int> chipsValues = new List<int>();

        for (int i = 0; i < chips.GetLength(0); i++)
        {
            for (int j = 0; j < chips.GetLength(1); j++)
            {
                if (chips[i,j] != null)
                {
                    chipsValues.Add(chips[i, j].Value);
                }
                
            }
        }

        for (int i = 0; i < chipsValues.Count - 1; i++)
        {
            if (chipsValues[i] > chipsValues[i + 1])
            {
                chipInRightPositions++;
            }
        }

        if (chipInRightPositions == 3)
        {
            Debug.Log("WIN");
        }

    }
}
