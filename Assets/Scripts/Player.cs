using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float speed = 720;
    private readonly float rightAngle = 45;
    private readonly float leftAngle = -45;

    private bool isFacingRight;
    private bool isTurning;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, rightAngle, 0);
        isFacingRight = true;
        isTurning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Turn()
    {
        if(!isTurning)
        {
            StartCoroutine(SmoothTurn());
        }
    }

    private IEnumerator SmoothTurn()
    {
        isTurning = true;

        float targetAngle = isFacingRight ? leftAngle : rightAngle;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
            yield return null;
        }

        isFacingRight = !isFacingRight;

        isTurning = false;
    }
}
