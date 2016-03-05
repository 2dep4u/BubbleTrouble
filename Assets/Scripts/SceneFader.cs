using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneFader : MonoBehaviour {
    public float fadeSpeed = 1.5f;
    public GUITexture guiFadeTexture;
    public GameObject buttons;
    public Text gameTitle, bestScore;
    private bool sceneStarting = true;

	void Awake () {
        guiFadeTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

    void Start()
    {
        if (PlayerPrefs.HasKey("Player Score"))
            bestScore.text = "Best Score: " + PlayerPrefs.GetInt("Player Score");
        else
            bestScore.text = "";
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (sceneStarting)
            StartScene();
	}


    void FadeToClear()
    {
        guiFadeTexture.color = Color.Lerp(guiFadeTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        guiFadeTexture.color = Color.Lerp(guiFadeTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();
        if (guiFadeTexture.color.a <= 0.05f)
        {
            guiFadeTexture.color = Color.clear;
            guiFadeTexture.enabled = false;
            sceneStarting = false;
        }
    }

    public void startFade()
    {
        SceneManager.LoadScene("MainNew");
        buttons.SetActive(false);
        gameTitle.fontSize = 40;
        gameTitle.text = "loading...";
        bestScore.text = "";
    }
}
