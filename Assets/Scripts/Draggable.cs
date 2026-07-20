using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image _image;
    [SerializeField] private Image _imageDrop;
    public Vector3 _oldPosition;

    void Start()
    {
        _image = GetComponent<Image>();
        _oldPosition = _image.rectTransform.localPosition;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
        ResetPosition();
    }

    public void ResetPosition()
    {
        _image.rectTransform.localPosition = _oldPosition;
    }
}
