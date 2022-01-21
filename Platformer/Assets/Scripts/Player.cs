using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _isDead;
    [SerializeField] private Transform _spawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out SharpWood sharpWood))
        {
            transform.position = _spawnPoint.position;
            _isDead?.Invoke();
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            transform.position = _spawnPoint.position;
            _isDead?.Invoke();
        }
    }
}
