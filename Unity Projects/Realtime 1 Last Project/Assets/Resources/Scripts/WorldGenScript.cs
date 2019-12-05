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

    public uint maxPaintings;
    
    public List<Texture> paintingList;

    public GameObject wallPrefab;
    public GameObject PaintingPrefab;
    public GameObject DoorPrefab;
    
    /// <summary>
    /// Private variables used for world gen
    /// </summary>
    private List<GameObject> walls;
    private uint max_numPaintingsX;

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

            max_numPaintingsX = (uint)((WorldWidth - PaintingPrefab.transform.localScale.x) / PaintingPrefab.transform.localScale.x);

            float rotationAngle = 0;

            placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, 0, -1), new Vector3(0, halfHeight, halfDepth), false);    //BackWall
            placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(-1, 0, 0), new Vector3(halfWidth, halfHeight, 0), false);    //RightWall
            placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, 0, 1), new Vector3(0, halfHeight, -halfDepth), false);   //FrontWall
            placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(1,0,0), new Vector3(-halfWidth, halfHeight, 0), true);       //LeftWall
        //}
    }

    private Vector3 dot(Vector3 a, Vector3 b)
    {
        Vector3 tmp = new Vector3();
        tmp.x = a.x * b.x;
        tmp.y = a.y * b.y;
        tmp.z = a.z * b.z;
        return tmp;
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
            //places door at center of wall
            Vector3 doorPos = new Vector3(pos.x, DoorPrefab.transform.localScale.y / 2, pos.z) + dot(offsetPos, DoorPrefab.transform.localScale * .5f);
            GameObject door = Instantiate(DoorPrefab, doorPos, wall.transform.rotation);
        }
        else
        {
            for(int i = 0; i < maxPaintings; i++)
            {
                //places paintings at center of walls
                Vector3 paintingPos = new Vector3(pos.x, pos.y - PaintingPrefab.transform.localScale.y / 2, pos.z) + dot(offsetPos, PaintingPrefab.transform.localScale * .5f);
                paintingPos.z = pos.z + offsetPos.z * wall.transform.localScale.z;

                // move painting by num painting on wall
                if (offsetPos.z != 0)
                    paintingPos.x = (PaintingPrefab.transform.localScale.x + (-wall.transform.localScale.x + PaintingPrefab.transform.localScale.x) * .5f);
                else
                    paintingPos.z = (PaintingPrefab.transform.localScale.x + (-wall.transform.localScale.x + PaintingPrefab.transform.localScale.x) * .5f);

                GameObject painting = Instantiate(PaintingPrefab, paintingPos, wall.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
