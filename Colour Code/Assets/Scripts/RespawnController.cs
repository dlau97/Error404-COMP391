using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{

    private Vector3 lastCheckpointPos;


    private string lastColour;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        lastCheckpointPos = player.GetComponent<Transform>().position;
        lastColour = player.GetComponent<PlayerController>().getColour();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCheckpoint(Vector3 pos){
        lastCheckpointPos = pos;
        lastColour = player.GetComponent<PlayerController>().getColour();
    }

    public Vector3 getCheckpointPos(){
        return lastCheckpointPos;
    }

    public string getLastColour(){
        return lastColour;
    }
}
