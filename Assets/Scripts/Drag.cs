using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image _image;
    private Vector3 _startDragPosition;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var temp = _image.color;
        temp.a = 0.5f;
        _image.color = temp;

        _image.raycastTarget = false;
        //_startDragPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var temp = _image.color;
        temp.a = 1f;
        _image.color = temp;

        _image.raycastTarget = true;
        //transform.position = _startDragPosition;
    }
}
