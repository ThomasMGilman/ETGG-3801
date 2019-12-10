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

    public float paintingHeight;
    public float paintingOffsetAlongWall;

    public uint maxPaintings;
    
    public List<Texture> paintingList;

    public GameObject wallPrefab;
    public GameObject PaintingPrefab;
    public GameObject DoorPrefab;

    /// <summary>
    /// Private variables used for world gen
    /// </summary>
    private Dictionary<string, GameObject> paintings;
    private List<GameObject> walls;

    float halfWidth;
    float halfHeight;
    float halfDepth;

    private float paintingWidth = 3;        //Size of the painting model made in Maya for the group project in Unity's scale with a scale factor of 40
    private float paintingStartOffsetX;
    private float paintingOffset;
    private int gameSeed;

    // Start is called before the first frame update
    void Start()
    {
        gameSeed = Mathf.Abs(System.DateTime.Now.GetHashCode());
        paintings = new Dictionary<string, GameObject>();
        halfWidth = WorldWidth / 2;
        halfHeight = WallHeight / 2;
        halfDepth = WorldDepth / 2;

        //Set scales for the walls along the x and z planes
        walls = new List<GameObject>();
        Vector3 scale0 = new Vector3(WorldWidth, WallHeight, 1);
        Vector3 scale1 = new Vector3(WorldDepth, WallHeight, 1);

        //Set Painting start and offset amount
        paintingOffset = ((WorldWidth - paintingWidth) / paintingWidth) / maxPaintings + paintingWidth + paintingOffsetAlongWall;
        paintingStartOffsetX = (-WorldWidth + paintingWidth) * .5f + paintingWidth;

        float rotationAngle = 0;
        placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, 0, -1), new Vector3(0, halfHeight, halfDepth), false, -180);  //BackWall
        placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(-1, 0, 0), new Vector3(halfWidth, halfHeight, 0), false, -90);   //RightWall
        placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, 0, 1), new Vector3(0, halfHeight, -halfDepth), false, 0);     //FrontWall
        placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(1, 0, 0), new Vector3(-halfWidth, halfHeight, 0), true, 0);      //LeftWall
    }

    private Vector3 dot(Vector3 a, Vector3 b)
    {
        Vector3 tmp = new Vector3();
        tmp.x = a.x * b.x;
        tmp.y = a.y * b.y;
        tmp.z = a.z * b.z;
        return tmp;
    }

    private void placeWall(ref float rotation, in GameObject prefab, in Vector3 scale, Vector3 offsetVec, Vector3 pos, bool DoorWall, float paintingRotAmount)
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
                Vector3 paintingPos = new Vector3(pos.x, paintingHeight + pos.y - PaintingPrefab.transform.localScale.y / 2, pos.z) + offsetPos;
                paintingPos.z = pos.z + offsetPos.z * wall.transform.localScale.z;

                // move painting by num painting on wall
                if (offsetPos.z != 0)
                    paintingPos.x = paintingStartOffsetX + paintingOffset * i;
                else
                    paintingPos.z = paintingStartOffsetX + paintingOffset * i;

                Quaternion paintingRot = Quaternion.Euler(0, paintingRotAmount, 0);
                GameObject painting = Instantiate(PaintingPrefab, paintingPos, paintingRot);
                //Fix here
                int texIndex = Random.Range(0, paintingList.Count - 1);
                painting.GetComponent<Material>().SetTexture("_MainTex", paintingList[texIndex]);
                paintingList.RemoveAt(texIndex);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
