using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CatTriggerer : MonoBehaviour
{
    [SerializeField] private PlayableDirector dir;

    public void StartTrigger()
    {
        StartCoroutine(Gesu());

        IEnumerator Gesu()
        {
            dir.enabled = false;
            yield return null;
            dir.enabled = true;

            AudioManager.Instance.Sfx_Game_Cat_Hiss();

            if (dir.time < 0.1f)
            {
                AudioManager.Instance.Sfx_Game_Cat_Paw();
            }
        }
    }
}
