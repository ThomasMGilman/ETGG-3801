using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlaneScript : GlobalScript
{
    private int rocketCount = 0, maxRockets = 10;
    private float fireTimer = 0;
    private Vector3 pos;
    private float minX, maxX, minZ, maxZ;
    private bool ready = false;

    float minRocketRate = 1f;
    float maxRocketRate = 10f;

    private groundGroup firstBlock, lastBlock;
    private Dictionary<string, groundGroup> g;
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(Time.time.GetHashCode());
        fireTimer = minRocketRate;
        pos = this.transform.position;
        setMinMaxRange();
    }

    private void setMinMaxRange()
    {
        string minBlock = groundName + "_X:0_Z:0";
        string maxBlock = groundName + "_X:" + (worldWidth - 1) + "_Z:" + (worldDepth - 1);
        if(g.TryGetValue(minBlock, out firstBlock))
        {
            minX = firstBlock.ground.transform.position.x;
            minZ = firstBlock.ground.transform.position.z;
        }
        if(g.TryGetValue(maxBlock, out lastBlock))
        {
            maxX = lastBlock.ground.transform.position.x;
            maxZ = lastBlock.ground.transform.position.z;
            ready = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= minRocketRate * Time.deltaTime;
        if(fireTimer <= 0 && ready)
        {
            Vector3 tmpPos = pos;
            tmpPos.x = Random.Range(minX, maxX);
            tmpPos.z = Random.Range(minZ, maxZ);
            GameObject newRocket = InstantiateObject(Rocket_prefab, tmpPos, Rocket_prefab.transform.localScale, this.transform);
            fireTimer = Random.Range(minRocketRate, maxRocketRate);
            rocketCount++;
            newRocket.SendMessage("ToCheck", g);
        }
    }

    public void ToCheck(Dictionary<string, groundGroup> map)
    {
        g = map;
        setMinMaxRange();
    }

    public void deadRocket()
    {
        rocketCount--;
        if (rocketCount < 0) rocketCount = 0;
    }
}
