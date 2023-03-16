using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve _pathCurve;
    [SerializeField] private float _duration;
    [SerializeField] private float _threshold;

    private Chip _chip;
    private Vector3 _destination;
    private float _currentTime = 0f;
    private bool _isMoving = false;

    public void StartMovement(Chip chip, Vector3 destination)
    {
        _chip = chip;
        _destination = destination;
        _isMoving = true;
    }

    private void Update()
    {
        if (_isMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        float t = _pathCurve.Evaluate(_currentTime / _duration);
        _chip.transform.position = Vector3.Lerp(transform.position, _destination, t);
        _currentTime += Time.deltaTime;

        if (Vector3.Distance(transform.position, _destination) < _threshold)
        {
            transform.position = _destination;
            StopMoving();
        }
    }

    private void StopMoving()
    {
        _chip = null;
        _isMoving = false;
    }
}
