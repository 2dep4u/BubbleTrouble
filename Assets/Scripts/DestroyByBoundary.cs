using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    public int spikeBallScoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" && !gameController.isGameOver())
            gameController.AddScore(spikeBallScoreValue);
        if (other.tag == "Player")
            gameController.endGame();
        Destroy(other.gameObject);
    }

}
