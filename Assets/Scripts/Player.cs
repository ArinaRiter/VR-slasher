using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth = 16;

    [SerializeField] private float _playerDmg;

    public bool _enemyIsDied { get; private set; }

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
        EnemyHit(_playerDmg, curEnemy);
        Debug.Log("TryAttack");
    }

    public void EnemyHit(float _playerDmg, GameObject curEnemy)
    {
        if (curEnemy.gameObject.GetComponent<EnemyAI>()._enemyHP - _playerDmg <= 0)
        {
            curEnemy.gameObject.GetComponent<EnemyAI>()._enemyHP = 0;
            Destroy(curEnemy);
            _enemyIsDied = true;
            return;
        }
        else
        {
            curEnemy.gameObject.GetComponent<EnemyAI>()._enemyHP -= _playerDmg;
            return;

        }
    }
}