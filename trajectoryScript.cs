using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class trajectoryScript : MonoBehaviour {

	public Sprite dotSprite;					//All of the dots will become the sprite assigned to this if this has a sprite assigned to it and changeSpriteAfterStart is true
	public bool changeSpriteAfterStart;			//When enabled, you will be able to change the above in the update loop. (it's less efficient)
	public float initialDotSize;				//The intial size of the trajectoryDots gameobject
	public int numberOfDots;					//The number of points representing the trajectory
	public float dotSeparation;					//The space between the points representing the trajectory
	public float dotShift;						//How far the first dot is from the "ball"
	public float idleTime;						//How long the player has to be inactive for the Help Gesture to begin animating
	private GameObject trajectoryDots;			//The parent of all the points representing the trajectory
	private GameObject ball;					//The projectile the player will be shooting
    public GameObject ballHolder;               //The collider which holds the ball in its place before being released
	private Rigidbody2D ballRB;					//The Rigidbody2D attached to the projectile the player will be shooting
	private Vector3 ballPos;					//Position of the ball
	private Vector3 fingerPos;					//Position of the pressed down finger/cursor on the screen 
	private Vector3 ballFingerDiff;				//The distance between where the finger/cursor is and where the "ball" is when screen is being pressed
	private Vector2 shotForce;					//How much velocity will be applied to the ball
	private float x1, y1;						//X and Y position which will be applied to each point of the trajectory
	private GameObject helpGesture;				//The Help Gesture which will become active after a period of inactivity
	private float idleTimer = 7f;				//How long the initial inactivity period will need to be before the Help Gesture shows up
	private bool ballIsClicked = false;			//If the cursor is hovering over the "Ball Click Area"
	private bool ballIsClicked2 = false;		//If the finger/cursor is pressing down in the "Ball Click Area" to activate the shot
	private GameObject ballClick;				//The area which the player needs to click in to activate a shot
	public float shootingPowerX;				//The amount of power which can be applied in the X direction
	public float shootingPowerY;				//The amount of power which can be applied in the Y direction
	public bool usingHelpGesture;				//If you want to use the Help Gesture
	public bool explodeEnabled;					//If you want to do something when the projectile reaches the last point of the trajectory
	public bool grabWhileMoving;				//Off means the player won't be able to shoot until the "ball" is still. On means they can stop the "ball" by clicking on it and shoot
	public GameObject[] dots;					//The array of points that make up the trajectory
	public bool mask;                           //Masking boolean variable of the Mask script
	private BoxCollider2D[] dotColliders;       //Arrray of colliders for dots
    public BasketScoreScript score;             
    public PoleBasketRandom pole;
    public GameManager game;
    private int i;                              //Variable for for-loops
    private Sprite[] spriteArray;               //SpriteArray from spritesheet
    [HideInInspector]
    public int spriteIndex;                     //Sprite index
    [HideInInspector]
    public int scoreCompare;                    
    public GameObject dots0;            //dots for activation and deactivation
    public GameObject dots1;
    public GameObject dots2;
    public GameObject dots3;
    public GameObject dots4;
    public GameObject dots5;
    public GameObject dots6;
    public GameObject dots7;
    public GameObject dots8;
    public GameObject dots9;
    public GameObject dots10;
    public GameObject dots11;
    public GameObject dots12;
    public GameObject dots13;
    public GameObject dots14;
    public GameObject dots15;
    public GameObject dots16;
    public GameObject dots17;
    public GameObject dots18;
    public GameObject dots19;
    public Color color1;                //Colors for main camera background
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color color8;
    public Color color9;
    public Color color10;
    public Color color11;
    public Color color12;
    public Color color13;
    public Color color14;
    public Color color15;
    public Color color16;
    void Start () {
        spriteArray = Resources.LoadAll<Sprite>("SpriteSheet");
        spriteIndex = 0;
        scoreCompare = -1;
		ball = gameObject;                                          //Script has to be applied to the "ball"
        GameObject.Find("Ball").GetComponent<Rigidbody2D>().gravityScale = 0;
        ballClick = GameObject.Find ("Ball Click Area");
        
		trajectoryDots = GameObject.Find ("Trajectory Dots");		
		if (usingHelpGesture == true) {								
			helpGesture = GameObject.Find ("Help Gesture");			
		}
		ballRB = GetComponent<Rigidbody2D> ();						

		trajectoryDots.transform.localScale = new Vector3 (initialDotSize, initialDotSize, trajectoryDots.transform.localScale.z); 

		for (int k = 0; k < 40; k++) {
			dots [k] = GameObject.Find ("Dot (" + k + ")");			
			if (dotSprite != null) {								
				dots [k].GetComponent<SpriteRenderer> ().sprite = dotSprite;	//All points will have that sprite applied
			}
		}
		
		trajectoryDots.SetActive (false);							//Trajectory initialization complete, the trajectory is hidden
	

		}
	

		

	void Update () {

        
        /*Condition of scores and decreasing trajectory dots*/
        if (score.score >= 0 && score.score <= 3)
        {
            numberOfDots = 20;
            
            
            Camera.main.backgroundColor = color1;
           
        }

        else if (score.score >= 4 && score.score <= 7)
        {
            numberOfDots = 17;
            
            
            dots19.SetActive(false);
            dots18.SetActive(false);
            dots17.SetActive(false);
            Camera.main.backgroundColor = color2;
        }

        else if (score.score >= 8 && score.score <= 11)
        {
            numberOfDots = 15;
            
            
            dots16.SetActive(false);
            dots15.SetActive(false);
            Camera.main.backgroundColor = color3;
        }

        else if (score.score >= 12 && score.score <= 15)
        {
            numberOfDots = 13;
            
            
            dots14.SetActive(false);
            dots13.SetActive(false);
            Camera.main.backgroundColor = color4;
        }

        else if (score.score >= 16 && score.score <= 20)
        {
            numberOfDots = 11;
            
            
            dots12.SetActive(false);
            dots11.SetActive(false);
            Camera.main.backgroundColor = color5;
        }

        else if (score.score >= 21 && score.score <= 25)
        {
            numberOfDots = 10;
            
            
            dots10.SetActive(false);
            Camera.main.backgroundColor = color6;
        }

        else if (score.score >= 26 && score.score <= 31)
        {
            numberOfDots = 9;
            
            
            dots9.SetActive(false);
            Camera.main.backgroundColor = color7;
        }

        else if (score.score >= 32 && score.score <= 40)
        {
            numberOfDots = 8;
            
            
            dots8.SetActive(false);
            Camera.main.backgroundColor = color8;
        }

        else if (score.score >= 41 && score.score <= 50)
        {
            numberOfDots = 7;
            
            
            dots7.SetActive(false);
            Camera.main.backgroundColor = color9;
        }

        else if (score.score >= 51 && score.score <= 60)
        {
            numberOfDots = 6;
           
            
            dots6.SetActive(false);
            Camera.main.backgroundColor = color10;
        }

        else if (score.score >= 61 && score.score <= 74)
        {
            numberOfDots = 5;
            
            
            dots5.SetActive(false);
            Camera.main.backgroundColor = color11;
        }

        else if (score.score >= 75 && score.score <= 90)
        {
            numberOfDots = 4;
            
            
            dots4.SetActive(false);
            Camera.main.backgroundColor = color12;
        }

        else if (score.score >= 91 && score.score <= 110)
        {
            numberOfDots = 3;
            
            
            dots3.SetActive(false);
            Camera.main.backgroundColor = color13;
        }

        else if (score.score >= 111 && score.score <= 134)
        {
            numberOfDots = 2;
            
            
            dots2.SetActive(false);
            Camera.main.backgroundColor = color14;
        }

        else if (score.score >= 135 && score.score <= 164)
        {
            numberOfDots = 1;
            
           
            dots1.SetActive(false);
            Camera.main.backgroundColor = color15;
        }

        else if (score.score >= 165 && score.score <= 200)
        {
            numberOfDots = 1;
            
            dots1.SetActive(false);
            Camera.main.backgroundColor = color15;
        }

        else if (score.score > 200)
        {
            numberOfDots = 0;
            
            
            dots0.SetActive(false);
            Camera.main.backgroundColor = color16;
        }

        if (numberOfDots > 40) {
			numberOfDots = 40;
		}

		if (usingHelpGesture == true) {								
			helpGesture.transform.position = new Vector3 (ballPos.x, ballPos.y, ballPos.z);	//It will have the same position as the "ball"
		}

		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);	//Used to determine if the finger/cursor is on the Ball Click Area

		if (hit.collider != null && ballIsClicked2 == false)
        {					
			if (hit.collider.gameObject.name == ballClick.gameObject.name)
            {	
				ballIsClicked = true;											
			} else {															
				ballIsClicked = false;											
			}
		}
        else
        {																
			ballIsClicked = false;												
		}

		if (ballIsClicked2 == true)
        {											
			ballIsClicked = true;												
		}


		if ((ballRB.velocity.x * ballRB.velocity.x) + (ballRB.velocity.y * ballRB.velocity.y) <= 0.0085f)
        { 
			ballRB.velocity = new Vector2 (0f, 0f);								
			idleTimer -= Time.deltaTime;
            
            GameObject.Find("Ball").transform.position = new Vector3(-0.66f, -1.7f, 0.5f);
            GameObject.Find("Ball").GetComponent<Rigidbody2D>().gravityScale = 0;
            GameObject.Find("PoleSystem").GetComponent<EdgeCollider2D>().enabled = true;
            GameObject.Find("Basket").GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[spriteIndex];
            /*SpriteIndex @
             * 0 = Basketball
             * 1 = Football/Soccer ball
             * 2 = BowlingBall
             * 3 = BeachBall
             * 4 = Cricket Leather Ball
             * 5 = Tennis Ball */
             // Sprite randomization from PoleBasketRandom Script
            if (spriteIndex == 0)
            {
                this.GetComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Ball Physics_0");
                this.GetComponent<Rigidbody2D>().mass = 10;
                this.GetComponent<Rigidbody2D>().drag = 0.45f;
            }
            else if (spriteIndex == 1)
            {
                this.GetComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Ball Physics_1");
                this.GetComponent<Rigidbody2D>().mass = 8;
                this.GetComponent<Rigidbody2D>().drag = 0.4f;
            }
            else if (spriteIndex == 2)
            {
                this.GetComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Ball Physics_2");
                this.GetComponent<Rigidbody2D>().mass = 400;
                this.GetComponent<Rigidbody2D>().drag = 1f;

            }
            else if (spriteIndex == 3)
            {
                this.GetComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Ball Physics_3");
                this.GetComponent<Rigidbody2D>().mass = 0.5f;
                this.GetComponent<Rigidbody2D>().drag = -0.2f;
            }
            else if (spriteIndex == 4)
            {
                this.GetComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Ball Physics_4");
                this.GetComponent<Rigidbody2D>().mass = 0.7f;
                this.GetComponent<Rigidbody2D>().drag = -0.1f;
            }
            else if (spriteIndex == 5)
            {
                this.GetComponent<CircleCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("Ball Physics_5");
                this.GetComponent<Rigidbody2D>().mass = 0.2f;
                this.GetComponent<Rigidbody2D>().drag = 0;
            }
            

        }
        else {																
			trajectoryDots.SetActive (false);
            
        }

		if (usingHelpGesture == true && idleTimer <= 0f) {						
			helpGesture.GetComponent<Animator> ().SetBool ("Inactive", true);	//Begin the Help animation
		}
	

		ballPos = ball.transform.position;										//ballPos is updated to the position of the "ball"

		if (changeSpriteAfterStart == true) {									
			for (int k = 0; k < numberOfDots; k++) {
				if (dotSprite != null) {										
					dots [k].GetComponent<SpriteRenderer> ().sprite = dotSprite;
				}
			}
		}


		if ((Input.GetKey (KeyCode.Mouse0) && ballIsClicked == true) && ((ballRB.velocity.x == 0f && ballRB.velocity.y == 0f) || (grabWhileMoving == true))) {											
			ballIsClicked2 = true;												

			if (usingHelpGesture == true) {										
				idleTimer = idleTime;											
				helpGesture.GetComponent<Animator> ().SetBool ("Inactive", false);	
			}

			fingerPos = Camera.main.ScreenToWorldPoint (Input.mousePosition); 	
			fingerPos.z = 0;													

			if (grabWhileMoving == true) {										
				ballRB.velocity = new Vector2 (0f, 0f);							
				ballRB.isKinematic = true;										//The "ball" isn't affected by other forces (it stays in the same spot)
		}

			ballFingerDiff = ballPos - fingerPos;								//The distance between the finger/cursor and the "ball" is found
			
			shotForce = new Vector2 (ballFingerDiff.x * shootingPowerX, ballFingerDiff.y * shootingPowerY);	//The velocity of the shot is found

			if ((Mathf.Sqrt ((ballFingerDiff.x * ballFingerDiff.x) + (ballFingerDiff.y * ballFingerDiff.y)) > (0.4f))) { 
				trajectoryDots.SetActive (true);								//Display the trajectory
			} else {
				trajectoryDots.SetActive (false);								
				if (ballRB.isKinematic == true) {
					ballRB.isKinematic = false;
				}
			}

			for (int k = 0; k < numberOfDots; k++) {							//Each point of the trajectory will be given its position
				x1 = ballPos.x + shotForce.x * Time.fixedDeltaTime * (dotSeparation * k + dotShift);	
			y1 = ballPos.y + shotForce.y * Time.fixedDeltaTime * (dotSeparation * k + dotShift) - (-Physics2D.gravity.y/2f * Time.fixedDeltaTime * Time.fixedDeltaTime * (dotSeparation * k + dotShift) * (dotSeparation * k + dotShift));	//Y position for each point is found
				dots [k].transform.position = new Vector3 (x1, y1, dots [k].transform.position.z);	
			}
		}


		if (Input.GetKeyUp (KeyCode.Mouse0)) {

            //Destroy(GameObject.Find("BallHolder"));
            GameObject.Find("Ball").GetComponent<Rigidbody2D>().gravityScale = 1;
            ballIsClicked2 = false;											

			if (trajectoryDots.activeInHierarchy) {							
				if(explodeEnabled == true){									
				StartCoroutine(explode ());									
			}
			trajectoryDots.SetActive (false);								
				ballRB.velocity = new Vector2 (shotForce.x, shotForce.y);	
				if (ballRB.isKinematic == true) {							
					ballRB.isKinematic = false;								
			}
		}
	}
}

	public IEnumerator explode(){											//The explode function
		yield return new WaitForSeconds (Time.fixedDeltaTime * (dotSeparation * (50f)));
        spriteIndex = Mathf.RoundToInt(Random.Range(-0.4f, 5.4f));
    }

	public void collided(GameObject dot){

		for (int k = 0; k < numberOfDots; k++) {
			if (dot.name == "Dot (" + k + ")") {
				
				for (int i = k + 1; i < numberOfDots; i++) {
					
					dots [i].gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				}

			}

		}
	}
	public void uncollided(GameObject dot){
		for (int k = 0; k < numberOfDots; k++) {
			if (dot.name == "Dot (" + k + ")") {

				for (int i = k-1; i > 0; i--) {
				
					if (dots [i].gameObject.GetComponent<SpriteRenderer> ().enabled == false) {
						Debug.Log ("nigggssss");
						return;
					}
				}

				if (dots [k].gameObject.GetComponent<SpriteRenderer> ().enabled == false) {
					for (int i = k; i > 0; i--) {
						
						dots [i].gameObject.GetComponent<SpriteRenderer> ().enabled = true;

					}

				}
			}

		}
	}
}

