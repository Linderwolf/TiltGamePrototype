using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GravityControl))]
public class PlayerController : MonoBehaviourPun
{

    PhotonView view;

    // public vars
    public float walkSpeed = 6;
    public float jumpForce = 750;
    public LayerMask groundedMask;

    // System vars
    bool grounded;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    Rigidbody rigidbody;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private AudioListener playerListener;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
        playerListener = playerCamera.GetComponent<AudioListener>();

        if (!photonView.IsMine && PhotonNetwork.IsConnected == true)
        {
            // If we want a Death-cam (See Other player's perspective), it may be best to set camera to not-active instead.
            //Destroy(playerCamera);
            //Destroy(playerListener);
            
            playerListener.enabled = false;
            playerCamera.enabled = false;
        }
    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        if (Input.GetKey(KeyCode.Escape))
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("MainMenuScene");
        }

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        // Jump via keyboard button, or phone screen touch // Input.acceleration is too finicky
        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (grounded)
            {
                rigidbody.AddForce(transform.up * jumpForce);
            }
        }
    }

    void FixedUpdate()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        // Player will only move if the view is for that player character - the one you spawned into the game
        {
            // Apply movement to rigidbody
            Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
            rigidbody.MovePosition(rigidbody.position + localMove);
        }
    }
}