/*This is the Game Manager script that  is being used for all the UI components of the main gameplay except the SCore*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public Camera camera1;                              //Camera for Raycast          
    public RaycastHit hit;                              //To get hitInfo
    public Ray ray;                                     //Ray initialization
    [HideInInspector]                                 
    public int loadScene = 0;                           //Hidden loadscene value which is 0 and 1 for MainMenu and Gameplay(Demo Scene) respectively
    public BasketScoreScript basketScore = null;        //BasketScore Object for score comparision with the HighScore
    public Text scoreOb = null;                         //The score Text in hierarchy
    public Text highScoreOb = null;                     //The highScore Text
    public GameObject panel;                            //Pop up panel for game over condition
    public GameObject pause;                            //Pause Button
    public GameObject ball;                             //Ball 
    public GameObject help;                             //Hand Help Gesture

    private void Start()
    {
        highScoreOb.text = PlayerPrefs.GetInt("HighScore", 0).ToString();  //Loads playerPrefs in the highscore
    }

    void Update()
    {
        ScoreChange();
        if (Input.GetMouseButtonDown(0))    //Rather than OnMouseClick implementation from the hierarchy in the game this function is bieng used
        {
            ray = camera1.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Pause")
                {
                    panel.SetActive(true);
                    ball.SetActive(false);
                    help.SetActive(false);
                }

                else if (hit.collider.name == "Refresh")
                {
                    panel.SetActive(false);
                    pause.SetActive(true);
                    ball.SetActive(true);
                    help.SetActive(true);
                    loadScene = 1;
                    LoadScene();
                    
                                            
                }
            }

                

            
        }
    }

    

    private void ScoreChange()  //This function changes the score as well as the highscore 
    {
        scoreOb.text = basketScore.score.ToString();
        if (basketScore.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", basketScore.score);
            highScoreOb.text = basketScore.score.ToString();
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision) //Function for the boudary triggers which if the ball crosses makes the game over condition
    {
        if (collision.name =="Ball")
        {
            AdManager.Instance.ShowVideo();     //Interstitial ads are called
            panel.SetActive(true);
            pause.SetActive (false);
            ball.SetActive (false);
            help.SetActive(false);
            
        }
    }

    public void LoadScene()                     // For the reset button this resets the screen and start showing banner ads
    {
        SceneManager.LoadScene(loadScene);
        AdManager.Instance.ShowBanner();
    }
}
