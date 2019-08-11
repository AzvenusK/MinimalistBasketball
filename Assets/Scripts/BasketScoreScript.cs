/*This is the BasketScore Script which increases the score everytime there is a baket using a circle2D collider trigger in the basket of Hierarchy*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketScoreScript : MonoBehaviour {

    [HideInInspector]
    public int score = 0;                       //The score variable being  displayed in the bottom


    private void OnTriggerEnter2D(Collider2D collision)         //This is score increase triggering componenet 
    {
        if (collision.name == "Ball")
        {
            score += 1;
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
