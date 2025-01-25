using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject iconCover;
    bool muteSound = false;
    // if (partita da continare) all'Awake() controllare le player pref e mod il play_text con Continue
    void Start()
    {
        audioManager = AudioManager.Instance;

    }
    public void OnMouseOverSound()
    {
        if(audioManager != null)
        audioManager.Sfx_Menu_MouseOver();
    }

    public void Interaction()
    {
        audioManager.Sfx_Menu_Interaction();
    }
    public void Play(bool multi)
    {
        // scenemanager
        
        if (multi)
            SessionInfo.IsMultiplayer = true; // <-- multy
        else
            SessionInfo.IsMultiplayer = false;
        
        SceneManager.LoadScene(1);
        audioManager.Sfx_Game_Ost();
        audioManager.Sfx_Menu_PlayGame();


    }
    public void Quit()
    {
        // add save
        Application.Quit();
    }

    public void PauseEnter()
    {
        // enter pause
        Time.timeScale = 0;
        audioManager.TogglePauseAll();
        Interaction();
    }
    public void PauseEsc()
    {
        // esc pause
        Time.timeScale = 1;
        Interaction();
        Debug.Log("Yoo");
        audioManager.TogglePauseAll();

    }
    public void SoundOnOff()
    {
        audioManager.SFX_On_Off();
        audioManager.Sound_On_Off();
        Interaction();

        if (!muteSound && iconCover != null)
        {
            iconCover.SetActive(true);
            muteSound = true;
        }
        else
        {
            iconCover.SetActive(false);
            muteSound = false;
        }

    }
    public void SfxOnOff()
    {
        audioManager.SFX_On_Off();
        Interaction();


    }

    public void EnterMainMenu()
    {
        SceneManager.LoadScene(0);
        audioManager.Sfx_Game_Ost();
        Interaction();

    }

}
