using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperPickupPower : MonoBehaviour
{
    Pickup m_Pickup;
    public float timerLength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }
        

    // Update is called once per frame
 void OnPicked(PlayerCharacterController player)
    {
        if (player && !player.pepperIsOn)
        {
           player.pepperIsOn = true;
           player.pepperTimer = timerLength;
           player.audioSource.PlayOneShot(player.pepperMusic);
           Destroy(gameObject);
        }
    }
}
