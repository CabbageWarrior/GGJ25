using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singelton
    [SerializeField] AudioSource sfx_source;
    [Tooltip("This AudioSource must have a Loop")]
    [SerializeField] AudioSource background;

    #region Game
    [Header("Game")]
    [Tooltip("You have to drag this sound to the AudioSource in Loop")]
    [SerializeField] AudioClip sfx_game_end;

    [SerializeField] AudioClip sfx_game_bubble;

    public void Sfx_Game_Ost() => background.Play();
    public void Sfx_Game_End() => sfx_source.PlayOneShot(sfx_game_end);

    // Dialogues
    public void Sfx_Play_Bulle()
    {
        if(sfx_game_bubble != null)
        {
            sfx_source.clip = sfx_game_bubble;
            sfx_source.Play();
        }
    }
    public void Sfx_Stop_Bubble()
    {
        if (sfx_source.isPlaying)
            sfx_source.Stop();
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
}
