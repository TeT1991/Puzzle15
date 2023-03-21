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
    private GameStatus _gameStatus;

    public void StartTurn()
    {
        Chip chip = _chipSelector.SelectedChip;

        int xCoordinate = 0;
        int yCoordinate = 0;

        GetEmptyCellCoordinates(ref xCoordinate, ref yCoordinate);  

        _chipMover.StartMovement(chip, new Vector3(xCoordinate, yCoordinate, 0));

        SetChipsNotMovable();
        ChangeChipIndexes(xCoordinate, yCoordinate, chip);
    }

    public void EndTurn()
    {
        SetMovableChips();
        _chipSelector.SetUnselectedStatus();
        _gameStatus.CheckGameStatus(_chips);
    }

    private void Start()
    {
        _fieldCreator = GetComponent<FieldCreator>();
        _fieldCreator.CreateField(ref _chips);
        _chipMover = GetComponent<ChipMover>();
        _chipSelector = GetComponent<ChipSelector>();
        _gameStatus = GetComponent<GameStatus>();
        SetMovableChips();

        _chipSelector.ChipSelected.AddListener(StartTurn);
        _chipMover.MovingStoped.AddListener(_chipSelector.SetUnselectedStatus);
        _chipMover.MovingStoped.AddListener(EndTurn);
    }

    private void GetEmptyCellCoordinates(ref int x, ref int y)
    {
        for (int i = 0; i < _chips.GetLength(0); i++)
        {
            for (int j = 0; j < _chips.GetLength(1); j++)
            {
                if (_chips[i, j] == null)
                {
                    x = i;
                    y = j;
                }
            }
        }
    }

    private void SetMovableChips()
    {
        int xCoordinate = 0;
        int yCoordinate = 0;

        GetEmptyCellCoordinates(ref xCoordinate, ref yCoordinate);


        if (yCoordinate + 1 < _chips.GetLength(1))
        {
            _chips[xCoordinate, yCoordinate + 1].SetMovable();
        }

        if (yCoordinate - 1 >= 0)
        {
            _chips[xCoordinate, yCoordinate - 1].SetMovable();
        }

        if (xCoordinate + 1 < _chips.GetLength(0))
        {
            _chips[xCoordinate + 1, yCoordinate].SetMovable();
        }

        if (xCoordinate - 1 >= 0)
        {
            _chips[xCoordinate - 1, yCoordinate].SetMovable();
        }
    }

    private void SetChipsNotMovable()
    {
        foreach(var chip in _chips)
        {
            if(chip != null)
            {
                chip.SetNotMovable();
            }
        }
    }

    private void ChangeChipIndexes(int x, int y, Chip chip)
    {
        var temp = chip;
        _chips[chip.MatrixCoordinates.X, chip.MatrixCoordinates.Y] = null;
        _chips[x,y] = temp;
        chip.SetMatrixCoordinates(x, y);
    }
}
