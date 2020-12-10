using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    private bool onGround = true;
    private const int maxJump = 2;
    private int currentJump = 0;
    private int score;


    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);
        // Taking the cameras transform to always look forward
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        var cameraRotation = Quaternion.LookRotation(cameraForward);
        //rotating input direction
        Vector3 cameraRelativeInputDirection = cameraRotation * inputDirection;
        // Change physics material
        collider.material = inputDirection.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;

        //Old way to changing physics materials

        //if(inputDirection.magnitude > 0)
        //{
        //    collider.material = movingPhysicsMaterial;
        //}
        //else
        //{
        //    collider.material = stoppingPhysicsMaterial;
        //}

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(cameraRelativeInputDirection * accelerationForce, ForceMode.Acceleration);
        }

        if (cameraRelativeInputDirection.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(cameraRelativeInputDirection);
            transform.rotation = targetRotation;
        }
        

        


    }
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && (onGround || maxJump > currentJump))
        {
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        currentJump = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            
            Destroy(other.gameObject);
            score++;
            if (score == 5)
            {
                Debug.Log("WIN");
            }
        }

    }
}
