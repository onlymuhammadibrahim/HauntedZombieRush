using UnityEngine;
using System.Collections;

public class Rock : Object {

    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    [SerializeField] int speed;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move(bottomPosition));
    }

    // Update is called once per frame
    protected override void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0, Space.Self); //rotate 
        if (GameManager.instance.PlayerActive)
        {
            base.Update();
            
        }

    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {

            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * (Time.deltaTime * speed);
            //transform.Rotate(Vector3.up, 50 * Time.deltaTime);
            transform.Rotate(new Vector3(0, Time.deltaTime * 3, 0));

            yield return null;
            //Running whiles will return so its null
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }

    
}
