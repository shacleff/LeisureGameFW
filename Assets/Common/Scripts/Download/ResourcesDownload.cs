using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourcesDownload:MonoSingleton<ResourcesDownload>
{

    private ResourcesDownload() { }

    public string Load(string path)
    {
        TextAsset txt = Resources.Load<TextAsset>(path);
        return txt.text;
    }

}
