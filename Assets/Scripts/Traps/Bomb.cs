using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Trap {

    [SerializeField]
    private float _proximityRadius = 1.0f;

    [SerializeField]
    private float _explodeRadius = 1.5f;

    private Collider2D[] _colliders = null;

    protected override void Awake()
    {
        base.Awake();

        _colliders = new Collider2D[20];
    }

    protected override void Activate()
    {
        base.Activate();

        this.tag = "Untagged";
    }

    public void ProximityCheck()
    {
        if (IsArmed())
        {
            bool selfDestruct = false;
            int count = Physics2D.OverlapCircleNonAlloc(this.transform.position, _proximityRadius, _colliders);
            if (count > 0)
            {
                for (int i = 0; i < count; ++i)
                {
                    if (_colliders[i].tag == "Elf")
                    {
                        selfDestruct = true;
                        break;
                    }
                }
            }

            if (selfDestruct)
            {
                count = Physics2D.OverlapCircleNonAlloc(this.transform.position, _explodeRadius, _colliders);
                if (count > 0)
                {
                    for (int i = 0; i < count; ++i)
                    {
                        if (_colliders[i].tag == "Elf")
                        {
                            Elf elf = _colliders[i].GetComponent<Elf>();
                            elf.ElfExplode();
                            LevelAudioController.explosion.Play();
                        }
                    }
                }

                Destroy(this.gameObject);
            }
        }
    }
}
