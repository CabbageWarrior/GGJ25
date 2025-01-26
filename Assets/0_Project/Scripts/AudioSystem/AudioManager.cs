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

    [Header("Gameplay - End of match")]
    [SerializeField] AudioClip sfx_game_win;
    [SerializeField] AudioClip sfx_game_score_1;
    [SerializeField] AudioClip sfx_game_score_2;
    [SerializeField] AudioClip sfx_game_score_3;
    [SerializeField] AudioClip sfx_game_score_4;
    [SerializeField] AudioClip sfx_game_score_5;
    [SerializeField] AudioClip sfx_game_score_6;
    [SerializeField] AudioClip sfx_game_score_7;

    public void Sfx_Menu_Interaction() => sfx_source.PlayOneShot(sfx_menu_mouseClick);
    public void Sfx_Menu_PlayGame() => sfx_source.PlayOneShot(sfx_menu_gameStart);
    public void Sfx_Menu_MouseOver() => sfx_source.PlayOneShot(sfx_game_mouseHover);

    public void Sfx_Game_Win() => sfx_source.PlayOneShot(sfx_game_win);
    public void Sfx_Game_Score_1() => sfx_source.PlayOneShot(sfx_game_score_1);
    public void Sfx_Game_Score_2() => sfx_source.PlayOneShot(sfx_game_score_2);
    public void Sfx_Game_Score_3() => sfx_source.PlayOneShot(sfx_game_score_3);
    public void Sfx_Game_Score_4() => sfx_source.PlayOneShot(sfx_game_score_4);
    public void Sfx_Game_Score_5() => sfx_source.PlayOneShot(sfx_game_score_5);
    public void Sfx_Game_Score_6() => sfx_source.PlayOneShot(sfx_game_score_6);
    public void Sfx_Game_Score_7() => sfx_source.PlayOneShot(sfx_game_score_7);

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
