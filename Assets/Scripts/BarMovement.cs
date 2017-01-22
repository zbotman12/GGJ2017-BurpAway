using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarMovement : MonoBehaviour
{
    [HideInInspector]
    public float lowestPos, highestPos, speed, deltaLerp, dir, startTime;
    public Animator animator;
    public float speedOfBar;
    Vector2 to, from;
    Vector2 startPos;
    public int AmountOfPresses;
    int presses = 0;
    RectTransform trans;
    public Image DangerText;
    public Image SpaceText;
    public RectTransform goalBar, backBar;
    public SodameterGauge sodameter;
    // Use this for initialization
    bool started = false;
	void Awake ()
    {
        trans = GetComponent<RectTransform>();
        startPos = trans.anchoredPosition;
        highestPos = backBar.anchoredPosition.y + backBar.rect.height / 1.5f;
        lowestPos = backBar.anchoredPosition.y - backBar.rect.height / 1.5f;
        to = new Vector2(backBar.anchoredPosition.x, lowestPos);
        from = new Vector2(backBar.anchoredPosition.x, highestPos);
        StartCoroutine(speedUpBar());
    }

    IEnumerator speedUpBar()
    {
        yield return new WaitForSeconds(0.1f);
        speedOfBar += speedOfBar;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / 2f, 1f)));
        if (Input.GetButtonDown("Jump") && !started)
        {
            //startTime = Time.time;
            StartCoroutine(getRidOfStuff());
            started = true;
            deltaLerp = 0.5f;
            dir = 1;
        }
        else if (started)
        {
            if (Input.GetButtonDown("Jump"))
            {
                presses++;
                if(presses >= (AmountOfPresses - 5))
                {
                    DangerText.enabled = true;
                    SpaceText.enabled = false;
                }
                if(presses >= AmountOfPresses)
                {
                    animator.SetTrigger("Explode");
                    SceneManager.LoadScene(1);

                }
                dir *= -1;
            }
            if (deltaLerp >= 1)
            {
                dir = -1;
            }
            else if (deltaLerp <= 0)
            {
                dir = 1;
            }
            deltaLerp += speedOfBar * Time.deltaTime * dir;
            trans.anchoredPosition = Vector2.Lerp(from, to, deltaLerp);

            if ((trans.anchoredPosition.y >= (goalBar.anchoredPosition.y + goalBar.rect.height / 2.5f)) ||
               (trans.anchoredPosition.y <= (goalBar.anchoredPosition.y - goalBar.rect.height / 2.5f)))
            {
                sodameter.stopFill();
            }
            else
            {
                sodameter.fill();
            }
        }
    }

    IEnumerator getRidOfStuff()
    {
        yield return new WaitForSeconds(6.0f);
        sodameter.stopFill();
        Destroy(GameObject.FindGameObjectWithTag("MainMechanicBar"));
        Destroy(GameObject.FindGameObjectWithTag("Sodameter"));
    }
}
