using UnityEngine;
using TMPro;

public class LastGameResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _totalScoreText;

    void Start()
    {
        _scoreText.text = PlayerManager.Instance.LastGameScore.ToString();
        _totalScoreText.text = "Total: " + PlayerManager.Instance.PlayerScore.ToString();
    }

}
