using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        _scoreGui.text = LevelController.Get().GetSeconds().ToString();
    }
}
