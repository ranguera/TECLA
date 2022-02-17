using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem
{
    public enum Language
    {
        English,
        Spanish
    }

    public static Language language = Language.English;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedES;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedES = csvLoader.GetDictionaryValues("es");

        isInit = true;
    }

    public static string GetLocalisedValue(string key)
    {
        if(!isInit) { Init(); }

        string value = key;

        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.Spanish:
                localisedES.TryGetValue(key, out value);
                break;
            default:
                break;
        }

        return value;
    }

}
