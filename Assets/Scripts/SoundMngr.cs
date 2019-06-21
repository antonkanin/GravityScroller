﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SoundMngr : MonoBehaviour
{
    [SerializeField] private AudioSource m_soundBall;
    [SerializeField] private AudioSource m_soundBtns;
    [SerializeField] private AudioSource m_soundGameOver;
    [SerializeField] private AudioMixer m_mixer;
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

    public void PlaySoundBtns()
    {
        m_soundBtns.Play();
    }

    public void PlaySoundGameOver()
    {
        m_soundGameOver.Play();
    }

    public void SoundOffBtn()
    {
        PlaySoundBtns();

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
