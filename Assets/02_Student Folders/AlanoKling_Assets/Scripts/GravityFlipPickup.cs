using UnityEngine;

public class GravityFlipPickup : MonoBehaviour
{    
    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, GravityFlipPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player) {
        player.transform.Rotate(0f, 0f, 180f, Space.Self);
        Destroy(gameObject);
    }
}
