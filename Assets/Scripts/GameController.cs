using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController UIController = default;

    [SerializeField] private TMP_Text bestScoreText = default;

    [SerializeField] private GameObject player = default;

    [SerializeField] private GameEvent gameResetEvent = default;

    public static int currentScore;
    public static bool m_isGameEnd;

    private WaitForSeconds m_delay;


    private void Awake()
    {
        Camera.main.orthographicSize = 5f;
    }

    void Start()
    {
        m_delay = new WaitForSeconds(1);

        player.SetActive(false);
        m_isGameEnd = true;
        SetBestScore();
    }

    public void AddPoint()
    {
        currentScore++;
        UIController.SetScore(currentScore);
    }

    public void ResetGame()
    {
        currentScore = 0;
        UIController.SetScore(0);

        if (Physics2D.gravity.y < 0)
        {
            Physics2D.gravity = -Physics2D.gravity;
        }

        player.transform.position = Vector2.zero;
        player.SetActive(true);

        gameResetEvent.Raise();

        m_isGameEnd = false;
    }

    public void EndOfGame()
    {
        m_isGameEnd = true;

        StartCoroutine(EndOfGameCor());

        SetBestScore();

        player.SetActive(false);
    }

    private IEnumerator EndOfGameCor()
    {
        yield return m_delay;

        UIController.ShowMainMenu(true);
    }

    private void SetBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (currentScore > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }

        bestScoreText.text = "Best score: " + PlayerPrefs.GetInt("BestScore").ToString();
    }
}