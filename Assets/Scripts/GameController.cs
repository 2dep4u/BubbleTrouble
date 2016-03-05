using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    public int hazardCount;
    public GameObject spike, submarine, green, rainbow, slime;
    public Vector3 spawnValues;
    public float startWait, spawnWait, waveWait;
    public float speed, difficultySpeedFactor, difficultySpawnWaitFactor;

    public Text scoreText, endScoreText, soapText, bestScore;
    public GameObject restartButton;

    private bool gameOver;
    private int score;
   
    void Start()
    {
        gameOver = false;
        restartButton.SetActive(false);
        endScoreText.text = "";
        bestScore.text = "";
        score = 0;
        StartCoroutine(spawnHazards());
        UpdateScore();

        if (!PlayerPrefs.HasKey("Player Score"))
        {
            PlayerPrefs.SetInt("Player Score", score);
        }
    }

    IEnumerator spawnHazards()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; ++i)
            {
                if (gameOver)
                    break;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                if(Random.value<0.02)
                    Instantiate(green, spawnPosition, spawnRotation);
                else if(Random.value<0.09)
                    Instantiate(rainbow, spawnPosition, spawnRotation);
                else if (Random.value < 0.30)
                    Instantiate(slime, spawnPosition, spawnRotation);
                else
                    Instantiate(spike, spawnPosition, spawnRotation); 
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver)
            {
                int tempScore = PlayerPrefs.GetInt("Player Score");
                if (score > tempScore)
                {
                    PlayerPrefs.SetInt("Player Score", score);
                    bestScore.text = "New Record!: " + score;
                }
                else
                {
                    endScoreText.text = scoreText.text;
                    bestScore.text = "Record: " + tempScore;
                }
                restartButton.SetActive(true);
                scoreText.text = "";
                soapText.text = "";
                break;
            }
            yield return new WaitForSeconds(waveWait);
            if(speed < -11.5)
                speed += difficultySpeedFactor;
            if(spawnWait > 0.08)
                spawnWait *= difficultySpawnWaitFactor;
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainNew");

    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetScore()
    {
        return score;
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public void endGame()
    {
        gameOver = true;
    }
}
