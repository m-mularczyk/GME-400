using UnityEngine;
using UnityEngine.UI;

public class ForceLayoutUpdate : MonoBehaviour
{
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}