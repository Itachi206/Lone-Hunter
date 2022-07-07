using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("Quit the Game");
        Application.Quit();
    }

    public void OptionMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
    }
}
