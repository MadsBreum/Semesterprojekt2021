using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesFireWizard : MonoBehaviour
{
    public Transform firePoint;
    //public Transform firePoint2;
    public GameObject Fireball;
    public GameObject FireNuke;
    public GameObject FireRing;

    public float timeBetweenAbilities = 0.5f;
    public float cooldownTimeFireball = 1;
    public float cooldownTimeFirering = 2;
    public float cooldownTimeFireNuke = 3;

    public string playerNumber;

    public bool canMove = true;
    public bool canUseAbility;

    bool offCooldownFireball;
    bool offCooldownFirering;
    bool offCooldownFireNuke;

    private Animator animator;

    // Start is called before the first frame update
    void OnEnable()
    {
        canUseAbility = true;

        offCooldownFireball = true;
        offCooldownFirering = true;
        offCooldownFireNuke = true;

        FireRing.gameObject.SetActive(false);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = GetComponent<PlayerMovementController>().canMove;

        bool touchingGround = GetComponent<PlayerMovementController>().touchingGround;


        if (canMove && canUseAbility)
        {/*
            // If the ability key is pressed once, check if it's off cooldown
            if (Input.GetKeyDown(KeyCode.Comma) && offCooldownFireball)
            {
                // Use the ability
                StartCoroutine("UseFireball");
            }*/
            // If the ability key is pressed once, check if it's off cooldown

            if (Input.GetButtonDown(playerNumber + "Ability1") && offCooldownFireball)
            {
                // Use the ability
                StartCoroutine("TimeBetweenAbilities");
                StartCoroutine("UseFireball");

                animator.SetTrigger("Attack");
            }

            else if (Input.GetButtonDown(playerNumber + "Ability2") && offCooldownFirering)
            {
                // Use the ability
                StartCoroutine("TimeBetweenAbilities");
                StartCoroutine("UseFirering");
            }
            // If the ability key is pressed once, check if it's off cooldown and if the player is touching the ground
            else if (Input.GetButtonDown(playerNumber + "Ability3") && offCooldownFireNuke && GetComponent<PlayerHealth>().p_UltimatePoint == 2)
            {
                // Use the ability
                StartCoroutine("TimeBetweenAbilities");
                StartCoroutine("UseFireNuke");
                GetComponent<PlayerHealth>().OnUseUltimate();

                animator.SetTrigger("Attack");
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

    IEnumerator TimeBetweenAbilities()
    {
        canUseAbility = false;

        yield return new WaitForSeconds(timeBetweenAbilities);

        canUseAbility = true;
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
        FireRing.gameObject.SetActive(true);

        offCooldownFirering = false;
        Debug.Log("Firering on cooldown");

        yield return new WaitForSeconds(cooldownTimeFireball);

        offCooldownFirering = true;
        Debug.Log("Firering off cooldown");
    }
    
    IEnumerator UseFireNuke()
    {
        // Instantiate fireball prefab in the direction the player is looking
        FireNuke.GetComponent<FireNuke>().playerNumber = playerNumber;
        Instantiate(FireNuke, firePoint.position, firePoint.rotation);

        //FireNuke.GetComponent<FireNuke>().playerNumber = playerNumber;
        // Put it on cooldown
        offCooldownFireNuke = false;
        Debug.Log("Fireball on cooldown");

        yield return new WaitForSeconds(cooldownTimeFireNuke);
        // Put it off cooldown
        offCooldownFireNuke = true;
        Debug.Log("Fireball off cooldown");
    }

    public IEnumerator Stunned(float stunTime)
    {
        canUseAbility = false;
        Debug.Log("Stunned for " + stunTime + " seconds");

        yield return new WaitForSeconds(stunTime);

        canUseAbility = true;
        Debug.Log("Not stunned anymore");
    }
}
