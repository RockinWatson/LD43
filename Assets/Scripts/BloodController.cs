using UnityEngine;

public class BloodController : MonoBehaviour {

    public GameObject BloodLevel;
    private Vector3 _bloodLevelVisualStartPos;
    private Vector3 _bloodLevelVisualZeroPos;
    private float _bloodLevelMaxForVisual = 1000.0f;
    private float _bloodLevelMaxPosY = 8.1f;

    // Use this for initialization
    void Start () {
        float scaleToZero = Player.Get().GetBloodLevel() / _bloodLevelMaxForVisual * _bloodLevelMaxPosY;
        _bloodLevelVisualZeroPos = BloodLevel.transform.position - (Vector3.up * scaleToZero);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateBloodLevelVisual();
    }

    private void UpdateBloodLevelVisual()
    {
        float bloodScale = Mathf.Min(Player.Get().GetBloodLevel(), _bloodLevelMaxForVisual) / _bloodLevelMaxForVisual * _bloodLevelMaxPosY;
        BloodLevel.transform.position = _bloodLevelVisualZeroPos + (Vector3.up * bloodScale);
    }
}
