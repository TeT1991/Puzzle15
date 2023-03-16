using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldCreator))]
[RequireComponent(typeof(ChipMover))]

public class Field : MonoBehaviour
{
    private List<Chip> _chips;
    private FieldCreator _fieldCreator;
    private Cell[,] _cells;
    private Cell _emptyCell;

    private ChipMover _chipMover;   

    public void TryGetMovableCell(int xDirection, int yDirection, List<Chip> chips, ref Chip movableChip)
    {
        int size = _cells.GetLength(0);

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if(_cells[x,y].IsEmpty)
                {
                    if (y + yDirection >= 0 && y + yDirection <= size && x + xDirection >= 0 && x + xDirection <= size)
                    {
                        //movableChip =  _cellsCoordinates[x + xDirection, y + yDirection];
                    }
                }
            }
        }
    }

    private void Start()
    {
        _fieldCreator = GetComponent<FieldCreator>();
        _fieldCreator.CreateField(ref _cells, ref _chips, ref _emptyCell);
        _chipMover = GetComponent<ChipMover>();
        _chipMover.StartMovement(_chips[0], _emptyCell.gameObject.transform.position);
    }
}
