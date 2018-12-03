using UnityEngine;

public class Elf : MonoBehaviour {

    [HideInInspector]
    public GameObject ElfExit;
    public float Speed;

    private bool _moveRight = true;
    private SpriteRenderer _sprtRend;

    public GameObject AnimDeath;

    private Rigidbody2D _rb = null;

    private bool _tarred = false;
    public void Tar()
    {
        _tarred = true;
        _sprtRend.color = new Color(.25f, .25f, .25f);
    }

    private bool _poisoned = false;
    private float _poisonTimer = 0.0f;
    private float _poisonTick = 0.5f;
    private bool _poisonStab = false;
    private int _poisonHP = 3;
    static private Color _poisonStabColor = Color.green;
    public void Poison()
    {
        if (!_poisoned)
        {
            _poisoned = true;
            PoisonStab();
        }
    }

    private void Awake()
    {
        _sprtRend = GetComponent<SpriteRenderer>();

        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        float speedAdjusted = (_tarred) ? Speed * 0.5f : Speed;

        if (_moveRight)
        {
            _sprtRend.flipX = false;
            transform.Translate(Vector2.right * Time.deltaTime * speedAdjusted);
        }
        else
        {
            _sprtRend.flipX = true;
            transform.Translate(Vector2.left * Time.deltaTime * speedAdjusted);
        }
    }

    private void FixedUpdate()
    {
        UpdatePoison();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            _moveRight = true;
        }
        if (collision.gameObject.tag == "RightWall")
        {
            _moveRight = false;
        }
        if (collision.gameObject.tag == "Ground")
        {
            _moveRight = SetRandLefRight(0.5f);
        }
        //if (collision.gameObject.tag == "Elf")
        //{
        //    if (_moveRight)
        //    {
        //        _moveRight = false;
        //    }
        //    else
        //    {
        //        _moveRight = true;
        //    }
        //}
        if (collision.gameObject.tag == "ElfExit")
        {
            LevelController.Get().IncreasElfsEscaped();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "DeadElf")
        {
            ElfExplode();
        }
    }

    private bool SetRandLefRight(float chanceOfSuccess)
    {
        return Random.value < chanceOfSuccess;
    }

    public void ElfExplode() {
        GameObject explode = Instantiate(AnimDeath);
        explode.transform.position = transform.position;

        LevelController.Get().IncreaseScore();

        gameObject.SetActive(false);
    }

    public void ResetElf() {
        _tarred = false;
        _poisoned = false;

        _sprtRend.color = Color.white;
    }

    private void UpdatePoison()
    {
        if(_poisoned)
        {
            _poisonTimer += Time.fixedDeltaTime;
            if (!_poisonStab)
            {
                if (_poisonTimer > _poisonTick)
                {
                    PoisonStab();
                }
            }
            else
            {
                _sprtRend.color = _poisonStabColor;
                if(_poisonTimer > (_poisonTick / 5.0f))
                {
                    _rb.AddForce(Vector2.down * 12.0f, ForceMode2D.Impulse);

                    if (--_poisonHP < 0)
                    {
                        ElfExplode();
                    }
                    else
                    {
                        _poisonStab = false;
                        _poisonTimer = 0.0f;

                        _sprtRend.color = Color.white;

                        if (_tarred)
                        {
                            Tar();
                        }
                    }
                }
            }
        }
    }

    private void PoisonStab()
    {
        //@TODO: Poison stab
        _poisonStab = true;
        _poisonTimer = 0.0f;

        _sprtRend.color = _poisonStabColor;

        _rb.AddForce(Vector2.up * 7.0f, ForceMode2D.Impulse);
    }
}
