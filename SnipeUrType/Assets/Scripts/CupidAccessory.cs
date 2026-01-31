using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CupidAccessory : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    public int pickedEntryIndex;
    public Image[] images;

    void Start()
    {
        UpdateImages(dropdown.value);
    }
    public void GetDropdownValue()
    {
        UpdateImages(dropdown.value);
    }
    void UpdateImages(int index)
    {
        if (index == 0) index = -1; //if none selected
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i == index);
        }
    }
}

