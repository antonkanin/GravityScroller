using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameController gameController = default;

    [SerializeField] private GameObject m_mainMenu = default;
    [SerializeField] private GameObject m_gamePlayMenu = default;
    [SerializeField] private GameObject m_bestScoreTitle = default;
    [SerializeField] private TMP_Text m_scoreText = default;

    private void Start()
    {
        ShowMainMenu(true);
        SetScore(0);
    }

    public void PlayBtn()
    {
        gameController.ResetGame();
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
}
