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
    public Texture[] btnTextures;
    
    //GUI
    public Texture aTexture;
    private bool openShop;
    
    //SwipeDalay
    private bool canSwipe = false;
    

    private void Start()
    {
        canSwipe = true;
        canMove = true;
        ropeAmt = 60;
        ropeText.text = "Rope left:" + ropeAmt;

        openShop = false;

    }


    public void swipeUp()
    {
        getSwipe = true;
        if (canMove)
        {
            Debug.DrawRay(transform.position, transform.up * 0.8f);

            Ray ray = new Ray(this.transform.position, this.transform.up);
            if (Physics.Raycast(ray, out hit_Info, 0.8f))
            {
                if (hit_Info.collider.tag == "Dirt" && canSwipe)
                {
                    canSwipe = false;
                    Debug.Log("Does it work?!??");

                    if (ropeAmt > 0)
                    {
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        XPSlider.Brain.AddXP();
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
            canSwipe = true;
        }


        Debug.DrawRay(transform.position, transform.up * 0.6f);

        Ray rayy= new Ray(this.transform.position, this.transform.up);
        if (Physics.Raycast(rayy, out hit_Info, 0.6f))
        {
            if (hit_Info.collider.tag == "Shop")
            {

                Shop();
              
            }
        }
/*
        RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
        Debug.DrawRay(transform.position,transform.up *0.8f , Color.red);
        hits = Physics.RaycastAll(this.transform.position, this.transform.up, 0.8f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();

            if (rend)
            {
              Debug.Log("Opened Shop");
                   
                    Shop();
                    
                
            }
        }
        */
    }


    public void swipeDown()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.up*-1f * 5f);
            
            Ray ray = new Ray(this.transform.position, transform.up * -1f);
            if (Physics.Raycast(ray,out hit_Info,0.8f))
            {
                if (hit_Info.collider.tag == "Dirt" && !openShop && canSwipe)
                {
                    canSwipe = false;
                    openShop = false;  
                    Debug.Log("Does it work?!??");
                    if (ropeAmt > 0 && openShop)
                    {
                        openShop = false;  
                    }
                    if (ropeAmt > 0 && !openShop)
                    {  
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        XPSlider.Brain.AddXP();
                        this.transform.Translate(0, yDown, 0);
                        

                    }
                    else if (ropeAmt == 0)
                    {
                        ropeText.text = "Not enough rope.....";
                    }
                    
                }

                if (hit_Info.collider.tag == "Dirt" && openShop)
                {
                    openShop = false;  
                }

              

            }

        }
        canSwipe = true;
    }

    public void swipeLeft()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.right*-1f* 5f);
            
            Ray ray = new Ray(this.transform.position, transform.right * -1f );
            if (Physics.Raycast(ray,out hit_Info,1f))
            {
                if (hit_Info.collider.tag == "Dirt" && canSwipe)
                {
                    canSwipe = false;
                    
                    Debug.Log("Does it work?!??");
                    if (ropeAmt > 0 && openShop)
                    {
                        openShop = false;  
                    }
                    
                    if (ropeAmt > 0)
                    {  
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        XPSlider.Brain.AddXP();
                        this.transform.Translate(xLeft, 0, 0);
                        openShop = false;  
                        
                    }
                    else if (ropeAmt == 0)
                    {
                        ropeText.text = "Not enough rope.....";
                    }
                    
                }
                if (hit_Info.collider.tag == "Dirt" && openShop)
                {
                    openShop = false;  
                }
             
            }
        }

        canSwipe = true;
    }

    public void swipeRight()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.right* 5f);
            
            Ray ray = new Ray(this.transform.position, transform.right);
            if (Physics.Raycast(ray,out hit_Info,1f))
            {
                if (hit_Info.collider.tag == "Dirt" && canSwipe)
                {
                    canSwipe = false;
                    if (ropeAmt > 0 && openShop)
                    {
                        openShop = false;  
                    }
                    Debug.Log("Does it work?!??");
                    
                    if (ropeAmt > 0)
                    {  
                        ropeAmt--;
                        ropeText.text = "Rope left:" + ropeAmt;
                        XPSlider.Brain.AddXP();
                        this.transform.Translate(xRight, 0, 0);
                        openShop = false;  
                        
                    }
                    else if (ropeAmt == 0)
                    {
                        ropeText.text = "Not enough rope.....";
                    }
                    
                }
                if (hit_Info.collider.tag == "Dirt" && openShop)
                {
                    openShop = false;  
                }
            }
        }

        canSwipe = true;
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

   void Shop()
   {
       openShop = true;


   }

 
   void OnGUI()
   {
       if (openShop)
       {
           GUI.backgroundColor = new Color(0,0,0,0);
           Debug.Log("Tried to open Shop2");
           GUI.DrawTexture(new Rect(100, 100, 900, 2000), aTexture, ScaleMode.ScaleToFit, true, 0.0F);
          
               if (GUI.Button(new Rect(250, 390, 128, 128), btnTextures[0]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 390, 128, 128), btnTextures[1]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 390, 128, 128), btnTextures[2]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 390, 128, 128), btnTextures[3]))
                   Debug.Log("Clicked the button with an Image1");
           

        
               if (GUI.Button(new Rect(250, 740, 128, 128), btnTextures[4]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 740, 128, 128), btnTextures[5]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 740, 128, 128), btnTextures[6]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 740, 128, 128), btnTextures[7]))
                   Debug.Log("Clicked the button with an Image1");
           

          
               if (GUI.Button(new Rect(250, 1100, 128, 128), btnTextures[8]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 1100, 128, 128), btnTextures[9]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 1100, 128, 128), btnTextures[10]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 1100, 128, 128), btnTextures[11]))
                   Debug.Log("Clicked the button with an Image1");
           
    
       }

   }

 
}

