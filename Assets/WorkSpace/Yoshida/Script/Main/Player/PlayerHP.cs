using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int MaxHP = 3;
    public int HP;
    public GameObject DeathEffect;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SnowBallEnemy")
        {
            HP--;
        }
    }

    public int GetHP()
    {
        return HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0)
        {
            Destroy(gameObject);
            obj = Instantiate(DeathEffect, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            Destroy(obj, 1.0f);
        }
    }
}
