using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        //{
        //    source.clip = sounds[Random.Range(0, sounds.Length)];
        //    source.Play();
        //}
    }
}
