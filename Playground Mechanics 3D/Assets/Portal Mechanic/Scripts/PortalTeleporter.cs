using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    public bool playerIsOverLapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverLapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positioOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positioOffset;
                playerIsOverLapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            playerIsOverLapping = true;
        }    
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player")
        {
            playerIsOverLapping = false;
        }
    }
}
