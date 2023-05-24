using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSword : MonoBehaviour
{
    [SerializeField] private GameObject _sword;

    public void TakeOutSword()
    {
        _sword.SetActive(true);
        Debug.Log("Take");
    }

    public void PutSword()
    {
        _sword.SetActive(false);
        Debug.Log("Put");
    }
}
