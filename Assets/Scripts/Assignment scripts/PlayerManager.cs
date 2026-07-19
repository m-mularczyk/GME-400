using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private string _playerName;
    [SerializeField] private int _playerScore;
    [SerializeField] private int _lastGameScore;
    [SerializeField] private string _lastGame;

    public string PlayerName
    {
        get
        {
            return _playerName;
        }
    }

    public int PlayerScore
    {
        get
        {
            return _playerScore;
        }
    }
    public int LastGameScore
    {
        get
        {
            return _lastGameScore;
        }
    }
    public string LastGame
    {
        get
        {
            return _lastGame;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string playerName)
    {
        _playerName = playerName;
    }

    public void SetScore(int score)
    {
        _playerScore = score;
    }

    public void AddScore(int amount)
    {
        _playerScore += amount;
    }

    public void ResetScore()
    {
        _playerScore = 0;
    }

    public void AddLastGameScore(int score)
    {
        _lastGameScore += score;
    }

    public void ResetLastGameScore()
    {
        _lastGameScore = 0;
    }

    public void SetLastGame(string lastGameName)
    {
        _lastGame = lastGameName;
    }
}