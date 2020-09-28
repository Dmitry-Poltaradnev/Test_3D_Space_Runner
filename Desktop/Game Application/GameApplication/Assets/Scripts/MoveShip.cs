using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    CharacterController cc;
    Vector3 moveVec;
    public Animator Ship;
    public GameManager GM;
    public bool CanPlay;


    int laneNumber = 1,
        lanesCount = 2;

    public float speed = 5;

    public float FirstLanePos,
                LaneDistance,
                SideSpeed;



    void Start()
    {
        cc = GetComponent<CharacterController>();
        moveVec = new Vector3(1, 0, 0);
        Ship = GetComponent<Animator>();

    }

    private void Update()
    {
        if (CanPlay)
        {
            moveVec.x = speed;
        }
        
        moveVec *= Time.deltaTime;

        CheckInput();




        cc.Move(moveVec);
        Vector3 newPos = transform.position;
        newPos.z = Mathf.Lerp(newPos.z, FirstLanePos + (laneNumber + LaneDistance), Time.deltaTime * SideSpeed);
        transform.position = newPos;

    }

    void CheckInput()
    {
        if (!CanPlay)
        {
            return;
        }
        int sign = 0;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Ship.Play("Right");
            sign = 1;

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Ship.Play("LeftTurn");
            sign = -1;
        }
        else
        {
            return;
        }



        laneNumber += sign;
        laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        CanPlay = false;

        yield return new WaitForSeconds(1);

        GM.ShowResult();
    }


}

