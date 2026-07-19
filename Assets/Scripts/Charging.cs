using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;

public class Charging : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Button _chargeButton;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private Animator _chargeBarAnim;

    private bool _isCharging = false;
    private float _chargingValue = 0f;



    void Start()
    {
        
    }

    void Update()
    {
        if (_isCharging)
        {
            if(_chargingValue <= 100)
            {
                _chargingValue += 50f * Time.deltaTime;
                _slider.value = _chargingValue;
                _text.text = "Charging";

                ChangeAnimSpeed();
            }
        }
        else
        {
            if(_chargingValue >= 0)
            {
                _chargingValue -= 200f * Time.deltaTime;
                _slider.value = _chargingValue;
                _text.text = "No charging";
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isCharging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isCharging = false;
    }

    public void ChangeAnimSpeed()
    {
        if (_chargingValue < 33f)
        {
            _chargeBarAnim.speed = 1f;
        }
        else if (_chargingValue >= 33f && _chargingValue < 66f)
        {
            _chargeBarAnim.speed = 2f;
        }
        else if (_chargingValue >= 66f)
        {
            _chargeBarAnim.speed = 4f;
        }
    }
}
