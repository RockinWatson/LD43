using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudioController : MonoBehaviour {

    //public AudioSource[] elfDeath;

    public AudioSource levelMusic;
    public static AudioSource elfDeath1;
    public static AudioSource elfDeath2;
    public static AudioSource elfDeath3;
    public static AudioSource elfDeath4;
    public static AudioSource elfDeath5;
    public static AudioSource elfDeath6;
    public static AudioSource bubbly;
    public static AudioSource buzzsaw;
    public static AudioSource springboard;
    public static AudioSource explosion;
    public static AudioSource placeTrap;

    // Use this for initialization
    void Awake () {
        InitAudio();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        levelMusic = audio[0];
        elfDeath1 = audio[1];
        elfDeath2 = audio[2];
        elfDeath3 = audio[3];
        elfDeath4 = audio[4];
        elfDeath5 = audio[5];
        elfDeath6 = audio[6];
        bubbly = audio[7];
        buzzsaw = audio[8];
        springboard = audio[9];
        explosion = audio[10];
        placeTrap = audio[11];

        audio[1].volume = .5f;
        audio[2].volume = .5f;  
        audio[3].volume = .5f;  
        audio[4].volume = .5f;  
        audio[5].volume = .5f;  
        audio[6].volume = .5f;  
        audio[7].volume = .5f;
        audio[8].volume = .15f;
        audio[9].volume = .4f;
        audio[10].volume = .7f;
        audio[11].volume = .3f;
    }
}
