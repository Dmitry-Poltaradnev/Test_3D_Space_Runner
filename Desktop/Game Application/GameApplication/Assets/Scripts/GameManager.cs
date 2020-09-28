using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ResultObj;   
   

    public void ShowResult()
    {
        ResultObj.SetActive(true); 
    }
}
