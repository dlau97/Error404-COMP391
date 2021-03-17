using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveType {horizontal, vertical};
    public MoveType type = MoveType.horizontal;
    public enum Direction {Negative, Positive};
    public Direction startDirection = Direction.Positive;
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 10.0f;
    public float moveDistance = 2f;

    public float offsetTime = 0f;

    private int direction = 1; //1 = right ; -1 = left


  
    void Start() 
    {
        pos1 = this.transform.position;
        pos2 = this.transform.position;

        if(startDirection == Direction.Positive){
            direction = 1;
        }
        else{
            direction = -1;
        }

        if(type ==MoveType.horizontal){
            pos1.x -= moveDistance*direction;
            pos2.x += moveDistance*direction;
        }
        else if(type == MoveType.vertical){
            pos1.y -= moveDistance*direction;
            pos2.y += moveDistance*direction;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed + offsetTime, 1.0f));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            GameObject player = other.gameObject;
            player.transform.SetParent(this.transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            GameObject player = other.gameObject;
            player.transform.SetParent(null);
            player.transform.localScale = new Vector3(1,1,1);
        }
    }
}
