using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    Rigidbody rb;

    private float distanceToGround;
    bool isGrounded;
    public float jump = 5f;
    public float walkSpeed = 5f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    private Animator playerAnimator;
    private bool isWalking = false;

    private void Awake() {
        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();

        inputAction.Player.Look.performed += cntxt => rotate = cntxt.ReadValue<Vector2>();
        inputAction.Player.Look.canceled += cntxt => rotate = Vector2.zero;

        inputAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() {
        inputAction.Player.Enable();
    }

    // 20 frames per second
    // 1/20 = 0.05
    // 20 * 1 * 10 * 0.05 = 10
    // 500 frames per second
    // 1/500 = 0.002
    // 500 * 1* 10 * 0.002 = 10
    private void Update() {
        cameraRotation = new Vector3(cameraRotation.x + rotate.y, cameraRotation.y + rotate.x, cameraRotation.z);
        transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);

        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);
    }

    private void LateUpdate() {
        // playerCamera.transform.eulerAngles = new Vector3(cameraRotation.x, cameraRotation.y, cameraRotation.z);
        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    private void OnDisable() {
        inputAction.Player.Disable();
    }

    private void Jump()
    {
        Debug.Log("Jump button is pressed!");
    }

    private void Shoot()
    {

    }
}
