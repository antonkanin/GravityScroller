using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_soundBall = default;
    [SerializeField] private AudioSource m_soundBtns = default;
    [SerializeField] private AudioSource m_soundGameOver = default;
    [SerializeField] private AudioMixer m_mixer = default;
    public static bool m_isSoundOn;

    public static UnityEvent ChangeSoundOffBtnStatusEvent = new UnityEvent();

    private void Start()
    {
        m_isSoundOn = true;
    }

    public void PlaySoundBall()
    {
        m_soundBall.Play();
    }

    public void PlaySoundButtons()
    {
        m_soundBtns.Play();
    }

    public void PlaySoundGameOver()
    {
        m_soundGameOver.Play();
    }

    public void SoundOffBtn()
    {
        PlaySoundButtons();

        if (m_isSoundOn)
        {
            m_mixer.SetFloat("MasterVol", -80);
            m_isSoundOn = false;
            ChangeSoundOffBtnStatusEvent.Invoke();
        }
        else
        {
            m_mixer.SetFloat("MasterVol", 0);
            m_isSoundOn = true;
            ChangeSoundOffBtnStatusEvent.Invoke();
        }
    }
}
