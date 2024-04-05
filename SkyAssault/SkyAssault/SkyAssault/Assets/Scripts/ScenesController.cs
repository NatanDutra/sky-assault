using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void BtnNextGameScene(){
        SceneManager.LoadScene("Login");
    }

    public void BtnNextCreditos(){
        SceneManager.LoadScene("Creditos");
    }

    public void BtnSampleScene(){
        SceneManager.LoadScene("SampleScene");
    }
}
