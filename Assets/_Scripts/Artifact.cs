using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                Debug.Log("YEET");
            if (hit.collider.gameObject.tag == "Artifact")
            {
                Debug.Log("ARTIFACT");
                //Destroy(gameObject. >);
            }
        }
    }
}
