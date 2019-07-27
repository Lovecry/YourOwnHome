using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelBehavior", menuName = "Scriptable/LevelBehavior", order = 1)]
public class LevelBehavior : ScriptableObject
{
    public Level[] levels;
}

[System.Serializable]
public class Level
{
    public List<ObjectHome> listObject;
    [SerializeField]
    public float velocityScroll = 1;
    [SerializeField]
    public float tempSpawn = 1;
}

[System.Serializable]
public class ObjectHome
{
    [SerializeField]
    public string nameFile;
    [SerializeField]
    public int numberObject = 1;
    [SerializeField]
    public int point = 10;
}

public class Goal
{
    ObjectHome obj;
    int goal = 0;

    public Goal(ObjectHome obj)
    {
        this.obj = obj;
        this.goal = obj.numberObject;
    }
}