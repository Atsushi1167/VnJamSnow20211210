using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPup : MonoBehaviour
{
    GameObject Player;
    GameObject obj;
    public GameObject HPupEffect;
    public Text txtNav;

    int HP;
    int MAXHP;
    bool isDestroy;
    bool Jadge = true;

    float Elapsed;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        isDestroy = false;
        MAXHP = Player.GetComponent<PlayerHP>().MaxHP;
        txtNav.text = "";
        Elapsed = 0.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HP = Player.GetComponent<PlayerHP>().GetHP();
            if (HP < MAXHP)
            {
                txtNav.text = "[RMB]";
                if (Input.GetButton("Fire2"))
                {
                    isDestroy = true;
                }
            }
            else
            {
                txtNav.text = "[HPfull]";
            }
        }
        if(other.gameObject.tag == "Item")
        {
            if (Jadge)
            {
                this.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0.5f, Random.Range(-5.0f, 5.0f));
                Jadge = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            txtNav.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Elapsed += Time.deltaTime;
        if (isDestroy)
        {
            Player.GetComponent<PlayerHP>().HPPluse();
            Destroy(gameObject);
            obj = Instantiate(HPupEffect, this.transform.position, Quaternion.identity);
            Destroy(obj, 2.0f);
        }
        if (Elapsed > 30.0f)
        {
            Destroy(gameObject);
        }
    }
}
