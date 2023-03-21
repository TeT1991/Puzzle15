using UnityEngine;

[RequireComponent(typeof(FieldCreator))]

public class Field : MonoBehaviour
{
    private Chip[,] _chips;

    private FieldCreator _fieldCreator;
    [SerializeField] private ChipSelector _chipSelector;
    [SerializeField] private ChipMover _chipMover;
    [SerializeField] private GameStatus _gameStatus;

    public void StartTurn()
    {
        Chip chip = _chipSelector.SelectedChip;

        int xCoordinate = 0;
        int yCoordinate = 0;
        int size = _chips.GetLength(0);

        GetEmptyCellCoordinates(ref xCoordinate, ref yCoordinate);

        _chipMover.StartMovement(chip, new Vector2(xCoordinate, size - yCoordinate));

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

        SetMovableChips();

        _chipSelector.ChipSelected.AddListener(StartTurn);
        _chipMover.MovingStoped.AddListener(_chipSelector.SetUnselectedStatus);
        _chipMover.MovingStoped.AddListener(EndTurn);

        _gameStatus.CheckGameStatus(_chips);
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
