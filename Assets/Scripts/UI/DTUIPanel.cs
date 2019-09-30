using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTUIPanel
{
    public UIPanelID PanelId { get; set; }
    public string PanelName { get; set; }
    public string PanelPath { get; set; }


    public DTUIPanel()
    {

    }

    public DTUIPanel(UIPanelID _id, string _name, string _path)
    {
        this.PanelId = _id;
        this.PanelName = _name;
        this.PanelPath = _path;
    }


}

