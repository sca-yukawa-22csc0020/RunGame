using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstaclePrefab;
    private Vector3 spawnPos=new Vector3(25,0,0);
    private float startDelay=2;
    private float repeatRate=2;
    private PlayerController pc;
    void Start()
    {
       InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        pc=GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void SpawnObstacle()
    {
        if (!pc.gameOver) { 
       Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
