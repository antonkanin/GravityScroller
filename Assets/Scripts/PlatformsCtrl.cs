using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformsCtrl : MonoBehaviour
{
    [SerializeField] private GameObject m_platformsPrefab;
    [SerializeField] private float m_distanceBetweenRows;
    [SerializeField] private GameObject m_platformsParent;

    [Header("Game Difficulty (1 - Hard, 2 - Easy)")]
    [Range(1f, 2f)]
    [SerializeField] private float m_gameDifficulty = 1f;

    private float m_minPlatformsLenghtScale;
    private float m_maxPlatformsLenghtScale;
    private float m_maxDistanceBetweenPlatformsEdges;
    private float m_minDistanceBetweenPlatformsEdgesInRow;
    private int m_amountOfPlatforms;

    private List<GameObject> m_platformsPool;

    private float prefabLocalScaleY;
    private float platformDistanceFromCenter;
    private float currPlatformLocalScaleX;

    private float leftBorderForRangeXPosOfPlatform;
    private float leftBorderBasedOnCenterOverBorder;
    private float leftBorderBasedOnXPosPrevPlatformInRow;

    private GameObject m_platformsPoolItemCash;

    private float screenWidth;


    private void Start()
    {
        m_platformsParent.SetActive(false);

        m_minPlatformsLenghtScale = m_gameDifficulty;
        m_maxPlatformsLenghtScale = m_minPlatformsLenghtScale * 2;
        m_minDistanceBetweenPlatformsEdgesInRow = m_gameDifficulty;

        //Calculation maxDistanceBetweenPlatformsEdges using the formula for the free-falling body path S = (gt^2)/2;
        //Default platform speed = 1;
        //Difficulty is taken into account
        m_maxDistanceBetweenPlatformsEdges = Mathf.Sqrt((2 * m_distanceBetweenRows) / Physics2D.gravity.magnitude) - 0.1f;//0.1 - reserv for jump

        //Calculation required amount platforms at m_minPlatformsLenghtScale for each platform
        screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        m_amountOfPlatforms = (int)Math.Ceiling(screenWidth / (m_minPlatformsLenghtScale + m_minDistanceBetweenPlatformsEdgesInRow) * 2);

        //Make m_amountOfPlatforms even
        if (m_amountOfPlatforms % 2 != 0)
        {
            m_amountOfPlatforms++;
        }

        //Creating object pool
        m_platformsPool = new List<GameObject>();

        for (int i = 0; i < m_amountOfPlatforms; i++)
        {
            m_platformsPool.Add(Instantiate(m_platformsPrefab, m_platformsParent.transform));
        }

        //
        prefabLocalScaleY = m_platformsPrefab.transform.localScale.y;
        platformDistanceFromCenter = m_distanceBetweenRows * 0.5f + prefabLocalScaleY * 0.5f;

        InitialSettingPlatformsInPool();
    }

    public void InitialSettingPlatformsInPool()
    {
        //First top platform                
        m_platformsPool[0].transform.position = new Vector2(1, platformDistanceFromCenter);
        m_platformsPool[0].transform.localScale = new Vector3(2 * m_maxPlatformsLenghtScale, prefabLocalScaleY);
        m_platformsPool[0].GetComponentInChildren<PlatformEffector2D>().rotationalOffset = 180;

        //First down platform 
        leftBorderForRangeXPosOfPlatform = m_maxPlatformsLenghtScale;
        m_platformsPool[1].transform.position = new Vector2(1 + leftBorderForRangeXPosOfPlatform, -platformDistanceFromCenter);
        m_platformsPool[1].transform.localScale = new Vector3(m_maxPlatformsLenghtScale, prefabLocalScaleY);
        m_platformsPool[1].GetComponentInChildren<PlatformEffector2D>().rotationalOffset = 0;

        //Other platforms in pool
        for (int i = 2; i < m_amountOfPlatforms; i++)
        {
            SettingPlatformInEndOfPool(i, true);

            m_platformsPool[i].GetComponentInChildren<PlatformEffector2D>().rotationalOffset = (i % 2 == 0 ? 180 : 0);
        }
    }

    void FixedUpdate()
    {
        if (!GameCtrl.m_isGameEnd)
        {
            foreach (var item in m_platformsPool)
            {
                item.transform.Translate(Vector3.left * Time.fixedDeltaTime);
            }

            //Detecting platform overrun
            if ((m_platformsPool[0].transform.position.x + m_platformsPool[0].transform.localScale.x * 0.5f) < (-screenWidth * 0.5f))
            {
                ReplacePlatformFromBeginningToEnd();
            }
        }
    }

    public void ShowPlatformsPool(bool isActive)
    {
        m_platformsParent.SetActive(isActive);
    }

    private void ReplacePlatformFromBeginningToEnd()
    {
        m_platformsPoolItemCash = m_platformsPool[0];
        m_platformsPool.RemoveAt(0);
        m_platformsPool.Add(m_platformsPoolItemCash);

        SettingPlatformInEndOfPool(m_platformsPool.Count - 1, false);
    }

    private void SettingPlatformInEndOfPool(int index, bool isYPosSet)
    {
        float platformYPosition =
            (isYPosSet ? ((index % 2 == 0 ? 1 : -1) * platformDistanceFromCenter) : m_platformsPool[index].transform.position.y);

        currPlatformLocalScaleX = UnityEngine.Random.Range(m_minPlatformsLenghtScale, m_maxPlatformsLenghtScale);

        leftBorderBasedOnCenterOverBorder = m_platformsPool[index - 1].transform.position.x
            + 0.5f * m_platformsPool[index - 1].transform.localScale.x;
        leftBorderBasedOnXPosPrevPlatformInRow = m_platformsPool[index - 2].transform.position.x
            + 0.5f * m_platformsPool[index - 2].transform.localScale.x
            + m_minDistanceBetweenPlatformsEdgesInRow
            + 0.5f * currPlatformLocalScaleX;
        leftBorderForRangeXPosOfPlatform = leftBorderBasedOnCenterOverBorder > leftBorderBasedOnXPosPrevPlatformInRow ?
           leftBorderBasedOnCenterOverBorder : leftBorderBasedOnXPosPrevPlatformInRow;

        m_platformsPool[index].transform.position = new Vector2
            (UnityEngine.Random.Range
                (leftBorderForRangeXPosOfPlatform, leftBorderForRangeXPosOfPlatform + m_maxDistanceBetweenPlatformsEdges),
            platformYPosition);
        m_platformsPool[index].transform.localScale = new Vector3(currPlatformLocalScaleX, prefabLocalScaleY);
    }
}
