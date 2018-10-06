using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExcelToCSV
{

    public static void Converte(Hashtable originData)
    {
        string str;
        str = "int,int,int,int,int,int,int,int,int";
        str += "ID,upgradeExp,maxHp,maxMp,attack,defense,precise,dodge,blastAttack";
       // File.WriteAllText(Application.streamingAssetsPath + "/item.csv", str);

        FileStream fileStream = new FileStream(Application.streamingAssetsPath + "/item.csv",FileMode.OpenOrCreate,FileAccess.Write);
        StreamWriter sw = new StreamWriter(fileStream);
        sw.WriteLine("int,int,int,int,int,int,int,int,int");
        sw.WriteLine("ID,upgradeExp,maxHp,maxMp,attack,defense,precise,dodge,blastAttack");
        foreach (var key in originData.Keys)
        {
            RoleItem i = originData[key] as RoleItem;
            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}",i.ID,i.upgradeExp,i.maxHp,i.maxMp,i.attack,i.defense,i.precise,i.dodge,i.blastAttack);
        }

        sw.Close();
        fileStream.Close();

    }
}
