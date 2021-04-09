using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private SpriteRenderer checkpointSR;

    private bool checkpointReached = false;

    // Start is called before the first frame update
    void Start()
    {
        checkpointSR = this.gameObject.GetComponent<SpriteRenderer>();
        checkpointReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && checkpointReached == false){
            checkpointReached = true;
            GameObject.Find("GameController").SendMessage("setCheckpoint", this.gameObject.transform.position);
            checkpointSR.color =  new Color(0.2684663f, 1f, 0.2301887f, 1f); //Green
            Debug.Log("Checkpoint: "+ this.gameObject.transform.position);
            GameObject.Find("GameController").SendMessage("PlayCheckpointSFX");
        }
    }
}

