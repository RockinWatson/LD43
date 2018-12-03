using UnityEngine;

public class LevelController : MonoBehaviour {

    static private LevelController _singleton = null;
    static public LevelController Get() { return _singleton; }

    public GameObject BloodLevel;

    private int _score = 0;
    public int GetScore() { return _score; }

    private int _elfsEscaped = 0;
    public int GetEscapedElfs() { return _elfsEscaped; }

    private void Awake()
    {
        _singleton = this;
    }

    public void IncreaseScore() {
        BloodLevel.gameObject.transform.position += transform.up * Time.deltaTime * 2f;
        _score += 1;
    }

    public void IncreasElfsEscaped() {
        _elfsEscaped += 1;
    }
}
