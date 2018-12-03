﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    [SerializeField]
    private float _bloodCost = 10.0f;
    public float GetBloodCost()
    {
        return _bloodCost;
    }

    private SpriteRenderer _sprite = null;
    private Rigidbody2D _rb = null;

    private bool _armed = false;
    public bool IsArmed()
    {
        return _armed;
    }

    virtual protected void Awake()
    {
        _sprite = this.GetComponent<SpriteRenderer>();
        _rb = this.GetComponent<Rigidbody2D>();

        //@TODO: Set to disabled to start.
        Disable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    public void Place()
    {
        //@TODO: Set to active.
        Activate();

        Player.Get().SpendBloodLevel(_bloodCost);
    }

    private void Disable()
    {
        _armed = false;

        //@TODO: Turn on half alpha.
        Color preColor = _sprite.color;
        preColor.a = 0.5f;
        _sprite.color = preColor;

        //@TODO: Set layer to NOT DeadElf
        this.tag = "Untagged";

        _rb.simulated = false;
    }

    virtual protected void Activate()
    {
        _armed = true;

        //@TODO: Turn on full alpha.
        Color preColor = _sprite.color;
        preColor.a = 1.0f;
        _sprite.color = preColor;

        //@TODO: Set layer to DeadElf
        this.tag = "DeadElf";

        _rb.simulated = true;
    }
}
