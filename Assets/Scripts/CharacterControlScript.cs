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
        //6 layer is Floor 
        maskForClick =1<<6;
        //reversing layer mask for everything that is not Floor
        maskForClick = ~maskForClick;
    }
    
    /// <summary>
    ///in Update there is checking input and setting destination fo nav mesh Agent
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown((0)))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (Physics.Raycast(ray,out hitPoint,Mathf.Infinity,~maskForClick))
            {
                targetDest.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);
            }
        }
        //set active animation 
        playerAnimator.SetBool("isWalking", player.velocity!=Vector3.zero);

    }
}
