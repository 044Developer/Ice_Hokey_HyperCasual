using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerStats PlayerStats;
    
    [SerializeField] private Rigidbody _ballRigidBody;
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private GameObject _arrow;

    private PlayerInputController _inputController = new PlayerInputController();

    private void Start()
    {
        _inputController.Init(PlayerStats.ShootForce, PlayerStats.SmoothRotation, PlayerStats.AngleLimits, PlayerStats.DragLimit, _ballRigidBody, _ballTransform, _arrow, transform);
    }

    private void Update()
    {
        //_inputController.RegisterTouchInput();
        _inputController.RegisterMouseInput();

        if (_ballRigidBody.IsSleeping())
        {
            GameEvents.CallRespawnBall();
        }
    }
}
