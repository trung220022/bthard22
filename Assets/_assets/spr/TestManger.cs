using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject root;
    public GameObject showtestbutton;

    private void Start()
    {
        ClosedUi();
    }

    public void ShowUi()
    {
        root.SetActive(true);
        showtestbutton.SetActive(false);
    }

    public void ClosedUi()

    {
        root.SetActive(false);
    }

    public void Test()
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();

        foreach (var kvp in dict)
        {
            var value = kvp.Value;
        }
    }
}