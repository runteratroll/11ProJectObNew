using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFx : MonoBehaviour
{
    public GameObject dotPrefab;

    public int dotAmount;

    [Space]
    [Header("Line Variables")]

    public AnimationCurve followCurve;

    public float followSpeed;

    [Space]
    [Header("Pulse Variables")]


    public AnimationCurve expandCurve;

    public float expandAmount;

    public float expandSpeed;

    Vector3 m_startSize;

    Vector3 m_tagetSize;

    float m_scrollAmount;
    float m_dotGap;

    GameObject[] m_dotArray;

    TrailRenderer m_trailRenderer;
    private void Start()
    {
        m_dotGap = 1f / dotAmount; // percentage of one dot relative to whole
        GetComponents();
        InitPulseEffectVariables();
        SpawnDots();

    }

    void GetComponents()
    {
        m_trailRenderer = GetComponentInChildren<TrailRenderer>();
    }
    
    void InitPulseEffectVariables()
    {
        m_startSize = transform.localScale;
        m_tagetSize = m_startSize * expandAmount;
    }
    void SpawnDots()
    {
        m_dotArray = new GameObject[dotAmount];

        for(int i = 0; i<dotAmount; i++)
        {
            GameObject _dot = Instantiate(dotPrefab);
            _dot.SetActive(false);
            m_dotArray[i] = _dot;
        }
    }

    public void SetDotPos(Vector3 startPos, Vector3 endPos)
    {
        for(int  i = 0; i < dotAmount; i++)
        {
            Vector3 _dotPos = m_dotArray[i].transform.position;
            Vector3 _targetPos = Vector2.Lerp(startPos, endPos, i * m_dotGap); //플레이어 - => 마우스 -값 ,

            float _smoothSpeed = (1f - followCurve.Evaluate(i * m_dotGap)) * followSpeed; //처음과 끝은 빠르고 가운데는 느림? 1일경우 안따라오는 점이 생김
            //m_dotArray[i].transform.position = _targetPos;

            m_dotArray[i].transform.position = Vector2.Lerp(_dotPos, _targetPos, _smoothSpeed * Time.deltaTime);
            
        }
    }

    public void SetDotStartPos(Vector3 pos)
    {
        for(int  i = 0; i< dotAmount; i++)
        {
            
            m_dotArray[i].transform.position = pos;
            
        }
    }

    public void MakeBallPulse()
    {
        m_scrollAmount += Time.deltaTime * expandSpeed;

        float _percent = expandCurve.Evaluate(m_scrollAmount);

        transform.localScale = Vector2.Lerp(m_startSize, m_tagetSize, _percent);
    }

    

    public void ResetBallSize()
    {
        transform.localScale = m_startSize;
        m_scrollAmount = 0f;
    }
    public void ChangeDotActiveState(bool state)
    {
        for(int i = 0; i< dotAmount; i++)
        {
            m_dotArray[i].SetActive(state);
        }
    }

    public void ChangeTrailState(bool emitting, float time)
    {
        m_trailRenderer.emitting = emitting;
        m_trailRenderer.time = time;
    }
}
