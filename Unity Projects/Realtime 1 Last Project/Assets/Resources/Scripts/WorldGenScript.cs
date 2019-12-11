using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public int maxCodeRange;

    public List<Texture> paintingList;

    public GameObject wallPrefab;
    public GameObject PaintingPrefab;
    public GameObject DoorPrefab;

    /// <summary>
    /// Private variables used for world gen
    /// </summary>
    private Dictionary<int, GameObject> paintings;
    private List<int> keys;
    private List<GameObject> walls;
    private GameObject door;
    private Text timer, codeText;

    float halfWidth;
    float halfHeight;
    float halfDepth;

    private float timeLeft = 1000 * 60 * 5; //thousand milliseconds * 60 seconds = 1 minute * 5 = 5 minutes
    private float paintingWidth = 3;        //Size of the painting model made in Maya for the group project in Unity's scale with a scale factor of 40
    private float paintingStartOffsetX;
    private float paintingOffset;
    private int gameSeed;

    // Start is called before the first frame update
    void Start()
    {
        //Get UI Elements
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        codeText = GameObject.FindGameObjectWithTag("Code").GetComponent<Text>();

        gameSeed = Mathf.Abs(System.DateTime.Now.GetHashCode());        //Generate Seed
        //Init variables and dictionary of paintings
        paintings = new Dictionary<int, GameObject>();
        keys = new List<int>();
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
        placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, 0, -1), new Vector3(0, halfHeight, halfDepth), false, -180, "Back");      //BackWall
        placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(-1, 0, 0), new Vector3(halfWidth, halfHeight, 0), false, -90, "Right");      //RightWall
        placeWall(ref rotationAngle, in wallPrefab, in scale0, new Vector3(0, 0, 1), new Vector3(0, halfHeight, -halfDepth), false, 0, "Front");        //FrontWall
        placeWall(ref rotationAngle, in wallPrefab, in scale1, new Vector3(1, 0, 0), new Vector3(-halfWidth, halfHeight, 0), true, 0, "Left");          //LeftWall

        //Send Each Painting their code to display
        foreach(KeyValuePair<int, GameObject> keyPair in paintings)
        {
            //print("key: " + keyPair.Key + " " + keyPair.Value.name);  //Debug print

            keyPair.Value.SendMessage("SetCode", keyPair.Key);
        }
        //Send Door the code to match inorder to win
        door.SendMessage("SetCode", keys[Random.Range(0, keys.Count - 1)]);
    }

    private Vector3 dot(Vector3 a, Vector3 b)
    {
        Vector3 tmp = new Vector3();
        tmp.x = a.x * b.x;
        tmp.y = a.y * b.y;
        tmp.z = a.z * b.z;
        return tmp;
    }

    private void placeWall(ref float rotation, in GameObject prefab, in Vector3 scale, Vector3 offsetVec, Vector3 pos, bool DoorWall, float paintingRotAmount, string side)
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
            door = Instantiate(DoorPrefab, doorPos, wall.transform.rotation);
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

                //Apply Texture to Painting
                int texIndex = Random.Range(0, paintingList.Count - 1);
                painting.GetComponent<Renderer>().material.SetTexture("_MainTex", paintingList[texIndex]);
                paintingList.RemoveAt(texIndex);

                //Assign name to painting
                painting.name = side + " Painting " + i.ToString();

                //Generate random code for painting
                int code = Random.Range(0, maxCodeRange);
                int infCheck = 0;
                while(paintings.ContainsKey(code))
                {
                    if (infCheck == 10)
                        break;
                    code = Random.Range(0, maxCodeRange);
                    infCheck++;
                }
                if (infCheck >= 10)
                    throw new System.Exception("Need to set maxCodeRange!!");
                    
                paintings.Add(code, painting);
                keys.Add(code);
            }
        }
    }

    void updateCodeDisplayed(int val)
    {
        codeText.text = val.ToString();
        codeText.enabled = true;
    }

    void hideCode()
    {
        codeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = ((int)timeLeft).ToString();
        if (timeLeft <= 0)
            lose();
    }

    void lose()
    {
        
    }
}
