using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public GameObject player;
    public float minimum = 0.0f;
    public float maximum = 0.5f; 

    private Vector3 _angles;

    Rigidbody m_Rigidbody;

    static float t = 0.0f; 

    void Start()
    {
        _angles = new Vector3(0.0f, 1.0f, 0.0f);
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 d = player.transform.position - transform.position;

        d.Normalize();

        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(new Vector3(0.0f, 0.0f, 1.0f), d));

        Vector3 cross = Vector3.Cross(Vector3.forward, d); 
        if (cross.y < 0.0f)
        {
            angle = -angle;
        }

        _angles.y = angle;
        transform.eulerAngles = _angles;

        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimum, maximum, t), transform.position.z);

        // Increment interpolater based on gametime
        t += 0.1f * Time.deltaTime;

        // If interpolater >= .9f reverse direction of floating animation
        if (t >= .9f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
