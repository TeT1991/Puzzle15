using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldCreator))]
[RequireComponent(typeof(ChipMover))]

public class Field : MonoBehaviour
{
    private Chip[,] _chips;
    private FieldCreator _fieldCreator;
    private ChipSelector _chipSelector; 

    private ChipMover _chipMover;   

    public void StartTurn()
    {
        Debug.Log("STSRT TURN");

        Chip chip = _chipSelector.SelectChip(_chips);

        if (chip != null)
        {
            Debug.Log(chip.X + " " + chip.Y);
        }
    }

    private void Start()
    {
        _fieldCreator = GetComponent<FieldCreator>();
        _fieldCreator.CreateField(ref _chips);
        _chipMover = GetComponent<ChipMover>();
        _chipSelector = GetComponent<ChipSelector>();
        _chipSelector.MovableChipSelected.AddListener(StartTurn);
    }
}
