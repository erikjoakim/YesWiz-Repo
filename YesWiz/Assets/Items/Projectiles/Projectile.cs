using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public DamageType damage;
    public float liveForSeconds;

    void Start()
    {
        Destroy(gameObject, liveForSeconds);
        //StartCoroutine(Die(liveForSeconds));
    }
        
    IEnumerator Die(float liveForSeconds)
    {

        yield return new WaitForSeconds(liveForSeconds);
        DestroyImmediate(this);

    }
    void OnCollisionEnter(Collision collision)
    {
        //Stop Projectile
        //Apply Damage
        //Destroy
        
        if (collision.gameObject.tag=="Player")
        {
            DamageReceiver damageReceiver = collision.gameObject.GetComponent<DamageReceiver>();
            damageReceiver.ApplyDamage(damage);
        }
        Destroy(this);
    }
}
