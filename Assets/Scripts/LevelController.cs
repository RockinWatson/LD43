using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    static private LevelController _singleton = null;
    static public LevelController Get() { return _singleton; }

    private Scene _currentScene;

    private float _timer;
    private int _seconds;
    public int GetSeconds() { return _seconds; }

    private int _score = 0;
    public int GetScore() { return _score; }

    private int _elfsEscaped = 0;
    public int GetEscapedElfs() { return _elfsEscaped; }

    private void Awake(){
        DontDestroyOnLoad(gameObject);

        _timer = 0;
        _singleton = this;
        _currentScene = SceneManager.GetActiveScene();

        if (_currentScene.name == "JTestScene" )
        {
            _score = 0;
            _elfsEscaped = 0;
        }
    }

    private void Update()
    {
        UpdateTimer();
    }

    public void IncreaseScore() {
        _score += 1;
    }

    public void IncreasElfsEscaped() {
        _elfsEscaped += 1;
    }

    private void UpdateTimer() {
        _timer += Time.deltaTime;
        _seconds = (int)(_timer % 60);
    }
}
