using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelConfig : MonoBehaviour
{
    public List<GameObject> UIBasePanels = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {

    }

    public GameObject GetPanel(string _name)
    {
        for (int i = 0; i < UIBasePanels.Count; i++)
        {
            if (UIBasePanels[i].name == _name)
            {
                return UIBasePanels[i];
            }
        }

        return null;
    }
}


