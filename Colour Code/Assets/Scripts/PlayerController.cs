using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public enum Colour {blue, red, yellow, neutral};
	public float speed = 5f;
	public float jumpHeight = 5;
	public Transform groundCheck;
	public LayerMask groundLayer;
	public Colour playerColour = Colour.neutral;
	private bool canJump = true;
	private Rigidbody2D playerRB;
	private Transform playerT;
	private SpriteRenderer playerSR;

    // Start is called before the first frame update
    void Start()
    {
		playerRB = this.gameObject.GetComponent<Rigidbody2D> ();
		playerT = this.gameObject.GetComponent<Transform> ();
		playerSR = this.gameObject.GetComponent<SpriteRenderer> ();
 		playerColour = Colour.neutral;
		this.gameObject.layer = 3; //white
	}

    // Update is called once per frame
    void Update()
    {
		checkMovement ();
		checkJump();
		checkRotation();
    }

	public string getColour(){
		switch(playerColour){
			case Colour.blue:
				return "Blue";
			case Colour.red:
				return "Red";
			case Colour.yellow:
				return "Yellow";
			case Colour.neutral:	
			default:
				return "Neutral";
		}
	}

	void checkMovement()
	{
		float horizontalMovement = Input.GetAxis ("Horizontal") * speed;
		Vector3 movement = new Vector3 (horizontalMovement, 0f, 0f) * Time.deltaTime;
		this.transform.Translate(movement, Space.World);
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
	}

	void checkRotation(){
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}


	public void EnableJump(){
		canJump = true;
	}

	public void DisableJump(){
		canJump = false;
	}

	void checkJump()
	{
		//canJump = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

		if(Input.GetKeyDown(KeyCode.Space) && canJump == true){
			playerRB.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
			canJump = false;
		}
	}

	public void ChangeColour(string colour){
		switch(colour){
			case "Blue":
				playerSR.color = new Color(0, 0, 1f, 1f); //Blue
				playerColour = Colour.blue;
				this.gameObject.layer = 7; //blue
				GameObject.Find("GroundCheck").layer = 7;
				break;
			case "Red":
				playerSR.color = new Color(1f, 0, 0f, 1f); //Red
				playerColour = Colour.red;
				this.gameObject.layer = 8; //red
				GameObject.Find("GroundCheck").layer = 8;
				break;
			case "Yellow":
				playerSR.color = new Color(1f, 1f, 0f, 1f); //Blue
				playerColour = Colour.yellow;
				this.gameObject.layer = 9; //yellow
				GameObject.Find("GroundCheck").layer = 9;
				break;
			default:
				Debug.Log("Incorrect colour option - This should never appear.");
				playerColour = Colour.neutral;
				this.gameObject.layer = 6; 
				GameObject.Find("GroundCheck").layer = 6;
				break;
		}
	}
}
