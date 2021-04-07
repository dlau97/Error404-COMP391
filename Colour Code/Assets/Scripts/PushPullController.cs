using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullController : MonoBehaviour
{
    private bool holding = false;
    private bool canHold = true;
    private bool holdingDelayEnabled = true;
    private float startTime;

    private float delayHoldingTime = 0.5f;

    private Vector3 initialPos;


    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        holdingDelayEnabled = false;
        startTime = Time.time;
        canHold = false;
        initialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Prevent block from rotating

        if(Time.time >= startTime + delayHoldingTime){
            holdingDelayEnabled = false;
        }

        if(holdingDelayEnabled == false && canHold == true){
            if(Input.GetKeyDown(KeyCode.F)){
                if(holding == false){
                    holding = true;
                    GameObject player = GameObject.Find("Player");
                    this.transform.SetParent(player.transform, true);
                    player.SendMessage("EnableHolding");
                    Debug.Log("Holding");
                    holdingDelayEnabled = true;
                    startTime = Time.time;
                    Debug.Log("Holding delay enabled = " + holdingDelayEnabled);
                    //this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                }
                else if(holding == true){
                    holding = false;
                    GameObject player = GameObject.Find("Player");
                    this.transform.SetParent(null);
                    //this.transform.localScale = new Vector3(1,1,1);
                    player.SendMessage("DisableHolding");
                    Debug.Log("No Longer holding");
                    holdingDelayEnabled = true;
                    startTime = Time.time;
                    //this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                    Debug.Log("Holding delay enabled = " + holdingDelayEnabled);
                }
            }
        }

    }

    public void ResetObj(){
        this.transform.position = initialPos;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            canHold = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            canHold = false;
            if(holding == true){
                holding = false;
                GameObject player = GameObject.Find("Player");
                this.transform.SetParent(null);
                //this.transform.localScale = new Vector3(1,1,1);
                player.SendMessage("DisableHolding");
                Debug.Log("No Longer holding");
                holdingDelayEnabled = true;
                startTime = Time.time;
                //this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                Debug.Log("Holding delay enabled = " + holdingDelayEnabled);
            }
        }
    }

}
