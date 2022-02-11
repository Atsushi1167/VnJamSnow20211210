using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAction : MonoBehaviour
{
    float Elapsed;
    public GameObject Enemy;
    public float Num;
    private Quaternion RandomQ;
    public float Max = 25;
    public float Min = -25;
    // Start is called before the first frame update
    void Start()
    {
        Elapsed = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Num = Random.Range(-180, 180);
        RandomQ = Quaternion.Euler(0, Num, 0);
        this.transform.position = new Vector3(Random.Range(Min, Max), 0.2f, Random.Range(Min, Max));
    }

    // Update is called once per frame
    void Update()
    {
        Elapsed += Time.deltaTime;

        if(Elapsed > 3.0f)
        {
            Num = Random.Range(-180, 180);
            RandomQ = Quaternion.Euler(0, Num, 0);
            Instantiate(Enemy, this.transform.position, RandomQ);
            Destroy(gameObject);
        }
    }
}
