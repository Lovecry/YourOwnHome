using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] Button m_startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        m_startGameButton.onClick.AddListener(OnStartGameButtonPressed);
    }

    private void OnStartGameButtonPressed()
    {
        SceneManagement.instance.LoadSelectLevelScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
