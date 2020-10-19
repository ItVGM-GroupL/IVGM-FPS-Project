using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Jumppack : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Audio source for jumppack sfx")]
    public AudioSource audioSource;
 //   [Tooltip("Particles for rocket boost")]
//    public ParticleSystem jumppackVfx;

    [Header("Parameters")]
    [Tooltip("Whether the jumppack is unlocked at the beginning or not")]
    public bool isJumpackUnlockedAtStart = false;
//    [Tooltip("The strenght of the horizontal boost")]
//    public float horizontalBoostAcceleration = 7f;
    [Tooltip("The strenght of the vertical boost")]
    public float verticalBoostAcceleration = 7f;
    [Tooltip("The strenght of the horizontal boost")]
    public float horizontalBoostAcceleration = 7f;

    [Range(0f, 1f)]
    [Tooltip("This will affect how much using the jumppack will cancel the gravity value, to start going up faster. 0 is not at all, 1 is instant")]
    public float jumppackDownwardVelocityCancelingFactor = 1f;

    [Header("Audio")]
    [Tooltip("Sound played when using the jumppack")]
    public AudioClip jumppackSFX;

    bool m_CanUseJumppack;
    PlayerCharacterController m_PlayerCharacterController;
    PlayerInputHandler m_InputHandler;
    float m_LastTimeOfUse;

    public bool isJumppackUnlocked { get; private set; }

    public bool isPlayerGrounded() => m_PlayerCharacterController.isGrounded;
    bool hasJumppackBeenUsed = false;

    public UnityAction<bool> onUnlockJumppack;

    void Start()
    {
        isJumppackUnlocked = isJumpackUnlockedAtStart;

        m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, Jumppack>(m_PlayerCharacterController, this, gameObject);

        m_InputHandler = GetComponent<PlayerInputHandler>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerInputHandler, Jumppack>(m_InputHandler, this, gameObject);
        audioSource.clip = jumppackSFX;
        audioSource.loop = false;
    }

    void Update()
    {
        // jumppack can only be used if not grounded and jump has been pressed again once in-air.
        // the double jump is only activated once per jump.
        if (isPlayerGrounded())
        {
            m_CanUseJumppack = false;
            hasJumppackBeenUsed = false;
        }
        else if (!m_PlayerCharacterController.hasJumpedThisFrame && m_InputHandler.GetJumpInputDown() && !hasJumppackBeenUsed && isJumppackUnlocked)
        {
            m_CanUseJumppack = true;
            hasJumppackBeenUsed = true;

            // perform double jump
            if (m_CanUseJumppack)
            {
                // jump power
                float totalAcceleration = verticalBoostAcceleration;

                m_PlayerCharacterController.characterVelocity = new Vector3(m_PlayerCharacterController.characterVelocity.x, 0f, m_PlayerCharacterController.characterVelocity.z);


                // apply the acceleration to characters's velocity
                m_PlayerCharacterController.characterVelocity += Vector3.up * totalAcceleration;

                // play jump sound effect
                audioSource.Play();
            }
        }
    }

    public void Enable()
    {
        isJumppackUnlocked = true;
    }

    public bool TryUnlock()
    {
        isJumppackUnlocked = true;
        if (isJumppackUnlocked)
            return false;

        onUnlockJumppack.Invoke(true);
        isJumppackUnlocked = true;
        m_LastTimeOfUse = Time.time;
        return true;
    }
}
