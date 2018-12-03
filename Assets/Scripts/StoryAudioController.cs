using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryAudioController : MonoBehaviour {

    private bool _select() { return (Input.GetKeyDown(KeyCode.Space)); }
    private bool isStory;
    public AudioSource storyMusic;
    public AudioSource select;

    private float selectVolume;

    // Use this for initialization
    void Awake()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        isStory = true;
        InitAudio();
    }

    // Update is called once per frame
    void Update()
    {
        if ((_select()) && (isStory))
        {
            StartCoroutine(LoadStory());
        }

    }

    private void InitAudio()
    {
        selectVolume = .5f;
        AudioSource[] audio = GetComponents<AudioSource>();
        storyMusic = audio[0];
        select = audio[1];
        select.playOnAwake = false;
        select.volume = selectVolume;
        storyMusic.Play();
        storyMusic.loop = true;

    }

    IEnumerator LoadStory()
    {
        isStory = false;
        select.Play();
        storyMusic.Stop();
        yield return new WaitForSeconds(2.8f);
        Debug.Log("Loading Level");
        SceneManager.LoadScene("RopeTestScene");
    }
}
