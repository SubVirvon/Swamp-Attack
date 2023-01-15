using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemys;
    [SerializeField] private int _enemysMaxCount;
    [SerializeField] private float _delay;
    [SerializeField] private Character _character;
    
    private float _timeAfterLastSpawn;
    private int _enemysCount;

    private void Awake()
    {
        _timeAfterLastSpawn = _delay;
        _enemysCount = 0;
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= _delay && _enemysCount <= _enemysMaxCount)
        {
            _enemysCount++;
            _timeAfterLastSpawn = 0;
            InstantiateEnemy();
        }
    }

    private void InstantiateEnemy()
    {   
        var enemy = Instantiate(_enemys[Random.Range(0, _enemys.Count)], transform.position, Quaternion.identity).GetComponent<Enemy>();

        enemy.Init(_character);
        enemy.Died += OnEnemyDying;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Died -= OnEnemyDying;
        _character.AddMoney(enemy.Reward);
    }
}
