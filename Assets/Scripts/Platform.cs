using UnityEngine;

public class Platform : MonoBehaviour {

    public Transform targetPos;
    public Transform startPos;

    bool _right = true;
    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (_right)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            if (Vector2.Distance(transform.position, targetPos.position) < 0.1f)
            {
                _right = false;
            }
        }
        else
        {
            transform.position += transform.right * -speed * Time.deltaTime;
            if (Vector2.Distance(transform.position, startPos.position) < 0.1f)
            {
                {
                    _right = true;
                }
            }
        }
    }
}
