using UnityEngine;
using TMPro;

public class UICtrl : MonoBehaviour
{
    [SerializeField] private GameCtrl m_gameCtrl = default;
    [SerializeField] private SoundMngr m_soundMngr = default;

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
        m_gameCtrl.ResetGame();
        ShowMainMenu(false);
        m_soundMngr.PlaySoundBtns();
    }

    public void GetScoreBtn()
    {
        m_bestScoreTitle.SetActive(true);
        m_soundMngr.PlaySoundBtns();
    }

    public void ExitBtn()
    {
        m_soundMngr.PlaySoundBtns();
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
        m_scoreText.text = "Score: " + score.ToString();
    }
}
