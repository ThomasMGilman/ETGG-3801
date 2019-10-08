using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingCubeScript : GlobalScript
{
    public float fallRate = 1;
    public float spinRate = 1;

    public float minAngle = 0;
    public float maxAngle = 50;

    private float xRotSpeed;
    private float yRotSpeed;
    private float zRotSpeed;

    private Rigidbody rb;
    private Vector3 Position;
    private Vector3 Rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Position = this.transform.position;
        Rotation = this.transform.rotation.eulerAngles;
        xRotSpeed = Random.Range(minAngle, maxAngle);
        yRotSpeed = Random.Range(minAngle, maxAngle);
        zRotSpeed = Random.Range(minAngle, maxAngle);
    }

    // Update is called once per frame
    void Update()
    {
        this.Position -= updatePos();
        this.Rotation += updateRotation();
        this.transform.position = this.Position;
        this.transform.rotation = Quaternion.Euler(this.Rotation);
    }

    private Vector3 updatePos()
    {
        Vector3 posOffset = new Vector3(0, 0, 0);
        posOffset.y = this.fallRate * Time.deltaTime;
        return posOffset;
    }

    private Vector3 updateRotation()
    {
        Vector3 rotOffset = new Vector3(0, 0, 0);
        rotOffset.x = xRotSpeed * Time.deltaTime;
        rotOffset.y = yRotSpeed * Time.deltaTime;
        rotOffset.z = zRotSpeed * Time.deltaTime;
        return rotOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Catcher") updateScore(addativeScore);
        else updateScore(deductiveScore);
        Destroy(this.gameObject);
    }

    public void updateScore(int scoreAdder)
    {
        Score += scoreAdder;
        ScoreText.text = scoreString + Score;

        if (Score <= 0)
        {
            Score = 100;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
