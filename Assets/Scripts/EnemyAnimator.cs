using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Run = Animator.StringToHash("IsRunning");
    private static readonly int Walk = Animator.StringToHash("IsWalking");
    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void IsRunning(bool condition)
    {
        _animator.SetBool(Run, condition);
    }

    public void IsWalking(bool condition)
    {
        _animator.SetBool(Walk, condition);
    }
}
