using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("levelComplete", 2f);


        }
    }

    private void levelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
