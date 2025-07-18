using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndOpen : MonoBehaviour
{
    public Text GameEndText;

    private void OnEnable() {
        float score = BaseManagement.Score;
        BaseManagement.isRecord();
        float record = BaseManagement.Record;

        GameEndText.text = $"Score - {score}\nRecord - {record}";
    }
}
