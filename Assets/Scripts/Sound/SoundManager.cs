using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_soundBall = default;
    [SerializeField] private AudioSource m_soundBtns = default;
    [SerializeField] private AudioSource m_soundGameOver = default;
    [SerializeField] private AudioMixer m_mixer = default;

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

    public void SoundTurnOn()
    {
        m_mixer.SetFloat("MasterVol", 0);
    }

    public void SoundTurnOff()
    {
        m_mixer.SetFloat("MasterVol", -80);
    }
}