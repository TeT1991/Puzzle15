using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class ChipSelector : MonoBehaviour
{
    public UnityEvent ChipSelected;

    [SerializeField] private Field _field;

    public Chip SelectedChip { get; private set; }
    public bool IsSelected { get; private set; } = false; 

    public void SetSelectedChip(Chip chip)
    {
        SelectedChip = chip;

        if (SelectedChip != null && IsSelected == false)
        {
            IsSelected = true;  
            ChipSelected.Invoke();
        }
    }

    public void SetUnselectedStatus()
    {
        IsSelected = false;
    }
}