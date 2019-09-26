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

    private GameObject firstBlock, lastBlock;
    Dictionary<Vector3, GameObject> g;
    // Start is called before the first frame update
    void Start()
    {
        fireTimer = minRocketRate;
        pos = this.transform.position;
        setMinMaxRange();
    }

    private void setMinMaxRange()
    {
        Vector3 minBlock = new Vector3(0, 0, 0);
        Vector3 maxBlock = new Vector3(worldWidth-1, 0, worldDepth-1);
        if(g.TryGetValue(minBlock, out firstBlock))
        {
            minX = firstBlock.transform.position.x;
            minZ = firstBlock.transform.position.z;
        }
        if(g.TryGetValue(maxBlock, out lastBlock))
        {
            maxX = lastBlock.transform.position.x;
            maxZ = lastBlock.transform.position.z;
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
            InstantiateObject(Rocket_prefab, tmpPos, Rocket_prefab.transform.localScale, this.transform);
            fireTimer = Random.Range(minRocketRate, maxRocketRate);
            rocketCount++;
        }
    }

    public void ToCheck(Dictionary<Vector3, GameObject> gin)
    {
        g = gin;
        setMinMaxRange();
    }

    public void deadRocket()
    {
        rocketCount--;
        if (rocketCount < 0) rocketCount = 0;
    }
}
