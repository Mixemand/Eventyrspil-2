using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private static sceneManager _instance;
    public static sceneManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Main Menu har index 0
    }

    public void LoadGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Jons scenen har index 0 + 1 = 1
        }
    }

    public void QuitApp()
    {
#if UNITY_EDITOR // Preprocessor
        Debug.LogWarning("Game Quit");
#else
        Application.Quit();
#endif
    }
}
