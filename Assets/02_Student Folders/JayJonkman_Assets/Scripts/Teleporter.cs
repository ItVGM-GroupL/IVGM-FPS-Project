//Jay Jonkman
//s2333368
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System;

public class Teleporter : MonoBehaviour
{

    [Header("Proximity")]
    [Tooltip("Minimum range from coordinate to teleport")]
    public Vector3 range = Vector3.zero;

    public enum teleportway // your custom enumeration
    {
        Absolute,
        Relative
    };

    [Header("Teleport to")]
    [Tooltip("Teleport to coordinate or add values to current position")]
    public teleportway teleportOption = teleportway.Absolute;
    [Tooltip("Teleport to coordinate or add offset")]
    public Vector3 teleport = Vector3.zero;

    [Header("Object")]
    [Tooltip("Object to teleport")]
    public GameObject character;

    Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = character.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(Target.transform.position.x - transform.position.x) < range.x &&
            Math.Abs(Target.transform.position.y - transform.position.y) < range.y &&
            Math.Abs(Target.transform.position.z - transform.position.z) < range.z)
        {
            if (teleportOption == teleportway.Absolute)
            {
                character.transform.position = teleport;
            } else
            {
                character.transform.position = new Vector3(character.transform.position.x + teleport.x, character.transform.position.y + teleport.y, character.transform.position.z + teleport.z);
            }
            Physics.SyncTransforms();
            }
    }
}
