using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckController : MonoBehaviour
{
    public GameObject playerObj;
    void Start()
    {
         
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "PushPull" || other.gameObject.tag == "Moving Platform"){
            playerObj.SendMessage("EnableJump");
           // Debug.Log("Can jump");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "PushPull" || other.gameObject.tag == "Moving Platform"){
            playerObj.SendMessage("EnableJump");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "PushPull" || other.gameObject.tag == "Moving Platform"){
            playerObj.SendMessage("DisableJump");
           // Debug.Log("Cant jump");
        }
    }
}
