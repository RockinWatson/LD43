using UnityEngine;

public class ExitLevelController : MonoBehaviour {

    static private ExitLevelController _singleton = null;
    static public ExitLevelController Get() { return _singleton; }

    public GameObject BloodLevel;

    public int Score = 0;

    private void Awake()
    {
        _singleton = this;
    }

    public void IncreaseScore() {
        BloodLevel.gameObject.transform.position += transform.up * Time.deltaTime * 1.1f;
        Score += 1;
    }
}
