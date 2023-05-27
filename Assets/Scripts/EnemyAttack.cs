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
    private Weapon weapon;

    public bool CanAttack { get; private set; }

    private Player _player;
    public float AttackRange => _attackRange;

    //[SerializeField] private ParticleSystem[] psarray;

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
            _player.deadEnemy.GetComponent<EnemyAttack>()._damage = 0;
        }

    }

    public void TryAttackPlayer()
    {
        _player.TakeDamage(_damage);
        //var slash = curEnemy.GetComponentInChildren<ParticleSystem>();
        var slash = GameObject.Find("slash").GetComponent<ParticleSystem>();
        source.clip = sounds[Random.Range(0, sounds.Length)];
        source.PlayDelayed(0.8f);
        //if (psarray.Length > 0)
        //{
        //    for (int i = 0; i < psarray.Length; i++)
        //    {
        //        psarray[i].Play();
        //    }

        //}
        slash.Play();
        Debug.Log("TryAttackPlayer");
        CanAttack = false;
        Invoke("sethbvalue", 1);
    }
    public void sethbvalue()
    {
        UIManager.SetHealthBarValue(_player.valueforhealthbar);
    }
}