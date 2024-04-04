using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    public LayerMask movMask;
    PlayerMotor motor;

    public Interactable focus; //focus and defocus from objs
    void Start()
    {
        cam=Camera.main;
        motor=GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movMask))
            {
                motor.MoveToPoint(hit.point);
                //move towards to what we hit 

                //stop focusing any objs
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check if we hit interactable
                Interactable  inter= hit.collider.GetComponent<Interactable>();
                if(inter!=null)
                {
                    SetFocus(inter);
                }

            }
        }
    }
    void SetFocus(Interactable newFocus)
    {

        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;   
            motor.FollowTarget(newFocus);   
        }

        newFocus.OnFocused(transform);

    }
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }
}
