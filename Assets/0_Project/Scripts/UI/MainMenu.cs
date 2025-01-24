using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;

    // if (partita da continare) all'Awake() controllare le player pref e mod il play_text con Continue
    void Start()
    {
        audioManager = AudioManager.Instance;

        // play track
        if (audioManager != null)
            audioManager.Sfx_Game_Ost();
    }
    public void Play()
    {
        // scenemanager
        SceneManager.LoadScene(1);

    }
    public void Quit()
    {
        // add save
        Application.Quit();
    }
}
