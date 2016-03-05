using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float ySpeed, xSpeed;
    private GameController gameController;
    
   void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        if (gameController.GetSpeed() < -2)
            ySpeed = gameController.GetSpeed();  
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-xSpeed, xSpeed), 0f,ySpeed );
    }
}
