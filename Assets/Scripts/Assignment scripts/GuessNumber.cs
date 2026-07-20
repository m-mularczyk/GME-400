using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuessNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _instructionsText;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextMeshProUGUI _tipText;

    [SerializeField] private int _myNumber;
    [SerializeField] private int _trials = 10;
    [SerializeField] private int _trialsLeft;
    [SerializeField] private int _maxPoints = 100;
    [SerializeField] private int _currentPoints = 100;
    private int _lastGuess;
    [SerializeField] private int _totalTrials = 0;
    private bool _success = false;

    void Start()
    {
        _myNumber = Random.Range(1, 1001);
        _instructionsText.text = "Guess my number 1-1000 in " + _trials + " trials";
        _trialsLeft = _trials;
        _currentPoints = _maxPoints;
        _totalTrials = 0;
        _success = false;
        _inputField.interactable = true;
    }

    public void VerifyNumber()
    {
        if(_inputField != null && _inputField.text != "")
        {
            if(int.Parse(_inputField.text) != _lastGuess)
            {
                if (int.Parse(_inputField.text) < _myNumber)
                {
                    //Tip: try higher
                    _tipText.text = "Too low, try higher...";
                    WrongGuess();
                    _totalTrials++;
                }
                else if (int.Parse(_inputField.text) > _myNumber)
                {
                    // Tip: try lower
                    _tipText.text = "Too high, try lower...";
                    WrongGuess();
                    _totalTrials++;
                }
                else
                {
                    // GUESSED CORRECTLY
                    _totalTrials++;

                    if(_totalTrials > _trials)
                    {
                        _currentPoints = 0;
                        Debug.Log("Too many trials - zero points");
                    }

                    if (_currentPoints < 0)
                    {
                        _currentPoints = 0;
                    }

                    // Exact number! Success!
                    PlayerManager.Instance.AddScore(_currentPoints);
                    PlayerManager.Instance.AddLastGameScore(_currentPoints);

                    if(_totalTrials < _trials)
                    {
                        _tipText.text = "You guessed it in " + (_totalTrials) +" trials! Congratulations!";
                    }
                    else
                    {
                        _tipText.text = "You guessed it but in too many trials!";
                    }

                    if (!_success)
                    {
                        StartCoroutine("GuessNumberSuccessRoutine");
                        _success = true;
                    }
                    

                }

            }
            else
            {
                if(!_tipText.text.Contains("You already tried this number"))
                _tipText.text += " You already tried this number.";
            }


        }
    }

    private void WrongGuess()
    {
        _trialsLeft--;
        _currentPoints -= Mathf.CeilToInt(_maxPoints/_trials);

        _lastGuess = int.Parse(_inputField.text);

        UIAudioManager.Instance.PlayDropSound();
    }

    public void SetCaretPosition()
    {
        _inputField.ActivateInputField();
        _inputField.caretPosition = _inputField.text.Length;
    }

    IEnumerator GuessNumberSuccessRoutine()
    {
        _inputField.interactable = false;
        UIAudioManager.Instance.PlaySucessSound();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Assignment-ResultScreen");
    }
}
