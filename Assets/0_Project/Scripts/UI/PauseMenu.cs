using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;
    private GameInputSystem gameInputSystem;

    public void OpenMenu()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Awake()
    {
        CloseMenu();

        gameInputSystem = new GameInputSystem();

        gameInputSystem.Common.Pause.performed += Pause_performed;
    }
    private void OnEnable()
    {
        gameInputSystem.Enable();
    }
    private void OnDisable()
    {
        gameInputSystem.Disable();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (isPaused)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
