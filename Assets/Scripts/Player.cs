using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        if (_health - damage <= 0)
        {
            Debug.Log("Died");
            return;
        }
        else
        {
            _health -= damage;
            return;
        }
    }
}
