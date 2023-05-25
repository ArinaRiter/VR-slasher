using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth = 16;
    [SerializeField] private float _experience;

    [SerializeField] private float _playerDmg;
    [SerializeField] private bool _enemyisdead;
    private GameObject DeadEnemy;

    public GameObject deadEnemy
    {
        get { return DeadEnemy; }
        set { DeadEnemy = value; }
    }
    private GameObject DeadEnemy;
    //[SerializeField] private AudioSource _deathsound;
    public bool enemyisdead
    {
        get { return _enemyisdead; }
        set { _enemyisdead = value; }
    }

    private void Start()
    {
        _health = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (_health - damage <= 0)
        {
            Debug.Log("Died");
            SceneManager.LoadScene("Dead");
            //_deathsound.Play();
            _experience = 0;
            return;
        }
        else
        {
            _health -= damage;
            return;
        }
    }

    public void TryAttackEnemy(GameObject curEnemy)
    {
        EnemyHit(_playerDmg + (_experience/100), curEnemy);
        Debug.Log("TryAttack");
    }

    public void EnemyHit(float _playerDmg, GameObject curEnemy)
    {
        if (curEnemy.gameObject.layer == 10)
        {
            if (curEnemy.gameObject.GetComponent<BossAI>()._bossHP - _playerDmg <= 0)
            {
                curEnemy.gameObject.GetComponent<BossAI>()._bossHP = 0;
                //Destroy(curEnemy);
                curEnemy.gameObject.GetComponent<Animator>().enabled = false;
                curEnemy.gameObject.GetComponent<AIPath>().enabled = false;
                _enemyisdead = true;
                deadEnemy = curEnemy;
                //curEnemy.gameObject.GetComponent<EnemyAttack>().enabled = false;
                var colliders = curEnemy.GetComponentsInChildren<CharacterJoint>();
                foreach (var collider in colliders)
                {
                    collider.GetComponent<Collider>().isTrigger = false;
                }
                _experience += Random.Range(90, 120);
                Destroy(deadEnemy, 10);
                return;
            }
            else
            {
                curEnemy.gameObject.GetComponent<BossAI>()._bossHP -= _playerDmg;
                return;
            }
        }
        else
        {
            if (curEnemy.gameObject.GetComponent<EnemyAI>()._EnemyHP - _playerDmg <= 0)
            {
                curEnemy.gameObject.GetComponent<EnemyAI>()._EnemyHP = 0;
                curEnemy.gameObject.GetComponent<Animator>().enabled = false;
                curEnemy.gameObject.GetComponent<AIPath>().enabled = false;
                _enemyisdead = true;
                deadEnemy = curEnemy;
                var colliders = curEnemy.GetComponentsInChildren<CharacterJoint>();
                foreach (var collider in colliders)
                {
                    collider.GetComponent<Collider>().isTrigger = false;
                }
                _experience += Random.Range(90, 120);
                Destroy(deadEnemy, 10);
                return;
            }
            else
            {
                curEnemy.gameObject.GetComponent<EnemyAI>()._EnemyHP -= _playerDmg;
                return;
            }
        }
    }
}