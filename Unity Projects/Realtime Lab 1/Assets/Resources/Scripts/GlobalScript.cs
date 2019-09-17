using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    private int score = 0;

    public int worldWidth = 50;
    public int worldDepth = 50;
    public int turretCount = 5;

    public float amplitude = 1;         //sineAmplitudeFor worldGen
    public float turretRadius = 25;
    public float splashRadius = 5;      //Radius for rocket collision/explosion

    public float blockSpacing = 0.5f;   //gap between blocks
    public float CurrencyValue = 1.00f; //value for currency

    public Vector3 playerScale = new Vector3(1, 1, 1);

    //WorldObjects
    public GameObject GroundBlock_prefab;
    public GameObject FiringPlane_prefab;
    public GameObject Base_prefab;
    public GameObject Turret_prefab;

    //Player
    public GameObject Player_prefab;
    
    //Projectiles
    public GameObject Arrow_prefab;
    public GameObject Rocket_prefab;

    //Currency/Score object
    public GameObject Money_prefab;

    private GameObject playerChar;
    private GameObject homeBase;
    private GameObject FireingZone;
    private GameObject[] turrets;
    private GameObject[,] ground;

    private Transform globalParent;

    private void InstantiateObject(out GameObject obj, GameObject prefab, Vector3 worldPos, Vector3 Scale, Transform parent = null)
    {
        obj = Instantiate(prefab, worldPos, prefab.transform.rotation);
        obj.transform.localScale = prefab.transform.localScale;
        obj.transform.parent = parent;
        obj.transform.localScale = Scale;
    }

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(Time.time.GetHashCode());          //Seed random
        ground = new GameObject[worldWidth, worldDepth];    //set ground array to world width and height
        turrets = new GameObject[turretCount];              //set turret array
        globalParent = this.transform;                      //setGlobal Parent pointer 

        float angleInc = 360 / turretCount, xPos = 0, zPos = 0;
        Vector3 worldPos = new Vector3(xPos, 0, zPos);
        int halfWidth = worldWidth / 2;
        int halfDepth = worldDepth / 2;

        float waveInc = 360 / halfDepth;
        for (int x = 0; x < worldWidth; x++)
        {
            xPos = (x + (x * 1)) + x*blockSpacing;
            float angleX = (float)((((x + 1) * waveInc) * Mathf.PI) / 180);
            for (int z = 0; z < worldDepth; z++)
            {
                zPos = (z + (z * 1)) + z*blockSpacing;
                float angleS = (float)((((z + 1) * waveInc) * Mathf.PI) / 180);
                
                //Add Block x, z
                worldPos.x = xPos; worldPos.z = zPos;     //setPos
                worldPos.y = Mathf.Sin(angleS * amplitude) * Mathf.Cos(angleX * amplitude);

                InstantiateObject(out ground[x, z], GroundBlock_prefab, worldPos,
                    GroundBlock_prefab.transform.localScale, globalParent);

                //place world objects if at center
                if (x == halfWidth && z == halfDepth)   
                {
                    float tmpY = worldPos.y;

                    worldPos.y = tmpY + 1.38f;
                    InstantiateObject(out homeBase, Base_prefab, worldPos, Base_prefab.transform.localScale);   //setBase in center of map

                    worldPos.y = 100f;
                    InstantiateObject(out FireingZone, FiringPlane_prefab, worldPos, FiringPlane_prefab.transform.localScale); //set Firing plane in center of map

                    //place turrets
                    float tmpX = worldPos.x;
                    float tmpZ = worldPos.z;
                    for (int i = 0; i < turretCount; i++)
                    {
                        float turretAngle = (float)((angleInc * Mathf.PI) / 180);                          //Calculate angle into radians

                        worldPos.x = (turretRadius * Mathf.Cos((i + 1) * turretAngle)) + tmpX;
                        worldPos.y = 2.03f;
                        worldPos.z = (turretRadius * Mathf.Sin((i + 1) * turretAngle)) + tmpZ;

                        InstantiateObject(out turrets[i], Turret_prefab, worldPos, Turret_prefab.transform.localScale);
                    }
                    worldPos.x = tmpX + .5f; worldPos.y = tmpY + 2; worldPos.z = tmpZ + .5f;
                    InstantiateObject(out playerChar, Player_prefab, worldPos, playerScale);
                }
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incScore()
    {
        score += 100;
    }
}
