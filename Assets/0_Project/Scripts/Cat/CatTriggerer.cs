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
        }
    }
}
