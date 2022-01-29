using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    int centerX = Screen.width / 2;
    int centerY = Screen.height / 2;

    public Vector3 hitpos;

    private Ray ray;
    private RaycastHit hit;

    public Camera Camera;
    public GameObject TargetPos;
    public GameObject Nohit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 RayOn()
    {
        Vector3 pos = new Vector3(centerX, centerY, 0.1f); // Zを少しだけ前に出す
        ray = Camera.ScreenPointToRay(pos);

        if (Physics.Raycast(ray, out hit))
        {
            hitpos = hit.point;
            //Rayを緑色の線で可視化する
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 5, false);

            return new Vector3(hitpos.x, hitpos.y, hitpos.z);
        }
        else if(hit.collider == null)
        {
            return new Vector3(Nohit.transform.position.x, Nohit.transform.position.y, Nohit.transform.position.z);
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
