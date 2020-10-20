using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{ 
    BoxCollider triggerZone;
	Rigidbody boulderBody;
	bool boulderTriggered = false; 
	private Transform boulderTransform;
    //use this for initialization  
  
    void Start () {  
           triggerZone = GetComponent<BoxCollider>();
		   boulderBody = GetComponentInChildren<Rigidbody>();
		   boulderTransform = GetComponentInChildren<Transform>();
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
		boulderTransform.localPosition += new Vector3(10,0,0);
		//boulderTransform.localPosition = new Vector3(boulderTransform.localPosition.x + 10, boulderTransform.localPosition.y, boulderTransform.localPosition.z);
		boulderTriggered = true;
	}
}