using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private FieldCreator _fieldCreator;

    private void Start()
    {
        float xPosition = _fieldCreator.transform.position.x + _fieldCreator.GetSize() / 2;
        float yPosition = _fieldCreator.transform.position.y + _fieldCreator.GetSize() / 2;

        transform.position = new Vector3(xPosition, yPosition, -1);
    }
}
