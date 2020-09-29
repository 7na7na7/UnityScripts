using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject item;
    public float delay;
    void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    IEnumerator ItemSpawn()
    {
        Instantiate(item,transform.position,Quaternion.identity);
        while (true)
        {
            yield return new WaitForSeconds(delay);
            GameObject[] obs = GameObject.FindGameObjectsWithTag("Item");
            if (obs.Length < 2)
            {
                if (obs.Length == 1)
                {
                    if (obs[0].transform.position == transform.position)
                        Instantiate(item, new Vector2(transform.position.x*-1, transform.position.y * -1 - 1),
                            Quaternion.identity);
                    else
                        Instantiate(item, transform.position, Quaternion.identity);
                }
                else
                    Instantiate(item, transform.position, Quaternion.identity);
            }
        }
    }
}
