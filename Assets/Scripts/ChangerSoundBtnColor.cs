using UnityEngine;
using UnityEngine.UI;

public class ChangerSoundBtnColor : MonoBehaviour
{
    private Image m_image;
    private Color m_defaultColor;


    void Start()
    {
        SoundManager.ChangeSoundOffBtnStatusEvent.AddListener(ChangeSoundOffBtnColor);

        m_image = GetComponent<Image>();
        m_defaultColor = m_image.color;
    }

    private void OnDestroy()
    {
        SoundManager.ChangeSoundOffBtnStatusEvent.RemoveListener(ChangeSoundOffBtnColor);
    }

    private void ChangeSoundOffBtnColor()
    {
        if (SoundManager.m_isSoundOn)
        {
            m_image.color = m_defaultColor;
        }
        else
        {
            m_image.color = Color.red;
        }
    }
}
