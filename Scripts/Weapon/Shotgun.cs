using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform shootPoin)
    {
        Instantiate(Bullet, shootPoin.position, Quaternion.identity);
    }
}
