using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
