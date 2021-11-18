using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject BigProjectile;
    public float cooldownTime = 2;
    bool offCooldown = true;
    

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
            if (offCooldown == true)
            {
                ShootProjectile();
                // Then put it on cooldown
                StartCoroutine("Cooldown");
                Debug.Log("On cooldown");
            }
        }
    }

    void ShootProjectile()
    {
        // Instantiate the Projectile Prefab from the FirePoint
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator Cooldown()
    {
        offCooldown = false;

        yield return new WaitForSeconds(cooldownTime);

        offCooldown = true;
        Debug.Log("Off cooldown");
    }


}
