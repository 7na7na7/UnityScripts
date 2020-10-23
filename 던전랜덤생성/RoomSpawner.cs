using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 --> need bottom door
    //2 --> need top door
    //3 --> need left door
    //4 --> need right door
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;
    private void Start()
    {
        Destroy(gameObject,waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.1f);
    }

    void Spawn()
    {
        int playerValue = 0;
        if(templates.PlayerCount>0) 
            playerValue= ((templates.maxRoomCountSave-templates.PlayerSpawnMinusValue) / templates.PlayerCount);
        if (spawned == false)//생성되지 않았으면
        {
            if (openingDirection == 1) {//아래쪽에 문
                if (templates.minRoomCount > 0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length-1);
                        if (rand != 0&&rand != 1&&rand != 2)
                            break;
                    }
                }
                else if (templates.maxRoomCount<0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length-1);
                        if (rand == 0)
                            break;
                    }
                }
                else
                {
                    if (templates.PlayerCount > 0)
                    {
                        if (templates.rooms.Count + 1 > playerValue)
                        {
                            rand = templates.bottomRooms.Length - 1;
                            templates.PlayerCount--;
                        }
                        else
                        {
                            rand = Random.Range(0, templates.bottomRooms.Length-1);
                        }
                    }
                    else
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length-1);   
                    }
                }
                Instantiate(templates.bottomRooms[rand], transform.position,
                    templates.bottomRooms[rand].transform.rotation);
            }else if (openingDirection == 2){//위쪽에 문
                if (templates.minRoomCount > 0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.topRooms.Length-1);
                        if (rand != 0&&rand != 1&&rand != 2)
                            break;
                    }
                }
                else if (templates.maxRoomCount<0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.topRooms.Length-1);
                        if (rand == 0)
                            break;
                    }
                }
                else
                {
                    if (templates.PlayerCount > 0)
                    {
                        if (templates.rooms.Count + 1 > playerValue)
                        {
                            rand = templates.bottomRooms.Length - 1;
                            templates.PlayerCount--;
                        }
                        else
                        {
                            rand = Random.Range(0, templates.bottomRooms.Length-1);
                        }
                    }
                    else
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length-1);   
                    }
                }
                Instantiate(templates.topRooms[rand], transform.position,
                    templates.topRooms[rand].transform.rotation);
            }else if (openingDirection == 3) {//왼쪽에 문
                if (templates.minRoomCount > 0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.leftRooms.Length-1);
                        if (rand != 0&&rand != 1&&rand != 2)
                            break;
                    }
                }
                else if (templates.maxRoomCount<0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.leftRooms.Length-1);
                        if (rand == 0)
                            break;
                    }
                }
                else
                {
                    if (templates.PlayerCount > 0)
                    {
                        if (templates.rooms.Count + 1 > playerValue)
                        {
                            rand = templates.bottomRooms.Length - 1;
                            templates.PlayerCount--;
                        }
                        else
                        {
                            rand = Random.Range(0, templates.bottomRooms.Length-1);
                        }
                    }
                    else
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length-1);   
                    }
                }
                Instantiate(templates.leftRooms[rand], transform.position,
                    templates.leftRooms[rand].transform.rotation);
            } else if (openingDirection == 4) {//오른쪽에 문
                if (templates.minRoomCount > 0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.rightRooms.Length-1);
                        if (rand != 0&&rand != 1&&rand != 2)
                            break;
                    }
                }
                else if (templates.maxRoomCount<0)
                {
                    while (true)
                    {
                        rand = Random.Range(0, templates.rightRooms.Length-1);
                        if (rand == 0)
                            break;
                    }
                }
                else
                {
                    if (templates.PlayerCount > 0)
                    {
                        if (templates.rooms.Count + 1 > playerValue)
                        {
                            rand = templates.bottomRooms.Length - 1;
                            templates.PlayerCount--;
                        }
                        else
                        {
                            rand = Random.Range(0, templates.bottomRooms.Length-1);
                        }
                    }
                    else
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length-1);   
                    }
                }
                Instantiate(templates.rightRooms[rand], transform.position,
                    templates.rightRooms[rand].transform.rotation);
            }

            if(templates.minRoomCount>0) 
                templates.minRoomCount--;
            templates.maxRoomCount--;
            
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false) //겹친 방이 아직 생성되지 않았고, 자신도 생성되지 않았다면
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject); //방이 겹치면 자신을 파괴   
            }
            spawned = true;
        }
    }
}
