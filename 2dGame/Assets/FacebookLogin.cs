using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class FacebookLogin : MonoBehaviour
{

    // Include Facebook namespace
    public Text FriendsText,CoinText;
   

    private void Start()
    {

        CoinText.text =""+ PlayerPrefs.GetInt("moneta");
        Login();

    }

    // Awake function from Unity's MonoBehavior
    void Awake()
{
    if (!FB.IsInitialized)
    {
        // Initialize the Facebook SDK
        FB.Init(InitCallback, OnHideUnity);
    }
    else
    {
        // Already initialized, signal an app activation App Event
        FB.ActivateApp();
    }
}

private void InitCallback()
{
    if (FB.IsInitialized)
    {
        // Signal an app activation App Event
        FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
           
        }
    else
    {
        Debug.Log("Failed to Initialize the Facebook SDK");
    }
}

private void OnHideUnity(bool isGameShown)
{
    if (!isGameShown)
    {
        // Pause the game - we will need to hide
        Time.timeScale = 0;
    }
    else
    {
        // Resume the game - we're getting focus again
        Time.timeScale = 1;
    }
}

    public void Login()
    {
        var perms = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    public void Share()
    {
        FB.ShareLink(
        new System.Uri("https://www.facebook.com/EcchiSenseii"), "Check it out!",
            "Good programming tutorials lol!",
            new System.Uri("https://www.cloudbees.com/sites/all/themes/juc2018/images/InfinityAnim_400px.gif"),
    callback: ShareCallback
);



    }

private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
                    }
    }

    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey! Come and play this awesome game!", title: "Recycle The World");
    }




    public void GetFriendsPlayingThisGame()
    {
        string query = "/me/friends";
        FB.API(query, HttpMethod.GET, result =>
        {
            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
            var friendsList = (List<object>)dictionary["data"];
            FriendsText.text = string.Empty;
            foreach (var dict in friendsList)
                FriendsText.text += ((Dictionary<string, object>)dict)["name"];
        });
    }

}

