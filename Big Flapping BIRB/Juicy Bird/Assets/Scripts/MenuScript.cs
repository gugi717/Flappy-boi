using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    //Grim
    void FixedUpdate()
    {
        //Checks if space is pressed
        if (Input.GetKeyDown("space"))
        {
            //sSend you to the game scene
            SceneManager.LoadScene("MainScene");
        }
    }
}

