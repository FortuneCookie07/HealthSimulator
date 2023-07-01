using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploy : MonoBehaviour {
    public List<GameObject> vegetablePrefabs;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(VegetableWave());
    }

    private void SpawnEnemy(){
        int randomIndex = Random.Range(0, vegetablePrefabs.Count);
        GameObject vegetablePrefab = vegetablePrefabs[randomIndex];

        GameObject a = Instantiate(vegetablePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(screenBounds.y * -1, screenBounds.y));
    }

    IEnumerator VegetableWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
