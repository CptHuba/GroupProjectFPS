using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    Pickup m_Pickup;
    //public float timerlength = 11f;
    // Start is called before the first frame update
    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        if (player && !player.heartIsOn)
        {
            player.heartIsOn = true;
            player.heartTimer = 11f;
            player.audioSource.PlayOneShot(player.heartMusic);
            m_Pickup.PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
}
