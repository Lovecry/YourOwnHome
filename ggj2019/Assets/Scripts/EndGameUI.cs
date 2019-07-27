using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] Button m_goToLevelsButton;

    private void Start()
    {
        m_goToLevelsButton.onClick.AddListener(()=> { SceneManagement.instance.LoadSelectLevelScene(); });
    }
}
