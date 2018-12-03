using UnityEngine;

public class ElfsEscaped : MonoBehaviour {

    private TextMesh _scoreGui;

    // Use this for initialization
    void Start()
    {
        _scoreGui = gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreGui.text = LevelController.Get().GetEscapedElfs().ToString();
    }
}
