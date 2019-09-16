using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject player;
    public Rigidbody fysik;
    public bool lose;
    public bool start;
    public List<GameObject> ajj;
    public GameObject Upperpipe;
    public GameObject Lowerpipe;
    public GameObject ExtraLife;
    public float tid;
    public AudioSource ljud;
    public Text points;
    public float pointsIgen;
    public float SoundReplay;
    public float life;


    // Start is called before the first frame update
    void Start()
    {

        tid = 3;
        SoundReplay = 0;
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Score: " + pointsIgen;
        tid -= Time.deltaTime;
        if (start == true && tid <= 0)
        {
            GameObject typ = new GameObject();
            int r = Random.Range(0, 2);

            typ = Instantiate(ExtraLife, new Vector3(4, 1.2f, 0), Quaternion.identity);

            ajj.Add(typ);

            typ = Instantiate(Upperpipe, new Vector3(3, 2.5f, 0), Quaternion.identity);

            ajj.Add(typ);

            typ = Instantiate(Lowerpipe, new Vector3(3, 0.6f, 0), Quaternion.identity);

            ajj.Add(typ);
            tid = 3;
        }

        if (start == true)
        {
            if (lose == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    fysik.AddForce(Vector3.up * 250);
                }
            }
        }

        if (lose == true)
        {
            if (ljud.isPlaying == false)
            {
                ljud.Play();
            }
            
            fysik.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("lost");
        }

        if (ajj.Count > 10)
        {
            Destroy(ajj[0]);
            ajj.RemoveAt(0);
        }
        if (start == true)
        {
            if (lose == false)
            {
                pointsIgen += 1 * Time.deltaTime;
            }
        }
        for (int i = 0; i < ajj.Count; i++)
        {

            ajj[i].transform.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        }

        if (start == false)
        {
            fysik.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Not started");
        }
        else
        {
            if (lose == false)
            {
                fysik.constraints = RigidbodyConstraints.None;
                fysik.constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log("started");
            }
            
        }

        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                fysik.AddForce(Vector3.up * 250);
            }
        }

        if (life <= 0)
        {
            lose = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "DONTTOUCH")
        {
            life -= 1;
        }

        if (collision.gameObject.tag == "extralife")
        {
            life += 1;
        }
    }
}
