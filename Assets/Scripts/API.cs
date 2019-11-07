using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class API : MonoBehaviour
{
    public String answer;

    private const string URL = "http://94.73.244.109:8080/server-1.0.0.0/";
    public void RequestToUploadShootStatistic(ShootingStatistic statistic)
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

        UnityWebRequest request = UnityWebRequest.Get(URL + "hits" + paramsForRequest);
        request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            answer = request.downloadHandler.text;
            Debug.Log(answer);
        }
    }
}
