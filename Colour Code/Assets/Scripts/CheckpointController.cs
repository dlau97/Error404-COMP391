using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameObject.Find("GameController").SendMessage("setCheckpoint", this.gameObject.transform.position);
            Debug.Log("Checkpoint: "+ this.gameObject.transform.position);
        }
    }
}
