using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += Transit;
    }

    private void OnDisable()
    {
        _enemy.Died -= Transit;
    }

    private void Transit(Enemy enemy)
    {
        NeedTransit = true;
    }
}
