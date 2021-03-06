using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesIceWizard : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform iceProjectile1;
    public Transform iceProjectile2;
    public Transform iceProjectile3;
    public GameObject IceShard;
    public GameObject IceSpikes;
    public GameObject IceBeam;

    public float timeBetweenAbilities = 0.5f;
    public float cooldownTimeIceShards = 1;
    public float cooldownTimeIceSpikes = 2;
    public float cooldownTimeIceBeam = 2;

    public string playerNumber;

    public bool canMove = true;
    public bool canUseAbilities;

    bool offCooldownIceShards;
    bool offCooldownIceSpikes;
    bool offCooldownIceBeam;

    private Animator animator;

    // Start is called before the first frame update
    void OnEnable()
    {
        canUseAbilities = true;

        offCooldownIceShards = true;
        offCooldownIceSpikes = true;
        offCooldownIceBeam = true;

        IceBeam.gameObject.SetActive(false);
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

        if (canMove && canUseAbilities)
        {
            // If the ability key is pressed once, check if it's off cooldown
            if (Input.GetButtonDown(playerNumber + "Ability1") && offCooldownIceShards)
            {
                // Use the ability
                StartCoroutine("TimeBetweenAbilities");
                StartCoroutine("UseIceShards");

                animator.SetTrigger("Attack");
            }

            // If the ability key is pressed once, check if it's off cooldown and if the player is touching the ground
            else if (Input.GetButtonDown(playerNumber + "Ability2") && offCooldownIceSpikes && touchingGround)
            {
                // Use the ability
                StartCoroutine("TimeBetweenAbilities");
                StartCoroutine("UseIceSpikes");
            }

            // If the ability key is pressed once, check if it's off cooldown
            else if (Input.GetButtonDown(playerNumber + "Ability3") && offCooldownIceBeam && GetComponent<PlayerHealth>().p_UltimatePoint == 2)
            {
                // Use the ability
                StartCoroutine("TimeBetweenAbilities");
                StartCoroutine("UseIceBeam");
                GetComponent<PlayerHealth>().OnUseUltimate();

                //animator.SetBool("BeamAttack", true);
            }
        }
    }

    IEnumerator TimeBetweenAbilities()
    {
        canUseAbilities = false;

        yield return new WaitForSeconds(timeBetweenAbilities);

        canUseAbilities = true;
    }

    IEnumerator UseIceShards()
    {
        // Instantiate fireball prefab in the direction the player is looking
        //Quaternion iceShard2 = new Quaternion(0, 0, 45, 1);
        //Quaternion iceShard3 = new Quaternion(0, 0, -45, 1);
        Instantiate(IceShard, iceProjectile1.position, iceProjectile1.rotation);
        Instantiate(IceShard, iceProjectile2.position, iceProjectile2.rotation);
        Instantiate(IceShard, iceProjectile3.position, iceProjectile3.rotation);
        // Put it on cooldown
        offCooldownIceShards = false;
       // Debug.Log("IceShards on cooldown");

        yield return new WaitForSeconds(cooldownTimeIceShards);
        // Put it off cooldown
        offCooldownIceShards = true;
       // Debug.Log("IceShards off cooldown");
    }
    
    IEnumerator UseIceSpikes()
    {
        Instantiate(IceSpikes, firePoint2.position, firePoint2.rotation);

        offCooldownIceSpikes = false;
        Debug.Log("IceSpikes on cooldown");

        yield return new WaitForSeconds(cooldownTimeIceSpikes);

        offCooldownIceSpikes = true;
        Debug.Log("IceSpikes off cooldown");
    }

    IEnumerator UseIceBeam()
    {
        IceBeam.gameObject.SetActive(true);
        animator.SetBool("BeamAttack", true);
        offCooldownIceBeam = false;
        Debug.Log("IceBeam on cooldown");

        yield return new WaitForSeconds(cooldownTimeIceBeam);

        //animator.SetBool("BeamAttack", false);
        offCooldownIceBeam = true;
        Debug.Log("IceBeam off cooldown");
    }
}
