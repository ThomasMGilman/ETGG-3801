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

    public float randMin = -100;
    public float randMax = 100;
    public bool randomizeHills = false;

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

    private void InstantiateGroundBlock(int x, int z, Vector3 worldPos)
    {
        ground[x,z] = Instantiate(GroundBlock_prefab, worldPos, GroundBlock_prefab.transform.rotation);
        ground[x, z].transform.localScale = GroundBlock_prefab.transform.localScale;
        ground[x, z].transform.parent = globalParent;
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
        for (int x = -halfWidth; x < halfWidth; x++)
        {
            xPos = ((x + 1) + (x * 1)) + x*blockSpacing;
            float angleX = (float)((((x + 1) * waveInc) * Mathf.PI) / 180);
            for (int z = -halfDepth; z < halfDepth; z++)
            {
                zPos = ((z + 1) + (z * 1)) + z*blockSpacing;
                float angleS = (float)((((z + 1) * waveInc) * Mathf.PI) / 180);
                
                //Add Block x, z
                worldPos.x = xPos; worldPos.z = zPos;     //setPos
                worldPos.y = !randomizeHills ? Mathf.Sin(angleS * amplitude) * Mathf.Cos(angleX * amplitude) : 
                    Mathf.Sin((Random.Range(-randMin, randMax) * Mathf.PI / 180)*amplitude) 
                    * Mathf.Cos((Random.Range(randMin, randMax) * Mathf.PI / 180) * amplitude);

                InstantiateGroundBlock(x+halfWidth, z+halfDepth, worldPos);
            }
        }

        //SetBase in origin of map
        worldPos.x = 0;
        worldPos.y = 1.38f;
        worldPos.z = 1f;
        homeBase = Instantiate(Base_prefab, worldPos, Base_prefab.transform.rotation);

        //place firing object
        worldPos.y = 100f;
        FireingZone = Instantiate(FiringPlane_prefab, worldPos, FiringPlane_prefab.transform.rotation);

        //place turrets
        for(int i = 0; i < turretCount; i++)
        {
            float angleS = (float)((angleInc * Mathf.PI) / 180);                          //Calculate angle into radians

            worldPos.x =(turretRadius * Mathf.Cos((i + 1) * angleS));
            worldPos.y = 2.03f;
            worldPos.z =(turretRadius * Mathf.Sin((i + 1) * angleS));

            turrets[i] = Instantiate(Turret_prefab, worldPos, Turret_prefab.transform.rotation);
            turrets[i].transform.parent = globalParent;
        }

        //Place Player Character
        worldPos.x = 1; worldPos.y = 2; worldPos.z = 1;
        playerChar = Instantiate(Player_prefab, worldPos, Player_prefab.transform.rotation);
        playerChar.transform.localScale = Player_prefab.transform.localScale;
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
