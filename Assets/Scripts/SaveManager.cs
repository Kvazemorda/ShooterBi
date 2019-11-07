using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public API API;
    public static SaveManager Instance { set; get; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void Save(ShootingStatistic shootingStatic)
    {
        Debug.Log(Helper.Serialize<ShootingStatistic>(shootingStatic));
        PlayerPrefs.SetString("save", Helper.Serialize<ShootingStatistic>(shootingStatic));
        UploadOnServer(shootingStatic);
    }

    private void UploadOnServer(ShootingStatistic shooting)
    {
        ShootingStatistic shooterId = new ShootingStatistic();
        API.RequestToUploadShootStatistic(shooting);
        JsonUtility.FromJsonOverwrite(API.answer, shooterId);
        Debug.Log(shooterId.shooterId);
        if (!shooting.shooterId.Equals(shooterId.shooterId) && shooterId.shooterId != 0)
        {
            Debug.Log("create new ID");
            Save(shooterId);
        }

        /* проверить ответ от сервера и если был создан новый юзер, то сохранить его id в ShootingStatistic. */
    }

    public ShootingStatistic LoadShootingStatic()
    {
        if (PlayerPrefs.HasKey("save"))
        { 
            ShootingStatistic statistic = Helper.Deserialize<ShootingStatistic>(PlayerPrefs.GetString("save"));
            if(statistic != null)
            {
                return statistic;
            }
            else
            {
                return new ShootingStatistic();
            }
        }
        else
        {
            Debug.Log("SaveNewShootingStatistic");
            return new ShootingStatistic();
        }
    }
}
