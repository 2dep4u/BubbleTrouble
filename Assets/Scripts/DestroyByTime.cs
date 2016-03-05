using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
    float timeLeft = 2f;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
