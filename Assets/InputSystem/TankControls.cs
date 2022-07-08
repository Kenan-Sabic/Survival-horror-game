using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TankControls : MonoBehaviour
{
    //reference variable declarations
   PlayerTankControls playerTankControls;
   InputAction movement;
   CharacterController characterController;
   float rotationPerFrame = 30.0f;

   //variables that store player input
   Vector2 currentMovementInput; 
   Vector3 currentMovement;
   float currentTurning;
   bool isMovementPressed;
   bool isTurningPressed;

 



    void Awake()
    {


     //actual controls
   playerTankControls = new PlayerTankControls ();
   characterController = GetComponent<CharacterController>();  //character controller

      //player input, getting character to actually move
   playerTankControls.Player.Movement.started +=onMovementInput;
   playerTankControls.Player.Movement.performed +=onMovementInput;
   playerTankControls.Player.Movement.canceled +=onMovementInput;  

    playerTankControls.Player.Turning.started +=onTurning;
    playerTankControls.Player.Turning.performed +=onTurning;
   playerTankControls.Player.Turning.canceled +=onTurning;

    }

    void onMovementInput (InputAction.CallbackContext context){
       Debug.Log(context.ReadValue<Vector2>());
  
      currentMovementInput = context.ReadValue<Vector2>();
      currentMovement.x = currentMovementInput.x;
      currentMovement.z = currentMovementInput.y;
      isMovementPressed = currentMovementInput.x !=0 || currentMovementInput.y !=0;


    }

    void onTurning (InputAction.CallbackContext context){
      Debug.Log(context.ReadValue<float>());
      currentTurning = context.ReadValue<float>();
      isTurningPressed = currentTurning !=0;

    }


    void handleRotation (){
      Vector3 positionToLookAt ;
      positionToLookAt.x = 0.0f ;
      positionToLookAt.y = currentTurning*rotationPerFrame*Time.deltaTime;
      positionToLookAt.z = 0.0f;

     // Quaternion currentRotation = transform.rotation;

      if(isTurningPressed){
        // Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
        // transform.rotation = Quaternion.Slerp(currentRotation,targetRotation, rotationPerFrame);
            transform.Rotate(positionToLookAt,Space.Self);


      }

    

    }


     void OnEnable()
    {

        playerTankControls.Player.Enable();
    
 }

    

    void OnDisable()
    {
       playerTankControls.Player.Disable();
       






    }

    void Update(){
     // currentMovement = Vector3.forward;
 

     characterController.Move( currentMovement *Time.deltaTime);
     handleRotation();

    }
    void FixedUpdate(){}
    

 
}

    
   


