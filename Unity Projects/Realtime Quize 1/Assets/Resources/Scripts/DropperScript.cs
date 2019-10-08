using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperScript : MonoBehaviour
{
    public float cubeSpawnRate = 1000;
    public GameObject FallingCube_Prefab;

    private Vector3 Position;
    private float halfWidth, halfDepth;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        Position = this.transform.position;

        //get scale halves for cube spawning
        halfWidth = (this.transform.localScale.x / 2) - (FallingCube_Prefab.transform.localScale.x / 2);    
        halfDepth = this.transform.localScale.z / 2;
        Random.InitState(Time.time.GetHashCode());      //seed random
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime > 0) elapsedTime -= Time.deltaTime;
        else
            spawnCube();
    }

    private void spawnCube()
    {
        float xPos = Random.Range(this.Position.x - halfWidth, this.Position.x + halfWidth);
        float zPos = Random.Range(this.Position.z - halfDepth, this.Position.z + halfDepth);
        Vector3 newCubePos = new Vector3(xPos, this.Position.y, zPos);
        GameObject newCube = Instantiate(FallingCube_Prefab, newCubePos, FallingCube_Prefab.transform.rotation);
        elapsedTime = cubeSpawnRate;
    }
}
