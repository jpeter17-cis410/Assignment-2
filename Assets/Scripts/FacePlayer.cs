using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 _angles;

    void Start()
    {
        _angles = new Vector3(0.0f, 1.0f, 0.0f);
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
}
