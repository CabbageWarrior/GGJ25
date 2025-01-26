using UnityEngine;

public class GameSelector : MonoBehaviour
{
    [SerializeField] private GameObject fish1;
    [SerializeField] private GameObject fish2;
    [Space]
    [SerializeField] private GameObject cameraSingle;
    [SerializeField] private GameObject cameraMulti1;
    [SerializeField] private GameObject cameraMulti2;
    [Space]
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject gameEndCanvas;
    [Space]
    [SerializeField] private GameObject multiplayerSeparator;

#if UNITY_EDITOR
    [Space]
    [Header("EDITOR")]
    [SerializeField] private bool forceMulti;
#endif

    private void Awake()
    {
#if UNITY_EDITOR
        if (forceMulti)
            SessionInfo.IsMultiplayer = true;
#endif

        fish1.SetActive(true);
        fish2.SetActive(SessionInfo.IsMultiplayer);

        cameraSingle.SetActive(!SessionInfo.IsMultiplayer);
        cameraMulti1.SetActive(SessionInfo.IsMultiplayer);
        cameraMulti2.SetActive(SessionInfo.IsMultiplayer);

        multiplayerSeparator.SetActive(SessionInfo.IsMultiplayer);
    }

    public void TriggerGameEnd()
    {
        pauseMenu.enabled = false;

        fish1.GetComponent<FishController>().enabled = false;
        fish2.GetComponent<FishController>().enabled = false;

        gameEndCanvas.SetActive(true);
    }
}
