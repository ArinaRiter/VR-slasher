using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth = 16; //

    private void Start()
    {
        _health = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        if (_health - damage <= 0)
        {
            Debug.Log("Died");
            SceneManager.LoadScene("Dead"); //
            return;
        }
        else
        {
            _health -= damage;
            return;
        }
    }
}
