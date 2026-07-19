using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _maxSeconds = 20f;

    private TextMeshProUGUI _timerText;
    private float _maxTimeStamp;

    void Start()
    {
        _timerText = GetComponent<TextMeshProUGUI>();

        _maxTimeStamp = Time.time + _maxSeconds;
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
            SceneManager.LoadScene("Assignment-ResultScreen");
        }
    }
}
