using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float boostSpeed = 20f; // Kecepatan boost
    [SerializeField] float baseSpeed = 5f; // Kecepatan dasar
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    public float rotationSpeed = 90f; // derajat per detik (sumbu Z)
    private GameObject[] wheels;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        wheels = GameObject.FindGameObjectsWithTag("Wheel");
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondBoost();
    }

    void RespondBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed; // Set speed to boost speed
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed; // Set speed to base speed
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }

        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
