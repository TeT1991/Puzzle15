using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldCreator))]

public class Field : MonoBehaviour
{
    private List<Chip> _chips;
    private FieldCreator _fieldCreator;
    private Vector3[,] _cellsCoordinates;
    private Vector3 _emptyCell;

    private void Start()
    {
        _fieldCreator = GetComponent<FieldCreator>();
        _fieldCreator.CreateField(ref _cellsCoordinates, ref _chips, ref _emptyCell);
    }
}
