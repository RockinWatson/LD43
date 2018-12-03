using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    private TextMesh _scoreGui;

    // Use this for initialization
    void Start()
    {
        _scoreGui = gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.Get().GetSeconds() <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        _scoreGui.text = LevelController.Get().GetSeconds().ToString();
    }
}
