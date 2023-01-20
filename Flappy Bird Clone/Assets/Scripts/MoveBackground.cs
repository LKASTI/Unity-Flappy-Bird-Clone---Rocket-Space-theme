using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private float repeatWidth;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOn || gameManager.waitingToStart) //background moves while waiting or game is on
        {
            MoveLeftAndRepeat();
        }

    }

    private void MoveLeftAndRepeat()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
