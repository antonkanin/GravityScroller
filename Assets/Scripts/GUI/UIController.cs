using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject m_mainMenu = default;
    [SerializeField] private GameObject m_gamePlayMenu = default;
    [SerializeField] private GameObject m_bestScoreTitle = default;
    [SerializeField] private TMP_Text m_scoreText = default;

    [SerializeField] private IntVariable score = default;

    private void Start()
    {
        ShowMainMenu(true);
        UpdateScore();
    }

    public void PlayBtn()
    {
        ShowMainMenu(false);
    }

    public void GetScoreButton()
    {
        m_bestScoreTitle.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void ShowMainMenu(bool isActive)
    {
        m_mainMenu.SetActive(isActive);
        m_gamePlayMenu.SetActive(!isActive);
        m_bestScoreTitle.SetActive(false);
    }

    public void SetScore(int score)
    {
        m_scoreText.text = score.ToString();
    }

    public void UpdateScore()
    {
        SetScore(score.Value);
    }
}