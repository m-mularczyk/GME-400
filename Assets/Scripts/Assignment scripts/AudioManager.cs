using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager Instance { get; private set; }

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;


    [SerializeField] private AudioClip _bgMusic;
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

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        _musicSource.clip = _bgMusic;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayButtonClick()
    {
        _sfxSource.PlayOneShot(_buttonClickSound);
    }

    public void PlaySucessSound()
    {
        _sfxSource.PlayOneShot(_successSound);
    }

    public void PlayDropSound()
    {
        _sfxSource.PlayOneShot(_dropSound);
    }

    public void PlayPopSound()
    {
        _sfxSource.PlayOneShot(_popSound);
    }

    public void PlayHoverSound()
    {
        _sfxSource.PlayOneShot(_hoverSound);
    }

    public void PlayPickUpSound()
    {
        _sfxSource.PlayOneShot(_pickUpSound);
    }
}