using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject BreakableWall;
    public AudioSource Bombsound;
    private bool IsExploded;
    // Start is called before the first frame update
    void Start()
    {
        IsExploded = false;  
    }

   
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (!IsExploded)
        {
            IsExploded = true;
            Bomb.SetActive(false);
            BreakableWall.SetActive(false);
            Bombsound.Play();
            
        }

    }
}
