using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _attackPoint;

    public event UnityAction Shooted;
    public event UnityAction<int> WeaponChanged;
    public int Money { get; private set; }

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;

    private void Awake()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        Money = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shooted?.Invoke();
        if (Input.GetMouseButtonDown(1))
            NextWeapon();
    }

    public void Shoot()
    {
        _currentWeapon.Shoot(_attackPoint);
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    private void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        WeaponChanged?.Invoke(weapon.ID);
    }
}
