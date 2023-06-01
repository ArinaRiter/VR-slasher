using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float _range = 2;
    private string open = "Near";
    private Player _player;
    [SerializeField] private AudioSource opening;
    private bool hasPlayed = false;
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _range)
        {
            if (!hasPlayed)
            {
                opening.PlayOneShot(opening.clip);
                hasPlayed = true;
            }
            animator.SetBool(open, true);
            Invoke("Winner", 10);
        }

    }

    void Winner()
    {
        SceneManager.LoadScene("Win");
    }
}