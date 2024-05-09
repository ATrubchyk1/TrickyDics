using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _activeSoundSprite;
    [SerializeField] private Sprite _inactiveSoundSprite;
    
    private int _soundVolume;
    
    private void Awake()
    {
        _soundVolume = PlayerPrefs.GetInt(GlobalConstants.SOUND_ENABLED_PREFS_KEY, 1);
        SetSoundValue();
    }
    
    private void SaveSoundVolume()
    {
        PlayerPrefs.SetInt(GlobalConstants.SOUND_ENABLED_PREFS_KEY, _soundVolume);
        PlayerPrefs.Save();
    }
    private void SetSoundValue()
    {
        AudioListener.volume = _soundVolume;
        _image.sprite = _soundVolume == 1 ? _activeSoundSprite : _inactiveSoundSprite;
    }
    
    [UsedImplicitly]
    public void ToggleSound() // Вызывается при нажатии на кнопку звука
    {
        _soundVolume = _soundVolume == 1 ? 0 : 1;
        SetSoundValue();
        SaveSoundVolume();
    }
}
