using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AxeBullet : Bullet
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speed);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(Damage);

        DestroyBullet();
    }
}
