using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : Trap {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Activate()
    {
        base.Activate();

        this.tag = "Untagged";
    }
}
