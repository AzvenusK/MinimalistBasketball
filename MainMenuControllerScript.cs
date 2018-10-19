/*This script controls the UI elements of the MainMenu. This script is fairly similar to GameManager script so refer it.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    public Camera camera1;        //Main Camera to be dragged to this variable                    //The build index of all scenes are :  
    public RaycastHit hit;                                                                        //Main_Menu = 0
    public Ray ray;                                                                               //Gameplay_1 = 1
    [HideInInspector]                                 
    public int loadScene = 0;                        
                                                      
                                                      
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))                                    //Refer 
        {
            ray = camera1.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "PlayButton")
                {
                    loadScene = 1;
                    LoadScene();
                }

                /*else if (hit.collider.name == "LeaderboardButton")
                {
                    loadScene = 2;
                    LoadScene();
                }*/

                /*else if (hit.collider.name == "ShopButton")
                {
                    loadScene = 3;
                    LoadScene();
                }*/

            }
        }

    }

    public void LoadScene()                                         //Refer
    {
        SceneManager.LoadScene(loadScene);
        AdManager.Instance.ShowBanner();
    }

}
