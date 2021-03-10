using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourTokenController : MonoBehaviour
{

    //public bool blueToken = false, redToken = false, yellowToken = false;
    public enum Colour {blue, red, yellow, neutral};
    public Colour tokenColour = Colour.blue;
    public float rotationSpeed;
    public Material blueMat, redMat, yellowMat;

    private Transform tokenT;
    // Start is called before the first frame update
    void Start()
    {
        tokenT = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tokenT.rotation = Quaternion.Euler((Time.time * rotationSpeed), 0f, (Time.time * rotationSpeed));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameObject player = other.gameObject;
            string playerColour = player.GetComponent<PlayerController>().getColour();

            switch(tokenColour){
                case Colour.blue:
                    player.SendMessage("ChangeColour", "Blue");
                    break;
                case Colour.red:
                    player.SendMessage("ChangeColour", "Red");
                    break;
                case Colour.yellow:
                    player.SendMessage("ChangeColour", "Yellow");
                    break;
            }
            changeTokenColour(playerColour);
            
        }
    }

    private void changeTokenColour(string colour){
        switch(colour){
			case "Blue":
                this.gameObject.GetComponent<MeshRenderer> ().material = blueMat;
                tokenColour = Colour.blue;
				break;
			case "Red":
                this.gameObject.GetComponent<MeshRenderer> ().material = redMat;
                tokenColour = Colour.red;
				break;
			case "Yellow":
                this.gameObject.GetComponent<MeshRenderer> ().material = yellowMat;
                tokenColour = Colour.yellow;
				break;
            case "Neutral":
                Destroy(this.gameObject);
                break; 
			default:
				Debug.Log("Incorrect colour option");
				break;
		}
    }
}
