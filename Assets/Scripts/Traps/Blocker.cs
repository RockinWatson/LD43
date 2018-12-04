using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : Trap {

    protected override void Activate()
    {
        base.Activate();

        this.tag = "Untagged";
    }
}
