using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject firePillar;
    private float maxPillarYrange = -2.0f;
    private float minPillarYrange = -7.0f;
    private float spawnInterval = 2;

    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        InvokeRepeating("spawnFirePillar", 0, spawnInterval); //spawn pillars every while game is on 
    }

    private void spawnFirePillar()
    {
        if(gameManager.isGameOn)
        {
            float randomYpos = Random.Range(minPillarYrange, maxPillarYrange);
            Instantiate(firePillar, new Vector3(firePillar.transform.position.x, randomYpos,0), firePillar.transform.rotation);
        }

    }
    
    void Update()
    {
        
    }


    
}
