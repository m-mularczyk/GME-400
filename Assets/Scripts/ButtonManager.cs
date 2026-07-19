using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Toggle[] _toggles;

    [SerializeField] private Toggle[] _picToggles;
    [SerializeField] private Sprite[] _pictures;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    public void Toggle0True()
    {
        if (_toggles[0].isOn)
        {
            Debug.Log("Difficulty level set to EASY");
        }
    }

    public void Toggle1True()
    {
        if (_toggles[1].isOn)
        {
            Debug.Log("Difficulty level set to MEDIUM");
        }
    }

    public void Toggle2True()
    {
        if (_toggles[2].isOn)
        {
            Debug.Log("Difficulty level set to HARD");
        }
    }

    // Challenge1 code
    #region Kod dla sceny Challenge1
    public void Pic1()
    {
        if (_picToggles[0].isOn)
        {
            _image.sprite = _pictures[0];
            _text.text = "Picture 1";
        }
    }

    public void Pic2()
    {
        if (_picToggles[1].isOn)
        {
            _image.sprite = _pictures[1];
            _text.text = "Picture 2";
        }
    }

    public void Pic3()
    {
        if (_picToggles[2].isOn)
        {
            _image.sprite = _pictures[2];
            _text.text = "Picture 3";
        }
    }

    #endregion
}
