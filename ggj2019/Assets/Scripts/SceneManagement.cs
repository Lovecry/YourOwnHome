using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void LoadSelectLevelScene()
    {
        SceneManager.LoadScene("SelectLevel", LoadSceneMode.Single);
    }

    int lev = 0;
    public void LoadGameScene(int level)
    {
        lev = level;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        GameObject gameplayGO = GameObject.FindGameObjectWithTag("Gameplay");
        GamePlay gameplayComp = gameplayGO.GetComponent<GamePlay>();
        gameplayComp.SetLevel(lev);
    }
}
