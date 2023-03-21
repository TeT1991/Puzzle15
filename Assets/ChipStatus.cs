using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStatus : MonoBehaviour
{
    private Chip[,] _chips;

    public void SetChips(Chip[,] chips)
    {
        _chips = chips;
    }
}
