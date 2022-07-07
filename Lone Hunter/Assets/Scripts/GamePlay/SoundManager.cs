using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundMusic;
    public AudioSource soundEffect;

    [SerializeField] private SoundType[] arrayofSounds;
    [SerializeField] private WeaponSoundType[] arrayofWeaponSound;
    public bool isMute = false;
    public float Volume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;                                         // setting levelmanager to the current instance
            DontDestroyOnLoad(gameObject);                          //  we dont want to destroy our levelmanager
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(Sounds.BackGround_Music);
    }

    public void Mute(bool _status)
    {
        isMute = _status;
    }

    public void SetVolume(float _volume)
    {
        Volume = _volume;
        soundEffect.volume = Volume;
        soundMusic.volume = Volume;
    }

    public void PlayMusic(Sounds _sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(_sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("no audio found for sound type " + _sound);
        }
    }

    public void Play(Sounds _sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(_sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("no audio found for sound type " + _sound);
        }
    }

    private AudioClip getSoundClip(Sounds _sound)
    {
        SoundType sound = Array.Find(arrayofSounds, item => item.soundType == _sound);
        if (sound != null)
        {
            return sound.soundClip;
        }
        return null;

    }

    public void PlayWeaponSound(WeaponSound _sound)
    {
        if (isMute)
            return;

        AudioClip clip = getWeaponSoundClip(_sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("no audio found for sound type " + _sound);
        }
    }

    private AudioClip getWeaponSoundClip(WeaponSound _sound)
    {
        WeaponSoundType sound = Array.Find(arrayofWeaponSound, item => item.weaponSound == _sound);
        if (sound != null)
        {
            return sound.weaponClip;
        }
        return null;

    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;    
    public AudioClip soundClip;
}

[Serializable]
public class WeaponSoundType
{
    public WeaponSound weaponSound;
    public AudioClip weaponClip;
}

public enum Sounds
{//11
    ButtonClick,
    BackGround_Music,
    Jungle_Music,
    Player_Death,
    Enemy_Scream,
    Enemy_Attack,
    Enemy_Death,
    Boar_Death,
    Boar_Attack,
}

public enum WeaponSound
{//7
    AXE,
    Revolver,
    Shotgun_Shoot,    
    Assualt,
    Spear,
    Bow
}

