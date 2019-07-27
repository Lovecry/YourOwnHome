using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DayPhases
{
    DAY = 0,
    NIGHT =1
}

public class TimeManagement : MonoBehaviour
{
    public event System.Action m_onDayNightChanged;
    public event System.Action m_onDayEnded;

    [SerializeField] float m_secPerHour = 2;
    [HideInInspector] public float Hour24 = 0;
    [HideInInspector] public float Hour12 = 0;
    [SerializeField] Material m_blackWhiteMat;
    public DayPhases m_currentDayPhase = DayPhases.DAY;
    public int m_currentDay = 1;

    float m_currentTime = 0;

    public static TimeManagement instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Hour24 += Time.deltaTime / m_secPerHour;
        Hour12 += Time.deltaTime / m_secPerHour;
        if (Hour24 > 24)
        {
            if (m_onDayEnded != null)
                m_onDayEnded();
            Hour24 = 0;
            m_currentDay++;
        }
        if (Hour12 > 12)
        {
            Hour12 = 0;

            if (m_currentDayPhase == DayPhases.DAY)
            {
                m_currentDayPhase = DayPhases.NIGHT;
                m_blackWhiteMat.SetFloat("_isReverse", 1);
            }
            else
            {
                m_currentDayPhase = DayPhases.DAY;
                m_blackWhiteMat.SetFloat("_isReverse", 0);
            }
            if (m_onDayNightChanged != null)
                m_onDayNightChanged();
        }
    }
}
