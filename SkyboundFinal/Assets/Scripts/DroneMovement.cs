using UnityEngine;
using UnityEngine.SceneManagement;


public class DroneMovement : MonoBehaviour
{
    public float movementSpeed = .1f;
    public float forwardSpeed = 3f;
    public float rayCastOffset = 3f;
    public float detectionDist = 20f;
    public float droneCorrectionConstant = 6f;
    public float gravityCorrectionConstant = 3.5f;

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
        Vector3 down = transform.position - transform.up * rayCastOffset; down.y += .6f;

        Vector3 forwardUpDirVec = new Vector3(-1f, .05f, .3f);
        Vector3 forwardDownDirVec = new Vector3(-1f, -.05f, .3f);
        Vector3 backUpDirVec = new Vector3(-1f, .05f, -.3f);
        Vector3 backDownDirVec = new Vector3(-1f, -.05f, -.3f);
        Vector3 upDirVec = new Vector3(-1f, .3f, 0f);
        Vector3 downDirVec = new Vector3(-1f, -.3f, 0f);

        Debug.DrawRay(forward, forwardUpDirVec*detectionDist, Color.yellow);
        Debug.DrawRay(forward, forwardDownDirVec*detectionDist, Color.yellow);
        Debug.DrawRay(backward, backUpDirVec*detectionDist, Color.blue);
        Debug.DrawRay(backward, backDownDirVec*detectionDist, Color.blue);
        Debug.DrawRay(up, upDirVec*detectionDist, Color.red);
        Debug.DrawRay(down, downDirVec*detectionDist, Color.red);

        if(Physics.Raycast(forward, forwardUpDirVec, out hit, detectionDist) || Physics.Raycast(forward, forwardDownDirVec, out hit, detectionDist)){
            raycastOffset -= Vector3.forward * droneCorrectionConstant;
        }
        if(Physics.Raycast(backward, backUpDirVec, out hit, detectionDist) || Physics.Raycast(backward, backDownDirVec, out hit, detectionDist)){
            raycastOffset += Vector3.forward * droneCorrectionConstant;
        }

        if(Physics.Raycast(up, upDirVec, out hit, detectionDist)){
            raycastOffset -= Vector3.up * droneCorrectionConstant;
        }
        if(Physics.Raycast(down, downDirVec, out hit, detectionDist)){
            raycastOffset += Vector3.up * droneCorrectionConstant;
        }

        Debug.Log(raycastOffset);
        rb.AddForce(raycastOffset);
    }
}
