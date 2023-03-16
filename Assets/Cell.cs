using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsEmpty { get; private set;} = false;    

    public void SetEmpty()
    {
        IsEmpty = true;
    }

    public void SetNotEmpty()
    {
        IsEmpty = false; ;
    }
}
