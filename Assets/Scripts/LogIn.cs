using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class LogIn : MonoBehaviour
{
    public GameObject login;
    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.Activate();

    }
    
    public void Login()
    {
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Authentication successful");
                string userInfo = "Username: " + Social.localUser.userName +
                    "\nUser ID: " + Social.localUser.id +
                    "\nIsUnderage: " + Social.localUser.underage;
                Debug.Log(userInfo);
                Social.ShowAchievementsUI();
            }
            else
                Debug.Log("Authentication failed");
        });
    }

}