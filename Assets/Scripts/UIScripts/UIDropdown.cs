using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDropdown : MonoBehaviour
{
    [SerializeField] private Dropdown _Dropdown;
    [SerializeField] private JsonSerializationController _JsonSerializationController;
    
    
    
    void Start()
    {
        _JsonSerializationController.OnSetsUpdate += UpdateList;
    }

    private void UpdateList(List<int> ids)
    {
        
    }
}
