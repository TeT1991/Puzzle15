using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backGroundSprite;

    public Vector3 Size { get; private set; }
    public int Value { get; private set; }

    private void Start()
    {
        Size = _backGroundSprite.sprite.bounds.size;
    }

    public void SetValue(int value)
    {
        Value = value;
    }

    private void OnMouseDown()
    {
        Debug.Log(Value);
    }
}
