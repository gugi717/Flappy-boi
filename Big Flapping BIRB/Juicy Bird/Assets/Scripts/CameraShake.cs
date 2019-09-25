using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Everythin is Gustav
    public Vector2 Amplitude;
    public Vector2 Frequency;
    Vector2 time = Vector2.zero;
    static bool shouldShake;
    static float Shaketime;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {


        time.x += Time.deltaTime * Frequency.x;
        time.y += Time.deltaTime * Frequency.y;

        Vector2 ShakePos;

        if (Shaketime > 0)
        {
            shouldShake = true; // activates the shake
        }
        else
        {
            shouldShake = false;
        }

        Shaketime -= Time.deltaTime; // how it counts how long you want the shake

        if (shouldShake)
        {
            ShakePos = new Vector3(Mathf.Sin(time.x),Mathf.Sin(time.y),0)* Amplitude; // the row of code that takes the variables to move the object accordingly.
        }
        else
        {
            ShakePos = Vector3.zero; // resets to default position when not being used
        }

        transform.localPosition = ShakePos;
    }

    public static void Shake(bool value)
    {
        shouldShake = value;
    } //useless just an example

    public static void Shake(float timeShake) // Exist so you can call on the funktion without having a GetComponent.
    {
        Shaketime = timeShake; 
    }
}
