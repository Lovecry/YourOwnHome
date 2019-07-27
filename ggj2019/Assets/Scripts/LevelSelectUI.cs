using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    Button[] m_buttonList;

    // Start is called before the first frame update
    void Start()
    {
        m_buttonList = GetComponentsInChildren<Button>();

        for (int i = 0; i < m_buttonList.Length; ++i)
        {
            int x = i;
            m_buttonList[i].onClick.AddListener( () => { OnLevelButtonCLicked(x); });
        }
    }

    void OnLevelButtonCLicked(int level)
    {
        SceneManagement.instance.LoadGameScene(level);
    }
}
