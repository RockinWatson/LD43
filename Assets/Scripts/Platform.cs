using UnityEngine;

public class Platform : MonoBehaviour {

    public Transform targetPos;
    public Transform startPos;

    private bool _start= true;
    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (_start)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
                new Vector2(targetPos.position.x, targetPos.position.y),
                speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPos.position) < 0.1f)
            {
                _start = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
                new Vector2(startPos.position.x, startPos.position.y),
                speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPos.position) < 0.1f)
            {
                {
                    _start = true;
                }
            }
        }
    }
}
