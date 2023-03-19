using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ChipSelector : MonoBehaviour
{
    private Field _field;
    private Chip _chip;

    private bool _isChipSelected = false;

    private KeyCode _keyPressed;

    private int _xDirection = 0;
    private int _yDirection = 0;

    public UnityEvent MovableChipSelected;

    public Chip SelectChip(Chip[,] chips)
    {
        int xPosition = 0;
        int yPosition = 0;

        for (int x = 0; x < chips.Length; x++)
        {
            for (int y = 0; y < chips.Length; y++)
            {
                if (chips[x,y] == null)
                {
                    xPosition = x;
                    yPosition = y;
                }
            }
        }

        if(xPosition + _xDirection >= 0 && xPosition + _xDirection < 4 && yPosition + _yDirection >= 0 && yPosition + _yDirection < 4)
        {
            chips[xPosition + _xDirection, yPosition + _yDirection].GetComponentInChildren<SpriteRenderer>().color = Color.red;
            MovableChipSelected.Invoke();
            return chips[xPosition + _xDirection, yPosition + _yDirection];
        }
        else
        {
            return null;
        }


    }

    private void Start()
    {
        _field = GetComponent<Field>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _yDirection = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _xDirection = -1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _yDirection = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _xDirection = 1;
        }

        if (_isChipSelected)
        {
            MovableChipSelected.Invoke();
        }
        
    }
}