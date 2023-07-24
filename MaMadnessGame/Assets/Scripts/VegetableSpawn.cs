using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSpawn : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform spawnContainer;
    
    void SpawnItem()
    {
        GameObject newItem = Instantiate(itemPrefab, spawnContainer);
        // Set the position of the newItem if needed
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            SpawnItem(); 
    }
}
