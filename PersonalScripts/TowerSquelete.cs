using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class TowerSquelete
{

    public GameObject prefab;
    public int cost;
    public GameObject upgradeprefab;
    public int upgradecost;

    public int QuantityForSelling()
    {
        return cost / 2;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
