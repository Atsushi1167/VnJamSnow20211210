using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] Item;
    GameObject[] tagObjects;
    public int ItemMax = 3;
    bool CanSpawn = true;
    float cnt;
    public float cooltime = 10.0f;
    public float Max = 25;
    public float Min = -25;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0.0f;
    }

    void SearchItem()
    {
        CanSpawn = true;
        tagObjects = GameObject.FindGameObjectsWithTag("Item");
        if(tagObjects.Length >= ItemMax + 1)
        {
            CanSpawn = false;
        }
        if (tagObjects.Length == 0)
        {
            CanSpawn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
            cnt += Time.deltaTime;
            if (cnt >= cooltime)
            {
                SearchItem();
                if (CanSpawn)
                {
                    int value = Random.Range(0, Item.Length);
                    Instantiate(Item[value], new Vector3(Random.Range(Min, Max), 0.5f, Random.Range(Min, Max)), Quaternion.identity);
                }
                cnt = 0.0f;
            }
    }
}
