using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singelton
    [SerializeField] AudioSource sfx_source;
    [SerializeField] AudioSource sfx_source2;
    [Tooltip("This AudioSource must have a Loop")]
    [SerializeField] AudioSource inGameBackground;
    [SerializeField] AudioSource menuBackground;
    [SerializeField] AudioMixerGroup bob;

    public AudioSource GetAudio() { return sfx_source; }
    bool muteSfx;
    bool muteSound;

    #region Menu
    [Header("Menu")]
    [Tooltip("You have to drag this sound to another GameObject with the AudioSource in Loop")]
    [SerializeField] AudioClip sfx_menu_gameStart;
    [SerializeField] AudioClip sfx_menu_mouseClick;
    [SerializeField] AudioClip sfx_game_mouseHover;

    [Header("Gameplay")]
    [SerializeField] List<AudioClip> sfx_game_intro_voice;
    [Space]
    [SerializeField] AudioClip sfx_bubble_place;
    [SerializeField] List<AudioClip> sfx_fish_place_bubble_voice;
    [Space]
    [SerializeField] AudioClip sfx_bubble_collect;
    [Space]
    [SerializeField] List<AudioClip> sfx_fish_get_big_bubble_voice;
    [Space]
    [SerializeField] AudioClip sfx_bubble_spawn;
    [Space]
    [SerializeField] AudioClip sfx_bubble_explode;
    [Space]
    [SerializeField] List<AudioClip> sfx_fish_get_special_bubble_voice;
    [Space]
    [SerializeField] List<AudioClip> sfx_fish_hit_voice;
    [Space]
    [SerializeField] List<AudioClip> sfx_fish_jump;
    [SerializeField] AudioClip sfx_fish_hit;
    [SerializeField] AudioClip sfx_coral_hit;
    [SerializeField] AudioClip sfx_cat_hiss;
    [SerializeField] AudioClip sfx_cat_paw;

    [Header("Gameplay - End of match")]
    [SerializeField] AudioClip sfx_game_win;
    [SerializeField] AudioClip sfx_game_score_1;
    [SerializeField] AudioClip sfx_game_score_2;
    [SerializeField] AudioClip sfx_game_score_3;
    [SerializeField] AudioClip sfx_game_score_4;
    [SerializeField] AudioClip sfx_game_score_5;
    [SerializeField] AudioClip sfx_game_score_6;
    [SerializeField] AudioClip sfx_game_score_7;

    // Menu
    public void Sfx_Menu_PlayGame()
    {
        sfx_source.PlayOneShot(sfx_menu_gameStart);
    }

    public void SFX_WE_Testa()
    {
        sfx_source2.PlayOneShot(GetRandom(sfx_game_intro_voice));
    }

    public void Sfx_Menu_Interaction() => sfx_source.PlayOneShot(sfx_menu_mouseClick);
    public void Sfx_Menu_MouseOver() => sfx_source.PlayOneShot(sfx_game_mouseHover);

    // Gameplay
    public void Sfx_Game_Place_Bubble()
    {
        sfx_source.PlayOneShot(sfx_bubble_place);
        sfx_source2.PlayOneShot(GetRandom(sfx_fish_place_bubble_voice));
    }
    public void Sfx_Game_Get_Bubble()
    {
        sfx_source.PlayOneShot(sfx_bubble_collect);
    }
    public void Sfx_Game_Get_Big_Bubble()
    {
        sfx_source.PlayOneShot(sfx_bubble_collect);
        sfx_source2.PlayOneShot(GetRandom(sfx_fish_get_big_bubble_voice));
    }

    public void Sfx_Game_Bubble_Spawn()
    {
        sfx_source.PlayOneShot(sfx_bubble_spawn);
    }
    public void Sfx_Game_Bubble_Explode()
    {
        sfx_source.PlayOneShot(sfx_bubble_explode);
    }
    public void Sfx_Game_Get_Special_Bubble()
    {
        sfx_source.PlayOneShot(sfx_bubble_explode);
        sfx_source2.PlayOneShot(GetRandom(sfx_fish_get_special_bubble_voice));
    }

    public void Sfx_Game_Fish_Jump()
    {
        sfx_source2.PlayOneShot(GetRandom(sfx_fish_jump));
    }
    public void Sfx_Game_Fish_Hit()
    {
        sfx_source.PlayOneShot(sfx_coral_hit);
        sfx_source2.PlayOneShot(GetRandom(sfx_fish_hit_voice));
    }
    public void Sfx_Game_Fish_Cat_Hit()
    {
        sfx_source2.PlayOneShot(GetRandom(sfx_fish_hit_voice));
    }
    public void Sfx_Game_Cat_Hiss()
    {
        sfx_source.PlayOneShot(sfx_cat_hiss);
    }
    public void Sfx_Game_Cat_Paw()
    {
        sfx_source.PlayOneShot(sfx_cat_paw);
    }

    // Gameplay - End
    public void Sfx_Game_Win() => sfx_source.PlayOneShot(sfx_game_win);
    public void Sfx_Game_Score_1() => sfx_source.PlayOneShot(sfx_game_score_1);
    public void Sfx_Game_Score_2() => sfx_source.PlayOneShot(sfx_game_score_2);
    public void Sfx_Game_Score_3() => sfx_source.PlayOneShot(sfx_game_score_3);
    public void Sfx_Game_Score_4() => sfx_source.PlayOneShot(sfx_game_score_4);
    public void Sfx_Game_Score_5() => sfx_source.PlayOneShot(sfx_game_score_5);
    public void Sfx_Game_Score_6() => sfx_source.PlayOneShot(sfx_game_score_6);
    public void Sfx_Game_Score_7() => sfx_source.PlayOneShot(sfx_game_score_7);



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

    public void SFX_On_Off()
    {
        if (!muteSfx)
        {
            sfx_source2.volume = 0;
            sfx_source.volume = 0;
            muteSfx = true;
        }
        else
        {
            sfx_source2.volume = 1;
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
            menuBackground.volume = 0.75f;
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



    private AudioClip GetRandom(List<AudioClip> list)
    {
        var index = UnityEngine.Random.Range(0, list.Count);
        return list[index];
    }
}
