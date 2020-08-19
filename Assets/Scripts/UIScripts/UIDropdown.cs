using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDropdown : MonoBehaviour
{
    [SerializeField] private Dropdown _Dropdown;
    [SerializeField] private JsonSerializationController _JsonSerializationController;
    [SerializeField] private SphereSpawnerController _SphereSpawnerController;
    
    void Start()
    {
        _JsonSerializationController.OnSetsUpdate += UpdateList;
        
        _Dropdown.onValueChanged.AddListener(NewSetSelected);
    }

    private void NewSetSelected(int value)
    {
        int setId = int.Parse(_Dropdown.options[value].text);
        _SphereSpawnerController.SpawnSpheres(_JsonSerializationController.GetSetParamsById(setId));
    }

    private void UpdateList(List<int> ids)
    {
        _Dropdown.options.Clear();

        foreach (var id in ids)
        {
            _Dropdown.options.Add(new Dropdown.OptionData(id.ToString()));
        }
    }

}
