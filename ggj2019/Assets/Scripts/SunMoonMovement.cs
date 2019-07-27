using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonMovement : MonoBehaviour
{
    [SerializeField] AnimationCurve m_movimentCurve;
    [SerializeField] AnimationCurve m_alphaCurve;
    [SerializeField] CanvasGroup m_canvasGroup;

    [SerializeField] float m_movementSpeed;
    [SerializeField] SpriteRenderer m_spriteImage;
    [SerializeField] Sprite[] m_sunMoonSprites;

    private void Start()
    {
        TimeManagement.instance.m_onDayNightChanged += OnNightDayChanged;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,0,1));

        m_canvasGroup.alpha = m_alphaCurve.Evaluate(TimeManagement.instance.Hour12 / (float)12);

        Vector3 newPositionViewport = new Vector3();
        newPositionViewport.x = TimeManagement.instance.Hour12 / (float)12;
        newPositionViewport.y = m_movimentCurve.Evaluate(TimeManagement.instance.Hour12 / (float)12);
        newPositionViewport.z = Camera.main.nearClipPlane;

        transform.position = Camera.main.ViewportToWorldPoint( newPositionViewport);
    }

    void OnNightDayChanged()
    {
        if (TimeManagement.instance.m_currentDayPhase == DayPhases.DAY)
        {
            m_spriteImage.sprite = m_sunMoonSprites[0];
        }
        else
        {
            m_spriteImage.sprite = m_sunMoonSprites[1];
        }
    }
}
