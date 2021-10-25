using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public float multiplier = 10f;
    public GameObject pickupEffect;
    public AudioClip coinSound;

    public override bool Equals(object obj)
    {
        return obj is powerup powerup &&
               multiplier == powerup.multiplier;
    }

    void OnTriggerEnter (Collider other){
    if (other.CompareTag("Player")){
        Pickup(other);
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }
    }
    void Pickup(Collider player){

        Instantiate(pickupEffect,
                    transform.position,
                    transform.rotation);
        //Health stats = player.GetComponent<Health>();
        //stats.maxHealth *= multiplier;
        //stats.currentHealth *= multiplier;
        Damageable dmg = player.GetComponent<Damageable>();
        dmg.damageMultiplier = 0f;
        PlayerWeaponsManager fov = player.GetComponent<PlayerWeaponsManager>();
        fov.defaultFOV = 50f;
        //WeaponController ammo = player.GetComponent<WeaponController>();
        //ammo.currentAmmoRatio = 6f;
        //ammo.ammoReloadRate = 55f;
        //ammo.m_CurrentAmmo = 55f;
        

        Destroy(gameObject);
    }
}
