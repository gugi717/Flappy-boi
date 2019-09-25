using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

