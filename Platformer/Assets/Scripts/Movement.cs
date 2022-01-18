using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isJump;
    private readonly string Run = "Run";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        transform.Translate(_speed * Time.deltaTime * direction,0,0);

        if (direction > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (direction < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (direction == 0)
        {
            _animator.SetBool(Run, false);
        }
        else
        {
            _animator.SetBool(Run, true);
        }

        if (Input.GetAxis("Jump") == 1 && _isJump == false)
        {
            _isJump = true;
            _rigidbody2D.AddForce(new Vector2(0,_jumpPower));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isJump = false;
        }
    }
}
