using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject controls;
    private GameObject controlsInstance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    public void Controls()
    {
        controlsInstance = Instantiate(controls, Vector3.zero, Quaternion.identity);
    }

    public void ReturnControls()
    {
        Destroy(controlsInstance);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
