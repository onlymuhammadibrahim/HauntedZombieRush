using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {

    [SerializeField] private float objectSpeed = 3;
    [SerializeField] private float resetPosition = -39.0f;
    [SerializeField] private float startPosition = 64.7f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {

        if (!GameManager.instance.GameOver)
        {
            //transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);

            transform.Translate(-objectSpeed * Time.deltaTime, 0, 0, Space.World);  //move
            if (transform.localPosition.x <= resetPosition)
            {
                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
        
	}
}
