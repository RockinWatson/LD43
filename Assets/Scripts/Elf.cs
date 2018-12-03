using UnityEngine;

public class Elf : MonoBehaviour {

    [HideInInspector]
    public GameObject ElfExit;
    public float Speed;

    private bool _moveRight = false;
    private SpriteRenderer _sprtRend;

    public GameObject AnimDeath;

    private void Awake()
    {
        _sprtRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {     

        if (_moveRight)
        {
            _sprtRend.flipX = false;
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
        else
        {
            _sprtRend.flipX = true;
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
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
            LevelController.Get().IncreasElfsEscaped();
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
