using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float Damage;

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
