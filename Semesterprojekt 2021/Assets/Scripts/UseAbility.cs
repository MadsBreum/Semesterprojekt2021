using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Fireball;
    public GameObject BigProjectile;

    public float cooldownTimeFireball = 2;
    public float cooldownTimeFirering = 2;
    bool offCooldownFireball = true;
    bool offCooldownFirering = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the comma key is pressed once, and if it's not on cooldown, then shoot the projectile
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            if (offCooldownFireball == true)
            {
                UseFireball();
                // Then put it on cooldown
                StartCoroutine("FireballCooldown");
                Debug.Log("On cooldown");
            }
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            if (offCooldownFirering == true)
            {
                UseFirering();
                // Then put it on cooldown
                StartCoroutine("FireringCooldown");
                Debug.Log("On cooldown");
            }
        }
    }

    void UseFireball()
    {
        // Instantiate the Projectile Prefab from the FirePoint
        Instantiate(Fireball, firePoint.position, firePoint.rotation);
    }

    void UseFirering()
    {
        transform.GetChild(1).gameObject.SetActive(true);

    }

    IEnumerator FireballCooldown()
    {
        offCooldownFireball = false;

        yield return new WaitForSeconds(cooldownTimeFireball);

        offCooldownFireball = true;
        Debug.Log("Off cooldown");
    }

    IEnumerator FireringCooldown()
    {
        offCooldownFirering = false;

        yield return new WaitForSeconds(cooldownTimeFireball);

        offCooldownFirering = true;
        Debug.Log("Off cooldown");
    }
}
