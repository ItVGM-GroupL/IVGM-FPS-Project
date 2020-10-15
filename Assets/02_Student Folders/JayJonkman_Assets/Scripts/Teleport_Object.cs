using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Teleport_Object : MonoBehaviour { 


    [Header("Proximity")]
    [Tooltip("Minimum range from coordinate to teleport")]
    public Vector3 range = Vector3.zero;

    [Header("Teleport to")]
    [Tooltip("Object to teleport to relatively")]
    public GameObject toObject;

    [Header("Object")]
    [Tooltip("Object to teleport")]
    public GameObject character;

    Transform Target, TLocation;

    public Matrix4x4 RotateY(float angleD)
    {
        float angleR = angleD * (float)Math.PI / 180; //convert to radians
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix.m00 = matrix.m22 = Mathf.Cos(angleR);
        matrix.m02 = Mathf.Sin(angleR);
        matrix.m20 = -matrix.m02;     
        return matrix;
    }

    // Start is called before the first frame update
    void Start()
    {
        Target = character.transform;
        TLocation = toObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(Target.position.x - transform.position.x) < range.x &&
            Math.Abs(Target.position.y - transform.position.y) < range.y &&
            Math.Abs(Target.position.z - transform.position.z) < range.z)
        {

            //rotation
            float rotation = TLocation.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
            Target.Rotate(0f, rotation, 0f, Space.World);

            //position
            Vector3 rotateThis = Target.position - transform.position;
            Vector3 addThis = RotateY(rotation).MultiplyVector(rotateThis);
            Target.position = addThis + TLocation.position;
            

            Physics.SyncTransforms();
        }
    }
}
