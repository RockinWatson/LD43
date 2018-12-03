using System;
using UnityEngine;

public class Wobble : MonoBehaviour {

    private Vector2 _floatY;
    private float _originalY;
    public float FloatStrength;
    public float FloatSpeed;

    void Start()
    {
        _originalY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, _originalY + ((float)Math.Sin(Time.time * FloatSpeed) * FloatStrength), transform.position.z);
    }
}
