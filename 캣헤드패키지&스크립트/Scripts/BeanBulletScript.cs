using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBulletScript : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip explosionSound;
    public float speedMinusValue;
    public float speed;
    public float force;
    public GameObject explosion;
    public bool canCluster = true;
    void Start()
    {
        audio = Camera.main.GetComponent<AudioSource>();
        StartCoroutine(cor());
    }

    IEnumerator cor()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * force;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().velocity = Vector2.up * force*0.6f;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody2D>().velocity = Vector2.down * force*0.2f;
        yield return new WaitForSeconds(0.6f);
        speed = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.75f);
        if (FindObjectOfType<GameManager>().GrenadeUp)
        {
            if (canCluster)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                audio.PlayOneShot(explosionSound,1f);
                
                GameObject b = Instantiate(gameObject, transform.position,
                    Quaternion.Euler(0, 0, 45)) as GameObject;
                b.GetComponent<BeanBulletScript>().speed = 1.3f;
                b.GetComponent<BeanBulletScript>().canCluster = false;
                GameObject db = Instantiate(gameObject, transform.position,
                    Quaternion.Euler(0, 0, 135)) as GameObject;
                db.GetComponent<BeanBulletScript>().speed = 1.3f;
                db.GetComponent<BeanBulletScript>().canCluster = false;
                GameObject cb = Instantiate(gameObject, transform.position,
                    Quaternion.Euler(0, 0, 225)) as GameObject;
                cb.GetComponent<BeanBulletScript>().speed = 1.3f;
                cb.GetComponent<BeanBulletScript>().canCluster = false;
                GameObject scb = Instantiate(gameObject, transform.position,
                    Quaternion.Euler(0, 0, 315)) as GameObject;
                scb.GetComponent<BeanBulletScript>().speed = 1.3f;
                scb.GetComponent<BeanBulletScript>().canCluster = false;
                
                
                Destroy(gameObject);
            }
            else
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                audio.PlayOneShot(explosionSound,1f);
                Destroy(gameObject);
            }
        }
        else
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            audio.PlayOneShot(explosionSound,1.2f);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
        if(speed>0)
            speed -= Time.deltaTime*speedMinusValue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
