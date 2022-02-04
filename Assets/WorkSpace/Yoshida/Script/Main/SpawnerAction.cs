using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAction : MonoBehaviour
{
    float Elapsed;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Elapsed += Time.deltaTime;

        if(Elapsed > 3.0f)
        {
            Instantiate(Enemy, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
