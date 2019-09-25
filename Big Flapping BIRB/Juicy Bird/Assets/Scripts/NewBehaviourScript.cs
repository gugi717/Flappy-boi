using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    //Variables
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
    public Text TextLife;
    public float JumpDelay = 0;
    private Animator anim;
    protected bool Jump = false;

    // Start is called before the first frame update
    void Start()
    {
        tid = 2;
        SoundReplay = false;
        life = 1;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Grim
        //Checks if key r is pressed if so you reload/restart the game.
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //Grim
        //The hp and score shown on screen
        TextLife.text = "Hp: " + life;
        points.text = "Score: " + pointsIgen;

        tid -= Time.deltaTime;
        if (start == true && tid <= 0 && !lose) // Gustav, If you have started the game there is a delay to activate the funktion
        {
            GameObject typ = new GameObject();
            ajj.Add(typ); //stops the row above from spawning empty gameobject that newer despawns
            int r = Random.Range(0, 8); //Gustav, Pick a random nummber so it can pick between the premade sets

            if (r == 0)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 3.1f, 0), Quaternion.identity); //Gustav, spawns a pipe in the location that has been set
                ajj.Add(typ); // places them in an array
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
                typ = Instantiate(Upperpipe, new Vector3(3, 2.55f, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, -0.6f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            if (r == 3)
            {
                typ = Instantiate(Upperpipe, new Vector3(3, 2.4f, 0), Quaternion.identity);
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
                typ = Instantiate(Upperpipe, new Vector3(3, 4, 0), Quaternion.identity);
                ajj.Add(typ);
                typ = Instantiate(Lowerpipe, new Vector3(3, 0.7f, 0), Quaternion.identity);
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
                //Grim
                //Extra life is spawned 1/8 of the times
                typ = Instantiate(ExtraLife, new Vector3(3.5f, 1f, 0), Quaternion.identity);
                ajj.Add(typ);
            }
            //Gustav, spawns an emnty gameobject that has a boxcollider that when toched gives a point due to the tag
            typ = Instantiate(GivePoint, new Vector3(3, 0.0f, 0), Quaternion.identity); 
            ajj.Add(typ);
            tid = 2;// resets the timer
        }

        if (start == true)
        {
            if (lose == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    fysik.AddForce(Vector3.up * 75); //Gustav, makes that player jump
                    anim.SetBool("Jump", true); //Gustav, plays the animation for jumping/flying
                }
                else
                {
                    anim.SetBool("Jump", false); //Gustav, stops the animation when falling
                }
            }
        }


        //Grim
        //Checks if you have lost
        if (lose == true)
        {
            //Checks if sound is playing
            if (ljud.isPlaying == false)
            {
                //Checks if the sound has played
                if (SoundReplay == false)
                {
                    //Plays sound
                    ljud.Play();
                    SoundReplay = true;
                }
            }
            
            fysik.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("lost");
        }

        if (ajj.Count > 17)
        {
            Destroy(ajj[0]); //destroys gameobjects in the array after so many has spawned 
            ajj.RemoveAt(0);
        }
        for (int i = 0; i < ajj.Count; i++)
        {
            if (!lose)
            {
                ajj[i].transform.position -= new Vector3(0.7f * Time.deltaTime, 0, 0); //Is the thing that moves the "pipes"
            }

        }
        // makes so you don't die before starting the game for real
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
        // Gustav, starts the game
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
                fysik.AddForce(Vector3.up * 75);
                anim.SetBool("Jump", true);
            }
        }

        //Grim
        //Makes you lose if you have 0 or less hp
        if (life <= 0)
        {
            lose = true;
            anim.SetBool("OnLose", true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Grim
        //A collider put on roof, floor and pillars to do damage to the player
        if (other.transform.tag == "DONTTOUCH" && !lose)
        {
            life -= 1;
            //Gustav
            //Starts camera shake if you die/takes damage
            CameraShake.Shake(0.5f);
        }

        //Grim
        //The tag that is put on the power up "extra life" to give the player more hp and summon a particle
        if (other.transform.tag == "extralife" && life < 3)
        {
            life += 1;
            GameObject typ = new GameObject();

            typ = Instantiate(LifeParticleSystem, new Vector3(-0.534f, 1, 0), Quaternion.identity);
        }

        if (other.transform.tag == "Point" && !lose) // We spawn emty gameobject between the "pipes" that has a trigger collider and tag to give you a point
        {
            pointsIgen += 1;
        }
    }
}
