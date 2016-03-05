using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}
public class PlayerControl : MonoBehaviour {
    private Vector2 fingerStart;
    public int health;
    public int soap = 25;
    public float slimeTime;
    public float slowFactor;
    public bool isSlime;
    public GameObject explosion;
    public GameObject hit;
    public GameObject miss;
    public Text soapCount;
    public Light lt;
    private Vector2 fingerEnd;
    public Vector3 delta;
    public Color c = new Color();
    Vector3 myscale;
    public float mag = 3;
    private GameController gameController;
    float vib = 0.1f;//determines the amplitude after user tap
    float angle = 0;
    float epsilon = 0.1f;
    float decay = 0.1f;//affects vib's magnitude
    //float sidetoside = 0.005f;
    public Boundary boundary;
    private Rigidbody rb;
    Vector3 pos;
    public GameObject smallbbl;
    //Variables for Achievement Tracking//
    private bool touched;
    private int rainbowCount, lifeCount;


    void Start () {
        rb = GetComponent<Rigidbody>();
        myscale.y = 1f;
        pos.y = 0f;
        delta.y = 0f;
        soapCount.text = "Soap: " + soap;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        myscale.x = transform.localScale.x;
        myscale.y = transform.localScale.y;
        myscale.z = transform.localScale.z;
        c = Color.white;
        lt.color = c;

        StartCoroutine(slimeTimer());
        isSlime = false;
        touched = false;
        rainbowCount = 0;
        lifeCount = 0;
    }

    IEnumerator slimeTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (isSlime)
            {
                mag /= slowFactor;
                yield return new WaitForSeconds(slimeTime);
                mag *= slowFactor;
                isSlime = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        decay = 0.3f;
        switch (other.tag) {
            case "Rainbow":
                soap += 3;
                soapCount.text = "Soap: " + soap;
                rainbowCount++;
                Instantiate(miss, transform.position, transform.rotation);
                break;
            case "Slime":
                isSlime = true;
                touched = true;
                health--;
                Instantiate(hit, transform.position, transform.rotation);
                break;
            case "Green":
                health++;
                lifeCount++;
                Instantiate(miss, transform.position, transform.rotation);
                break;
            case "Enemy":
                health--;
                touched = true;
                Instantiate(hit, transform.position, transform.rotation);
                break;
        }
        
        
        switch (health)
        {
            case 3:
                c = Color.cyan;
                lt.color = c;
                break;
            case 2:
                c = Color.yellow;
                lt.color = c;
                break;
            case 1:
                c = new Color(152f / 255f, 41f / 255f, 62f / 255f);
                lt.color = c;
                break;
        }
    }
    void Update()
    {
        //  if (Input.GetMouseButtonDown(0))
        // {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    decay = 0.3f;
                    fingerStart = touch.position;
                    fingerEnd = touch.position;
                if (soap > 0)
                {
                    Instantiate(smallbbl, transform.position, transform.rotation);
                    soap--;
                    soapCount.text = "Soap: " + soap;
                }
            }
                if (touch.phase == TouchPhase.Moved)
                {
                    fingerEnd = touch.position;

                }
                if (touch.phase == TouchPhase.Ended)
                {
                    delta.x = fingerStart.x - fingerEnd.x;
                    delta.z = fingerStart.y - fingerEnd.y;
                    delta.Normalize();
                    rb.velocity = -delta * mag;
                }
            }

        if (health <= 0)
        {
            myscale.x -= 0.05f;
            myscale.y -= 0.05f;
            if (myscale.y < 0.2f || myscale.x < 0.2f)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                gameController.endGame();
                Destroy(gameObject);
            }

        }

    }
    void FixedUpdate()
    {
        pos.x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax);
        pos.z = Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax);
        transform.position = pos;
        decay = (decay > epsilon)?decay -= 0.002f:decay;
        vib = decay * Mathf.Cos(75 * decay) + 0.05f;
        angle += Time.deltaTime;
        myscale.x = vib * Mathf.Cos(angle) + 1;
        myscale.z = -vib * Mathf.Cos(angle) + 1; ;
        transform.localScale = myscale;
    }

    public bool GetTouched()
    {
        return touched;
    }

    public int GetRainbowCount()
    {
        return rainbowCount;
    }

    public int GetLifeCount()
    {
        return lifeCount;
    }

}
