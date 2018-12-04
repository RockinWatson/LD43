using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : Trap {

    private BoxCollider2D _collider = null;
    private Collider2D[] _colliders = null;

    protected override void Awake()
    {
        base.Awake();

        _collider = this.GetComponent<BoxCollider2D>();
        _colliders = new Collider2D[20];
    }

    protected override void Activate()
    {
        base.Activate();

        this.tag = "Untagged";
    }

    public void Poison()
    {
        if (IsArmed())
        {
            int count = _collider.GetContacts(_colliders);
            if (count > 0)
            {
                for (int i = 0; i < count; ++i)
                {
                    if (_colliders[i].tag == "Elf")
                    {
                        Elf elf = _colliders[i].GetComponent<Elf>();
                        elf.Poison();

                        TallyKill();
                    }
                }
            }
        }
    }
}
