using UnityEngine;

public class CustomPickup : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Amount of health to heal on pickup")]
    public float maxHealthBoost;
    public float maxSpeedBoostGround;
    public float maxSpeedBoostAir;
    public float maxJumpForce;
    public float maxGravityDownForce;

    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        player.GetComponent<Health>().maxHealth = maxHealthBoost;
        player.GetComponent<Health>().Heal(maxHealthBoost);
        player.GetComponent<PlayerCharacterController>().maxSpeedOnGround = maxSpeedBoostGround;
        player.GetComponent<PlayerCharacterController>().maxSpeedOnGround = maxSpeedBoostAir;
        player.GetComponent<PlayerCharacterController>().jumpForce = maxJumpForce;
        player.GetComponent<PlayerCharacterController>().gravityDownForce = maxGravityDownForce;


        m_Pickup.PlayPickupFeedback();

        Destroy(gameObject);
    }
}
