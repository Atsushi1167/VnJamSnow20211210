using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerAction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        { //マーカーに警備員が侵入した
            other.GetComponent<EnemyAction>().OnHitMarker();
            Destroy(gameObject);
        }
    }
}
