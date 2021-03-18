using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private readonly float speed = 2;

    private new Rigidbody rigidbody;
    private Animator animator;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (GameManager.instance.GameRunning)
            {
                transform.rotation = Quaternion.Euler(0, -transform.rotation.eulerAngles.y, 0);
            }
            else
            {
                animator.SetTrigger("running");

                GameManager.instance.StartGame();
            }
        }


        animator.SetFloat("position.y", transform.position.y);

        if (transform.position.y < -3)
        {
            GameManager.instance.ResetGame();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.instance.GameRunning)
        {
            rigidbody.transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.AddPoint();
        other.gameObject.SetActive(false);
    }
}
