using UnityEngine;

public class LevelController : MonoBehaviour {

    static private LevelController _singleton = null;
    static public LevelController Get() { return _singleton; }

    public GameObject BloodLevel;

    public int Score = 0;
    public int GetScore() {
        return Score;
    }

    private void Awake()
    {
        _singleton = this;
    }

    public void IncreaseScore() {
        BloodLevel.gameObject.transform.position += transform.up * Time.deltaTime * 2f;
        Score += 1;
    }


}
