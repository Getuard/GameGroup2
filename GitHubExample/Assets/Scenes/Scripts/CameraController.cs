using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;
    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;


    // Start is called before the first frame update
    void Start()
    {
        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void LateUpdate()
    {
        //get the x position of the mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0,horizontal,0);

        //get y
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //pivot.Rotate(-vertical,0,0);
        if(invertY){
            pivot.Rotate(vertical,0,0);
        }else{
            pivot.Rotate(-vertical,0,0);

        }

        //limit up and down camera.

        if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f){
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);

        }

        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f+minViewAngle){
            pivot.rotation = Quaternion.Euler(360f+minViewAngle, 0 , 0);
        }


        //Move the camera based on the current roatiou of the target & the original offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        
        transform.position = target.position - (rotation*offset);
        
        //transform.position = target.position - offset;

        if(transform.position.y < target.position.y){
            transform.position = new Vector3(transform.position.x, target.position.y -0.5f, transform.position.z);

        }

        transform.LookAt(target);
    }
    //Video 9

//     I just figured it out! The problem is with the min and max y rotations. He said to put it as;
// if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
//    pivot.rotation = Quaternion.Euler (maxViewAngle, 0, 0);           
// But the problem is that it's setting the Y rotation back to 0 every time you hit min or max. So instead you need it to stay the same, or to be more precise, be set to its current figure. To do this we need a float value. What I did is I dragged up a bit of the code that talked about desiredYAngle, which is updated each frame and is the current Y rotation. I then used this figure to adjust it and worked for me. I had to drag(copy and paste) the code up, as you can't use a value that hasn't been created yet. The way the script reads the code is in order from top to bottom.
// Here is what I did. Now the x rotation is set to min and max view angles, and the Y rotation is set to the current Y euler angle.

//   // move the camera based on the current rotation of the target and the original offset
//   float desiredYAngle = pivot.eulerAngles.y;

//   float desiredXAngle = pivot.eulerAngles.x;

//   //Limit the up/down camera rotation
//   if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
//    pivot.rotation = Quaternion.Euler (maxViewAngle, desiredYAngle, 0);
//   }

//   if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {
//    pivot.rotation = Quaternion.Euler (360f + minViewAngle, desiredYAngle, 0);
//   }

// Dude it's not working because you haven't done what I suggested. I said you need to use the desiredYAngle in the pivot rotation, otherwise it's being set to 0.
// You have this ;
// pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
// pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);

// You need this;
// pivot.rotation = Quaternion.Euler (maxViewAngle, desiredYAngle, 0);
// pivot.rotation = Quaternion.Euler (360f + minViewAngle, desiredYAngle, 0);

// Do you see the difference? In your example the Y axis in the vector3 thing is set to 0. In mine it's set to the desiredYAngle.
// You also need to move the part of the script that creates the float to be BEFORE this section so that it can read the what the desiredYAngle is before it tries to use it.

// Again dude, this is what you want.

//  // move the camera based on the current rotation of the target and the original offset
//   float desiredYAngle = pivot.eulerAngles.y;

//   float desiredXAngle = pivot.eulerAngles.x;

//   //Limit the up/down camera rotation
//   if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
//    pivot.rotation = Quaternion.Euler (maxViewAngle, desiredYAngle, 0);
//   }

//   if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {
//    pivot.rotation = Quaternion.Euler (360f + minViewAngle, desiredYAngle, 0);
//   }

    // public Transform target;
    // public Vector3 offset;
    // public bool useOffsetValues;
    // public float rotateSpeed;

    // // Optionally, add limits to the vertical rotation
    // public float minY = -40f;
    // public float maxY = 40f;
    // private float currentX = 0f;
    // private float currentY = 0f;

    // void Start()
    // {
    //     if (!useOffsetValues)
    //     {
    //         offset = target.position - transform.position;
    //     }

    //     // Initialize the current rotation of the camera
    //     Vector3 angles = transform.eulerAngles;
    //     currentX = angles.y;
    //     currentY = angles.x;
    // }

    // void LateUpdate()
    // {
    //     // Get the mouse movement inputs
    //     currentX += Input.GetAxis("Mouse X") * rotateSpeed;
    //     currentY -= Input.GetAxis("Mouse Y") * rotateSpeed; // Invert the vertical input
    //     currentY = Mathf.Clamp(currentY, minY, maxY); // Clamp the vertical rotation

    //     // Calculate the rotation and the new position
    //     Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
    //     Vector3 position = target.position - (rotation * offset);

    //     // Apply the rotation and position to the camera
    //     transform.position = position;
    //     transform.LookAt(target);
    // }
}
