using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    private bool _select() { return (Input.GetKeyDown(KeyCode.Space)); }
    private bool isTitle;
    public AudioSource titleMusic;
    public AudioSource select;

    private float selectVolume;

    // Use this for initialization
    void Awake () {
        Scene currentScene = SceneManager.GetActiveScene();
        isTitle = true;
        InitAudio();
	}
	
	// Update is called once per frame
	void Update () {
        if ((_select()) && (isTitle))
            {
            StartCoroutine(LoadStory());
        }
		
	}

    private void InitAudio()
    {
        selectVolume = .5f;
        AudioSource[] audio = GetComponents<AudioSource>();
        titleMusic = audio[0];
        select = audio[1];
        select.playOnAwake = false;
        select.volume = selectVolume;
        titleMusic.Play();
        titleMusic.loop = true;

    }

    IEnumerator LoadStory()
    {
        isTitle = false;
        select.Play();
        titleMusic.Stop();
        yield return new WaitForSeconds(2.8f);
        Debug.Log("Loading Story");
        SceneManager.LoadScene("StoryTutorial");
    }
}
