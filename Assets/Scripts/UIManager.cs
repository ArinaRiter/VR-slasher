using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static Image HealthBarImage;
    [SerializeField] private float reducespeed = 2;
    private static float target = 1;
    public static void SetHealthBarValue(float value)
    {
        target = value;
        if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.5f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
    }
    private void Update()
    {
        HealthBarImage.fillAmount=Mathf.MoveTowards(HealthBarImage.fillAmount,  target, reducespeed*Time.deltaTime);
    }
}
