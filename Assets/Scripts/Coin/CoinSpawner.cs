using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _spawnHeight;

    private float _currentTime = 0;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _spawnTime)
        {
            SpawnCoin();
            _currentTime = 0;
        }
        
    }

    private void SpawnCoin()
    {
        Vector3 spawnCoordinates = new Vector3(transform.localPosition.x, transform.localPosition.y + _spawnHeight, transform.localPosition.z);
        Instantiate(_template, spawnCoordinates, Quaternion.identity);
    }
}
