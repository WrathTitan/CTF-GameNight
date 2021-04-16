using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class InteractionScript : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void BugFound();

    [DllImport("__Internal")]
    private static extern void ChestFound();

    [DllImport("__Internal")]
    private static extern void ChestNotFound();

    [DllImport("__Internal")]
    private static extern void MyAlert();


    private bool isNear;
    public GameObject textToDisplay;
    private bool adminCheck;
    private bool passCheck;
    void Start()
    {
        textToDisplay.SetActive(false);
        isNear = false;
        adminCheck = false;
        passCheck = false;
    }
    void Update()
    {
        if(isNear && Input.GetKeyDown(KeyCode.F))
        {
            if (gameObject.CompareTag("Bug"))
            {
                Debug.Log("Bug Found and Interacted with");
                BugFound();  
            }
            if (gameObject.CompareTag("Chest"))
            {
                Debug.Log("Chest Found and Interacted with");
                if (CheckWin(adminCheck,passCheck))
                {
                    ChestFound();
                    MyAlert();
                }
                else 
                {
                    ChestNotFound();
                }
            }
        }
    }
    private bool CheckWin(bool a,bool b)
    {
        if (a && b)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void CheckChestUser(string currentUser)
    {
        if (currentUser == "DSC_Admin")
        {
            adminCheck = true;
        }
        else
        {
            adminCheck = false;
        }
    }
    public void CheckChestPass(string currentPassword)
    {
        if (currentPassword == "n1cE_pA55wOrD")
        {
            passCheck = true;
        }
        else
        {
            passCheck = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNear = true;
        textToDisplay.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isNear = true;
        textToDisplay.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNear = false;
        textToDisplay.SetActive(false);
    }

}
