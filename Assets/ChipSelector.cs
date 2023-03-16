using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSelector : MonoBehaviour
{
    private Chip _chip;

    private bool _isChipSelected = false;

    private KeyCode _keyPressed;

    private void Update()
    {
        KeyCode keyPressed = Event.current.keyCode;

        switch (keyPressed)
        {
            case KeyCode.W:
                break;
            case KeyCode.A:
                break;
            case KeyCode.S:
                break;
            case KeyCode.D:
                break;
        }
    }
}
