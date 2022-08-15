using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject controls;

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
        Instantiate(controls, Vector3.zero, Quaternion.identity);
    }

    public void ReturnControls()
    {
        Debug.Log("test");
        Destroy(GameObject.FindGameObjectWithTag("Controls"));
    }

    public void Quit()
    {
        Application.Quit();
    }
}
