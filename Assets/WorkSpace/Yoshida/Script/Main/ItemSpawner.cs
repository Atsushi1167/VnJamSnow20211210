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
                    Instantiate(Item[value], new Vector3(Random.Range(-5.0f, 5.0f), 0.5f, Random.Range(-5.0f, 5.0f)), Quaternion.identity);
                }
                cnt = 0.0f;
            }
    }
}
