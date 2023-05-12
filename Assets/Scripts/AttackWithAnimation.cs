using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithAnimation : MonoBehaviour
{
    [SerializeField] private int dmg;

    private DamageCalculations _player;

    private void Start()

    {
        _player = GameObject.FindGameObjectWithTag("player").GetComponent<DamageCalculations>();
    }
    public void AttackAnimationEvent()
    {
        _player.TakeDamage(dmg);
    }
}
