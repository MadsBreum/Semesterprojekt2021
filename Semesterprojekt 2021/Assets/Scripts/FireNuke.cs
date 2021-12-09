using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNuke : MonoBehaviour
{
    public float speed = 10f;

    public string playerNumber;

    public Rigidbody2D rb;
    public GameObject Nuke;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        //playerNumber = GetComponent<AbilitiesFireWizard>().playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(playerNumber + "Ability3"))
        {
            //Instantiate(Nuke, ExplosionPoint.position, ExplosionPoint.rotation);
            Instantiate(Nuke, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // See if it hits the border and destroy it if it does
        if (collider.gameObject.CompareTag("Border"))
        {
            //Debug.Log("Projectile hit " + collider.name);
            
            Destroy(gameObject);
        }
    }
}
