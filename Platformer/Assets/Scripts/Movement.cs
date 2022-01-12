using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        transform.Translate(_speed * Time.deltaTime * horizontalMove,0,0);
    }
}
