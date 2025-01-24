using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singelton
    [SerializeField] AudioSource sfx_source;
    [Tooltip("This AudioSource must have a Loop")]
    [SerializeField] AudioSource background;
    [SerializeField] AudioSource dialogue_source;

    #region Menu
    [Header("Menu")]
    [Tooltip("You have to drag this sound to another GameObject with the AudioSource in Loop")]
    [SerializeField] AudioClip sfx_menu_soundmenu;
    [SerializeField] AudioClip sfx_menu_interaction;
    [SerializeField] AudioClip sfx_menu_newgame;
    [SerializeField] AudioClip sfx_game_uicard;
    [SerializeField] AudioClip sfx_menu_closinggame;
    [SerializeField] AudioClip sfx_menu_closemenu;

    public void Sfx_Menu_Interaction() => sfx_source.PlayOneShot(sfx_menu_interaction);
    public void Sfx_Menu_Newgame() => sfx_source.PlayOneShot(sfx_menu_newgame);
    public void Sfx_Game_Uicard() => sfx_source.PlayOneShot(sfx_game_uicard);
    public void Sfx_Menu_Closinggame() => sfx_source.PlayOneShot(sfx_menu_closinggame);
    public void Sfx_Menu_Closemenu() => sfx_source.PlayOneShot(sfx_menu_closemenu);
    #endregion
    #region Game
    [Header("Game")]
    [Tooltip("You have to drag this sound to the AudioSource in Loop")]
    [SerializeField] AudioClip sfx_game_ost;
    [SerializeField] AudioClip sfx_game_wand;
    [SerializeField] AudioClip sfx_game_glass;
    [SerializeField] AudioClip sfx_game_handkerchief;
    [SerializeField] AudioClip sfx_game_teleport;
    [SerializeField] AudioClip sfx_game_door;
    [SerializeField] AudioClip sfx_game_puzzlecomplete;
    [SerializeField] AudioClip sfx_game_curtain;
    [SerializeField] AudioClip sfx_game_spirit;
    [SerializeField] AudioClip sfx_game_illusionist;

    public void Sfx_Game_Ost() => background.Play();
    public void Sfx_Game_Wand() => sfx_source.PlayOneShot(sfx_game_wand);
    public void Sfx_Game_Glass() => sfx_source.PlayOneShot(sfx_game_glass);
    public void Sfx_Game_Handkerchief() => sfx_source.PlayOneShot(sfx_game_handkerchief);
    public void Sfx_Game_Teleport() => sfx_source.PlayOneShot(sfx_game_teleport);
    public void Sfx_Game_Door() => sfx_source.PlayOneShot(sfx_game_door);
    public void Sfx_Game_Puzzlecomplete() => sfx_source.PlayOneShot(sfx_game_puzzlecomplete);
    public void Sfx_Game_Curtain() => sfx_source.PlayOneShot(sfx_game_curtain);

    // Dialogues
    public void Sfx_Play_Spirit()
    {
        if(sfx_game_spirit != null)
        {
            dialogue_source.clip = sfx_game_spirit;
            dialogue_source.Play();
        }
    }
    public void Sfx_Stop_Spirit()
    {
        if (dialogue_source.isPlaying)
            dialogue_source.Stop();
    }
    public void Sfx_Play_Illusionist()
    {
        if(sfx_game_illusionist != null)
        {
            dialogue_source.clip = sfx_game_illusionist;
            dialogue_source.Play();
        }
    }
    public void Sfx_Stop_Illusionist()
    {
        if(dialogue_source.isPlaying)
            dialogue_source.Stop();
    }
    #endregion
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
        }
        #endregion
    }

    // TO call this singelton you have to:
    /*
    
    devi prima cosa citarlo nelle Varialbles vv
        AudioManager audioManager; // <-

    e all' AWAKE vv
       #region Singelton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        #endregion
    infine istanzio l'audioManager (nello script che voglio usarlo) allo Strat
            audioManager = AudioManager.Instance;

    */
}
