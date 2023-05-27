using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthfill;
    [SerializeField] private Gradient gradient;
    // Start is called before the first frame update
    private Player _player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SetInitialHealth(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        healthfill.color = gradient.Evaluate(1f);
    }

    public void UpdateHealth(float currentHealth)
    {
        healthBar.value = currentHealth;
        healthfill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
