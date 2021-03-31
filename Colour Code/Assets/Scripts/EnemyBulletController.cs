using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject EnemyBullet;
     public float WaitForSeconds;
    

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(EBullet());
    }

    IEnumerator EBullet()
    {   
        
        Instantiate(EnemyBullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(WaitForSeconds);

        StartCoroutine(EBullet());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
