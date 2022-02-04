using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int MaxHP = 1;
    public int HP;
    public GameObject DeathEffect;
    GameObject Manager;
    GameObject obj;
    public GameObject SpawnEffect;
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SnowBall")
        {
            HP--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HP == 0)
        {
            //transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f));
            Instantiate(SpawnEffect, new Vector3(Random.Range(-20.0f, 20.0f), 0, Random.Range(-20.0f, 20.0f)), Quaternion.identity);
            obj = Instantiate(DeathEffect, new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z), Quaternion.identity);
            Destroy(obj, 1.0f);
            //HP = MaxHP;
            Manager.GetComponent<ScoreManager>().ScorePulse();
            Destroy(gameObject);
        }
    }
}
