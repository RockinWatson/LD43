using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santaur : MonoBehaviour {

    public Transform targetPos;
    public Transform startPos;
    public float speed;

    public void Update()
    {
        if (LevelController.Get().GetSeconds() <= 60)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
                new Vector2(targetPos.position.x, targetPos.position.y),
                speed * Time.deltaTime);
        }    
    }
}
