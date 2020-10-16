using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!collected) { gameObject.SetActive(false); print("Exit is deactivated");  }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCollected()
    {
        collected = true;
        print("Exit is activated");
    }
}
