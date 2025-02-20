using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource;
    [SerializeField] List<AudioSource> _SFXSources;

    [SerializeField, Range(0, 1)] float _musicVolume = 0.5f;
    [SerializeField, Range(0, 1)] float _SFXVolume = 0.5f;

    public static AudioManager Instance { get; private set; }
    
    public void Awake()
    {
        if (!Instance.IsUnityNull() && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetVoulumes();
    }

    private void SetVoulumes()
    {
        _musicSource.volume = Mathf.Clamp(_musicVolume, 0, 1);
        for (int i = 0; i < _SFXSources.Count; i++)
        {
            _SFXSources[i].volume = Mathf.Clamp(_SFXVolume, 0, 1);
        }
    }
    public void PlayMusic(AudioClip clip = null)
    {
        if(clip == null)
        {
            _musicSource.Play();
            return;
        }
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        int sourceCount = _SFXSources.Count;
        for (int i = 0; i < sourceCount; i++)
        {
            if (!_SFXSources[i].isPlaying)
            {
                _SFXSources[i].clip = clip;
                _SFXSources[i].Play();
                return;
            }
        }
        for (int i = 0; i < sourceCount; i++)
        {
            CreateNewAudioSource();
        }
        _SFXSources[_SFXSources.Count - 1].clip = clip;
        _SFXSources[_SFXSources.Count - 1].Play();
    }

    private void CreateNewAudioSource()
    {
        _SFXSources.Add(Instantiate(_SFXSources[0]));
    }

    public void ChangeMusicVolume(Slider slider)
    {
        _musicVolume = slider.value;
        SetVoulumes();
    }

    public void ChangeSFXVolume(Slider slider)
    {
        _SFXVolume = slider.value;
        SetVoulumes();
    }
}
