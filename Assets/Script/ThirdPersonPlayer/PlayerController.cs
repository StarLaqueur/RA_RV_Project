
using UnityEngine;
using Photon.Pun;


public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{

    public CharacterController controller;
    private Transform cam;
    private Animator anim;

    private float rotationSpeed = 14f;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    private bool isGrounded;
    public ThirdPersonInit thirdPersonScript;

    private Vector3 playerVelocity;
    private float playerSpeed = 5f;
    private float gravityValue = -9.81f;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private void Start()
    {

        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
  
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
                
            Jump();
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move == Vector3.zero)
        {
            Idle();
        }
        else if (move != Vector3.zero)
        {
            Run();
        }
        
        move = move.x * cam.right.normalized + move.z * cam.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        playerVelocity.y += gravityValue * 2 * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        Quaternion targetRotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        
    }

    private void Jump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    public void TakeDamage(float damage)
    {
        thirdPersonScript.TakeDamageGo(damage);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }


}
