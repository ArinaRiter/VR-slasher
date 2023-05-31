using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;


    public void TakeOutShield()
    {
        _shield.SetActive(true);
    }

    public void PutShield()
    {
        _shield.SetActive(false);
    }
}
