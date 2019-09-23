using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
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
            shouldShake = true;
        }
        else
        {
            shouldShake = false;
        }

        Shaketime -= Time.deltaTime;

        if (shouldShake)
        {
            ShakePos = new Vector3(Mathf.Sin(time.x),Mathf.Sin(time.y),0)* Amplitude;
        }
        else
        {
            ShakePos = Vector3.zero;
        }

        transform.localPosition = ShakePos;
    }

    public static void Shake(bool value)
    {
        shouldShake = value;
    }

    public static void Shake(float timeShake)
    {
        Shaketime = timeShake;
    }
}
