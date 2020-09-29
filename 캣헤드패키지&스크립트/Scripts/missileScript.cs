using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileScript : MonoBehaviour
{
    public GameObject explosion;
    public float speed;
    private AudioSource audio;
    public AudioClip explosionSound;
    void Start()
    {
        audio = Camera.main.GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        audio.PlayOneShot(explosionSound,1.2f);
        Destroy(gameObject);
    }
}
