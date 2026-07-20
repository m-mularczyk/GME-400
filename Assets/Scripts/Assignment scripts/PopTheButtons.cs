using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopTheButtons : MonoBehaviour
{
    [SerializeField] private PopButton[] _popButtons;
    [SerializeField] private Timer _timer;
    [SerializeField] private ParticleSystem _particleSystem;
    void Start()
    {
        _timer.SetTimeForGame(15f);
        Time.timeScale = 1;
    }

    public void TimeOut()
    {
        // Play sound
        UIAudioManager.Instance.PlaySucessSound();
        
        // Turn off all buttons
        TurnAllPopButtonsOff();

        // Stop time
        Time.timeScale = 0;

        // Start success Coroutine
        StartCoroutine(SuccessRoutine());
    }

    private void TurnAllPopButtonsOff()
    {
        foreach (var button in _popButtons)
        {
            button.TurnOffButton();
        }
    }


    IEnumerator SuccessRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Assignment-ResultScreen");
    }
}
