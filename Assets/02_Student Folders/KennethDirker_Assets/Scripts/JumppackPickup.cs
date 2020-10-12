using UnityEngine;

public class JumppackPickup : MonoBehaviour
{
    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, JumppackPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController byPlayer)
    {
        var jumppack = byPlayer.GetComponent<Jumppack>();
        if (!jumppack)
            return;

        if (jumppack.TryUnlock())
        {
            m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        }
    }
}
