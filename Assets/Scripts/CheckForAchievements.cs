using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class CheckForAchievements : MonoBehaviour {

    public GameController gameController;
    public PlayerControl playerController;
    private bool tempTouched;
    private int tempScore, tempRainbowCount, tempLifeCount;

    private string ach1 = "CgkIvtum95UBEAIQAA";
    private string ach2 = "CgkIvtum95UBEAIQAQ";
    private string ach3 = "CgkIvtum95UBEAIQAg";
    private string ach4 = "CgkIvtum95UBEAIQAw";
    private string ach5 = "CgkIvtum95UBEAIQBA";
    private string ach6 = "CgkIvtum95UBEAIQBw";
    private string ach7 = "CgkIvtum95UBEAIQCA";

    void start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject playerControllerObject = GameObject.FindWithTag("Player");

        if (gameControllerObject != null && playerControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            playerController = playerControllerObject.GetComponent<PlayerControl>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' or 'PlayerControl' script");
        }

    }

    void Update()
    {
        tempTouched = playerController.GetTouched();
        tempScore = gameController.GetScore();
        tempRainbowCount = playerController.GetRainbowCount();
        tempLifeCount = playerController.GetLifeCount();

        if (tempScore == 500)
        {
            acheivement1();
        }
        if (tempScore == 1000)
        {
            acheivement2();
        }
        if (tempScore == 1500)
        {
            acheivement6();
        }
        if (tempScore == 2000)
        {
            acheivement7();
        }
        if (tempScore == 500 && !tempTouched)
        {
            acheivement3();
        }
        if (tempRainbowCount == 10)
        {
            acheivement4();
        }
        if (tempLifeCount == 3)
        {
            acheivement5();
        }



    }
    void acheivement1()
    {
        Social.ReportProgress(ach1, 100, (bool sucess) => {

        });
    }
    void acheivement2()
    {
        Social.ReportProgress(ach2, 100, (bool sucess) => {

        });
    }
    void acheivement3()
    {
        Social.ReportProgress(ach3, 100, (bool sucess) => {

        });
    }
    void acheivement4()
    {
        Social.ReportProgress(ach4, 100, (bool sucess) => {

        });
    }
    void acheivement5()
    {
        Social.ReportProgress(ach5, 100, (bool sucess) => {

        });
    }
    void acheivement6()
    {
        Social.ReportProgress(ach6, 100, (bool sucess) => {

        });
    }
    void acheivement7()
    {
        Social.ReportProgress(ach7, 100, (bool sucess) => {

        });
    }

}
