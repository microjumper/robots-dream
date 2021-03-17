using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapDirection()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, -currentAngle, 0);
    }
}
