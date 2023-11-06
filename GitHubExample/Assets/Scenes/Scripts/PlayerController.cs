using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    
    public float knockBackForce;
    public float KnockBackTime;
    private float KnockBackCounte;

    // Start is called before the first frame update
    void Start() {
        //theRB = GetComponent<Rigidbody>(); 
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        // if(Input.GetButtonDown("Jump")){
        //     theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);

        //}
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        
        if(KnockBackCounte <= 0)
        {

        float yStore = moveDirection.y;
        moveDirection = (Input.GetAxis("Vertical") * moveSpeed * transform.forward) + (Input.GetAxis("Horizontal") * moveSpeed * transform.right);
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if(controller.isGrounded)
        {
            moveDirection.y = 0.0f; 
            if (Input.GetButtonDown("Jump"))
             {
                moveDirection.y = jumpForce;
             }
        }
        }else{
            KnockBackCounte -= Time.deltaTime;
        }

        // if(Input.GetButtonDown("Jump"))
        // {
        //     moveDirection.y = jumpForce;
        // }
        moveDirection.y += Physics.gravity.y * gravityScale;
        controller.Move(moveDirection * Time.deltaTime);

        // //Move the player in different directions based on camera look directions
        // if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        // {
        //     transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
        //     Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
        //     playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        // }
    
    }
    public void Knockback(Vector3 direction)
    {
        KnockBackCounte = KnockBackTime;

        // direction = new Vector3(1f, 1f, 1f);

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;


    }
}
