﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScript : MonoBehaviour
{
    public int worldWidth = 75;
    public int worldDepth = 75;
    public int turretCount = 5;
    public int CurrencyValue = 1;       //value for currency

    public float gravitationalConstant = 1f;

    public float amplitude = 1;         //sineAmplitudeFor worldGen
    public float turretRadius = 25;
    public float splashRadius = 5;      //Radius for rocket collision/explosion
    public float blockSpacing = 0.5f;   //gap between blocks 
    private float health = 1;

    public Vector3 playerScale = new Vector3(.1f, .1f, .1f);

    public string Base = "base(Clone)", Turret = "launcher(Clone)", groundName = "ground_cube(Clone)"; //Structure Names

    public bool allSet = false;

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
    private GameObject groundParent;
    
    [HideInInspector]
    public Dictionary<string, groundGroup> ground;

    private Transform globalParent;

    public struct groundGroup
    {
        public GameObject ground;
        public int x, z;
    };

    public GameObject InstantiateObject(GameObject prefab, Vector3 worldPos, Vector3 Scale, Transform parent = null)
    {
        GameObject obj = Instantiate(prefab, worldPos, prefab.transform.rotation);
        obj.transform.parent = parent;
        obj.transform.localScale = prefab.transform.localScale;
        obj.transform.localScale = Scale;
        return obj;
    }

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(Time.time.GetHashCode());          //Seed random
        ground = new Dictionary<string, groundGroup>();     //setup ground dictionary for easy removall of blocks once they are gone
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
                Vector3 blockLocation = new Vector3(x, 0, z);
                zPos = (z + (z * 1)) + z*blockSpacing;
                float angleS = (float)((((z + 1) * waveInc) * Mathf.PI) / 180);
                string name = groundName+"_X:" + x.ToString() + "_Z:" + z.ToString();
                //Add Block x, z
                worldPos.x = xPos; worldPos.z = zPos;     //setPos
                worldPos.y = Mathf.Sin(angleS * amplitude) * Mathf.Cos(angleX * amplitude);

                groundGroup g = new groundGroup();
                g.ground = InstantiateObject(GroundBlock_prefab, worldPos,
                    GroundBlock_prefab.transform.localScale, globalParent);
                g.x = x; g.z = z;
                ground[name] = g;
                //print(ground[name].name + " new name: " + name);
                ground[name].ground.name = name;

                //place world objects if at center
                if (x == halfWidth && z == halfDepth)   
                {
                    float tmpY = worldPos.y;

                    worldPos.y = tmpY + 1.38f;
                    homeBase = InstantiateObject(Base_prefab, worldPos, Base_prefab.transform.localScale);   //setBase in center of map

                    worldPos.y = 100f;
                    FireingZone = InstantiateObject(FiringPlane_prefab, worldPos, FiringPlane_prefab.transform.localScale); //set Firing plane in center of map

                    //place turrets
                    float tmpX = worldPos.x;
                    float tmpZ = worldPos.z;
                    for (int i = 0; i < turretCount; i++)
                    {
                        float turretAngle = (float)((angleInc * Mathf.PI) / 180);                          //Calculate angle into radians

                        worldPos.x = (turretRadius * Mathf.Cos((i + 1) * turretAngle)) + tmpX;
                        worldPos.y = 2.03f;
                        worldPos.z = (turretRadius * Mathf.Sin((i + 1) * turretAngle)) + tmpZ;

                        turrets[i] = InstantiateObject(Turret_prefab, worldPos, Turret_prefab.transform.localScale);
                    }
                    worldPos.x = tmpX + .5f; worldPos.y = tmpY + 2; worldPos.z = tmpZ + .5f;
                    playerChar = InstantiateObject(Player_prefab, worldPos, playerScale);
                }
            }
        }
        FireingZone.SendMessage("ToCheck", ground);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GreaterOrLess(dynamic gOrl, dynamic val)
    {
        return (gOrl > val || gOrl < val);
    }

    public void removeHealth()
    {
        float newHealth = health - .1f;
        health = newHealth;
        RawImage HealthBar = GameObject.Find("Health").GetComponent<RawImage>();
        HealthBar.rectTransform.localScale = new Vector3(
           health, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);

        if (newHealth <= 0.0)
            return;     //GameOver
    }
}
