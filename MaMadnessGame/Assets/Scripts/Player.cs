using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 40;
    public int currentHealth;

    public bmiBar bmibar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        bmibar.SetMaxBMI(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            TakeDamage(5);   
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        bmibar.SetBMI(currentHealth);
    }
}
