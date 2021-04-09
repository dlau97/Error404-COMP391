using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameSceneController : MonoBehaviour
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
            if (GameObject.Find("HighscoreController") != null)
            {
                GameObject.Find("HighscoreController").SendMessage("EndTimer");
            }
            SceneManager.LoadScene("Main Menu");
        }
        
    }
}
