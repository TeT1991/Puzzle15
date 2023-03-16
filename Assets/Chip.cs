using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Chip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backGroundSprite;

    public Vector3 Size { get; private set; }
    public int Value { get; private set; }

    public void SetValue(int value)
    {
        Value = value;
    }

    public void TryToMove()
    {

    }

    private void Start()
    {
        Size = _backGroundSprite.sprite.bounds.size;
    }

}
