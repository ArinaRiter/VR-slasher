using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossAnimator : MonoBehaviour
{
    [SerializeField] private Animator _bossAnimator;

    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Kick = Animator.StringToHash("Kick");
    private static readonly int Idle = Animator.StringToHash("IsIdle");
    private static readonly int Strafe = Animator.StringToHash("IsStrafing");
    private static readonly int fightIdle = Animator.StringToHash("FightIdle");

    private static readonly int Block = Animator.StringToHash("Block");
    private static readonly int Impact = Animator.StringToHash("Impact");


    public void PlayAttack()
    {

        _bossAnimator.SetTrigger(Attack);
    }

    public void PlayKick()
    {
        _bossAnimator.SetTrigger(Kick);
    }
    public void PlayBlock()
    {
        _bossAnimator.SetTrigger(Block);
    }
    public void PlayImpact()
    {
        _bossAnimator.SetTrigger(Impact);
    }

    public void IsIdle(bool condition)
    {
        _bossAnimator.SetBool(Idle, condition);
    }
    public void IsStrafing(bool condition)
    {
        _bossAnimator.SetBool(Strafe, condition);
    }

    public void IsFightIdle(bool condition)
    {
        _bossAnimator.SetBool(fightIdle, condition);
    }

}
