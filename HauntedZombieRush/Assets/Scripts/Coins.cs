using UnityEngine;
using System.Collections;



public class Coins : Object {

    
    [SerializeField] private AudioClip sfxCoin;
    private AudioSource audioSource;
    

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "p1")
        {
            audioSource.PlayOneShot(sfxCoin);
            Vector3 newPos = new Vector3(64.7f, transform.position.y, transform.position.z);
            transform.position = newPos;
            GameManager.instance.score += 1;
            GameManager.instance.scoreText.text = "Score : " + GameManager.instance.score;
        }
    }
}
