using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_player.position.x,_player.position.y,-10),_speed * Time.deltaTime); 
    }
}
