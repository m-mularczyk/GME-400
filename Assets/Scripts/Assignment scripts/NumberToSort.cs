using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class NumberToSort : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private int _minNumber = 1;
    [SerializeField] private int _maxNumber = 99;
    [SerializeField] private int _numberToSort;
    [SerializeField] private TextMeshProUGUI _numberText;
    private NumberDropSlot _currentSlot;
    private Image _image;
    private int _siblingsCount;


    void Start()
    {
        _numberToSort = Random.Range(_minNumber, _maxNumber + 1);
        _numberText.text = _numberToSort.ToString();
        _image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //
        _image.raycastTarget = false;
        transform.SetSiblingIndex(transform.parent.childCount - 1);

        if (_currentSlot != null)
        {
            _currentSlot.ResetSlot();
            _currentSlot = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //
        _image.raycastTarget = true;
    }

    public int GetNumberToSort()
    {
        return _numberToSort;
    }

    public void SetSlot(NumberDropSlot slot)
    {
        _currentSlot = slot;
    }
}
