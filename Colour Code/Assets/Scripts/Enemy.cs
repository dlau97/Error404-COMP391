using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
   public GameObject Player;
   public GameObject Ground;
   public GameObject PlayerBullet;
   public void Dead()
   {
       Destroy(gameObject);
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
   }
  

  
  
   
    // Start is called before the first frame update
    
    void Start()
    {
       
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }
}
