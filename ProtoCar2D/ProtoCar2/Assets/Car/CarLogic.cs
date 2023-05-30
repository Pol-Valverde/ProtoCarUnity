using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CarLogic : MonoBehaviour
{
    Rigidbody2D rb;
    CinemachineImpulseSource impulse;
    [SerializeField] float accelerationPower = 5f;
    [SerializeField] float steeringPower = 5f;
    [SerializeField] Vector2 startPos = new Vector2(1,3.6f);
    [SerializeField] GameObject anim;
    public bool justCollided;
    float steeringAmount, speed, direction, tempSteer;
    Quaternion startRot;
    //Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        startRot = gameObject.transform.rotation;
        tempSteer = steeringPower;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        steeringAmount = -Input.GetAxis("Horizontal");
        if(steeringAmount >= 1f)
        {
           
            steeringPower += 0.3f * Time.deltaTime;
        }
        else
        {
              
            steeringPower = tempSteer;
            speed = accelerationPower;

        }
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "spline")
        {
            
            StartCoroutine(Die());
            
        }
    }
    IEnumerator Die()
    {
        if(justCollided == false)
        {
            
            justCollided = true;
           
            yield return new WaitForSeconds(1.0f);
            rb.velocity = Vector2.zero;
            steeringAmount = 0;
            
            gameObject.transform.rotation = startRot;
            transform.position = startPos;
            justCollided = false;
        }
        
    }
}
