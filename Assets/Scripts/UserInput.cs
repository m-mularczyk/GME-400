using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputFieldName;
    [SerializeField] private TMP_InputField _inputFieldPassword;
    [SerializeField] private TextMeshProUGUI _outputTxt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputFieldName()
    {
        PlayerPrefs.SetString("name", _inputFieldName.text);
    }
    public void InputFieldPassword()
    {
        PlayerPrefs.SetString("password", _inputFieldPassword.text);
    }

    public void OutputTxt()
    {
        _outputTxt.text = "Your username is: " + PlayerPrefs.GetString("name") + " and your password is: " + PlayerPrefs.GetString("password");
    }
}
