using UnityEngine;
using UnityEngine.UI;

public class ChangerSoundBtnColor : MonoBehaviour
{
    [SerializeField] private GameEvent soundOnEvent = default;

    [SerializeField] private GameEvent soundOffEvent = default;

    [SerializeField] private BoolVariable isSoundOn = default;

    private Image image;
    private Color defaultColor;

    void Start()
    {
        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    public void ChangeSoundOffBtnColor()
    {
        if (isSoundOn.Value)
        {
            soundOffEvent.Raise();
            image.color = Color.red;
        }
        else
        {
            soundOnEvent.Raise();
            image.color = defaultColor;
        }

        isSoundOn.Value = !isSoundOn.Value;
    }
}