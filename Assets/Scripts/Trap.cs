using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    private SpriteRenderer _sprite = null;

    private void Awake()
    {
        _sprite = this.GetComponent<SpriteRenderer>();

        //@TODO: Set to disabled to start.
        Disable();
    }

    public void Place()
    {
        //@TODO: Set to active.
        Activate();
    }

    private void Disable()
    {
        //@TODO: Turn on half alpha.
        Color preColor = _sprite.color;
        preColor.a = 0.5f;
        _sprite.color = preColor;

        //@TODO: Set layer to NOT DeadElf
        this.tag = "Untagged";
    }

    private void Activate()
    {
        //@TODO: Turn on full alpha.
        Color preColor = _sprite.color;
        preColor.a = 1.0f;
        _sprite.color = preColor;

        //@TODO: Set layer to DeadElf
        this.tag = "DeadElf";
    }
}
