using System;
using UnityEngine;

//�������������� ����� ������ � ��������
public class ExecutorZenject //: IData
{
    //public bool LoadDataFireBase(Firebase.Database.DataSnapshot dataSnapshot, out DataPlayer dataPlayerFireBase)//����� ��������� �� FireBase
    //{
    //    if (FireBaseTool.Snapshot != null)
    //    {
    //        dataPlayerFireBase = new DataPlayer
    //        {
    //            healtPlayer = Int32.Parse(dataSnapshot.Child("healtPlayer").GetValue(true).ToString()),
    //            shootCount = Int32.Parse(dataSnapshot.Child("shootCount").GetValue(true).ToString())
    //        };
    //        return true;
    //    }
    //    else
    //    {
    //        dataPlayerFireBase = new DataPlayer();
    //        return false;
    //    }
    //}
    //public bool LoadDataLocalBase(string hashKey, out DataPlayer dataPlayerLocal)//����� ��������� �� LocalBase
    //{
    //    if (PlayerPrefs.HasKey($"{hashKey}"))
    //    {
    //        string jsonString = PlayerPrefs.GetString($"{hashKey}");
    //        if (!jsonString.Equals(string.Empty, StringComparison.Ordinal))
    //        {
    //            dataPlayerLocal = JsonUtility.FromJson<DataPlayer>(jsonString);
    //            return true;
    //        }
    //        else
    //        {
    //            dataPlayerLocal = new DataPlayer();
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        dataPlayerLocal = new DataPlayer();
    //        return false;
    //    }
    //}

    //public void LoadDataDefault(out DataPlayer dataPlayerDefault)//����� ��������� Default
    //{
    //    dataPlayerDefault = new DataPlayer();
    //}

    //public string SaveData(DataPlayer dataPlayer, string hashKey)//����� ����� �������� � ���������
    //{
    //    string jsonString = JsonUtility.ToJson(dataPlayer);
    //    Debug.Log(jsonString);
    //    //local
    //    PlayerPrefs.SetString(hashKey, jsonString);
    //    //FireBase
    //    FireBaseTool.SaveData(hashKey, jsonString);

    //    return $"healtPlayer={dataPlayer.healtPlayer} shootCount={dataPlayer.shootCount}";
    //}
}
