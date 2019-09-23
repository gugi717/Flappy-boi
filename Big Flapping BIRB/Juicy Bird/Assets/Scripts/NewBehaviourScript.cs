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
    public GameObject GivePoint;
    public GameObject LifeParticleSystem;
    public float tid;
    public AudioSource ljud;
    public Text points;
    public float pointsIgen;
    public bool SoundReplay;
    public float life;


    // Start is called before the first frame update
    void Start()
    {

        tid = 2;
        SoundReplay = false;
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
            int r = Random.Range(0, 8);

            ajj.Add(typ);
            if (r == 0)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 3.1f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, 0.0f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 1)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 3.4f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, 0.3f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 2)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 2.5f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, -0.6f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 3)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 2.3f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, -0.8f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 4)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 3.1f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, 0.0f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 5)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 4.0f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, 0.775f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 6)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 3.2f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, 0.1f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 7)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 2.5f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, -0.7f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(ExtraLife, new Vector3(3.5f, 1.2f, 0), Quaternion.identity);
                ajj.Add(typ);
            }

            typ = Instantiate(GivePoint, new Vector3(3, 0.0f, 0), Quaternion.identity);
            ajj.Add(typ);
            tid = 2;
        }

        if (start == true)
        {
            if (lose == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    fysik.AddForce(Vector3.up * 75);
                }
            }
        }

        if (lose == true)
        {
            if (ljud.isPlaying == false)
            {
                if (SoundReplay == false)
                {
                    ljud.Play();
                    SoundReplay = true;
                }
            }
            
            fysik.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("lost");
        }

        if (ajj.Count > 17)
        {
            Destroy(ajj[0]);
            ajj.RemoveAt(0);
        }
        for (int i = 0; i < ajj.Count; i++)
        {

            ajj[i].transform.position -= new Vector3(0.7f * Time.deltaTime, 0, 0);
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
                fysik.AddForce(Vector3.up * 75);
            }
        }

        if (life <= 0)
        {
            lose = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "DONTTOUCH")
        {
            life -= 1;
        }

        if (other.transform.tag == "extralife")
        {
            life += 1;
            GameObject typ = new GameObject();

            typ = Instantiate(LifeParticleSystem, new Vector3(-0.534f, 1.453f, 0), Quaternion.identity);
            ajj.Add(typ);
        }

        if (other.transform.tag == "Point" && !lose)
        {
            pointsIgen += 1;
        }
    }
}
