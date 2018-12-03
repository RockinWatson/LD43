using UnityEngine;

public class Elf : MonoBehaviour {

    [HideInInspector]
    public GameObject ElfExit;
    public float Speed;

    private bool _moveRight = false;
    private SpriteRenderer _sprtRend;

    public GameObject AnimDeath;

    private bool _tarred = false;
    public void Tar()
    {
        _tarred = true;
        _sprtRend.color = new Color(.25f, .25f, .25f);
    }

    private void Awake()
    {
        _sprtRend = GetComponent<SpriteRenderer>();
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
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "DeadElf")
        {
            ElfExplode();
            LevelController.Get().IncreaseScore();
        }
    }

    private bool SetRandLefRight(float chanceOfSuccess)
    {
        return Random.value < chanceOfSuccess;
    }

    public void ElfExplode() {
        GameObject explode = Instantiate(AnimDeath);
        explode.transform.position = transform.position;

        gameObject.SetActive(false);
    }
}
