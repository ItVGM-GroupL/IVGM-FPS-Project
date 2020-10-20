using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ondestroydisplay : MonoBehaviour
{

	public GameObject UIObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        
        UIObject.SetActive(true);
        Debug.Log("Ondestroydisplay done");

    }
}
