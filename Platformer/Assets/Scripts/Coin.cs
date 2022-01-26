using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected;
    [SerializeField] private float _duration;

    private IEnumerator Pause(float duration)
    {
        var wait = new WaitForSeconds(duration);
        yield return wait;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _collected?.Invoke();
            StartCoroutine(Pause(_duration));
        }
    }
}
