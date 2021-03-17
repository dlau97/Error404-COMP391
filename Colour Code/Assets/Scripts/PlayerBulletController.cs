using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public enum Colour {blue, red, yellow};
    public Colour bulletColour;

    private Rigidbody2D bulletRB;

    private float startTime; 

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = this.gameObject.GetComponent<Rigidbody2D>();
        switch(bulletColour){
                case Colour.blue:
                    this.gameObject.layer = 7; //blue
                    break;
                case Colour.red:
                    this.gameObject.layer = 8; //red
                    break;
                case Colour.yellow:
                    this.gameObject.layer = 9; //yellow
                    break;
            }
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        if(Time.time >= startTime + 10f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
    }
}
