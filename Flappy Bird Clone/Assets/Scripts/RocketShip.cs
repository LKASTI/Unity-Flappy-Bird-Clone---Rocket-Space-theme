using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    private Rigidbody2D rocketRB;
    private GameManager gameManager;
    public Animator anim;
    public float jumpVelMod;
    public AudioClip thruster;
    public AudioClip explode;
    public AudioClip scorePoint;
    public AudioSource rocketAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        rocketAudio = gameObject.GetComponent<AudioSource>();
        anim = GameObject.Find("Thruster").GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rocketRB = gameObject.GetComponent<Rigidbody2D>();
        anim.SetBool("Jump", false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && gameManager.isGameOn) //jump when game on and mouse button 0
        {
            rocketAudio.PlayOneShot(thruster, 0.5f); //play thruster sound
            anim.SetBool("Jump",true); //play thruster animation
            MoveUp(); //increase velocity upwards
        }
        else
        {
            anim.SetBool("Jump", false);
        }


        if(gameObject.transform.position.y <= -6) //stop game when rocket below screen
        {
            gameManager.GameOver();
        }
        

        if(gameManager.waitingToStart) //while waiting to start stop movement in y direction
        {
            rocketRB.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else 
        {
            rocketRB.constraints = RigidbodyConstraints2D.None;
            rocketRB.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        
        
    }

void OnTriggerEnter2D(Collider2D o)
{
    if(o.gameObject.CompareTag("ScoreCollider"))
    {
        rocketAudio.PlayOneShot(scorePoint, 0.5f);
        gameManager.currentScoreCounter++;

        Destroy(o.gameObject);
    }
}


    private void StopGame()
    {

            gameManager.isGameOn = false;

    }

    public void MoveUp()
    {
            rocketRB.velocity = new Vector2(0,jumpVelMod); //move player up
    }

    void OnCollisionEnter2D(Collision2D o)
    {
        if(o.gameObject.CompareTag("Pillar"))
        {
            anim.SetBool("Death", true);
            rocketAudio.PlayOneShot(explode, 0.2f);
            GameObject.Find("Thruster").transform.localScale *= 3.0f;
            o.collider.enabled = false;
            gameManager.GameOver();
            
        }

    }



    void FixedUpdate()
    {
        
    }
}
