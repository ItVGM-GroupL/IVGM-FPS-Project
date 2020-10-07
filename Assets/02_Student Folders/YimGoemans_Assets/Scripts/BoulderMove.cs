using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{ 
    Collider triggerZone;
    //use this for initialization  
  
    void Start () {  
           triggerZone = GetComponent<Collider>();
    }  
	
    //Update is called once per frame  
    void Update () {  
        //this is for x axis' movement  
  
    }    
	void OnTriggerEnter(Collider other)
    {
        Damageable check = other.GetComponent<Damageable>();
        if (check == null) return;
    } 
}