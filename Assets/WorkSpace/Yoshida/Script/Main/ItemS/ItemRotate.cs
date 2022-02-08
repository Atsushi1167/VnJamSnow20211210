using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    float Elapsed;
    // Start is called before the first frame update
    void Start()
    {
        Elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        Elapsed += Time.deltaTime;
        if(Elapsed < 1.0f)
        {
            this.transform.position += new Vector3(0, 0.4f, 0) * Time.deltaTime;
        }
        else if(Elapsed < 2.0f)
        {
            this.transform.position -= new Vector3(0, 0.4f, 0) * Time.deltaTime;
        }
        else
        {
            Elapsed = 0.0f;
        }
    }
}
