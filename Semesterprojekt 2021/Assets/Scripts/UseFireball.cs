using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFireball : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Fireball;

    public float cooldownTime = 2;
    float timeOffCooldown;


    // Start is called before the first frame update
    void OnEnable()
    {
        timeOffCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeOffCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                LaunchFireball();
                Debug.Log("Fireball used, now on cooldown");
            }
        }
    }

    void LaunchFireball()
    {
        Instantiate(Fireball, firePoint.position, firePoint.rotation);

        timeOffCooldown = Time.time + cooldownTime;
    }
}
