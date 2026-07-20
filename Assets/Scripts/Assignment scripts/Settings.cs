using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundFXSlider;
    [SerializeField] private AudioMixer _audioMixer;

    void Start()
    {
        if (_audioMixer == null)
            Debug.LogError("Audio Mixer not found");

        float value;

        if (_audioMixer.GetFloat("Master", out value))
            _masterVolumeSlider.value = value;

        if (_audioMixer.GetFloat("BG_Music", out value))
            _musicVolumeSlider.value = value;

        if (_audioMixer.GetFloat("SFX_Audio", out value))
            _soundFXSlider.value = value;
    }

    void Update()
    {
        _audioMixer.SetFloat("Master", _masterVolumeSlider.value);
        _audioMixer.SetFloat("BG_Music", _musicVolumeSlider.value);
        _audioMixer.SetFloat("SFX_Audio", _soundFXSlider.value);
    }
}
