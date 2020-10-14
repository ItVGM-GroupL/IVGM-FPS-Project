using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{ 
    BoxCollider triggerZone;
	Rigidbody boulderBody;
	bool boulderTriggered = false; 
    //use this for initialization  
  
    void Start () {  
           triggerZone = GetComponent<BoxCollider>();
		   boulderBody = GetComponent<Rigidbody>();
		  
	}  
	
    //Update is called once per frame  
    void Update () {  
	
    }    
	void OnTriggerEnter(Collider other)
    {
        Damageable check = other.GetComponent<Damageable>();
        if (check == null) return;
		if(boulderTriggered == false) 
		TriggerBoulder(); 
    } 
	
	void TriggerBoulder()
	{
		transform.localPosition = new Vector3(transform.localPosition.x + 10, transform.localPosition.y, transform.localPosition.z);
		boulderTriggered = true;
		
	}
}