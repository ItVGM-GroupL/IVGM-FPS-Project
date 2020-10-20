using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Objective))]
public class Ondestroydisplay : MonoBehaviour
{

	public GameObject UIObject;
    Objective m_Objective;

    // Start is called before the first frame update
    void Start()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, Ondestroydisplay>(m_Objective, this, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        
        UIObject.SetActive(true);
        m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : " + m_Objective.title);

        Debug.Log("Ondestroydisplay done");

    }
}
