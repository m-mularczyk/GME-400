using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _minTimeOn = 0.5f;
    [SerializeField] private float _maxTimeOn = 1f;
    [SerializeField] private float _minTimeOff = 1.5f;
    [SerializeField] private float _maxTimeOff = 3.5f;
    private Image _overlayImage;
    private bool _isActive = false;

    void Start()
    {
        _overlayImage = transform.GetChild(0).GetComponentInChildren<Image>();
        _overlayImage.enabled = false;

        StartCoroutine("PopButtonActivationRoutine");
    }

    IEnumerator PopButtonActivationRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minTimeOff, _maxTimeOff));
            _overlayImage.enabled = true;
            _isActive = true;
            yield return new WaitForSeconds(Random.Range(_minTimeOn, _maxTimeOn));
            _overlayImage.enabled = false;
            _isActive = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isActive)
        {
            _overlayImage.enabled = false;
            _isActive = false;
            PlayerManager.Instance.AddScore(1);
            PlayerManager.Instance.AddLastGameScore(1);
            Debug.Log("Point awarded");
        }
        
    }
}
