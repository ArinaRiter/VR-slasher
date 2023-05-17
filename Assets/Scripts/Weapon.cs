using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool Hit;
    private Player _player;
    private Player _enemyIsDied;

    private GameObject curEnemy;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Hit = true;
            curEnemy = other.gameObject;
        }
    }

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Hit)
        {
            _player.TryAttackEnemy(curEnemy);
            Hit = false;
        }

        if (_enemyIsDied)
        {
            Destroy(curEnemy);
        }
    }


}
