using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveType {horizontal, vertical};
    public MoveType type = MoveType.horizontal;
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;
    public float moveDistance = 2f;


  
    void Start() 
    {
        pos1 = this.transform.position;
        pos2 = this.transform.position;

        if(type ==MoveType.horizontal){
            pos1.x -= moveDistance;
            pos2.x += moveDistance;
        }
        else if(type == MoveType.vertical){
            pos1.y -= moveDistance;
            pos2.y += moveDistance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
