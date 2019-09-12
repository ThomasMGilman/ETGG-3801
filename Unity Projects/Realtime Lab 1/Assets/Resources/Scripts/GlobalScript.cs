using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public int worldWidth = 50;
    public int worldHeight = 50;
    public int health = 5;              //players starting health

    public float amplitude = 1;         //sineAmplitudeFor worldGen
    public float splashRadius = 5;      //Radius for rocket collision/explosion
    public double blockSpacing = 0.01;  //gap between blocks
    public double CurrencyValue = 1.00; //value for currency

    //WorldObjects
    public GameObject GroundBlock;
    public GameObject FiringPlane;
    public GameObject Base;
    public GameObject Turret;

    //Player
    public GameObject Player;
    
    //Projectiles
    public GameObject Arrow;
    public GameObject Rocket;

    //Currency/Score object
    public GameObject Money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
