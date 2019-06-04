using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PersonalData
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public List<int> ownCharactors { get; set; }
    public List<int> ownThemes { get; set; }

    public PersonalData()
    {
        ID = 0;
        Name = "";
        ownCharactors = new List<int>();
        ownThemes = new List<int>();
    }

    public void SetName(string _name)
    {
        this.Name = _name;
        SaveData();
    }

    public void SetLevel(int _level)
    {
        this.Level = _level;
        SaveData();
    }

    public void AddOwnCharactor(int _index)
    {
        this.ownCharactors.Add(_index);
        SaveData();
    }

    public void AddOwnThemes(int _index)
    {
        this.ownThemes.Add(_index);
        SaveData();
    }

    public void SaveData()
    {
        CPlayerPrefs.SetString(PrefKeys.GAME_PERSONAL_DATA, JsonHelper.Serialize(this));
    }

}
