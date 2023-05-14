using UnityEngine;
using System;
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;

    [SerializeField] private float _coolDown;

    private float _timer;

    public bool CanAttack { get; private set; }

    private Player _player;
    public float AttackRange => _attackRange;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (CanAttack)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer < _coolDown)
        {
            return;
        }

        CanAttack = true;

        _timer = 0;

    }

    public void TryAttackPlayer()
    {
        _player.TakeDamage(_attackRange);

        CanAttack = false;
    }
}