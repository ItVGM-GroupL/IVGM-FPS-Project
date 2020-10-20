using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPickUp : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Amount of Speed lost on pickup")]
    public float SpeedDecreaseAmount;

    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, PoisonPickUp>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        PlayerCharacterController playercontroller = player.GetComponent<PlayerCharacterController>();
        playercontroller.poisonTaken(SpeedDecreaseAmount);

        m_Pickup.PlayPickupFeedback();

        Destroy(gameObject);
    }
}
