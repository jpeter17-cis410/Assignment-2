using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public GameObject player;
    public GameEnding gameEnding;
    public ParticleEffect particleEffect;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player.transform)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player.transform)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.transform.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player.transform)
                {
                    StartCoroutine("EndGame"); 
                    particleEffect.Activate();
                }
            }
        }
    }

    IEnumerator EndGame()
    {
        // your process
        yield return new WaitForSeconds(1);
        gameEnding.CaughtPlayer();
    }
}