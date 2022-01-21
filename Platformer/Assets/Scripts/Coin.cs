using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _isCollected;
    [SerializeField] private float _duration;

    private IEnumerator DestroyObjectForDuration(float duration)
    {
        var waitForDuration = new WaitForSeconds(duration);

        for (int i = 0; i < duration; i++)
        {
            yield return waitForDuration;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _isCollected?.Invoke();
            StartCoroutine(DestroyObjectForDuration(_duration));
        }
    }
}
