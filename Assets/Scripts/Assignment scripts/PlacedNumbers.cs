using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlacedNumbers : MonoBehaviour
{
    [SerializeField] private NumberDropSlot[] _slots;
    [SerializeField] private GameObject _successInfo;


    void Start()
    {
        _successInfo.SetActive(false);
    }

    public void CheckNumbers()
    {
        if (AreAllSlotsFilled())
        {
            bool correctOrder = VerifyNumbersOrder();

            if (correctOrder)
            {
                Debug.Log("Kolejnoœæ poprawna!");
                PlayerManager.Instance.AddScore(10);
                PlayerManager.Instance.AddLastGameScore(10);
                _successInfo.SetActive(true);
                StartCoroutine(SuccessfullyPlacedNumbersRoutine());
            }
            else
            {
                Debug.Log("Kolejnoœæ b³êdna!");
            }
        }
    }

    private bool AreAllSlotsFilled()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].CurrentlyPlacedNumber() <= 0)
            {
                return false;
            }
        }

        return true;
    }


    public bool VerifyNumbersOrder()
    {
        for (int i = 0; i < _slots.Length - 1; i++)
        {
            if (_slots[i].CurrentlyPlacedNumber() > _slots[i + 1].CurrentlyPlacedNumber())
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SuccessfullyPlacedNumbersRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Assignment-ResultScreen");
    }
}
