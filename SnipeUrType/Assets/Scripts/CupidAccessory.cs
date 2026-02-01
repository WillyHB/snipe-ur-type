using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CupidAccessory : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    public Image[] images;

    void Start()
    {
        int saved = PlayerPrefs.GetInt("CupidAccessory", 0);
        dropdown.value = saved;
        UpdateImages(dropdown.value);
    }
    public void GetDropdownValue()
    {
        UIAudio.instance.PlayClick();

        int value = dropdown.value;
        PlayerPrefs.SetInt("CupidAccessory", value);
        PlayerPrefs.Save();

        UpdateImages(value);
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

