using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    AudioSource source;
    Collider2D soundTrigger;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        source.Play();
    }
}