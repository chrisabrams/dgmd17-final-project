using UnityEngine;
using UnityEngine.SceneManagement;


public class DroneMovement : MonoBehaviour
{
    public float droneSize = 1f;
    public float forwardSpeed = 3f;
    public float rayCastOffset = 3f;
    public float detectionDist = 20f;
    public float droneCorrectionConstant = 6f;
    public float gravityCorrectionConstant = 3.5f;
    public bool enableVelocityControlling = true;

    private Rigidbody rb;
    private int counter = 0;

    void Start(){
        rb = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(droneSize, droneSize, droneSize);
    }

    void OnCollisionEnter(Collision other){
        //checks if it collides with endscreen
        if(other.gameObject.tag == "EndScreen"){
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }
    }



    void FixedUpdate()
    {
        PathFinding();
        ResetVelocity();

        //Uncomment when you want to go manual mode
        // //moves player
        // float zDir = Input.GetAxisRaw("Horizontal") * movementSpeed; 
        // float yDir = Input.GetAxisRaw("Vertical") ;
        // rb.velocity = new Vector3(rb.velocity.x, yDir, zDir) * movementSpeed;
        // rb.AddForce(new Vector3(-forwardSpeed,yDir*movementSpeed,zDir* movementSpeed/4));
        // transform.position += new Vector3(-forwardSpeed,yDir* movementSpeed,zDir* movementSpeed);
    }

    void PathFinding(){
        //Link to tutorial: https://www.youtube.com/watch?v=TsB_6yjACDY
        RaycastHit hit;
        Vector3 raycastOffset = new Vector3(-forwardSpeed,gravityCorrectionConstant,0);

        Vector3 forward = transform.position - transform.forward * rayCastOffset;
        Vector3 backward = transform.position + transform.forward * rayCastOffset;
        Vector3 up = transform.position + transform.up * rayCastOffset;
        Vector3 down = transform.position - transform.up * rayCastOffset; down.y += .6f;

        //Vector3 forwardUpDirVec = new Vector3(-1f, .05f, .3f);
        //Vector3 forwardDownDirVec = new Vector3(-1f, -.05f, .3f);
        //Vector3 backUpDirVec = new Vector3(-1f, .05f, -.3f);
        //Vector3 backDownDirVec = new Vector3(-1f, -.05f, -.3f);
        Vector3 forwardDirVec = new Vector3(-1f, 0f, .2f);
        Vector3 backDirVec = new Vector3(-1f, 0f, -.2f);
        Vector3 upDirVec = new Vector3(-1f, .35f, 0f);
        Vector3 downDirVec = new Vector3(-1f, -.35f, 0f);

        Debug.DrawRay(forward, forwardDirVec*detectionDist, Color.blue);
        Debug.DrawRay(backward, backDirVec*detectionDist, Color.blue);
        Debug.DrawRay(up, upDirVec*detectionDist, Color.red);
        Debug.DrawRay(down, downDirVec*detectionDist, Color.red);

        if(Physics.Raycast(forward, forwardDirVec, out hit, detectionDist) && Physics.Raycast(backward, backDirVec, out hit, detectionDist)){
            raycastOffset += Vector3.up * droneCorrectionConstant;
        }
        else if(Physics.Raycast(forward, forwardDirVec, out hit, detectionDist)){
            raycastOffset -= Vector3.forward * droneCorrectionConstant;
        }
        else if(Physics.Raycast(backward, backDirVec, out hit, detectionDist)){
            raycastOffset += Vector3.forward * droneCorrectionConstant;
        }

        if(Physics.Raycast(up, upDirVec, out hit, detectionDist) && Physics.Raycast(down, downDirVec, out hit, detectionDist)){
            if(Physics.Raycast(forward, forwardDirVec, out hit, detectionDist)){
                raycastOffset -= Vector3.forward * droneCorrectionConstant;
            }
            else{
                raycastOffset += Vector3.forward * droneCorrectionConstant;
            }
        }
        else if(Physics.Raycast(up, upDirVec, out hit, detectionDist)){
            raycastOffset -= Vector3.up * droneCorrectionConstant;
        }
        else if(Physics.Raycast(down, downDirVec, out hit, detectionDist)){
            raycastOffset += Vector3.up * droneCorrectionConstant;
        }

        Debug.Log(raycastOffset);
        Debug.Log(rb.velocity);
        Debug.Log(hit.collider);
        rb.AddForce(raycastOffset);
    }

    void ResetVelocity(){
        if(counter >= 200){
            if(enableVelocityControlling){
                Vector3 temp = rb.velocity;
                rb.velocity = new Vector3(temp.x/1.03f, temp.y/1.1f, temp.z/1.05f);
            }
            counter = 0;
        }
        counter++;
    }
}
