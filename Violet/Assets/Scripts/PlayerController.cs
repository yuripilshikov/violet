using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    
    Camera cam;

    public LayerMask movementMask;
    PlayerMotor motor;

    [SerializeField] int maxDistance = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        // do not move when clicking on inventory
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        //left click - movement
        // Right click - action
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, maxDistance, movementMask))
            {
                //Debug.Log("We hit " + hit.collider.name + hit.point);

                // move our player here
                motor.MoveToPoint(hit.point);

                //stop focusing any object
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if(interactable != null)
                {
                    SetFocus(interactable);
                }

            }
        }
    }

    

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.onDefocused();
            }
                        
            focus = newFocus;
            motor.FollowTarget(newFocus);

        }
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if(focus != null)
        {
            focus.onDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
}
