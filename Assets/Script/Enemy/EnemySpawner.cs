using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _leftSpawnPoint;
    [SerializeField] private Transform _rightSpawnPoint;
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private float _delayBetweenMovements;

    private float _minPointX;
    private float _maxPointX;
    public void Awake()
    {
        var camera = Camera.main;
        _minPointX = camera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        _maxPointX = camera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
    }

    public void Start()
    {
        Spawn();
    }

    private bool ShouldSpawnOnLeftSide()
    {
        var randomSpawn = Random.Range(0, 2);
        return randomSpawn == 1;
    }

    [UsedImplicitly]
    public void Spawn() // Вызывается при возвразении игрока на стартовую точку.
    {
        var spawnPoint = ShouldSpawnOnLeftSide() ? _leftSpawnPoint.position : _rightSpawnPoint.position;
        var currentEnemy = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity, transform);
        currentEnemy.Initialize(_minPointX, _maxPointX, _delayBetweenMovements);
    }
}
