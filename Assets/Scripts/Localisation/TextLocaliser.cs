using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLocaliser : MonoBehaviour
{
    public string key;

    private Text textField;

    void Start()
    {
        textField = GetComponent<Text>();

        if (key != "")
        {
            string val = LocalisationSystem.GetLocalisedValue(key);

            if (val.Contains("\\n"))
                val = val.Replace("\\n", "\n");

            textField.text = val;
        }
    }

    public void Refresh()
    {
        if (key != "")
        {
            if (LocalisationSystem.GetLocalisedValue(key).Contains("\\n"))
            {
                string[] tmp = LocalisationSystem.GetLocalisedValue(key).Split('\n');
                textField.text = tmp[0] + System.Environment.NewLine + tmp[1];
            }
            else
                textField.text = LocalisationSystem.GetLocalisedValue(key);
        }
    }
}

