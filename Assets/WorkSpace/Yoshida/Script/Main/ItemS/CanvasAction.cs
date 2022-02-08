using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAction : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
