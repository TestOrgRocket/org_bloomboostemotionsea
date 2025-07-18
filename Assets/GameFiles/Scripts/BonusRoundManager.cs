using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusRoundManager : MonoBehaviour
{
    public Sprite ClosedChest, OpenChest;
    public GameObject x2_Image;

    public List<GameObject> Chests;

    int _rndIntValue;

    private void OnEnable() {
        foreach(GameObject Chest in Chests)
            Chest.GetComponent<Image>().sprite = ClosedChest;
        _rndIntValue = Random.Range(0, Chests.Count);
    }

    public void PickChest(int position){
        Chests[position].GetComponent<Image>().sprite = OpenChest;
        x2_Image.SetActive(true);
        x2_Image.transform.localPosition = Chests[_rndIntValue].transform.localPosition;
        if(_rndIntValue == position){
            BaseManagement.Score *= 2;
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(1.5f);
        x2_Image.SetActive(false);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<BaseManagement>().OpenGameEnd();
    }
}
