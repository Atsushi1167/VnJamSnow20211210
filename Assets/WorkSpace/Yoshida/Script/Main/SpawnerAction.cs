using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAction : MonoBehaviour
{
    float Elapsed;
    public GameObject Enemy;
    public float Num;
    private Quaternion RandomQ;
    // Start is called before the first frame update
    void Start()
    {
        Elapsed = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.transform.position = new Vector3(Random.Range(-4.0f, 4.0f), 0.2f, Random.Range(-4.0f, 4.0f));
        Num = Random.Range(-180, 180);
        RandomQ = Quaternion.Euler(0, Num, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Elapsed += Time.deltaTime;

        if(Elapsed > 3.0f)
        {
            Instantiate(Enemy, this.transform.position, RandomQ);
            Destroy(gameObject);
        }
    }
}
