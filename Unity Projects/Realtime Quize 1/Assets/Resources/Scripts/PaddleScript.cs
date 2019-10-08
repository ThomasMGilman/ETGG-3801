using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : GlobalScript
{
    public int expansionCost = 10;
    public float moveSpeed = 2;
    public float expansionAmount = 2;
    public float deScale = 1;

    private Rigidbody rb;
    private Vector3 Position;
    private Vector3 originScale;
    
    private CursorLockMode wantMode;    //referenced https://docs.unity3d.com/ScriptReference/Cursor-lockState.html
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Position = this.transform.position;
        originScale = this.transform.localScale;
        SetCursorState(CursorLockMode.Locked);
    }

    // Update is called once per frame
    void Update()
    {
        checkInputs();
        Position += updatePos();
        updatePaddleScale();
        this.transform.position = this.Position;
    }

    private void updatePaddleScale()
    {
        if(this.transform.localScale.x > originScale.x)
        {
            Vector3 scale = this.transform.localScale;
            scale.x -= deScale * Time.deltaTime;
            this.transform.localScale = scale;
        }
    }

    private Vector3 updatePos()
    {
        Vector3 offset = new Vector3(0, 0, 0);
        float xVal = Input.GetAxis("Horizontal");
        if(xVal != 0) offset.x = xVal * moveSpeed * Time.deltaTime;
        return offset;
    }

    private void checkInputs()
    {
        if (Input.GetKeyDown(KeyCode.Q))        SetCursorState(CursorLockMode.None);
        if (Input.GetKeyDown(KeyCode.Escape))   Application.Quit();
        if (Input.GetKeyDown(KeyCode.Mouse0))   SetCursorState(CursorLockMode.Locked);
        if (Input.GetKeyDown(KeyCode.E)) expandPaddle();
    }

    private void expandPaddle()
    {
        Score -= expansionCost;
        ScoreText.text = scoreString + Score;
        Vector3 scale = this.transform.localScale;
        scale.x += expansionAmount;
        this.transform.localScale = scale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bumper")
            Position.x += ((Position.x - other.transform.position.x) * moveSpeed * Time.deltaTime) / 2;
    }

    private void SetCursorState(CursorLockMode state)
    {
        Cursor.lockState = wantMode = state;
        Cursor.visible = (CursorLockMode.Locked != wantMode);
    }
}
