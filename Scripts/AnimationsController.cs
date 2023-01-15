using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Character))]
public class AnimationsController : MonoBehaviour
{
    private Animator _animator;
    private Character _character;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        _character.Shooted += Attack;
        _character.WeaponChanged += ChangeWeapon;
    }

    private void OnDisable()
    {
        _character.Shooted -= Attack;
        _character.WeaponChanged -= ChangeWeapon;
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    private void ChangeWeapon(int WeaponID)
    {
        _animator.SetInteger("WeaponNumber", WeaponID);
    }
}
