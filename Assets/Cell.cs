using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int Value { get; private set; }  

    public void SetValue(int value)
    {
        Value = value;  
    }
}
