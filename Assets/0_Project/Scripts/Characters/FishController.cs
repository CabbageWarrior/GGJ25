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
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float blinkTime = 2f;

    [Header("References")]
    [SerializeField] private GameObject mesh1Pivot = null;
    [SerializeField] private GameObject mesh2Pivot = null;
    [Space]
    [SerializeField] private Rigidbody rb = null;
    [Space]
    [SerializeField] private NormalBubble bubble = null;
    [Space]
    [SerializeField] private List<Renderer> renderers = new List<Renderer>();

    #endregion

    private GameInputSystem input;
    private bool isGrounded = true;
    private bool jumpWait = false;

    private int bubbleState = 0;

    private bool isImmune = false;

    private ScoreManager sm;

    private Animator anim;

    private void Awake()
    {
        input = new GameInputSystem();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        sm = FindObjectOfType<ScoreManager>();

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
        if (Time.timeScale == 0f)
            return;

        if (value.sqrMagnitude == 0f)
        {
            return;
        }

        Vector2 axisInput = value;

        //float horizontalInput = axisInput.x;
        //float forwardInput = axisInput.y;

        //Vector3 vel = new Vector3(horizontalInput, 0f, forwardInput).normalized * speed;
        //vel.y = rb.velocity.y;
        //rb.velocity = vel;

        //rb.AddForce(new Vector3(axisInput.x, 0f, axisInput.y) * speed - rb.velocity, ForceMode.VelocityChange);
        rb.AddForce(new Vector3(axisInput.x, 0f, axisInput.y) * speed, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        rb.MoveRotation(Quaternion.LookRotation(rb.velocity));
        rb.angularVelocity = new Vector3(0f, rb.angularVelocity.y, 0f);
    }
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.timeScale == 0f)
            return;

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

    private void SetBubbleState(int state)
    {
        bubbleState = state;

        bubble.SetState(state);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("SpawnedBubble"))
        {
            if (bubbleState == 0)
            {
                SpawnBubble spawnBubble = collider.GetComponentInParent<SpawnBubble>();
                if (spawnBubble)
                {
                    SetBubbleState(spawnBubble.step);
                    spawnBubble.Grabbed();
                }
            }
        }
        else if (collider.CompareTag("SpawnedSpecialBubble"))
        {
            SpawnSpecialBubble spawnSpecialBubble = collider.GetComponentInParent<SpawnSpecialBubble>();

            ESpecialBubble specialState = spawnSpecialBubble.specialState;

            switch (specialState)
            {
                case ESpecialBubble.Marijuana:
                    break;
                case ESpecialBubble.Alcohol:
                    break;
                case ESpecialBubble.Heroine:
                    break;
                case ESpecialBubble.Cosby:
                    break;
                case ESpecialBubble.Viagra:
                    break;
                default:
                    break;
            }

            spawnSpecialBubble.Explode();
        }
        else if (collider.CompareTag("Nest"))
        {
            if (bubbleState != 0)
            {
                NestController nest = collider.GetComponentInParent<NestController>();

                nest.AddBubble(bubbleState);
                SetBubbleState(0);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;

        Debug.Log("COLLIDED!!!!!!! " + collider.tag, collider.gameObject);

        if (collider.CompareTag("stabby"))
        {
            SetHit();
        }
        else if (collider.CompareTag("Deadly"))
        {
            SetCatHit();
        }
    }

    private void SetHit()
    {
        if (!isImmune)
        {
            sm.AddHit();
            SetImmune();
        }

    }
    private void SetCatHit()
    {
        if (!isImmune)
        {
            sm.AddCatHit();
            SetImmune();
        }

    }

    private void SetImmune()
    {
        isImmune = true;
        anim.SetBool("DoBlink", true);

        StartCoroutine(Co());

        IEnumerator Co()
        {
            var timer = 0f;
            while (timer < blinkTime)
            {
                timer += Time.deltaTime;
                foreach (var item in renderers)
                {
                    item.enabled = !item.enabled;
                }
                yield return null;
            }
            foreach (var item in renderers)
            {
                item.enabled = true;
            }
            isImmune = false;
            anim.SetBool("DoBlink", false);
        }
    }
}
