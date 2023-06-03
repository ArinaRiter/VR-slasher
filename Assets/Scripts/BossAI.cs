using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossAI : MonoBehaviour
{
    private BossStates currentState;
    private Player _player;

    [SerializeField] private bool _haveSword;

    [SerializeField] private EnemyAttack _bossAttack;

    [SerializeField] private AIPath _aiPath;

    [SerializeField] private BossAnimator _bossAnimator;
    //[SerializeField] private float _reachedPointDistance;
    [SerializeField] private GameObject _roamTarget;

    [SerializeField] private AIDestinationSetter _aiDestinationSetter;
    [SerializeField] private float _stopTargetFollowingRange;
    [SerializeField] private float _targetFollowRange;

    [SerializeField] private float _bossMaxHP;


    [SerializeField] private float _BossHP;

    public bool bossAlive;

    [SerializeField] private GameObject walls;
    public float _bossHP
    {
        get
        {
            return _BossHP;
        }
        set
        {
            _BossHP = value;
        }
    }
    public enum BossStates
    {
        Idle,
        FightIdle,
        Strafing
    }

    void Start()
    {
        currentState = BossStates.Idle;

        _player = FindObjectOfType<Player>();

        _BossHP = _bossMaxHP;
    }
    void Update()
    {

        switch (currentState)
        {
            case BossStates.Idle:

                TryFindPlayer();

                _bossAnimator.IsIdle(true);
                //_bossAnimator.IsStrafing(false);

                break;

            case BossStates.FightIdle:

                TryFindPlayer();

                _aiPath.maxSpeed = 0;

                _bossAnimator.IsFightIdle(true);
                _bossAnimator.IsStrafing(false);

                break;

            case BossStates.Strafing:
                _aiDestinationSetter.target = _player.transform;

                _bossAnimator.IsFightIdle(false);
                _bossAnimator.IsIdle(false);
                _bossAnimator.IsStrafing(true);

                _aiPath.maxSpeed = 2;

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _bossAttack.AttackRange)
                {
                    if (_bossAttack.CanAttack)
                    {

                        if (_haveSword)
                        {
                            _bossAnimator.PlayAttack();
                        }
                        else
                        {
                            _bossAnimator.PlayKick();
                        }
                        _bossAttack.TryAttackPlayer();
                    }
                }

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >= _stopTargetFollowingRange)
                {
                    currentState = BossStates.FightIdle;
                }
                break;
        }
    }

    public void TryFindPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            currentState = BossStates.Strafing;
            walls.SetActive(true);
            bossAlive = true;
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >= _stopTargetFollowingRange)
            {
                currentState = BossStates.FightIdle;
            }
        }
    }

    public void Block()
    {
        _bossAnimator.PlayBlock();
    }
}




