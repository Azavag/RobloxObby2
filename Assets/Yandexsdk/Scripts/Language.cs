using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    public string currentLanguage;
    public static Language Instance;
    public bool isRusLang;
    
    [DllImport("__Internal")]
    private static extern string GetLang();
  
    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            //transform.SetParent(null);
            //DontDestroyOnLoad(this);

        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("Language");

#if !UNITY_EDITOR
            //currentLanguage = GetLang();          
#endif
        if (currentLanguage == "ru")
            isRusLang = true;
        else isRusLang = false;
    }
}
