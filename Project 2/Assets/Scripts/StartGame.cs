using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    // Use this for initialization
    public void PlayGame() {
        string scene = "WorkForce";
        Color loadToColor = Color.black;
        Initiate.Fade(scene, loadToColor, 3.0f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
