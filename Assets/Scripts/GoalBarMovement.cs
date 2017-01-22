using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBarMovement : MonoBehaviour
{
    [HideInInspector]
    public float lowestPos, highestPos, speed, deltaLerp, dir;
    bool reached = false;
    float speedOfBar = 0.15f;
    Vector2 to, from;
    Vector2 startPos;
    public RectTransform backBar;
    float startTime;
    RectTransform trans;
    bool started = false;
    // Use this for initialization
	void Start ()
    {
        trans = GetComponent<RectTransform>();
        startPos = trans.anchoredPosition;
        StartCoroutine(speedUpBar());
	}
	
    IEnumerator speedUpBar()
    {
        yield return new WaitForSeconds(0.1f);
        speedOfBar += speedOfBar;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Jump") && !started)
        {
            startTime = Time.time;
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

            if ((Time.time - startTime) <= 6f)
            {
                float scaleFactor = 0.7f - ((Time.time - startTime) / 12f);
                scaleFactor = (trans.localScale.y <= scaleFactor) ? trans.localScale.y : scaleFactor;
                //Debug.Log("Scale Factor: " + scaleFactor);
                trans.localScale = new Vector3(trans.localScale.x, scaleFactor, trans.localScale.z);
            }


            if (deltaLerp >= 1)
            {
                dir = -1;
                reached = true;
            }
            else if (deltaLerp <= 0)
            {
                dir = 1;
            }
            deltaLerp += speedOfBar * Time.deltaTime * dir;
            trans.anchoredPosition = Vector2.Lerp((reached)? from : startPos, to, deltaLerp);
        }
    }
}
