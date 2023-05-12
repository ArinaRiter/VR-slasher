using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats
{
    public float damageAmount;
    public Animator anim;
    public float hitPoints;
    public float moveRate;
    private PlayerStats playerStats;

    public EnemyStats(float damage, float health, float speed)/*, Animator a)*/
    {
        damageAmount = damage;
        hitPoints = health;
        moveRate = speed;
    }
}
