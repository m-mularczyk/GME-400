using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager Instance { get; private set; }

    [SerializeField] private AudioClip _buttonClickSound;
    [SerializeField] private AudioClip _pickUpSound;
    [SerializeField] private AudioClip _dropSound;
    [SerializeField] private AudioClip _successSound;
    [SerializeField] private AudioClip _popSound;
    [SerializeField] private AudioClip _hoverSound;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _audioSource = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }

    public void PlayButtonClick()
    {
        _audioSource.PlayOneShot(_buttonClickSound);
    }

    public void PlaySucessSound()
    {
        _audioSource.PlayOneShot(_successSound);
    }

    public void PlayDropSound()
    {
        _audioSource.PlayOneShot(_dropSound);
    }

    public void PlayPopSound()
    {
        _audioSource.PlayOneShot(_popSound);
    }

    public void PlayHoverSound()
    {
        _audioSource.PlayOneShot(_hoverSound);
    }

    public void PlayPickUpSound()
    {
        _audioSource.PlayOneShot(_pickUpSound);
    }
}