using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetScript : MonoBehaviour
{
    public float Zdirection         = 1f;   //Zdirection for Invaders
    public float moveSpeed          = 1f;
    public float fwrdDistance       = 1f;

    public float fleet_h            = 3f;
    public float fleet_w            = 3f;
    public float fleetSpaceing      = 1f;

    public float fireRate           = 1f;

    public GameObject invader_prefab;

    // Start is called before the first frame update
    void Start()
    {
        Bounds invaderBounds = invader_prefab.GetComponent<MeshRenderer>().bounds;
        for(int i = 0; i < fleet_h; i++)
        {
            for(int k = 0; k < fleet_w; k++)
            {
                Vector3 pos = new Vector3((i * (invaderBounds.size.z * 2 + fleetSpaceing))/3,
                    0.0f,
                    (k * (invaderBounds.size.x * 2 + fleetSpaceing))/3);
                GameObject newInvader = Instantiate(invader_prefab, pos + transform.position, invader_prefab.transform.rotation);
                //newInvader.transform.rotation.Set(-90f, 90f, -180f, 0f);
                newInvader.transform.localScale = invader_prefab.transform.localScale;
                newInvader.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void recCheckInFront()
    {
        BroadcastMessage("checkInFront");
    }


    private void changeDir()
    {
        BroadcastMessage("resetMovingFwrd");
    }
}
