using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject missile;
    public Transform missileSpawn;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject t_missile = Instantiate(missile, missileSpawn.position, Quaternion.identity);
            t_missile.GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
        }
    }
}
