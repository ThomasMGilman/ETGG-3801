using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenScript : MonoBehaviour
{
    /// <summary>
    /// Public variables to set in inspector
    /// </summary>
    [RangeAttribute(20f, 30f)]
    public float WorldWidth, WorldDepth;

    [RangeAttribute(7.5f, 10f)]
    public float WallHeight;

    public List<Texture> paintingList;

    public GameObject wallPrefab;
    public GameObject PaintingPrefab;
    public GameObject DoorPrefab;
    
    /// <summary>
    /// Private variables used for world gen
    /// </summary>
    private List<GameObject> walls;

    // Start is called before the first frame update
    void Start()
    {
        //if (paintingList.Count < 9)
            //throw new System.Exception("Need to provide 9 different textures for the paintings on the walls");
        //else
        //{
            float halfWidth = WorldWidth / 2;
            float halfHeight = WallHeight / 2;
            float halfDepth = WorldDepth / 2;

            walls = new List<GameObject>();
            Vector3 scale0 = new Vector3(WorldWidth, WallHeight, 1);
            Vector3 scale1 = new Vector3(WorldDepth, WallHeight, 1);
            float rotationAngle = 0;

            //placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, halfHeight, halfDepth), flase); //BackWall
            //placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(halfWidth, halfHeight, 0), false); //RightWall
            //placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, halfHeight, -halfDepth), false);//FrontWall
            placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(0,0,-1), new Vector3(-halfWidth, halfHeight, 0), true);  //LeftWall
        //}
    }

    private void placeWall(ref float rotation, in GameObject prefab, in Vector3 scale, Vector3 offsetVec, Vector3 pos, bool DoorWall)
    {
        GameObject wall = Instantiate(prefab, pos, Quaternion.Euler(0, rotation, 0));
        wall.transform.localScale = scale;
        walls.Add(wall);
        rotation += 90;

        Vector3 offsetPos = offsetVec * scale.z / 2;
        if (DoorWall)
        {
            Vector3 doorPos = new Vector3(pos.x, DoorPrefab.transform.localScale.y / 2, pos.z);
            GameObject door = Instantiate(DoorPrefab, doorPos + offsetPos, wall.transform.rotation);
            //door.transform.localScale = DoorPrefab.transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
