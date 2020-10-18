using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool collected = false;

    void Start()
    {
        if (!collected) { gameObject.SetActive(false); }
    }



}
