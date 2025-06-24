using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float torqueAmount = 10f;
    Rigidbody2D rb2d;
    public float rotationSpeed = 90f; // derajat per detik (sumbu Z)
    private GameObject[] wheels;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        wheels = GameObject.FindGameObjectsWithTag("Wheel");
    }

    // Update is called once per frame
    void Update()
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
