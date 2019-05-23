using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{

    public Text countText;
    private int count;

    private void Start()
    {
        countText.text = "Artifacts:" + count;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                Debug.Log("YEET");
            if (hit.collider.CompareTag("Artifact"))
            {
                Debug.Log("ARTIFACT");
                gameObject.SetActive(false);
                count++;
                SetCountText();
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}