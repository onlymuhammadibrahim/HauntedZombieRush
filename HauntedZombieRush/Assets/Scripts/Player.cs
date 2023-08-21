using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    private Animator anim;
    private Rigidbody rigidBody;
    private bool jump = false;
    private AudioSource audioSource;


    private void Awake()
    {
        Assert.IsNotNull(sfxDeath);
        Assert.IsNotNull(sfxJump);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + Time.deltaTime, -6.0f, 12.0f), transform.position.z);
                GameManager.instance.PlayerStartedGame();
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                jump = true;

            }
        }
	    
	}

    private void FixedUpdate()
    {
        if (jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(0, 20 , 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            audioSource.PlayOneShot(sfxDeath);
            rigidBody.AddForce(-20, 20, 0, ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            GameManager.instance.PlayerCollided();
        }
        


    }
    
}
