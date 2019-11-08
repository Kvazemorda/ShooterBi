using System;
using System.Collections;

using UnityEngine;


public class API : MonoBehaviour
{
    public String answer;

    private const string URL = "http://94.73.244.109:8080/server-1.0.0.0/";
    public void RequestToUploadShootStatistic(ShootingStatistic statistic, SaveManager manager)
    {
        string hitsParamName = "hits"; 
        int hits = statistic.hit;

        string shootCountParamName = "hits-count";
        int shootCount = statistic.shootCount;

        string shooterIdParamName = "userid";
        long idShooter = statistic.shooterId;

        string isStandParamName = "isStand";
        bool isStand = statistic.isStand;
        
        string paramsForRequest = "?" + hitsParamName + "=" + hits + "&" +
            shootCountParamName + "=" + shootCount + "&" +
            shooterIdParamName + "=" + idShooter + "&" +
            isStandParamName + "=" + isStand;

        WWW request = new WWW(URL + "hits" + paramsForRequest);
        StartCoroutine(Respond(request, manager, statistic));
        
    }

    IEnumerator Respond(WWW request, SaveManager manager, ShootingStatistic statistic)
    {
        yield return request;
        answer = request.text;
        if(!answer.Equals("hits saved"))
        {
            manager.saveNewId(statistic, answer);
        }
        

    }
}
