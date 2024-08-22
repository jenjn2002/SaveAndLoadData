using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class JsonReadWriteSystem 
{
    public static List<T> FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.lists;
    }

    public static string ToJson<T>(List<T> list)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.lists = list;
        return JsonUtility.ToJson(wrapper.lists);
    }

    public static string ToJson<T>(List<T> list, bool print)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.lists = list;
        return JsonUtility.ToJson(wrapper, print);
    }

    private class Wrapper<T>
    {
        public List<T> lists;
    }
}
