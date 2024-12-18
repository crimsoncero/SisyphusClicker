using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : Menu
{
    [SerializeField] private ToggleButton _musicToggle;
    [SerializeField] private ToggleButton _sfxToggle;


    public void ToggleMusic()
    {
        if (MMSoundManager.Current.IsMuted(MMSoundManager.MMSoundManagerTracks.Music))
        {
            MMSoundManager.Current.UnmuteMusic();
            _musicToggle.Toggle(true);
        }
        else
        {
            MMSoundManager.Current.MuteMusic();
            _musicToggle.Toggle(false);
        }

    }

    public void ToggleSFX()
    {
        if (MMSoundManager.Current.IsMuted(MMSoundManager.MMSoundManagerTracks.Sfx))
        {
            MMSoundManager.Current.UnmuteSfx();
            _sfxToggle.Toggle(true);
        }
        else
        {
            MMSoundManager.Current.MuteSfx();
            _sfxToggle.Toggle(false);
        }
    }
}
