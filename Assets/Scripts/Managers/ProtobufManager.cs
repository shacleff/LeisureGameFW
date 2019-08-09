using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ProtoBuf;
using FileUtility;
using tnt_deploy;
using System.IO;

public class ProtobufManager : Singleton<ProtobufManager>
{
    private ProtobufManager()
    {

    }

    public void Init()
    {
        //GOODS_INFO_ARRAY infos=
        FileStream fs = new FileStream(Application.streamingAssetsPath + "/tnt_deploy_goods_info.data", FileMode.Open);
        GOODS_INFO_ARRAY infos = Serializer.Deserialize<GOODS_INFO_ARRAY>(fs);
        fs.Close();
        for (int i = 0; i < infos.items.Count; i++)
        {
            GOODS_INFO _INFO = infos.items[i];
            Debug.Log(string.Format("name:{0},first_skill_desc:{1},second_skill_desc:{2}", _INFO.name,_INFO.first_skill_desc,_INFO.second_skill_desc));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
