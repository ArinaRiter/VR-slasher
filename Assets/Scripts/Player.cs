using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth = 16;
    [SerializeField] private float _experience;

    [SerializeField] private float _playerDmg;

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
        if (curEnemy.gameObject.GetComponent<EnemyAI>()._EnemyHP - _playerDmg <= 0)
        {
            curEnemy.gameObject.GetComponent<EnemyAI>()._EnemyHP = 0;
            Destroy(curEnemy);
            _experience += Random.Range(90,120);
            return;
        }
        else
        {
            curEnemy.gameObject.GetComponent<EnemyAI>()._EnemyHP -= _playerDmg;
            return;

        }
    }
}