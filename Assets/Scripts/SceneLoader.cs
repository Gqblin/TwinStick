using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject sceneLoader;

    public void LoadGame()
    {
        SceneManager.LoadScene("YoriOfficialLVL", LoadSceneMode.Single);
    }

    public void LoadMainScreen()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        PauseGame pause = FindObjectOfType<PauseGame>();
        pause.paused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
    }
}
