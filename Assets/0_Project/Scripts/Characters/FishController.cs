using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FishController : MonoBehaviour
{
    #region Enums

    private enum EPlayerNum
    {
        One,
        Two
    }

    #endregion

    #region Inspector info

    [SerializeField] private EPlayerNum playerNum = EPlayerNum.One;

    [Header("Settings")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1f;

    [Header("References")]
    [SerializeField] private GameObject mesh1Pivot = null;
    [SerializeField] private GameObject mesh2Pivot = null;
    [Space]
    [SerializeField] private Rigidbody rb = null;

    #endregion

    private GameInputSystem input;
    private bool isGrounded = true;
    private bool jumpWait = false;

    private void Awake()
    {
        input = new GameInputSystem();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        if (playerNum == EPlayerNum.One)
        {
            input.Player1.Movement.performed += Movement_performed;
            input.Player1.Jump.performed += Jump_performed;

            mesh1Pivot.SetActive(true);
            mesh2Pivot.SetActive(false);
        }
        else
        {
            input.Player2.Movement.performed += Movement_performed;
            input.Player2.Jump.performed += Jump_performed;

            mesh1Pivot.SetActive(false);
            mesh2Pivot.SetActive(true);
        }
    }

    private void Update()
    {
        if (jumpWait)
        {
            isGrounded = Grounded();
            jumpWait = false;
        }

        if (playerNum == EPlayerNum.One)
        {
            Move(input.Player1.Movement.ReadValue<Vector2>());
        }
        else
        {
            Move(input.Player2.Movement.ReadValue<Vector2>());
        }
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Move(obj.ReadValue<Vector2>());
    }
    private void Move(Vector2 value)
    {
        if (value.sqrMagnitude == 0f)
        {
            return;
        }

        Vector2 axisInput = value;

        float horizontalInput = axisInput.x;
        float forwardInput = axisInput.y;

        Vector3 vel = new Vector3(horizontalInput, 0f, forwardInput).normalized * speed;
        vel.y = rb.velocity.y;
        rb.velocity = vel;
    }
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (obj.ReadValueAsButton() && Grounded())
        {
            Vector3 vel = rb.velocity;
            vel.y = jumpForce;
            rb.velocity = vel;

            isGrounded = false;
            StartCoroutine(JumpFrameSkipRoutine());
        }
    }

    private bool Grounded()
    {
        return Physics.Raycast(gameObject.transform.position, -Vector3.up, .8f);
    }

    private IEnumerator JumpFrameSkipRoutine()
    {
        while (!isGrounded)
        {
            yield return new WaitForSeconds(.1f);
            jumpWait = true;
        }
    }
}
