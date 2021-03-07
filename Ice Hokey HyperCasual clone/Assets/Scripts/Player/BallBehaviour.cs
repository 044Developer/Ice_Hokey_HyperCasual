using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private const string EnemyBrick = "Enemy Brick";
    private const string Enemy = "Enemy";

    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Enemy))
        {
            _rigidbody.isKinematic = true;
            gameObject.SetActive(false);
            GameEvents.CallRespawnBall();
        }

        if (other.CompareTag(EnemyBrick))
        {
            _rigidbody.isKinematic = true;
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            GameEvents.CallWallDestroyed();
            
        }
    }
}
