using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BorderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            // Just for testing, so you don't have to stop and start the game everytime
            //SceneManager.LoadScene("LavaMap");
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.SetActive(false);
            // Just for testing, so you don't have to stop and start the game everytime
            //SceneManager.LoadScene("LavaMap");
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);

            SceneManager.LoadScene("LavaMap");
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.SetActive(false);

            SceneManager.LoadScene("LavaMap");
        }
    }
    */
}
