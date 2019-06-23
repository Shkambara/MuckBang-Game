using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    void Start()
    {
        newGameDelay();
    }

    IEnumerator newGameDelay()
    {
        yield return new WaitForSeconds(2);
    }

    // Use this for initialization
    public void RestartGame()
    {
        Application.LoadLevel(mainMenuLevel);
    }

    // Update is called once per frame
}
