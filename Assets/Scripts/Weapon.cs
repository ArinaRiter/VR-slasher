using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player _player;

    private GameObject curEnemy;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            curEnemy = other.gameObject;
            _player.TryAttackEnemy(curEnemy);
        }
    }

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }
}
