using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour
{
    public float speed;
    private int gameIsOn;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        DestroyWhenOutOfBounds();
    }

    private void MoveLeft()
    {
        if(gameManager.isGameOn)
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void DestroyWhenOutOfBounds()
    {
        if(transform.position.x <= -4.0f)
        {
            Destroy(gameObject);
        }
    }
}
