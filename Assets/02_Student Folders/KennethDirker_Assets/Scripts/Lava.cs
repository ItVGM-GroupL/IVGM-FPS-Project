using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Lava : MonoBehaviour
{
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
        Health m_health = other.GetComponent<Health>();
        m_health.Kill();
    }


}