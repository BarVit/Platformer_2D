using System.Collections;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private const string ObjectName = "[Coroutines]";

    private static Coroutines Instance
    {
        get
        {
            if(NewInstance == null)
            {
                GameObject gameObject = new GameObject(ObjectName);

                NewInstance = gameObject.AddComponent<Coroutines>();
                DontDestroyOnLoad(gameObject);
            }

            return NewInstance;
        }
    }

    private static Coroutines NewInstance;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return Instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine coroutine)
    {
        Instance.StopCoroutine(coroutine);
    }
}