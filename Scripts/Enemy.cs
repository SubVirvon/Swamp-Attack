using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;

    public Character Target => _target;
    public int Reward => _reward;
    public event UnityAction<Enemy> Died;

    private Character _target;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Died?.Invoke(this);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Init(Character target)
    {
        _target = target;
    }
}