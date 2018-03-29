using System;
using UnityEngine;

public class RoamScript : MonoBehaviour
{

    public GameObject[] waypoints;
    public int count = 0;

    public float minDist;
    public float speed;

    public bool rand = false;
    public bool traverse = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[count].transform.position);

        if (traverse)
        {
            if(dist > minDist)
            {
                Move();     
            }
            else if (!rand)
            {
                if(count + 1 == waypoints.Length)
                {
                    count = 0;      
                }
                else
                {
                    count++;
                }
            }
            else
            {
                count = UnityEngine.Random.Range(0, waypoints.Length);
            }
        }
	}

    private void Move()
    {
        gameObject.transform.LookAt(waypoints[count].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }
}
