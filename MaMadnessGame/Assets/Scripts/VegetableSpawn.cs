using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSpawn : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform spawnContainer;

    private GameObject spawnedItem;

    void Start()
    {
        // Call SpawnItem function repeatedly with a delay of 2 seconds (2.0f)
        InvokeRepeating("SpawnItem", 2.0f, 2.0f);
    }

    void SpawnItem()
    {
        spawnedItem = Instantiate(itemPrefab, spawnContainer);
        // Set the position of the newItem if needed
    }

    void Update()
    {
        if (spawnedItem != null)
        {
            // Check if the spawned item has reached the x value of -25
            if (spawnedItem.transform.position.x <= -25f)
            {
                // Destroy the item if it reaches -25
                Destroy(spawnedItem);
            }
        }
    }
}
