
using UnityEngine;
using Photon.Pun;


public class MovementPlayer : MonoBehaviourPunCallbacks
{

    public CharacterController controller;
    private Transform cam;

    private float rotationSpeed = 14f;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    private bool isGrounded;

    
    private Vector3 playerVelocity;
    private float playerSpeed = 5f;
    
    private float gravityValue = -9.81f;


    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    


    public float turnSmoothTime = 0.1f;

    private void Start()
    {

        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
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
            move = move.x * cam.right.normalized + move.z * cam.forward.normalized;
            move.y = 0f;
            controller.Move(move * Time.deltaTime * playerSpeed);



            // Changes the height position of the player..


            playerVelocity.y += gravityValue * 2 * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            Quaternion targetRotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        
    }

    private void Jump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
    }


}
