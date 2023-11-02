using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] GameObject controllers, canvases, sdk, level, player;

    private void Start()
    {
        //Invoke("LoadGame", 2f);
        //LoadGame();
    }
    public void LoadGame()
    {
        Debug.Log("LoadGôme");
        sdk.SetActive(true);
        controllers.SetActive(true);
        canvases.SetActive(true);
        level.SetActive(true);
        player.SetActive(true);
    }
}
