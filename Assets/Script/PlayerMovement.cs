using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rotationAngle = 35f;
    [SerializeField] private float movementSmoothing = 10f;
    [SerializeField] private int life = 3;
    [SerializeField] private GameObject LoseScreen;
    public AudioSource audiodamage;
    public AudioSource audioLose;
    public TextMeshProUGUI TextLife;
    private bool rotateRight = false;
    private bool rotateLeft = false;
    private bool rotateUp = false;
    private bool rotateDown = false;
    private Vector3 velocity;
    

    void Update()
    {
        Rotation();
        UpdateLife();

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 movementPlayer = context.ReadValue<Vector2>();
        myRBD.velocity = new Vector3(movementPlayer.x * velocityModifier, movementPlayer.y * velocityModifier, 0f);
        rotateRight = (movementPlayer.x > 0);
        rotateLeft = (movementPlayer.x < 0);
        rotateUp = (movementPlayer.y > 0);
        rotateDown = (movementPlayer.y < 0);
        Vector3 targetVelocity = new Vector3(movementPlayer.x, movementPlayer.y, 0f) * velocityModifier;
        velocity = Vector3.Lerp(velocity, targetVelocity, 1f - Mathf.Exp(-movementSmoothing * Time.deltaTime));
    }
    private void Rotation()
    {
        transform.position += velocity * Time.deltaTime;

        if (rotateRight)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -rotationAngle);
        }
        else if (rotateLeft)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }
        else if (rotateUp)
        {
            transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);
        }
        else if (rotateDown)
        {
            transform.rotation = Quaternion.Euler(-rotationAngle, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            life = life - 1;
            Shake.Instance.CameraMovement(4, 2, 3);
            audiodamage.Play();
        }
        else
        {
            
        }
    }
    private void UpdateLife()
    {
        TextLife.text = "Vida: " + life;

        if (life == 0)
        {
            audioLose.Play();
            LoseScreen.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}