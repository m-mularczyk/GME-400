using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AppButtonManager : MonoBehaviour
{
    [SerializeField] private string _playerName = "";
    [SerializeField] private int _playerScore = 0;
    [SerializeField] private TMP_InputField _playerNameInputField;
    [SerializeField] private TextMeshProUGUI _inputFieldStatusTxt;
    [SerializeField] private TextMeshProUGUI _currentProfileTxt;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

    }
    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CreateNewPlayerProfile()
    {
        _inputFieldStatusTxt.gameObject.SetActive(true);

        // Check current input field value
        if (_playerNameInputField.text == "")
        {
            _inputFieldStatusTxt.text = "Player name cannot be empty";
            Debug.Log("Player name cannot be empty");
            return;
        }

        if (_playerNameInputField.text != "" && !PlayerPrefs.HasKey(_playerNameInputField.text))
        {
            PlayerPrefs.SetString(_playerNameInputField.text, _playerNameInputField.text);
            PlayerPrefs.SetInt(_playerNameInputField.text + "_score", 0);
            PlayerPrefs.Save();
            Debug.Log("Created new profile named: " + _playerNameInputField.text);
            
            _playerName = _playerNameInputField.text;
            _playerScore = 0;
            _inputFieldStatusTxt.text = "Created new profile: " + _playerName;

            _playerNameInputField.text = "";

            _currentProfileTxt.gameObject.SetActive(true);
            _currentProfileTxt.text = _playerName + " : " + _playerScore;

            PlayerManager.Instance.SetPlayerName( _playerName );
            PlayerManager.Instance.SetScore( _playerScore );
            PlayerManager.Instance.ResetLastGameScore();
        }
        else
        {
            _inputFieldStatusTxt.text = "Player name already in use";
            Debug.Log("Player name already in use");
        }

    }

    public void LoadPlayerProfile()
    {
        _inputFieldStatusTxt.gameObject.SetActive(true);

        if (_playerNameInputField.text == "")
        {
            _inputFieldStatusTxt.text = "Player name cannot be empty";
            Debug.Log("Player name cannot be empty");
            return;
        }

        if(_playerNameInputField.text != "" && PlayerPrefs.HasKey(_playerNameInputField.text))
        {
            _playerName = PlayerPrefs.GetString(_playerNameInputField.text);
            _playerScore = PlayerPrefs.GetInt(_playerNameInputField.text + "_score");

            Debug.Log("Loaded player profile: " + _playerName + " with score of " + _playerScore);
            _inputFieldStatusTxt.text = "";

            _playerNameInputField.text = "";

            _currentProfileTxt.gameObject.SetActive(true);
            _currentProfileTxt.text = _playerName + " : " + _playerScore;
        }
        else
        {
            _inputFieldStatusTxt.text = "Player" + _playerNameInputField.text + " does not exist";
            Debug.Log("Player" + _playerNameInputField.text + " does not exist");
        }

        PlayerManager.Instance.SetPlayerName(_playerName);
        PlayerManager.Instance.SetScore(_playerScore);
        PlayerManager.Instance.ResetLastGameScore();
    }

    public void GoBackButton(string sceneName)
    {
        PlayerManager.Instance.ResetLastGameScore();
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()
    {
        PlayerManager.Instance.ResetLastGameScore();
        SceneManager.LoadScene(PlayerManager.Instance.LastGame);
    }

    public void ResetLastGameScore()
    {
        PlayerManager.Instance.ResetLastGameScore();
    }

    public void SavePlayerTotalScore()
    {
        if(PlayerManager.Instance.PlayerName != null && PlayerManager.Instance.PlayerName != "")
        {
            PlayerPrefs.SetInt(PlayerManager.Instance.PlayerName + "_score", PlayerManager.Instance.PlayerScore);
            Debug.Log("Saved new score to PlayerPrefs: " + PlayerManager.Instance.PlayerScore);
        }
    }

    public void QuitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
