using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLaunch : MonoBehaviour {

    public GameObject burpEffect;
    Rigidbody2D rb;
    bool jumped = false;
    bool fall = false;
    public float turnAmmount;
    //new Vector3(Ycomp, Xcomp, hangTime)
    public int JumpInfoX;
    public int JumpInfoY;
    public float hangTime;
    public SodameterGauge sodameter;
    public float power;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (jumped && rb.velocity.y <= 0)
        {
            rb.gravityScale = 0.0f;
        }

        if(fall)
        {
            rb.gravityScale = 3;
        }
    }

    public void Launch(float power)
    {
        if (power > 1)
        {
            power = 1.0f;
        }
        Instantiate(burpEffect,transform.position, Quaternion.identity);
        rb.AddForce(new Vector2(power * JumpInfoX, power * JumpInfoY));
        rb.AddTorque(turnAmmount);
        jumped = true;
        StartCoroutine(Hang());
    }

    //death at water bottom
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "deathzone") //loose at water
        {
            SceneManager.LoadScene(2);
        }
        if(coll.tag == "winzone") //win at flag
        {
            SceneManager.LoadScene(3);
        }
    }


    IEnumerator Hang()
    {
            yield return new WaitForSeconds(power * hangTime);
            fall = true;
            jumped = false;
    }
}
