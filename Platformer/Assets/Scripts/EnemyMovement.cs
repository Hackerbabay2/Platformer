using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _timeReachPoint;

    private Vector3 _targetPosition;
    private Tween _tween;

    private void Start()
    {
        _tween = transform.DOMoveX(_point.position.x,_timeReachPoint).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }
}
