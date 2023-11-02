using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Link : MonoBehaviour
{
   
    public static Link Instance;
    public string currentDomain;
    string link = "";
    //Получение домена
    [DllImport("__Internal")]
    private static extern string GetDomainExtern();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // transform.SetParent(null);
           // DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("Domain");
//#if !UNITY_EDITOR
//            currentDomain = GetDomainExtern();
//#endif
    }

    //Из jslib
    //public void SetDomain(string domainString)
    //{
    //    currentDomain = GetDomainExtern();       
    //}
    //По кнопке
    public void GotoDeveloperPage()
    {
#if !UNITY_EDITOR
            //currentDomain = GetDomainExtern();
#endif
        link = string.Format("https://yandex.{0}/games/developer?name=DemiGames", currentDomain);
        Application.OpenURL(link);
    }
}
