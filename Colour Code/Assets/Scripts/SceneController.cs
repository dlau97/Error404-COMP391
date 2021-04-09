using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Awake() {
        if (GameObject.Find("HighscoreController") != null)
        {
            GameObject.Find("HighscoreController").SendMessage("StartTimer");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("HighscoreController") != null)
        {
            GameObject.Find("HighscoreController").SendMessage("StartTimer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Main Menu");
        }
    }
}
