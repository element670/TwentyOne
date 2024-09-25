using System;
using System.Collections;
using UnityEngine;
public class Row : MonoBehaviour
{
    public void StartRotating(Action matchMaking, float speed)
    {
        StartCoroutine(RotatingRow(matchMaking, speed));
    }

    private IEnumerator RotatingRow(Action matchMaking, float speed)
    {

        while (speed >= 5)
        {
            speed = speed / 1.5f;
            transform.Translate(Vector2.up * Time.deltaTime * -speed);
            
            if (transform.localPosition.y <= -147)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 126.4f);
            }
            yield return new WaitForSeconds(0.05f);
        }

        if (transform.localPosition.y >= 39.2f)
        {
            transform.localPosition = new Vector2(transform.localPosition.x,130);
        }

        if (transform.localPosition.y < -85.8f)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, 3);
        }
        yield return new WaitForSeconds(1.5f);
        matchMaking.Invoke();
        
    }
}
