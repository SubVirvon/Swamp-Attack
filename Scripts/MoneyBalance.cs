using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] TMP_Text _money;
    [SerializeField] Character _character;

    private void OnEnable()
    {
        _money.text = _character.Money.ToString();
    }
}
