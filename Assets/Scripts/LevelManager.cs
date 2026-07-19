using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;


    void Start()
    {
        _text.text = _slider.value.ToString();
    }

    public void LoadNextScene()
    {
        StartCoroutine("LoadLevel");
        Debug.Log("Started loading");
    }


    IEnumerator LoadLevel()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("NextScene");
        yield return null;
        while (!asyncOperation.isDone)
        {
            //_slider.value = asyncOperation.progress;
            //_text.text = asyncOperation.progress.ToString();

            // Poni¿szy zapis modyfikuje wyœwietlane dane, bo async operation zatrzymuje siê na 0.9 jak ca³a scena zosta³a ju¿ za³adowana, a ostatnie 10% jest zarezerwowane na aktywacjê nowej sceny. Samo ³adowanie ju¿ zosta³o zakoñczone, dlatego ten kod wprowadza poprawkê ¿eby dla u¿ytkownika by³o jasne, ¿e nowa scena zosta³a ju¿ za³adowana.
            _slider.value = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            _text.text = $"{Mathf.RoundToInt(asyncOperation.progress / 0.9f * 100)}%";
            yield return null;
        }
    }
}
