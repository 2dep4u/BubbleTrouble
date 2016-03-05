using UnityEngine;
using System.Collections;

public class DestroyBonus : MonoBehaviour
{
    public int health;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            health--;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

