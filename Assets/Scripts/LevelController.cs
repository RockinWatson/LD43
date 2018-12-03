using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    static private LevelController _singleton = null;
    static public LevelController Get() { return _singleton; }

    public GameObject BloodLevel;
    private Vector3 _bloodLevelVisualStartPos;
    private Vector3 _bloodLevelVisualZeroPos;
    private float _bloodLevelMaxForVisual = 1000.0f;
    private float _bloodLevelMaxPosY = 8.1f;

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

        //_bloodLevelVisualStartPos = BloodLevel.transform.position;
    }

    private void Start()
    {
        float scaleToZero = Player.Get().GetBloodLevel() / _bloodLevelMaxForVisual * _bloodLevelMaxPosY;
        _bloodLevelVisualZeroPos = BloodLevel.transform.position - (Vector3.up * scaleToZero);
    }

    private void Update()
    {

        UpdateBloodLevelVisual();
    }

    public void IncreaseScore() {
        //BloodLevel.gameObject.transform.position += transform.up * Time.deltaTime * 2f;
        _score += 1;
    }

    public void IncreasElfsEscaped() {
        _elfsEscaped += 1;
    }

    private void UpdateBloodLevelVisual()
    {
        float bloodScale = Mathf.Min(Player.Get().GetBloodLevel(), _bloodLevelMaxForVisual) / _bloodLevelMaxForVisual * _bloodLevelMaxPosY;
        BloodLevel.transform.position = _bloodLevelVisualZeroPos + (Vector3.up * bloodScale);
    }
}
