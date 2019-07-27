using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public LevelBehavior levelDesign;
    public ObjectSpawnerTrasher ItemsSpawner;
    public ObjectSpawnerTarget GoalItems;
    public ObjectContainerMover ObjectMover;
    public EndGameUI endGameUI;

    public int currentLevel = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeManagement.instance.m_onDayEnded += OnDayEnded;
        ItemsSpawner.m_onItemDragEnded += OnItemDropped;
        endGameUI.gameObject.SetActive(false);
    }

    private void OnDayEnded()
    {
        endGameUI.gameObject.SetActive(true);
    }

    private void OnItemDropped(string obj)
    {
        GoalItems.RemoveDroppedItem(obj);
    }
   
    public void SetLevel(int currentLevel)
    {
        Level level = levelDesign.levels[currentLevel];

        ItemsSpawner.SetTimeSpawn( level.tempSpawn );
        ObjectMover.SetSpeedFactor( level.velocityScroll );
        GoalItems.SetGoal( level.listObject );
    }

}
