using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerTarget : MonoBehaviour
{
    public LevelBehavior levels;
    public int numberLevelSelected = 0;
    Sprite[] m_itemSprites;

    Dictionary<string, GoalItem> goalItemNameLink = new Dictionary<string, GoalItem>();
    Dictionary<string, int> goalItemCountLink = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Awake()
    {
        m_itemSprites = Resources.LoadAll<Sprite>("Items");
    }

    internal void SetGoal(List<ObjectHome> listObject)
    {
        foreach (ObjectHome objHome in listObject)
        {
            GameObject instance = Instantiate(Resources.Load("GoalItem", typeof(GameObject))) as GameObject;
            instance.transform.SetParent(transform, false);
            instance.transform.SetAsFirstSibling();
            GoalItem draggableItemComponent = instance.GetComponent<GoalItem>();
            if (draggableItemComponent != null)
            {
                foreach (Sprite sprite in m_itemSprites)
                {
                    if (sprite.name.Contains(objHome.nameFile))
                    {
                        draggableItemComponent.SetImage(sprite);
                        draggableItemComponent.SetText(objHome.numberObject + "");
                    }
                }
            }
            goalItemNameLink.Add(objHome.nameFile, draggableItemComponent);
            goalItemCountLink.Add(objHome.nameFile, objHome.numberObject);
        }
    }

    public void RemoveDroppedItem(string name)
    {
        if (goalItemCountLink.ContainsKey(name))
        {
            goalItemCountLink[name]--;
            goalItemNameLink[name].SetText(goalItemCountLink[name] + "");
            if (goalItemCountLink[name] == 0)
            {
                goalItemCountLink.Remove(name);
                GameObject.Destroy(goalItemNameLink[name].gameObject);
                goalItemNameLink.Remove(name);
            }
        }
    }
}
