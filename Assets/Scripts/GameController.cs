using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text bestScoreText = default;

    [SerializeField] private GameEvent gameOverEvent = default;

    [SerializeField] private IntVariable score = default;

    public static bool m_isGameEnd;

    private WaitForSeconds m_delay;

    private void Awake()
    {
        Camera.main.orthographicSize = 5f;
    }

    void Start()
    {
        m_delay = new WaitForSeconds(1);

        m_isGameEnd = true;
        SetBestScore();
    }

    public void AddPoint()
    {
        score.Value++;
    }

    public void StartGame()
    {
        score.Value = 0;

        if (Physics2D.gravity.y < 0)
        {
            Physics2D.gravity = -Physics2D.gravity;
        }

        m_isGameEnd = false;
    }

    public void OnCometHit()
    {
        StartCoroutine(Co_GameOver());
    }

    private IEnumerator Co_GameOver()
    {
        yield return new WaitForSeconds(Consts.GameOverDelay);

        gameOverEvent.Raise();
    }

    public void EndOfGame()
    {
        m_isGameEnd = true;

        SetBestScore();
    }

    private void SetBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (score.Value > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score.Value);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", score.Value);
        }

        bestScoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore").ToString();
    }
}