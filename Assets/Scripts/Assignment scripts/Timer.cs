using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _maxSeconds = 20f;
    [SerializeField] private PopTheButtons _popTheButtons;

    private TextMeshProUGUI _timerText;
    private float _maxTimeStamp;
    private bool _succeeded;

    void Start()
    {
        _timerText = GetComponent<TextMeshProUGUI>();

        _maxTimeStamp = Time.time + _maxSeconds;

        _succeeded = false;
    }

    void Update()
    {

        float timeLeft = _maxTimeStamp - Time.time;
        if (timeLeft > 0)
        {
            _timerText.text = Mathf.RoundToInt(timeLeft).ToString();
        }
        else
        {
            if (!_succeeded)
            {
                _popTheButtons.TimeOut();
            }
            _succeeded = true;
        }
    }



}
