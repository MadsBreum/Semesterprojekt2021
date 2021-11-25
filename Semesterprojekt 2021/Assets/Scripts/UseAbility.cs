using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAbility : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject Fireball;
    public GameObject FireNuke;
    //public GameObject IceSpikes;

    public float cooldownTimeFireball = 1;
    public float cooldownTimeFirering = 2;
    public float cooldownTimeFireNuke = 3;
    //public float cooldownTimeIceSpikes = 1;

    public string playerNumber = "Player2";

    public bool canUseAbility = true;
    bool offCooldownFireball = true;
    bool offCooldownFirering = true;
    bool offCooldownFireNuke = true;
    //bool offCooldownIceSpikes = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool touchingGround = GetComponent<PlayerMovementController>().touchingGround;

        if (canUseAbility)
        {/*
            // If the ability key is pressed once, check if it's off cooldown
            if (Input.GetKeyDown(KeyCode.Comma) && offCooldownFireball)
            {
                // Use the ability
                StartCoroutine("UseFireball");
            }*/
            // If the ability key is pressed once, check if it's off cooldown
            if (Input.GetKeyDown(KeyCode.Period) && offCooldownFirering)
            {
                // Use the ability
                StartCoroutine("UseFirering");
            }
            // If the ability key is pressed once, check if it's off cooldown and if the player is touching the ground
            if (Input.GetKeyDown(KeyCode.Minus) && offCooldownFireNuke)
            {
                // Use the ability
                StartCoroutine("UseFireNuke");
            }

            if (Input.GetButtonDown(playerNumber + "Ability1") && offCooldownFireball)
            {
                // Use the ability
                StartCoroutine("UseFireball");
            }

            /*
            // If the ability key is pressed once, check if it's off cooldown and if the player is touching the ground
            if (Input.GetKeyDown(KeyCode.Minus) && offCooldownIceSpikes && touchingGround)
            {
                // Use the ability
                StartCoroutine("UseIceSpikes");
            }
            */
        }
    }

    IEnumerator UseFireball()
    {
        // Instantiate fireball prefab in the direction the player is looking
        Instantiate(Fireball, firePoint.position, firePoint.rotation);
        // Put it on cooldown
        offCooldownFireball = false;
        Debug.Log("Fireball on cooldown");

        yield return new WaitForSeconds(cooldownTimeFireball);
        // Put it off cooldown
        offCooldownFireball = true;
        Debug.Log("Fireball off cooldown");
    }

    IEnumerator UseFirering()
    {
        transform.GetChild(1).gameObject.SetActive(true);

        offCooldownFirering = false;
        Debug.Log("Firering on cooldown");

        yield return new WaitForSeconds(cooldownTimeFireball);

        offCooldownFirering = true;
        Debug.Log("Firering off cooldown");
    }
    
    IEnumerator UseFireNuke()
    {
        // Instantiate fireball prefab in the direction the player is looking
        Instantiate(FireNuke, firePoint.position, firePoint.rotation);
        // Put it on cooldown
        offCooldownFireNuke = false;
        Debug.Log("Fireball on cooldown");

        yield return new WaitForSeconds(cooldownTimeFireNuke);
        // Put it off cooldown
        offCooldownFireNuke = true;
        Debug.Log("Fireball off cooldown");
    }
    /*
    IEnumerator UseIceSpikes()
    {
        Instantiate(IceSpikes, firePoint2.position, firePoint2.rotation);

        offCooldownIceSpikes = false;
        Debug.Log("IceSpikes on cooldown");

        yield return new WaitForSeconds(cooldownTimeIceSpikes);

        offCooldownIceSpikes = true;
        Debug.Log("IceSpikes off cooldown");
    }
    */
    public IEnumerator Stunned(float stunTime)
    {
        canUseAbility = false;
        Debug.Log("Stunned for " + stunTime + " seconds");

        yield return new WaitForSeconds(stunTime);

        canUseAbility = true;
        Debug.Log("Not stunned anymore");
    }
}
