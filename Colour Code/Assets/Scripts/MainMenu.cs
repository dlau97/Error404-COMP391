using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource source;
    public AudioClip menuClick;

    public GameObject creditCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        source.PlayOneShot(menuClick, 1f);
        SceneManager.LoadScene("Game Scene");
    }
    public void OnClickQuit()
    {
        source.PlayOneShot(menuClick, 1f);
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
    public void OnClickCredit()
    { 
        source.PlayOneShot(menuClick, 1f);
        creditCanvas.SetActive(true);
    }
    public void OnClickBack(){
        source.PlayOneShot(menuClick, 1f);
        creditCanvas.SetActive(false);
    }









}

