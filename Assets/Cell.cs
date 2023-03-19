using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsEmpty { get; private set;} = false;
    public int XCoordinate { get; private set; }
    public int YCoordinate { get; private set; } 

    public void SetEmpty()
    {
        IsEmpty = true;
    }

    public void SetNotEmpty()
    {
        IsEmpty = false; ;
    }

    public void SetCoordinates(int x, int y)
    {
        XCoordinate = x;
        YCoordinate = y;
    }
}
