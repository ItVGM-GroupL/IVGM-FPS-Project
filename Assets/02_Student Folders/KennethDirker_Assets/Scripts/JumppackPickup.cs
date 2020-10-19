using UnityEngine;

public class JumppackPickup : MonoBehaviour
{
    [Tooltip("Sound played on pickup")]
    public AudioClip pickupSFX;

    Pickup m_Pickup;
    Collider m_Collider;

    private void Start()
    {
        m_Collider = GetComponent<Collider>();
        DebugUtility.HandleErrorIfNullGetComponent<Collider, Pickup>(m_Collider, this, gameObject);

        // ensure the physics setup is a kinematic rigidbody trigger
        m_Collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Jumppack jumppack = other.GetComponent<Jumppack>();
        jumppack.Enable();

        if (pickupSFX)
        {
            AudioUtility.CreateSFX(pickupSFX, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        Destroy(gameObject);
    }
}
