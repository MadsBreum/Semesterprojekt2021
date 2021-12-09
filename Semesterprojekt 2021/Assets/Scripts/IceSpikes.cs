using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikes : MonoBehaviour
{
    public float spikeSizeY = 2f;
    public float spikeSizeX = 1.5f;
    public float timeTillDestroy = 2f;
    public float timeBetweenSpikes = 0.10f;
    public float stunTime = 1f;

    public float damage = 20f;

    public bool dealtDamage;

    // Start is called before the first frame update
    void Start()
    {
        dealtDamage = false;
        StartCoroutine("EnableIceSpikes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnableIceSpikes()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        transform.GetChild(0).gameObject.transform.localScale = new Vector3(spikeSizeX, spikeSizeY, 1);
        transform.GetChild(0).gameObject.transform.localPosition = new Vector3(1.25f, spikeSizeY / 4f, 0);

        yield return new WaitForSeconds(timeBetweenSpikes);

        transform.GetChild(1).gameObject.SetActive(true);

        transform.GetChild(1).gameObject.transform.localScale = new Vector3(spikeSizeX, spikeSizeY, 1);
        transform.GetChild(1).gameObject.transform.localPosition = new Vector3(2.75f, spikeSizeY / 4f, 0);

        yield return new WaitForSeconds(timeBetweenSpikes);

        transform.GetChild(2).gameObject.SetActive(true);

        transform.GetChild(2).gameObject.transform.localScale = new Vector3(spikeSizeX, spikeSizeY, 1);
        transform.GetChild(2).gameObject.transform.localPosition = new Vector3(4.25f, spikeSizeY / 4f, 0);

        yield return new WaitForSeconds(timeBetweenSpikes);

        transform.GetChild(3).gameObject.SetActive(true);

        transform.GetChild(3).gameObject.transform.localScale = new Vector3(spikeSizeX, spikeSizeY, 1);
        transform.GetChild(3).gameObject.transform.localPosition= new Vector3(5.75f, spikeSizeY / 4f, 0);

        yield return new WaitForSeconds(timeTillDestroy);

        Destroy(gameObject);
    }
    
    public void DealtDamage()
    {
        dealtDamage = true;
    }
}
