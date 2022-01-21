using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _coin;
    [SerializeField] private float _spawnTime;

    private List<Transform> _points;

    private void Start()
    {
        _points = new List<Transform>();

        if (_path.childCount > 0)
        {
            for (int i = 0; i < _path.childCount - 1; i++)
            {
                _points.Add(_path.GetChild(i));
            }
            StartCoroutine(SpawnCoins(_spawnTime));
        }
        else
        {
            Debug.Log("Нету точек спавна");
        }
    }

    private IEnumerator SpawnCoins(float duration)
    {
        bool isSpawn = true;
        var waitForDuration = new WaitForSeconds(duration);
        int indexPoint;

        while (isSpawn)
        {
            indexPoint = Random.Range(0,_points.Count);
            Instantiate(_coin, new Vector3(_points[indexPoint].position.x,_points[indexPoint].position.y,0), Quaternion.identity);
            yield return waitForDuration;
        }
    }
}
