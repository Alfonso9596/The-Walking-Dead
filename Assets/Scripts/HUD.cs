using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject dangerUI;
    public GameObject winUI;
    public GameObject pauseMenuUI;
    public GameObject deathUI;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (GameManager.Instance.IsAlertActive) { 
            dangerUI.SetActive(true);
        }
        else { 
            dangerUI.SetActive(false);
        }

        if (GameManager.Instance.IsSafeZoneActive)
        {
            Won();
        }

        if (!GameManager.Instance.IsPlayerAlive)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.IsGamePaused)
            {
                Cursor.visible = false;
                Resume();
            } else
            {
                Cursor.visible = true;
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (GameManager.Instance.IsAlertActive)
        {
            dangerUI.SetActive(true);
        }
        Cursor.visible = false;
        winUI.SetActive(false);
        deathUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.IsGamePaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        dangerUI.SetActive(false);
        deathUI.SetActive(false);
        winUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.IsGamePaused = true;
    }

    public void Won()
    {
        Cursor.visible = true;
        dangerUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        deathUI.SetActive(false);
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Death()
    {
        Cursor.visible = true;
        dangerUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        winUI.SetActive(false);
        deathUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.IsPlayerAlive = true;
        GameManager.Instance.IsGamePaused = false;
        GameManager.Instance.IsSafeZoneActive = false;
        dangerUI.SetActive(false);
        deathUI.SetActive(false);
        winUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
