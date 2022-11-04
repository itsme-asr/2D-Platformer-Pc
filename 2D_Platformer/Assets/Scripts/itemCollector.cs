using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int apples = 0;
    [SerializeField] private Text appleText;
    [SerializeField] private AudioSource itemsSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            itemsSoundEffect.Play();
            Destroy(collision.gameObject);
            apples++;
            appleText.text = "Fruit: " + apples;

        }
    }
}
