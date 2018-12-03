using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudioController : MonoBehaviour {

    //public AudioSource[] elfDeath;

    public AudioSource levelMusic;
    public AudioSource elfDeath1;
    public AudioSource elfDeath2;
    public AudioSource elfDeath3;
    public AudioSource elfDeath4;
    public AudioSource elfDeath5;
    public AudioSource elfDeath6;
    public AudioSource bubbly;
    public AudioSource buzzsaw;
    public AudioSource springboard;
    public AudioSource explosion;
    public AudioSource placeTrap;

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
    }
}
