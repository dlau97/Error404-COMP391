using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
   public GameObject Player;
   public GameObject Ground;
   public GameObject PlayerBullet;
   public float movePower = 1f;
   Vector3 movement;
   int movementFlag = 0;
   public float WaitForSeconds = 5f;
   

   public void Dead()
   {
       Destroy(gameObject);
   }
   
   void FixedUpdate()
   {
      Move();
   }
   
   void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);

        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
        
    }
   void Awake()
   {
      Player = GameObject.FindGameObjectWithTag ("Player");
      Ground = GameObject.FindGameObjectWithTag ("Ground");
      PlayerBullet = GameObject.FindGameObjectWithTag ("PlayerBullet");


   }
   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.gameObject == Player)
       {
        Destroy(other.gameObject);
       } 
       if (other.CompareTag ("PlayerBullet"))
       {
        Dead();
       }
       if (other.CompareTag("Ground"))
       {
           movementFlag = 0;
       }
   }
  void OnTriggerStay2D(Collider2D other)
   {
       if (other.CompareTag("Ground"))
       {
           movementFlag = 0;
       }
   }
  void OnTriggerExit2D(Collider2D other)
   {
       if(other.CompareTag("Ground"))
       {
           StartCoroutine("ChangeMovement");
       }
   }    
   
  
 
   
   // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeMovement");
    }
    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range (0, 3);
        yield return new WaitForSeconds(5f);
        
        StartCoroutine("ChangeMovement");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
