using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManagement : MonoBehaviour
{
    public GameObject Menu, GameUI, Game, GameEnd, Bonus;
    public string PrivacyLink;
    public static float Score,Record;

    private void Start() {
        Score = 0;
        Record = PlayerPrefs.GetFloat("record",0);
    }


    public void OpenGame(){
        Score = 0;
        Game.SetActive(true);
        GameUI.SetActive(true);
        Menu.SetActive(false);
        GameEnd.SetActive(false);
        Bonus.SetActive(false);
    }

    public void OpenMenu(){
        Menu.SetActive(true);
        Game.SetActive(false);
        GameUI.SetActive(false);
        GameEnd.SetActive(false);
        Bonus.SetActive(false);
    }

    public void OpenGameEnd(){
        PickRandom();
        Game.SetActive(false);
        GameUI.SetActive(false);
        Menu.SetActive(false);
    }

    public void CloseGame(){
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public static void isRecord(){
        if(Score > Record){
            Record = Score;
            PlayerPrefs.SetFloat("record",Record);
        }
    }

    public void OpenPrivacy(){
        Application.OpenURL(PrivacyLink);
    }

    void PickRandom(){
        int rndNum = Random.Range(0,5);
        bool state = true;
        if(rndNum == 2){
            GameEnd.SetActive(!state);
            Bonus.SetActive(state);
        }else{
            state = false;
            GameEnd.SetActive(!state);
            Bonus.SetActive(state);
        }
    }
}
