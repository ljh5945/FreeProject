using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Status
{
    public int atk;
    public int def;
    public int str;
    public int crt;

    public Status(int atk, int def, int str, int crt)
    {
        this.atk = atk;
        this.def = def;
        this.str = str;
        this.crt = crt;
    }
}

[System.Serializable]
public class UserData
{
    public string Name;
    public int Level;
    public int NowExp;
    public int FullExp;
    public Status Stat;
    public List<Item> Inventory = new List<Item>();

    public Status GetAllStat()
    {
        Status status = new Status(Stat.atk, Stat.def, Stat.str, Stat.crt);

        foreach(Item item in Inventory)
        {
            if(item.IsEquipped)
            {
                status.atk += item.Data.Stat.atk;
                status.def += item.Data.Stat.def;
                status.str += item.Data.Stat.str;
                status.crt += item.Data.Stat.crt;
            }    
        }

        return status;
    }
}

[System.Serializable]
public class Item
{
    public bool IsEquipped;
    public ItemData Data;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData User;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
