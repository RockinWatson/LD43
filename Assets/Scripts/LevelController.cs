using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    static private LevelController _singleton = null;
    static public LevelController Get() { return _singleton; }

    public GameObject BloodLevel;

    private Scene _currentScene;

    private float _timer;

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

    public void IncreaseScore() {
        BloodLevel.gameObject.transform.position += transform.up * Time.deltaTime * 2f;
        _score += 1;
    }

    public void IncreasElfsEscaped() {
        _elfsEscaped += 1;
    }
}
