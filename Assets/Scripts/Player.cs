using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Move();
        }
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Rotate();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Alert"))
        {
            GameManager.Instance.IsAlertActive = true;
        }

        if (other.CompareTag("Safe"))
        {
            GameManager.Instance.IsSafeZoneActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Alert"))
        {
            GameManager.Instance.IsAlertActive = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameManager.Instance.IsPlayerAlive = false;
        }
    }

    private void Move()
    {
        Vector3 movement = (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X"), 0f) * rotationSpeed * Time.deltaTime);
        cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0f, 0f) * rotationSpeed * Time.deltaTime);
    }
}
