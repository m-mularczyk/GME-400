using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthValueTxt;
    [SerializeField] private int _health = 100;

    private void Start()
    {
        _healthSlider.value = _health;
        _healthValueTxt.text = _health.ToString();
    }

    private void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            _health -= 20;
            if(_health < 0 )
                _health = 0;

            _healthSlider.value = _health;
            _healthValueTxt.text = _health.ToString();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            _health += 20;
            if( _health > 100)
                _health = 100;

            _healthSlider.value = _health;
            _healthValueTxt.text = _health.ToString();
        }
        
    }
}
