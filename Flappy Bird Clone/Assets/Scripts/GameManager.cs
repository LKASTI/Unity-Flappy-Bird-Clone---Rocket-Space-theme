using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOn;
    public bool waitingToStart;
   
    private Rigidbody2D rocket;
    private GameObject rs;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highestScore;
    public int currentScoreCounter;
    public static int highestScoreCounter = 0;
    public Button Restart;
    public GameObject ScoreBoard;
    public TextMeshProUGUI currentScore1; 
    private RocketShip rocketshipscript;
    public AudioClip thruster;
    
    
    void Start()
    {
        
        rs = GameObject.Find("RocketShip");
        rocketshipscript = GameObject.Find("RocketShip").GetComponent<RocketShip>();

        currentScoreCounter = 0;
        isGameOn = false;
        waitingToStart = true;
        
    }

    public void GameOver()
    {
        if(currentScoreCounter > highestScoreCounter)
        {
            highestScoreCounter = currentScoreCounter;
            highestScore.text = ""+highestScoreCounter;
        }
        highestScore.text = ""+highestScoreCounter;
        isGameOn = false;        
        Restart.gameObject.SetActive(true);
        
        ScoreBoard.gameObject.SetActive(true);
        currentScore.gameObject.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if(waitingToStart && Input.GetButtonDown("Fire1"))
        {
            rs.GetComponent<RocketShip>().MoveUp();
            rocketshipscript.anim.SetBool("Jump",true);
            rocketshipscript.rocketAudio.PlayOneShot(thruster, 0.1f);
            isGameOn = true;
            waitingToStart = false;

        }

        if(isGameOn)
        {
            UpdateScore();
        }

    }

    private void UpdateScore()
    {
        currentScore.text = ""+ currentScoreCounter;
        currentScore1.text = "" + currentScoreCounter;
       
    }


}
