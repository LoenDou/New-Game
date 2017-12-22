﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton <AudioManager >
{

    [SerializeField]
    private GameSetting gameSetting;
    [SerializeField]
    private AudioMixer mixer;
    private float musicValume;
    private float effectValume;

    protected override void Awake()
    {
        base.Awake();
        musicValume = gameSetting.musicValume;
        effectValume = gameSetting.effectValume;
    }
    public float MusicValume
    {
        get { return musicValume; }
        set {
            gameSetting.musicValume = value;
            musicValume = value;
            mixer.SetFloat("music", value);
        }
    }
    public float EffectValume
    {
        get { return effectValume; }
        set
        {
            gameSetting.effectValume = value;
            effectValume = value;
            mixer.SetFloat("music", value);
        }
    }


}
