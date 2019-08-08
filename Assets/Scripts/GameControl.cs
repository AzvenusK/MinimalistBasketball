using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
   
    [SerializeField]
    Game gamePrefab;

    public Game CurrentGame;
    public Resetter Reset;

	// Use this for initialization
	void Start ()
    {
        StartGame(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CurrentGame != null)
        {
            CheckForCurrentGameOver();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Reset.CheckForReset();
    }

    void CheckForCurrentGameOver()
    {
        if (CurrentGame.currLevelObj == null && CurrentGame.gameOver)
        {
            Destroy(CurrentGame.gameObject);
            Debug.Log("Game Over!");
        }
    }
    public void StartGame(int level)
    {
        CurrentGame = Instantiate(gamePrefab) as Game;
        CurrentGame.gameObject.name = "Game";

        CurrentGame.InitLevel(level, 3);
    }
}
