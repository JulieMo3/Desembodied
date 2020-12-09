using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public Camera cam;
    public InteractableObjects focus;
    private Vector3 moveDirection = Vector3.zero;
    public enum playerType { Demulos, Sfey, Puppet };
    public playerType myPlayer;


    private void Start()
    {
        //Set player type for the game
        int type = Random.Range(0, 2);
        switch (type)
        {
            case 0:
                myPlayer = playerType.Demulos;// | playerType.Puppet;
                break;
            case 1:
                myPlayer = playerType.Sfey;//| playerType.Puppet;
                break;
            default:
                Debug.Log("No type");
                break;
        }

    }

    void Update()
    {

        //Movement controller
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            //controller.Move(Vector3.back * Time.deltaTime);
            Vector3 camEuler = cam.transform.rotation.eulerAngles;
            transform.eulerAngles = new Vector3(0, camEuler.y, camEuler.z);
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);



        /*  //LeftClick mouse
          if (Input.GetMouseButtonDown(0))
          {

              //raycast creation
              Ray ray = cam.ScreenPointToRay(Input.mousePosition);
              RaycastHit hit;

              if (Physics.Raycast(ray, out hit, 100) )
              {
                  InteractableObjects interactable = hit.collider.GetComponent<InteractableObjects>();
                  if(interactable != null)
                  {
                      SetFocus(interactable);
                  }

              }
              else//modifier et mettre une condition d'interaction
              {
                  RemoveFocus();
              }

          }
      }
      
      void SetFocus(InteractableObjects newFocus)
      {
          if(newFocus != focus)
          {
              if (focus != null)
              {
                  focus.OnDefocused();
              }
              focus = newFocus;
          } 
          newFocus.OnFocused(transform);
      }

      void RemoveFocus()
      {

          if(focus!= null)
          {
              focus.OnDefocused();
          }
          focus = null;
      }*/
    }


    public virtual void camSetting()
    {

    }

    public void SetPlayerComposition(playerType player)
    {

    }

  
}
