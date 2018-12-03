using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blood : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BloodFull")
        {
            Debug.Log("Game Should Be over Or Change Scene!!!");
            SceneManager.LoadScene("GameOver");
        }
    }
}
