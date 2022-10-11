using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private int _cubesCount = 3;
    [SerializeField] private float _radius = 4f;
    [SerializeField] private CubeController _cubePrefab;
    [SerializeField] private float _runDistance = 5f;
    [SerializeField] private float _spawnCooldown = 3f;
    [SerializeField] private float _speed = 3f;

    public float RunDistance
    {
        get => _runDistance;
        set => _runDistance = value;
    }

    public float SpawnCooldown
    {
        get => _spawnCooldown;
        set => _spawnCooldown = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void Spawn(int index)
    {
        var position = GetPosition(index);

        var cube = Instantiate(_cubePrefab, position, Quaternion.identity);
        cube.Run(position.normalized * _runDistance, _speed);
    }

    private Vector3 GetPosition(int index)
    {
        return Quaternion.Euler(0, (float)index / _cubesCount * 360f, 0) * Vector3.right * _radius;
    }

    private IEnumerator SpawnCoroutine()
    {
        var index = 0;
        
        while (true)
        {
            Spawn(index++);

            index = index == _cubesCount ? 0 : index;
            
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
