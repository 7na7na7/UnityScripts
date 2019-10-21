using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int random;
    public GameObject[] zombie;
    public float minTime=3;
    public float maxTime=5;
    
    void Start()
    {
        Level level = FindObjectOfType<Level>();
        if(level.wave<level.zombiecount.Length) 
            StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        Level level = FindObjectOfType<Level>();
        while (true)
        {
            if (level.zombiecount[level.i] != level.currentzombie)
            {
                if (level.isdelay)
                    level.currentzombie = 0;
                yield return new WaitUntil(() => level.isdelay == false);
                if (level.currentzombie < level.savedcount)
                {
                    #region spawn

                    switch (level.wave) //2레벨까지는 보통좀비, 그리고 그다음에 순차적으로 좀비소환, 그리고 뚱땡이좀비 추가하기
                    {
                        case 1:
                        case 2:
                            Instantiate(zombie[0],
                                new Vector3(transform.position.x, transform.position.y,
                                    transform.position.z), //웨이브 1에서는 보통 좀비만 소환
                                Quaternion.identity);
                            break;
                        case 3:
                        case 4:
                            random = Random.Range(0,3);
                            if (random == 0||random==1)
                            {
                                Instantiate(zombie[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                            }
                            else
                            {
                                random = Random.Range(0, 2);
                                if (random == 0)
                                {
                                    Instantiate(zombie[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                                else
                                {
                                    Instantiate(zombie[2], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                            }
                            break;
                        case 5:
                        case 6:
                        case 7:
                            random = Random.Range(0,3);
                            if (random == 0||random==1)
                            {
                                Instantiate(zombie[0],
                                    new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                    Quaternion.identity);
                            }
                            else
                            {
                                random = Random.Range(0, 5);
                                if (random == 0||random==1)
                                {
                                    Instantiate(zombie[1],
                                        new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                                else if(random==2||random==3)
                                {
                                    Instantiate(zombie[2],
                                        new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                                else
                                {
                                    Instantiate(zombie[3],
                                        new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                            }
                            break;
                        default: //그 후로는 이렇게 소환
                            random = Random.Range(0,3);
                            if (random == 0||random==1)
                            {
                                Instantiate(zombie[0],
                                    new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                    Quaternion.identity);
                            }
                            else
                            {
                                random = Random.Range(0, 5);
                                if (random == 0||random==1)
                                {
                                    Instantiate(zombie[1],
                                        new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                                else if(random==2||random==3)
                                {
                                    Instantiate(zombie[2],
                                        new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                                else
                                {
                                    Instantiate(zombie[3],
                                        new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                }
                            }
                            break;
                    }

                    #endregion spawn

                    yield return new WaitForSeconds(Random.Range(minTime, maxTime));
                }

                if (level.wave > level.zombiecount.Length)
                {
                    Debug.Log("스폰코루틴종료!");
                    StopAllCoroutines();
                }
            }
            else
                yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}
