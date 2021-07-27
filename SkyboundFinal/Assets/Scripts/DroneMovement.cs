using UnityEngine;
using UnityEngine.SceneManagement;


public class DroneMovement : MonoBehaviour
{
    public float movementSpeed = .1f;
    public float forwardSpeed = .1f;

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

        //rb.velocity = new Vector3(rb.velocity.x, yDir, zDir) * movementSpeed;
        rb.AddForce(new Vector3(-forwardSpeed,yDir*movementSpeed,zDir* movementSpeed/4));
        //transform.position += new Vector3(-forwardSpeed,yDir* movementSpeed,zDir* movementSpeed);
    }
}
