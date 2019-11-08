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
        PlayerPrefs.SetString("save", Helper.Serialize<ShootingStatistic>(shootingStatic));
        UploadOnServer(shootingStatic);
    }

    private void UploadOnServer(ShootingStatistic shooting)
    {
        API.RequestToUploadShootStatistic(shooting, this);
    }

    public void saveNewId(ShootingStatistic shooting, string answer)
    {
        ShootingStatistic shooterId = new ShootingStatistic();
        Debug.Log(answer);
        JsonUtility.FromJsonOverwrite(answer, shooterId);

        if (!shooting.shooterId.Equals(shooterId.shooterId) && shooterId.shooterId != 0)
        {
            Debug.Log("create new ID");
            shooting.shooterId = shooterId.shooterId;
            Save(shooting);
        }
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
