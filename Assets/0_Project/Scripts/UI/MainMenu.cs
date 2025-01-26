using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject iconCover;
    bool muteSound = false;

    void Start()
    {
        audioManager = AudioManager.Instance;

        //icon logic
        if(iconCover != null)
        {
            AudioSource a = audioManager.GetAudio();
            if (a.volume == 0)
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
    }
    public void OnMouseOverSound()
    {
        if(audioManager != null)
        audioManager.Sfx_Menu_MouseOver();
    }

    public void Interaction()
    {
        if (audioManager != null)
            audioManager.Sfx_Menu_Interaction();
    }
    public void Play(bool multi)
    {
        if (multi)
            SessionInfo.IsMultiplayer = true; // <-- multy
        else
            SessionInfo.IsMultiplayer = false;
        
        SceneManager.LoadScene(1);

        if (audioManager != null)
        {
            audioManager.Sfx_Menu_PlayGame();
            audioManager.Track_Play_Ost();
        }
    }
    public void Quit()
    {
        // add save
        Application.Quit();
    }
    /*
    public void PauseEnter()
    {
        // enter pause
        Time.timeScale = 0;
        audioManager.TogglePauseAll();
        Interaction();
    }*/
    public void PauseEsc()
    {
        // esc pause
        Time.timeScale = 1;
        Interaction();
        // audioManager.TogglePauseAll();

    }
    public void SoundOnOff()
    {
        if (audioManager != null)
            audioManager.SFX_On_Off();
        if (audioManager != null)
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

    public void EnterMainMenu()
    {
        SceneManager.LoadScene(0);
        Interaction();
        audioManager.Track_Play_Menu();
    }
}
