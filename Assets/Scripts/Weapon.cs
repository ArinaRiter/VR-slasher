using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player _player;

    private GameObject curEnemy;

    public AudioClip[] sounds;
    private AudioSource source;




    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.gameObject.CompareTag("Enemy"))
        {
            curEnemy = other.gameObject.transform.root.gameObject;
            _player.TryAttackEnemy(curEnemy);
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
            //source.Play();
        }
        if (other.gameObject.transform.root.gameObject.CompareTag("Rat"))
        {
            Destroy(other, 3);
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
            //source.Play();
        }
        if (other.gameObject.transform.root.gameObject.CompareTag("Snake"))
        {
            Destroy(other, 3);
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
            //source.Play();
        }
    }

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
        source = GetComponent<AudioSource>();
    }
}
