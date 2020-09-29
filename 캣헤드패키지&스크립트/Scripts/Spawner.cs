
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public int doubleBossWave;
    private bool canBossSpawn = true;
    public GameObject BossMonster;
    private GameManager gm;
    public GameObject monster;
    public float samlldelay,bigdelay;
    private bool btn = false;

    void Start()
    {
        if (gameObject.name == "LSpawner" || gameObject.name == "RSpawner" || gameObject.name == "BossSpawner"|| gameObject.name == "RSpawner2" || gameObject.name == "LSpawner2"
            || gameObject.name == "RSpawner3" || gameObject.name == "LSpawner3"|| gameObject.name == "UpSpawner2" || gameObject.name == "DownSpawner2"
            || gameObject.name == "UpSpawner3" || gameObject.name == "DownSpawner3" || gameObject.name == "UpSpawner4" || gameObject.name == "DownSpawner4")
        {
        }
        else
        {
            StartCoroutine(spawn());
        }

        gm = FindObjectOfType<GameManager>();
            
    }

    private void Update()
    {
        if (gameObject.name == "BossSpawner")
        {
            if (gm.wave != 1)
            {
                if (gm.wave >= doubleBossWave)
                {
                    if (gm.currentzombie == gm.zombiecount[gm.i] - 2)
                    {
                        if (canBossSpawn)
                        {

                            Instantiate(BossMonster, transform.position + new Vector3(9, 0, 0), Quaternion.identity);
                            Instantiate(BossMonster, transform.position + new Vector3(-9, 0, 0), Quaternion.identity);

                            canBossSpawn = false;
                            StartCoroutine(delaySet());
                        }
                    }
                }
                else
                {
                    if (gm.currentzombie == gm.zombiecount[gm.i] - 1)
                    {
                        if (canBossSpawn)
                        {
                            int r = Random.Range(0, 2);
                            if (r == 0)
                                Instantiate(BossMonster, transform.position + new Vector3(9, 0, 0),
                                    Quaternion.identity);
                            else
                                Instantiate(BossMonster, transform.position + new Vector3(-9, 0, 0),
                                    Quaternion.identity);
                            canBossSpawn = false;
                            StartCoroutine(delaySet());
                        }
                    }
                }
            }
        }
        else if (gameObject.name == "LSpawner" || gameObject.name == "RSpawner")
        {
            if (!btn)
            {
                if (gm.wave >= 7)
                {
                    StartCoroutine(spawn());
                    btn = true;
                }
            }
        }
    }

    IEnumerator delaySet()
    {
        yield return new WaitForSeconds(5f);
        canBossSpawn = true; 
    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(samlldelay, bigdelay));
            if (gm.currentzombie < gm.zombiecount[gm.i])
            {
                if (gm.wave == 20)
                {
                    Instantiate(BossMonster, transform.position, Quaternion.identity);
                }
                else
                {
                    if (gameObject.name == "UpSpawner")
                    {
                        GameObject mob = Instantiate(monster, transform.position, Quaternion.identity);
                        mob.GetComponent<SlimeScript>().StartCoroutine(mob.GetComponent<SlimeScript>().UpSpawner());
                    }
                    else if (gameObject.name == "DownSpawner")
                    {
                        GameObject mob = Instantiate(monster, transform.position, Quaternion.identity);
                        mob.GetComponent<SlimeScript>().StartCoroutine(mob.GetComponent<SlimeScript>().DownSpawner());
                    }
                    else
                    {
                        Instantiate(monster, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
