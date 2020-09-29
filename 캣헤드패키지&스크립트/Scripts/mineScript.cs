using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineScript : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip explosionSound;
    public GameObject explosion;
    public Sprite mineOn;
    private void Awake()
    {
        transform.position=new Vector3(Mathf.RoundToInt(transform.position.x),Mathf.RoundToInt(transform.position.y),0);
    }

    void Start()
    {
        audio = Camera.main.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slime") || other.CompareTag("BossSlime"))
        {
            StartCoroutine(boooom());
        }
         if (other.gameObject.CompareTag("Container") || other.gameObject.CompareTag("wallsu"))
         {
             Destroy(gameObject);
         }
        
    }

    IEnumerator boooom()
    {
        GetComponent<SpriteRenderer>().sprite = mineOn;
        yield return new WaitForSeconds(1f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        audio.PlayOneShot(explosionSound,1f);
        Destroy(gameObject);
    }
}
