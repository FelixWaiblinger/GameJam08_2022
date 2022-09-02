using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject controls;
    [SerializeField] private Animator anim;
    [SerializeField] private float transitionTime = 1f;

    void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneUnloaded += _ => anim.SetTrigger("swipe_out");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        StartCoroutine(_LoadPlayScene());
    }

    public void Controls()
    {
        Instantiate(controls, Vector3.zero, Quaternion.identity);
    }

    public void ReturnControls()
    {
        Destroy(GameObject.FindGameObjectWithTag("Controls"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator _LoadPlayScene()
    {
        anim.SetTrigger("swipe_in");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }
}
