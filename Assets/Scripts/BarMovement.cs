using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{
    public float lowestPos, highestPos, speed, deltaLerp, dir, startTime;
    Vector2 to, from;
    RectTransform trans;
    public RectTransform goalBar, backBar;
    public SodameterGauge sodameter;
    // Use this for initialization
    bool started = false;
	void Awake ()
    {
        trans = GetComponent<RectTransform>();
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
            highestPos = backBar.anchoredPosition.y + backBar.rect.height / 1.5f;
            lowestPos = backBar.anchoredPosition.y - backBar.rect.height / 1.5f;
            to = new Vector2(backBar.anchoredPosition.x, lowestPos);
            from = new Vector2(backBar.anchoredPosition.x, highestPos);
            deltaLerp = 0;
            dir = 1;
        }
        if (started)
        {
            highestPos = backBar.anchoredPosition.y + backBar.rect.height / 1.5f;
            lowestPos = backBar.anchoredPosition.y - backBar.rect.height / 1.5f;
            to = new Vector2(backBar.anchoredPosition.x, lowestPos);
            from = new Vector2(backBar.anchoredPosition.x, highestPos);

            if (Input.GetKeyDown(KeyCode.Space))
            {
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
            deltaLerp += Time.deltaTime * dir;
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
