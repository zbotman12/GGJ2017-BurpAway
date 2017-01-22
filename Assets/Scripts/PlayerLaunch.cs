using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerLaunch : MonoBehaviour {

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
        rb.AddForce(new Vector2(power * JumpInfoX, power * JumpInfoY));
        rb.AddTorque(turnAmmount);
        jumped = true;
        StartCoroutine(Hang());
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "deathzone")
        {
            Debug.Log("changeScene~!!!!");
        }
    }

    IEnumerator Hang()
    {
            yield return new WaitForSeconds(power * hangTime);
            fall = true;
            jumped = false;
    }
}
