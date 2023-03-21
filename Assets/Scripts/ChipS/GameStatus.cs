using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private Field _field;

    public void CheckGameStatus(Chip [,] chips)
    {
        int chipsInRightPositions = 0;

        List<int> chipsValues = new List<int>();

        for (int j = 0; j < chips.GetLength(1); j++)
        {
            for (int i = 0; i < chips.GetLength(0); i++)
            {

                if (chips[i, j] != null && (j * chips.GetLength(1) + i) + 1 == chips[i,j].Value)
                {
                    chipsInRightPositions++;
                }
            }
        }
        if (chipsInRightPositions == chips.GetLength(1) * chips.GetLength(1) - 1)
        {
            EndGame();
        }   
    }

    private void EndGame()
    {
        Debug.Log("WIN");
    }
}
