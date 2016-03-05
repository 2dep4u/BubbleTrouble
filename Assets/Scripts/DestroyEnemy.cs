using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {
    public int health;

    private GameController gameController;
    public GameObject hit, prefabObject;
    private bool isEnemy;

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
        string tagStr = prefabObject.tag;
        if (tagStr == "Enemy" || tagStr == "Slime")
            isEnemy = true;
        else
            isEnemy = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" || other.tag == "SmallBubbles")
            health--;   
    }

    void Update() {
        if (health <= 0)
        {
            if(isEnemy)
            {
                gameController.AddScore(10);
                Instantiate(hit, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
