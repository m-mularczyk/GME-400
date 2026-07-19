using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] private string _currentGameName;

    void Start()
    {
        PlayerManager.Instance.SetLastGame(_currentGameName);
    }
}
