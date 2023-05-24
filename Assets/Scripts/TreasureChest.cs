using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float _range = 2;
    private string open = "Near";
    private Player _player;
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _range)
        {
            animator.SetBool(open, true);
        }

    }
}