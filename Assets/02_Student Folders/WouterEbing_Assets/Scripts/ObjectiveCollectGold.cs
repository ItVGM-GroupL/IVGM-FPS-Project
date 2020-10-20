using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePickupGold : MonoBehaviour
{
    Objective m_Objective;
    Pickup m_Pickup;
    public Deactivate exitObject;

    void Awake()
    {
        print("Gold is picked up");
    }

    void Start()
    {
        if (true) { print("Gold is dactivated"); }
    }

    void OnPickup(PlayerCharacterController player)
    {
        print("Gold is picked up 2");
    }

    void Update()
    {
        if( !gameObject.activeSelf ) { print("Goud bestaat niet meer");  }
        else { print("Goud bestaat"); }
    }
}

/*
using UnityEngine;

[RequireComponent(typeof(Objective))]
public class ObjectivePickupGold : MonoBehaviour
{
    Objective m_Objective;
    Pickup m_Pickup;
    public Deactivate exitObject;

    void Awake()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectivePickupGold>(m_Objective, this, gameObject);

        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, ObjectivePickupGold>(m_Pickup, this, gameObject);

        // subscribe to the onPick action on the Pickup component
        m_Pickup.onPick += OnPickup;
        print("Gold is picked up");
    }

    void OnPickup(PlayerCharacterController player)
    {
        if (m_Objective.isCompleted)
        {
            return;
        }



        // this will trigger the objective completion
        // it works even if the player can't pickup the item (i.e. objective pickup healthpack while at full heath)
        m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : " + m_Objective.title);
        exitObject.setCollected();
        exitObject.gameObject.SetActive(true);

        if (gameObject)
        {
            Destroy(gameObject);
        }
    }
}
 */