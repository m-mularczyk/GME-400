using UnityEngine;
using UnityEngine.EventSystems;

public class NumberDropSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private int _currentlyPlacedNumber = 0;
    [SerializeField] PlacedNumbers _placedNumbers;

    public void OnDrop(PointerEventData eventData)
    {
        NumberToSort number = eventData.pointerDrag.GetComponent<NumberToSort>();

        if (number != null)
        {
            eventData.pointerDrag.transform.position = transform.position;

            _currentlyPlacedNumber = number.GetNumberToSort();

            number.SetSlot(this);

            _placedNumbers.CheckNumbers();
        }

        UIAudioManager.Instance.PlayDropSound();

    }

    public void ResetSlot()
    {
        _currentlyPlacedNumber = 0;
    }

    public int CurrentlyPlacedNumber()
    {
        return _currentlyPlacedNumber;
    }
}
