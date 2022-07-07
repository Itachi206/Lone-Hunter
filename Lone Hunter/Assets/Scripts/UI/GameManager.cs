using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : GenericMonoSingleton<GameManager>
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameOverUI;
    public GameObject crossHair;
    public GameObject health_Stats, stamina_Stats;


    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        crossHair.SetActive(true);
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        crossHair.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        crossHair.SetActive(false);
    }

    public void Display_HealthStats(float healthValue)
    {
        healthValue /= 100f;
        health_Stats.GetComponent<Image>().fillAmount = healthValue;
    }

    public void Display_StaminaStats(float staminaValue)
    {
        staminaValue /= 100f;
        stamina_Stats.GetComponent<Image>().fillAmount = staminaValue;
    }

}
