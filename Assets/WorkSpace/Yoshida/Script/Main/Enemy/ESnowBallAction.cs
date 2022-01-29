using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESnowBallAction : MonoBehaviour
{
    GameObject Player;
    private Rigidbody rb;
    public float speed = 5.0f;

    public GameObject SnowEffect;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();

        SetPos(new Vector3(Player.transform.position.x, Player.transform.position.y + 1.0f, Player.transform.position.z));
    }

    void SetPos(Vector3 vector3)
    {
        this.transform.LookAt(vector3);
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Quaternion dir = Quaternion.Euler(new Vector3(this.transform.rotation.x, this.transform.rotation.y + 180, this.transform.rotation.z));
        Destroy(gameObject,0.01f);
        obj = Instantiate(SnowEffect, this.transform.position, dir);
        Destroy(obj, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}