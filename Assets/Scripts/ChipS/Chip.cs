using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    private ChipSelector _chipSelector;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public int Value { get; private set; }
    public bool IsMovable { get; private set; } = false;
    public MatrixCoordinates MatrixCoordinates { get; private set; }    

    public void SetValue(int value)
    {
        Value = value;
    }

    public void SetMovable()
    {
        IsMovable = true;
        _spriteRenderer.color = Color.green;
    }    
    public void SetNotMovable()
    {
        IsMovable = false;
        _spriteRenderer.color = Color.white;
    }

    public void SetMatrixCoordinates(int x, int y)
    {
        MatrixCoordinates = new MatrixCoordinates(x, y);    
    }

    private void Start()
    {
        _chipSelector = FindObjectOfType<ChipSelector>();
    }

    private void OnMouseDown()
    {
        if (IsMovable == true)
        {
            _chipSelector.SetSelectedChip(this);
        }
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
