
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config Parameters
    [SerializeField] Paddle Paddle1;
    [SerializeField] float BallLaunchInX = 2f;
    [SerializeField] float BallLaunchInY = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
     Rigidbody2D MyRigidBody2D;
  

    // state
    Vector2 paddleToBallVector;
     bool hasStarted = false;

    //Cached component refrences
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Since we are working on the ball script we don't need to specify in this script 
        //the object the transform.position is for the ball
        // now we can subtract the position of the ball from the paddle.
        paddleToBallVector = transform.position - Paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        MyRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
      
    }
   
    
    private void LaunchOnMouseClick()
    {

    
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            MyRigidBody2D.velocity = new Vector2(BallLaunchInX, BallLaunchInY);
             Debug.Log("Pressed primary button.");
        }
        
    }

    private void LockBallToPaddle()
    {
        Vector2 PaddlePos = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
        transform.position = PaddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor), 
           Random.Range(0f, randomFactor));
        if (hasStarted == true)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myAudioSource.PlayOneShot(clip);
            MyRigidBody2D.velocity += velocityTweak; // appending our velocity tweak to our rigid body at each collision. 
        }
    }
}
