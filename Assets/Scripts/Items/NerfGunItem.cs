using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used while held acts as a physics based projectile instantiator
/// </summary>
public class NerfGunItem : InteractiveItem
{
    public GameObject nerfDartPrefab;
    public Transform nerfDartSpawnLocation;
    public float fireRate = 1;
    public float launchForce = 10;
    protected float fireRateCounter;
    float timer;


    protected void Update()
    {
        timer += Time.deltaTime;
    }

    public override void OnUse()
    {
        base.OnUse();
        FireNow();
        //TODO: we need to determine if we can fire and if so, make the thing
    }

    public void FireNow()
    {
        if( timer >= fireRate )
        {
            GameObject dart = Instantiate(nerfDartPrefab, nerfDartSpawnLocation.position, Quaternion.identity);
            Rigidbody rb = dart.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * launchForce);


        }
        //TODO: this is where we would actually create the thing and get it on its way
    }

    public void erased()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BowlingBall")
        {
            Destroy(gameObject);
        }
    }

}
