using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Ray ray;
    private RaycastHit hit;

    private Animator anim;
    private float x, z;
    private float velocitySpeed;

    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos;
    private Vector3 currPos;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
    }
    void Update()
    {
        //Caculate VelocitySpeed
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;
        Debug.Log(ct.m_FollowOffset);
        //get mouse position
        pos = Input.mousePosition;
        ct.m_FollowOffset = currPos;

        //Move player to point
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                nav.destination = hit.point;
            }
        }

        //anim
        if (velocitySpeed != 0)
        {
            anim.SetBool("sprinting", true);
        }
        else
            anim.SetBool("sprinting", false);

        if (Input.GetMouseButton(1))
        {
            if (pos.x != 0 || pos.y != 0)
            {
                currPos = pos / 200;
            }
        }
    }
}
