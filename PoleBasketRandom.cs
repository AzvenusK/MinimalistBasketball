/*Use this script for the main */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleBasketRandom : MonoBehaviour {
    public trajectoryScript traject;        //Used for the TarjectoryScript elements drag and drop Ball from hierarchy
    public BasketScoreScript score;         //Used for the BasketScore elements drag and drop Basket from hierarchy
    public PoleBasketRandom pole;           //Used for this elements drag and drop PoleSystem from hierarchy
    public GameManager game;                //Used for the GameManager elements drag and drop GameManager from hierarchy
    [HideInInspector]
    public int scoreCompare;                //this variable is responsible for the Game Over conditon if the player misses the basket     

    private void Start()
    {
        scoreCompare = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball")
        {
            float randBasket = Random.Range(-0.3f, -2.6f);          //Randomize BasketPosition
            float randPole = Random.Range(-1.3f, -3.1f);            //Randomize PolePosition

            GameObject.Find("PoleSystem").transform.position = new Vector3(randPole, 1.0f, 0.5f);
            GameObject.Find("Basket").transform.position = new Vector3(randPole + 1.9f, randBasket, 0.5f);
            traject.spriteIndex = Mathf.RoundToInt(Random.Range(-0.4f, 5.4f));  //Randomize ball sprites from spritesheet

            scoreCompare += 1;
            
            if (scoreCompare != score.score)                //Game Over condition
            {
                AdManager.Instance.ShowVideo();
                game.panel.SetActive(true);
                game.pause.SetActive(false);
                game.ball.SetActive(false);
                game.help.SetActive(false);
                
            }
            pole.GetComponent<EdgeCollider2D>().enabled = false;

        }
    }
}
