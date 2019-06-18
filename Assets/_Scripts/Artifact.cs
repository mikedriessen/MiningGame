﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Artifact : MonoBehaviour
{

    public Text countText;
    public int count;

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
            {
                

            if (hit.collider.CompareTag("Artifact"))
            {
                
                Debug.Log("ARTIFACT");
                hit.collider.gameObject.SetActive(false);
                count++;
                SetCountText();
            }
            }
            if (count == 1)
            {
                //SceneManager.LoadScene("Start");
                Debug.Log("GOOD JOB");
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void Score()
    {
        if (count == 1)
        {
            Debug.Log("WOW MOOI MAN");
        }
    }
}