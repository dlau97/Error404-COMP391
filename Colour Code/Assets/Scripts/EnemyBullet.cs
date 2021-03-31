using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float startTime;
    public float speed;
    Transform playerPos; 
    Vector2 dir;


    

    // Start is called before the first frame update
    void Start()
    {   
       
       playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       dir = playerPos.position - transform.position; 
       GetComponent<Rigidbody2D>().AddForce(dir * Time.deltaTime * speed);
        startTime = Time.time;

    }

    
    void Update()
    {
       if(Time.time >= startTime + 15f)
       {
           Destroy(this.gameObject);
       }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }
        if(other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        
    }

    
}
