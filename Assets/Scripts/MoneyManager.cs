using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
//���������� �����
public class MoneyManager : MonoBehaviour
{
    int moneyCount;
    [SerializeField] SpawnPoint startSpawnPoint;
    int maxMoneyCount;
    int moneyOnRun = 300;
    int runsCount = 1;
    [SerializeField] TextMeshProUGUI moneyTextField;
    [SerializeField] TextMeshProUGUI startGameText;
    [SerializeField] GameObject finalMenu;
    string continueGameText, newGameText;
    string ruContinueText = "����������", ruNewGameText = "����� ����";
    string enContinueText = "Continue", enNewGameText = "New game";
    float timeToShowPanel = 1.5f;

    [SerializeField] SpawnManager spawnManager;
    [SerializeField] NavigationController navigationController;
    [SerializeField] CoinsCollectionController coinsCollectionController;
    [SerializeField] InputGame inputGame;
    [SerializeField] HardLevelsNavigation levelsNavigation;
    SoundController soundController;

    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        if (Language.Instance.currentLanguage == "ru")
        {
            continueGameText = ruContinueText;
            newGameText = ruNewGameText;
        }
        else
        {
            continueGameText = enContinueText;
            newGameText = enNewGameText;
        }

        runsCount = Progress.Instance.playerInfo.runsCount;
        moneyCount = Progress.Instance.playerInfo.moneyCount;
        maxMoneyCount = runsCount * moneyOnRun;
        finalMenu.SetActive(false);
        ChangeStartGameText();
        UpdateMoneyText();      
        

    }

    public void UpdateMoneyCount(int difference)
    {
        moneyCount += difference;
        UpdateMoneyText();
        if(moneyCount >= maxMoneyCount) 
        {
            StartCoroutine(ShowFinalMenu());
        }
        ChangeStartGameText();

        Progress.Instance.playerInfo.moneyCount = moneyCount;
        YandexSDK.Save();
    }

    public void UpdateMoneyText()
    {
        string tempText = moneyCount + "/" + maxMoneyCount;
        moneyTextField.text = tempText;
    }

    public int GetMoneyCount()
    {
        return moneyCount;
    }

    void ChangeStartGameText()
    {
        if (moneyCount > 0)
            startGameText.text = continueGameText;
        else startGameText.text = newGameText;
    }

    IEnumerator ShowFinalMenu()
    {
        soundController.Play("WinGame");
        yield return new WaitForSeconds(timeToShowPanel);
        navigationController.EnableCharacterControl(false);
        inputGame.ShowCursorState(true);
        finalMenu.SetActive(true);
    }
    //�� ������
    public void AnotherRun()
    {
        runsCount++;       
        maxMoneyCount = (runsCount * moneyOnRun);
        spawnManager.ResetSpawnpoints();
        spawnManager.UpdatePointNumber(startSpawnPoint);
        spawnManager.RespawnPlayer();
        finalMenu.SetActive(false);
        inputGame.ShowCursorState(false);
        coinsCollectionController.ResetCoins();
        UpdateMoneyText();
        navigationController.EnableCharacterControl(true);
        levelsNavigation.SetActiveState(false);
        Progress.Instance.playerInfo.runsCount = runsCount;
        YandexSDK.Save();
    }
}
