using UnityEngine;

public class Elf : MonoBehaviour {

    [SerializeField]
    private float _bloodLevel = 10.0f;

    [HideInInspector]
    public GameObject ElfExit;
    public float Speed;

    private bool _moveRight = true;
    private SpriteRenderer _sprtRend;
    private int _sfxPick;

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
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
            _moveRight = SetRandLefRight(0.8f);
        }
        if (collision.gameObject.tag == "ElfExit" || collision.gameObject.tag == "TopCollider")
        {
            LevelController.Get().IncreasElfsEscaped();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "DeadElf" || collision.gameObject.tag == "Santaur")
        {
            ElfExplode();
        }
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private bool SetRandLefRight(float chanceOfSuccess)
    {
        return Random.value < chanceOfSuccess;
    }

    public void ElfExplode() {
        _sfxPick = Random.Range(1, 7);

        switch (_sfxPick)
        {
            case 1:
                if (!LevelAudioController.elfDeath1.isPlaying)
                {
                    LevelAudioController.elfDeath1.Play();
                }
                break;
            case 2:
                if (!LevelAudioController.elfDeath2.isPlaying)
                {
                    LevelAudioController.elfDeath2.Play();
                }

                break;
            case 3:
                if (!LevelAudioController.elfDeath3.isPlaying)
                {
                    LevelAudioController.elfDeath3.Play();
                }
                break;
            case 4:
                if (!LevelAudioController.elfDeath4.isPlaying)
                {
                    LevelAudioController.elfDeath4.Play();
                }
                break;
            case 5:
                if (!LevelAudioController.elfDeath5.isPlaying)
                {
                    LevelAudioController.elfDeath5.Play();
                }
                break;
            case 6:
                if (!LevelAudioController.elfDeath6.isPlaying)
                {
                    LevelAudioController.elfDeath6.Play();
                }
                break;
            default:
                break;
        }
        GameObject explode = Instantiate(AnimDeath);
        explode.transform.position = transform.position;

        LevelController.Get().IncreaseScore();

        Player.Get().AddBloodLevel(_bloodLevel);

        gameObject.SetActive(false);
    }

    public void ResetElf() {
        _tarred = false;
        _poisoned = false;
        _poisonHP = 3;

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
