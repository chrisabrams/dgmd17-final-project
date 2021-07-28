using UnityEngine;
using UnityEngine.SceneManagement;


public class DroneMovement : MonoBehaviour
{
    public float movementSpeed = .1f;
    public float forwardSpeed = .1f;
    public float rayCastOffset = 2.5f;
    public float detectionDist = 20f;
    public float droneCorrectionConstant = 5f;
    public float gravityCorrectionConstant = 4f;

    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other){
        //checks if it collides with endscreen
        if(other.gameObject.tag == "EndScreen"){
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }
    }



    void Update()
    {
        //moves player
        float zDir = Input.GetAxisRaw("Horizontal") * movementSpeed; 
        float yDir = Input.GetAxisRaw("Vertical") ;

        PathFinding();

        //Uncomment when you want to go manual mode

        //rb.velocity = new Vector3(rb.velocity.x, yDir, zDir) * movementSpeed;
        //rb.AddForce(new Vector3(-forwardSpeed,yDir*movementSpeed,zDir* movementSpeed/4));
        //transform.position += new Vector3(-forwardSpeed,yDir* movementSpeed,zDir* movementSpeed);
    }

    void PathFinding(){
        //Link to tutorial: https://www.youtube.com/watch?v=TsB_6yjACDY
        RaycastHit hit;
        Vector3 raycastOffset = new Vector3(-forwardSpeed,gravityCorrectionConstant,0);

        Vector3 forward = transform.position - transform.forward * rayCastOffset;
        Vector3 backward = transform.position + transform.forward * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset;

        Vector3 forwardDirVec = new Vector3(-1f, 0f, .3f);
        Vector3 backDirVec = new Vector3(-1f, 0f, -.3f);
        Vector3 upDirVec = new Vector3(-1f, .3f, 0f);
        Vector3 downDirVec = new Vector3(-1f, -.3f, 0f);

        Debug.DrawRay(forward, forwardDirVec*detectionDist, Color.blue);
        Debug.DrawRay(backward, backDirVec*detectionDist, Color.blue);
        Debug.DrawRay(up, upDirVec*detectionDist, Color.red);
        Debug.DrawRay(down, downDirVec*detectionDist, Color.red);


        if(Physics.Raycast(forward, forwardDirVec, out hit, detectionDist)){
            raycastOffset -= Vector3.forward * droneCorrectionConstant;
        }
        else if(Physics.Raycast(backward, backDirVec, out hit, detectionDist)){
            raycastOffset += Vector3.forward * droneCorrectionConstant;
        }
        if(Physics.Raycast(up, upDirVec, out hit, detectionDist)){
            raycastOffset -= Vector3.up * droneCorrectionConstant;
        }
        else if(Physics.Raycast(down, downDirVec, out hit, detectionDist)){
            raycastOffset += Vector3.up * droneCorrectionConstant;
        }

        Debug.Log(transform.right);
        rb.AddForce(raycastOffset);
    }
}
