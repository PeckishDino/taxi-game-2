using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CarSounds volume;
    public bool paused = false;
    public GameObject pauseMenuUI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                
                Resume();
            }

            else
            {
                
                Pause();
            }
        }
    }


    void Resume()
    {
        volume.carAudio.Play();
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        volume.carAudio.Stop();
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        
    }

    public void ResumeButton()
    {
        volume.carAudio.Play();
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
