using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testlz : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform a;
    public Transform b;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, a.position);
        lineRenderer.SetPosition(1, b.position);
    }
}
