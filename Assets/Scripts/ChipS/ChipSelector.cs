using UnityEngine;
using UnityEngine.Events;


public class ChipSelector : MonoBehaviour
{
    [HideInInspector]public UnityEvent ChipSelected;

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