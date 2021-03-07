using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInputController
{
    private Rigidbody _rigidBody;
    private Transform _ballTransform;
    private Transform _playerTransform;
    private GameObject _arrow;

    private int _angleLimits;
    private int _maxDragLimits;
    private float _forcePower;
    private float _distance;
    private float _angle;
    private float _smoothRotation;
    private Touch _touch;
    private Vector3 _direction;
    private Camera _camera;

    public void Init(float forcePower, float smoothRotation, int angleLimit, int maxDragLimit,
        Rigidbody ballRigidbody, Transform ballTransform, GameObject arrow, Transform playerTransform)
    {
        _forcePower = forcePower;
        _smoothRotation = smoothRotation;
        _angleLimits = angleLimit;
        _maxDragLimits = maxDragLimit;
        _rigidBody = ballRigidbody;
        _ballTransform = ballTransform;
        _playerTransform = playerTransform;
        _arrow = arrow;
        _camera = Camera.main;
    }

    public void RegisterTouchInput()
    {
        if (Input.touchCount == 0) return;
        else
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began || Input.GetMouseButtonDown(1))
            {
                DragStart();
            }

            if (_touch.phase == TouchPhase.Moved || Input.GetMouseButton(1))
            {
                Dragging();
            }

            if (_touch.phase == TouchPhase.Ended || Input.GetMouseButtonUp(1))
            {
                DragRelease();
            }
        }
    }

    public void RegisterMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DragStart();
        }

        if (Input.GetMouseButton(0))
        {
            
            Dragging();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DragRelease();
        }
    }



    public void DragStart()
    {
        _arrow.SetActive(true);
        _rigidBody.isKinematic = false;
    }

    public void Dragging()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            CalculateInput(raycastHit);
            
            ControllArrow(raycastHit);
            ControllPlayer( raycastHit.point.x);
            RotateBall(raycastHit);
        }
    }

    public void DragRelease()
    {
        _arrow.SetActive(false);
        LaunchBall();
    }

    private void LaunchBall()
    {
        if (_rigidBody.velocity != Vector3.zero)
            return;
        
        _rigidBody.AddForce(-_direction * _distance * _forcePower, ForceMode.Impulse);
    }

    private void RotateBall(RaycastHit hit)
    {
        _ballTransform.Rotate(Vector3.up, hit.point.x * _smoothRotation);
    }

    private void ControllPlayer( float hit)
    {
        _playerTransform.position = new Vector3(_angle, _playerTransform.position.y, _playerTransform.position.z);
        _playerTransform.LookAt(Vector3.forward * hit);
    }

    private void ControllArrow(RaycastHit hit)
    {
        _arrow.transform.LookAt(hit.point, Vector3.up);
        _arrow.transform.localScale = new Vector3(_arrow.transform.localScale.x, _arrow.transform.localScale.y, _distance);
        _arrow.transform.Rotate(Vector3.up, _angle * _smoothRotation);
    }

    private void CalculateInput(RaycastHit hit)
    {
        _distance = Vector3.Distance(_ballTransform.position, hit.point);
        _distance = Mathf.Clamp(_distance, 0, _maxDragLimits);
        _angle = Mathf.Clamp(hit.point.x, -_angleLimits, _angleLimits);
        _direction = (_ballTransform.position - hit.point).normalized;
    }
}
