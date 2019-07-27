using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalItem : MonoBehaviour
{

    [SerializeField]
    Image m_itemImage;
    [SerializeField]
    Text m_text;

    public event System.Action<Vector3, Sprite> m_onEndDragItem;

    public void SetImage(Sprite itemImage)
    {
        m_itemImage.sprite = itemImage;
    }

    public void SetText(string numberGoal)
    {
        m_text.text = numberGoal;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
