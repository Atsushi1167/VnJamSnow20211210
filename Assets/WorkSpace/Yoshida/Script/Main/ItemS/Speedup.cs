using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedup : MonoBehaviour
{
    GameObject Player;
    public Text txtNav;

    bool speedup;
    bool isDestroy;
    bool Jadge = true;

    float Elapsed;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        isDestroy = false;
        txtNav.text = "";
        Elapsed = 0.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            speedup = Player.GetComponent<PlayerScript>().speedup;
            if (!speedup)
            {
                txtNav.text = "[RMB]";
                if (Input.GetButton("Fire2"))
                {
                    isDestroy = true;
                }
            }
            else
            {
                txtNav.text = "[×]";
            }
        }
        if (other.gameObject.tag == "Item")
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
            Player.GetComponent<PlayerScript>().Speedup();
            Destroy(gameObject);
        }
        if(Elapsed > 30.0f)
        {
            Destroy(gameObject);
        }
    }
}