using UnityEngine;

public class VegetableMove : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}