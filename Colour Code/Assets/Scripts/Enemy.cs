using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
   private GameObject Player;
   private SpriteRenderer enemySR;

   private BoxCollider2D enemyCollider;
 

   
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag ("Player");
       enemySR = this.gameObject.GetComponent<SpriteRenderer>();
       enemyCollider = this.gameObject.GetComponent<BoxCollider2D>();
       enemySR.enabled = true;
       enemyCollider.enabled = true;
    }
    
    public void EnableEnemy()
   {
       enemySR.enabled = true;
       enemyCollider.enabled = true;
   }
    public void DisableEnemy()
   {
       enemySR.enabled = false;
       enemyCollider.enabled = false;
   }


   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.gameObject.tag == "Player")
       {
           other.gameObject.SendMessage("RespawnPlayer");
       } 
       if (other.CompareTag ("PlayerBullet"))
       {
            DisableEnemy();
            GameObject.Find("GameController").SendMessage("PlayEnemyHitSFX");
       }
   }
  

  
   
    // Start is called before the first frame update
    


 
    // Update is called once per frame
    void Update()
    {
        
    }
}
