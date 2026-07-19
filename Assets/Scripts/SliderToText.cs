using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SliderToText : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textForSlider;

    void Update()
    {
        _textForSlider.text = _slider.value.ToString();
    }
}
