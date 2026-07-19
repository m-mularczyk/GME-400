using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropPosition : MonoBehaviour, IDropHandler
{
    private Image _thisImage;

    void Start()
    {
        _thisImage = GetComponent<Image>();
    }

    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.name.Contains("Bomb"))
        {
            eventData.pointerDrag.GetComponent<Draggable>()._oldPosition = _thisImage.rectTransform.localPosition;
        }
    }
}
