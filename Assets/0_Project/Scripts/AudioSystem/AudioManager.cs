using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singelton
    [SerializeField] AudioSource sfx_source;
    [Tooltip("This AudioSource must have a Loop")]
    [SerializeField] AudioSource inGameBackground;
    [SerializeField] AudioSource menuBackground;
    [SerializeField] AudioMixerGroup bob;

    public AudioSource GetAudio() {  return sfx_source; }
    bool muteSfx;
    bool muteSound;

    #region Menu
    [Header("Menu")]
    [Tooltip("You have to drag this sound to another GameObject with the AudioSource in Loop")]
    [SerializeField] AudioClip sfx_menu_gameStart;
    [SerializeField] AudioClip sfx_menu_mouseClick;
    [SerializeField] AudioClip sfx_game_mouseHover;

    public void Track_Play_Ost()
    {
        if (menuBackground.isPlaying)
            menuBackground.Stop();
        inGameBackground.Play();
    }
    public void Track_Play_Menu()
    {
        if (inGameBackground.isPlaying)
            inGameBackground.Stop();
        menuBackground.Play();
    }


    public void Sfx_Menu_Interaction() => sfx_source.PlayOneShot(sfx_menu_mouseClick);
    public void Sfx_Menu_PlayGame() => sfx_source.PlayOneShot(sfx_menu_gameStart);
    public void Sfx_Menu_MouseOver() => sfx_source.PlayOneShot(sfx_game_mouseHover);

    public void SFX_On_Off()
    {
        if (!muteSfx)
        {
            sfx_source.volume = 0;
            muteSfx = true;
        }
        else
        {
            sfx_source.volume = 1;
            muteSfx = false;
        }
    }
    public void Sound_On_Off()
    {
        if (!muteSound)
        {
            inGameBackground.volume = 0;
            menuBackground.volume = 0;
            muteSound = true;
        }
        else
        {
            inGameBackground.volume = 1;
            menuBackground.volume = 1;
            muteSound = false;
        }
    }
    #endregion
    /*
    #region Game
    [Header("Game")]
    [Tooltip("You have to drag this sound to the AudioSource in Loop")]
    [SerializeField] AudioClip sfx_game_end;

    [SerializeField] AudioClip sfx_game_bubble;

    public void Sfx_Game_Ost()
    {
        if (menuBackground.isPlaying)
            menuBackground.Stop();
        inGameBackground.Play();
    }
    public void Sfx_Game_Menu()
    {
        if (inGameBackground.isPlaying)
            inGameBackground.Stop();
        menuBackground.Play();
    }

    // public void Sfx_Game_End() => sfx_source.PlayOneShot(sfx_game_end);
    /*
    public void Sfx_Play_Bulle()
    {
        if(sfx_game_bubble != null)
        {
            sfx_source.clip = sfx_game_bubble;
            sfx_source.Play();
        }
    }*/


    /*public void Sfx_Stop_Bubble()
    {
        if (sfx_source.isPlaying)
            sfx_source.Stop();
    }*/
    // #endregion

    public void TogglePauseAll()
    {
        if (inGameBackground.isPlaying)
        {
            sfx_source.Pause();
            inGameBackground.Pause();
        }
        else
        {
            sfx_source.UnPause();
            inGameBackground.UnPause();
        }
    }
    void Awake()
    {
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this); // check if it usefull
        }
        #endregion
    }
}
