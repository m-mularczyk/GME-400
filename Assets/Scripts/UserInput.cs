using TMPro;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputFieldName;
    [SerializeField] private TMP_InputField _inputFieldPassword;
    [SerializeField] private TextMeshProUGUI _outputTxt;

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
