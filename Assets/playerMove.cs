using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float xRight = 1f;
    public float xLeft = -1f;
    public float yUp = 1f;
    public float yDown = -1f;

    private bool canMove;
    private bool getSwipe;

    private void Start()
    {
        canMove = true;
    }

    public void swipeUp()
    {
        getSwipe = true;
        if (canMove)
        {
            this.transform.Translate(0, yUp, 0);
        }
        /*
        if (getSwipe)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                movement = hit.point;          
            }

            getSwipe = false;
        }
     
        movePosition = Vector3.Lerp(transform.position, movement, Time.deltaTime * speed);
        PlayerRightbody.MovePosition(movePosition);
        */
    }

    public void swipeDown()
    {
        if (canMove)
        {
           
            this.transform.Translate(0,yDown,0);
        }   
    }

    public void swipeLeft()
    {
        if (canMove)
        {
            this.transform.Translate(xLeft,0,0);
        }
    }

    public void swipeRight()
    {
        if(canMove)
        {
            
            this.transform.Translate(xRight,0,0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Dirt"))
        {
            canMove = true;
            Destroy(other.gameObject);
            Debug.Log("Tried to destroy");
        }
        else
        {
            canMove = false;
        }


    }
}
