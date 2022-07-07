using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : GenericMonoSingleton<GameManager>
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameOverUI;
    public GameObject GameWinUI;
    public GameObject crossHair;
    public GameObject health_Stats, stamina_Stats;
    public TextMeshProUGUI enemy_Killed_Text, boar_Killed_Text;
    public TextMeshProUGUI total_Enemy, total_Boar;


    private void Start()
    {
        total_Enemy.text += (EnemyService.Instance.enemy_Count + EnemyService.Instance.boar_Count).ToString();

    }
    public void ResumeGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        crossHair.SetActive(true);
    }

    public void PauseGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        crossHair.SetActive(false);
    }

    public void RestartGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        crossHair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GameWin()
    {
        GameWinUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        crossHair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

    public void UpdateEnemyKilledUI(int count)
    {
        enemy_Killed_Text.text = count.ToString();

        if (count == EnemyService.Instance.enemy_Count + EnemyService.Instance.boar_Count)
            GameWin();
    }
}
