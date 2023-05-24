using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;

    [SerializeField] private float _coolDown;

    private float _timer;

    public AudioClip[] sounds;
    private AudioSource source;

    public bool CanAttack { get; private set; }

    private Player _player;
    public float AttackRange => _attackRange;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
        source = GetComponent<AudioSource>();
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

        if (_player.enemyisdead)
        {
            _attackRange = 0;
        }

    }

    public void TryAttackPlayer()
    {
        _player.TakeDamage(_attackRange);
        var slash = GameObject.Find("slash").GetComponent<ParticleSystem>();
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.PlayDelayed(0.8f);
        slash.Play();
        CanAttack = false;
    }
}