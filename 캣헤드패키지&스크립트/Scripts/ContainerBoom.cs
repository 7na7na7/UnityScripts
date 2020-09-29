using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBoom : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip explosionSound;
    public GameObject explosion;
    private bool canGo = true;
    private void Awake()
    {
        transform.position=new Vector3(Mathf.RoundToInt(transform.position.x),Mathf.RoundToInt(transform.position.y),0);
    }

    void Start()
    {
        audio = Camera.main.GetComponent<AudioSource>();
        StartCoroutine(super());
    }

    IEnumerator super()
    {
        GetComponent<Collider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Collider2D>().isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") || other.CompareTag("Grenade") || other.CompareTag("BossBullet"))
        {
            StartCoroutine(boooom());
        }

        if (other.gameObject.CompareTag("mine"))
        {
            if (canGo)
            {
                canGo = false;
                if (other.gameObject.transform.position.x < transform.position.x)
                    transform.Translate(1, 0, 0);
                else
                    transform.Translate(-1, 0, 0);
                if (other.gameObject.transform.position.y < transform.position.y)
                    transform.Translate(0, 1, 0);
                else
                    transform.Translate(0, -1, 0);
            }
            else
                Destroy(gameObject);
        }
    }

    IEnumerator boooom()
    {
        yield return new WaitForSeconds(0.05f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        audio.PlayOneShot(explosionSound,1.2f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Container") || other.gameObject.CompareTag("wallsu"))
        {
            if (other.gameObject.transform.position.x < transform.position.x)
                    transform.Translate(1, 0, 0);
                else
                    transform.Translate(-1, 0, 0);
                if (other.gameObject.transform.position.y < transform.position.y)
                    transform.Translate(0, 1, 0);
                else
                    transform.Translate(0, -1, 0);
        }
    }
}
