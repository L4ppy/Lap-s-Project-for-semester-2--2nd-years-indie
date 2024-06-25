using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Transform demoCamera;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        demoCamera.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);

    }
}
