using TMPro;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    void Start()
    {
        _dropdown = GetComponent<TMP_Dropdown>();

        // Przypiêcie listenera do zdarzenia onValueChanged
        _dropdown.onValueChanged.AddListener(OnDropdownChanged);

        // Dodanie nowej opcji w kodzie
        _dropdown.options.Add(new TMP_Dropdown.OptionData("Opcja dodana w kodzie"));
        _dropdown.RefreshShownValue();
    }


    private void OnDropdownChanged(int value)
    {
        // Odczytanie zawartoœci tekstowej wybranej opcji
        Debug.Log("Wybrano opcjê: " + _dropdown.options[value].text);
    }

    private void OnDestroy()
    {
        _dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
    }

}
