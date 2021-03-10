using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed = 5f;
	public float jumpHeight = 5;
	private bool canJump = true;
	private Rigidbody2D playerRB;
	private Transform playerT;

	public Transform groundCheck;
	public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
		playerRB = this.gameObject.GetComponent<Rigidbody2D> ();
		playerT = this.gameObject.GetComponent<Transform> ();
	}

    // Update is called once per frame
    void Update()
    {
		checkMovement ();
		checkJump();
		checkRotation();
    }

	void checkMovement()
	{
		float horizontalMovement = Input.GetAxis ("Horizontal") * speed;
		//float verticalMovement = Input.GetAxis ("Vertical") * speed;

		Vector3 movement = new Vector3 (horizontalMovement, 0f, 0f) * Time.deltaTime;

		this.transform.Translate(movement, Space.World);
	}

	void checkRotation(){
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}

	void checkJump()
	{
		canJump = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

		if(Input.GetKeyDown(KeyCode.Space) && canJump == true){
			playerRB.AddForce(new Vector2(0,jumpHeight), ForceMode2D.Impulse);
		}
	}
}
