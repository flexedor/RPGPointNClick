using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems; // Add this line
public class CharacterControlScript : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;
    public GameObject targetDest;
    private int maskForClick;

    private void Awake()
    {
        maskForClick =1<<6;
        maskForClick = ~maskForClick;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown((0)))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            //  || Physics.Raycast(ray,out hitPoint,Mathf.Infinity,maskForClick)
            //
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Debug.Log("Clicked on the UI");
                return;
            }

            if (Physics.Raycast(ray,out hitPoint,Mathf.Infinity,~maskForClick))
            {
                targetDest.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);
            }
        }

        if (player.velocity!=Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }else if (player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
        }
        
    }
}
