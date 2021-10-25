using UnityEngine;

public class Low_Gravity : MonoBehaviour
{
    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, Low_Gravity>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        player.gravityDownForce = 5.0f;
        player.recievesFallDamage = false;
        Destroy(gameObject);
    }
}