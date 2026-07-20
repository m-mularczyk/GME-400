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

    void Start()
    {
        _myNumber = Random.Range(1, 1001);
        _instructionsText.text = "Guess my number 1-1000 in " + _trialsLeft + " trials";
        _trialsLeft = _trials;
        _currentPoints = _maxPoints;
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
                }
                else if (int.Parse(_inputField.text) > _myNumber)
                {
                    // Tip: try lower
                    _tipText.text = "Too high, try lower...";
                    WrongGuess();
                }
                else
                {
                    if (_currentPoints < 0)
                    {
                        _currentPoints = 0;
                    }

                    // Exact number! Success!
                    PlayerManager.Instance.AddScore(_currentPoints);
                    PlayerManager.Instance.AddLastGameScore(_currentPoints);

                    _tipText.text = "You guessed it! Congratulations!";
                    StartCoroutine("GuessNumberSuccessRoutine");


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
        if (_currentPoints < 0)
        {
            _currentPoints = 0;
        }
        _lastGuess = int.Parse(_inputField.text);
    }

    IEnumerator GuessNumberSuccessRoutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Assignment-ResultScreen");
    }
}
