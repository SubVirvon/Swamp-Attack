using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private int _id;

    [SerializeField] protected Bullet Bullet;
    
    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public int ID => _id;

    public abstract void Shoot(Transform shootPoin);

    public void Buy()
    {
        _isBuyed = true; 
    }
}
