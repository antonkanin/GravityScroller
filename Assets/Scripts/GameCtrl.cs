using System.Collections;
using UnityEngine;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    [SerializeField] private PlatformsCtrl m_platformCtrl = default;
    [SerializeField] private UICtrl m_UICtrl = default;

    [SerializeField] private TMP_Text m_bestScoreText = default;

    [SerializeField] private GameObject m_ball = default;

    public static int m_currScore;
    public static bool m_isGameEnd;

    private WaitForSeconds m_delay;


    private void Awake()
    {
        Camera.main.orthographicSize = 5f;
    }

    void Start()
    {
        GameOverInvoker.GameOverEvent.AddListener(EndOfGame);
        m_delay = new WaitForSeconds(1);

        m_ball.SetActive(false);
        m_isGameEnd = true;
        SetBestScore();
    }

    private void OnDestroy()
    {
        GameOverInvoker.GameOverEvent.RemoveListener(EndOfGame);
    }

    public void AddPoint()
    {
        m_currScore++;
        m_UICtrl.SetScore(m_currScore);
    }

    public void ResetGame()
    {
        m_currScore = 0;
        m_UICtrl.SetScore(0);

        if (Physics2D.gravity.y < 0)
        {
            Physics2D.gravity = -Physics2D.gravity;
        }

        m_ball.transform.position = Vector2.zero;
        m_ball.SetActive(true);

        m_platformCtrl.InitialSettingPlatformsInPool();
        m_platformCtrl.ShowPlatformsPool(true);

        m_isGameEnd = false;
    }

    private void EndOfGame()
    {
        m_platformCtrl.ShowPlatformsPool(false);

        m_isGameEnd = true;

        StartCoroutine(EndOfGameCor());

        SetBestScore();

        m_ball.SetActive(false);
    }

    private IEnumerator EndOfGameCor()
    {
        yield return m_delay;

        m_platformCtrl.ShowPlatformsPool(false);

        m_UICtrl.ShowMainMenu(true);
    }

    private void SetBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (m_currScore > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", m_currScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", m_currScore);
        }

        m_bestScoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore").ToString();
    }
}
