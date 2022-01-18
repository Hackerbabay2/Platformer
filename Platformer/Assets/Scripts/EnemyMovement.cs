using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _point;

    private Vector3 _targetPosition;
    private Tween _tween;

    private void Start()
    {
        _tween = transform.DOMoveX(_point.position.x,3).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }
}
