using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public float xRight = 1f;
    public float xLeft = -1f;
    public float yUp = 1f;
    public float yDown = -1f;

    private bool canMove;
    private bool getSwipe;

    private int ropeAmt;

    public Text ropeText;

    private RaycastHit hit_Info;

    private GameObject other;

    private void Start()
    {
        canMove = true;
        ropeAmt = 6;
        ropeText.text = "Rope left:" + ropeAmt;

    }

    public void swipeUp()
    {
        getSwipe = true;
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.up * 5);
            
            Ray ray = new Ray(this.transform.position, this.transform.up);
            if (Physics.Raycast(ray,out hit_Info,5f))
            {
                if (hit_Info.collider.tag == "Dirt")
                {
                    
                    Debug.Log("Does it work?!??");
                    
                    if (ropeAmt > 0)
                    {
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        this.transform.Translate(0, yUp, 0);
                      
                    }
                    else if (ropeAmt == 0)
                    {
                        ropeText.text = "Not enough rope.....";
                    }
                        /*
                    if (other.GetComponent<Renderer>().enabled == false)
                    {
                        
                        this.transform.Translate(0, yUp, 0);
                    }
                    */
                    
                }
            }

        }
    }


    public void swipeDown()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.up*-1f * 5f);
            
            Ray ray = new Ray(this.transform.position, transform.up * -1f);
            if (Physics.Raycast(ray,out hit_Info,5f))
            {
                if (hit_Info.collider.tag == "Dirt")
                {
                    
                    Debug.Log("Does it work?!??");
                    
                    if (ropeAmt > 0)
                    {  
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        this.transform.Translate(0, yDown, 0);
                        
                    }
                    else if (ropeAmt == 0)
                    {
                        ropeText.text = "Not enough rope.....";
                    }
                    
                }
                  
               
            }

        }

    }

    public void swipeLeft()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.right*-1f* 5f);
            
            Ray ray = new Ray(this.transform.position, transform.right * -1f );
            if (Physics.Raycast(ray,out hit_Info,5f))
            {
                if (hit_Info.collider.tag == "Dirt")
                {
                    
                    Debug.Log("Does it work?!??");
                    
                    if (ropeAmt > 0)
                    {  
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        this.transform.Translate(xLeft, 0, 0);
                        
                    }
                    else if (ropeAmt == 0)
                    {
                        ropeText.text = "Not enough rope.....";
                    }
                    
                }
            }
        }
    }

    public void swipeRight()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.right* 5f);
            
            Ray ray = new Ray(this.transform.position, transform.right);
            if (Physics.Raycast(ray,out hit_Info,5f))
            {
                if (hit_Info.collider.tag == "Dirt")
                {
                    
                    Debug.Log("Does it work?!??");
                    
                    if (ropeAmt > 0)
                    {  
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        this.transform.Translate(xRight, 0, 0);
                        
                    }
                    else if (ropeAmt == 0)
                    {
                        ropeText.text = "Not enough rope.....";
                    }
                    
                }
            }

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Dirt"))
        {
       
            canMove = true;
            other.gameObject.GetComponent<Renderer>().enabled = false;
            //Destroy(other.gameObject);
            Debug.Log("Tried to destroy");
        }
        else
        {
            canMove = false;
        }


    }
}

