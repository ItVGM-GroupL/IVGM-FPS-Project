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
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, PoisonPickUp>(playercontroller, this, gameObject);	
        PlayerWeaponsManager weaponcontroller = player.GetComponent<PlayerWeaponsManager>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerWeaponsManager, PoisonPickUp>(weaponcontroller, this, gameObject);
        playercontroller.poisonTaken(SpeedDecreaseAmount);
        int numberofweapons = weaponcontroller.m_WeaponSlots.Length;
        for (int i = 0; i < numberofweapons; i++){
        	WeaponController temp = weaponcontroller.m_WeaponSlots[i];
        	temp.poisonTaken();

        }
        m_Pickup.PlayPickupFeedback();

        Destroy(gameObject);
    }
}
