using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    static private LevelController _singleton = null;
    static public LevelController Get() { return _singleton; }

    private Scene _currentScene;

    private int _seconds = 120;
    public int GetSeconds() { return _seconds; }

    private int _score = 0;
    public int GetScore() { return _score; }

    private int _elfsEscaped = 0;
    public int GetEscapedElfs() { return _elfsEscaped; }

    private void Awake(){
        DontDestroyOnLoad(gameObject);
       
        _singleton = this;
        _currentScene = SceneManager.GetActiveScene();

        if (_currentScene.name == "JTestScene" )
        {
            _seconds = 120;
            _score = 0;
            _elfsEscaped = 0;
        }
    }

    private void Start()
    {
        if (_currentScene.name == "JTestScene")
        {
            StartCoroutine("LoseTime");
            Time.timeScale = 1;
        }
    }

    public void IncreaseScore() {
        _score += 1;
    }

    public void IncreasElfsEscaped() {
        _elfsEscaped += 1;
    }

    IEnumerator LoseTime() {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _seconds--;
        }
    }
}
