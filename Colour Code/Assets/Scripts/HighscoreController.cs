using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
    private float currTime;
    private float bestTime;
    private float startTime, endTime;
    private string bestTimeKey = "BestTime";

    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
        void Start()
    {
        bestTime = PlayerPrefs.GetFloat(bestTimeKey, 9999.99f);
        //bestTime = 2.6537463842f;
        currTime = 0.0f;
        startTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene == "Main Menu"){
            GameObject.Find("txt_BestTime").GetComponent<Text>().text = (Mathf.Round(bestTime * 100.0f) / 100.0f).ToString() + " seconds" ;
        }
        else if(activeScene == "Game Scene"){

            GameObject.Find("txt_Timer").GetComponent<Text>().text = "Time: " + (Mathf.Round(GetCurrentTime() * 100.0f) / 100.0f).ToString();
        }
    }

    public void StartTimer(){
        startTime = Time.time;
    }

    public float GetCurrentTime(){
        currTime = Time.time - startTime;
        return currTime;
    }

    public void EndTimer(){
        endTime = Time.time;
        if(endTime - startTime < bestTime){
            bestTime = endTime - startTime;
            bestTime =  (Mathf.Round(bestTime * 100.0f) / 100.0f);
            PlayerPrefs.SetFloat(bestTimeKey, bestTime);
            PlayerPrefs.Save();
        }
    }
}
