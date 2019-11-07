using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 100f;
    public float range = 10000000f;
    public float xHit, yHit, zHit;
    public TextMeshPro leftBullet;
    public int bullet;
    public Camera fpscam;
    public AudioShootingScript audioScriptShooting;
    public AudioCockingScript audioCockingScript;
    public bool isReloaded, isStand;
    public List<Targert100> listOfTargets;
    public GameObject targetInfo;
    private ShootingStatistic statistic;
    public SaveManager saveManager;

    void Start()
    {
        //todo когда буду делать стрельбу стоя по установкам, то надо isStand перенести в метод и определять через toggle
        isStand = false;
        isReloaded = true;
        bullet = 5;
        listOfTargets = new List<Targert100>();
        statistic = saveManager.LoadShootingStatic();
    }

    private void Update()
    {
        leftBullet.text = bullet.ToString();
    }
    //создание отметки на мишени (показывает куда попал)
    public void CreateCirtle(Vector3 anchoredPosition)
    {
        int bulletLeft = 5 - bullet;
        GameObject circleGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circleGO.transform.parent = targetInfo.transform;
        circleGO.name = "Point-" + bulletLeft;
        circleGO.transform.localPosition = anchoredPosition;
        circleGO.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    }

    public void ResetGame()
    {
        ReloadRifle();
        OpenTheAim();
        Reload();
        DeleteAll();
    }

    //выстрел
    public void Shoot()
    {
        if (isReloaded)
        {
            audioScriptShooting.audioShoot.Play();
            isReloaded = false;
            statistic.shootCount++; //добавляем кол-во выстрелов в статистику
            bullet--;
            RaycastHit hit;

            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit))
            {
                Targert100 target = hit.transform.GetComponent<Targert100>();
                int coefOfset = 10; // задается различное смещение отметки на мишени если стрелок попадает в мишень 100 или 90 или 0
                if (target != null)
                {
                    Debug.Log(target.name);
                   if (target.name == "aim100")
                   {
                        //добавление цели в которую попал игров. Делается для того, чтобы получить крышку, 
                        //которая закрыла мешень и эту крышку вернуть на исходную позицию   
                        listOfTargets.Add(target);
                        if(target.closer != null)
                        {
                            target.closer.isClosing = true;
                        }
                        
                        statistic.isStand = false;
                        statistic.hit++; //добавляем кол-во попаданий в статистику
                  
                   }
                   if(target.name == "aim90")
                    {
                     
                    }

                   if(target.name == "aim0")
                    {
                        
                    }
                    
                    //todo https://answers.unity.com/questions/283138/how-do-i-use-raycasts-to-see-coordinates-of-the-hi.html
                    if(target.name == "aim0Registration" || target.name == "aim90Registration" || target.name == "aim100Registration")
                    {
                        xHit = fpscam.transform.forward.x * 10;
                        yHit = fpscam.transform.forward.y * 10;
                        zHit = -0.524f;
                        Debug.Log(xHit + " " + yHit + " " + fpscam.transform.forward.z);
                        Debug.DrawRay(fpscam.transform.forward, hit.transform.position);
                        CreateCirtle(new Vector3(xHit, yHit, zHit));
                    }
                }
            }
        }

    }


    public void DeleteAll()
    {
        string name = "Point-";
        foreach (GameObject o in GameObject.FindObjectsOfType<GameObject>())
        {
            if (o.name.Contains(name))
            {
                Destroy(o);
                listOfTargets.Clear();
            }
        }
        
        ReloadRifle();
    }
    public void Reload()
    {
        audioCockingScript.audioCocking.Play();
        isReloaded = true;
        if (bullet == 0)
        {
            OpenTheAim();
            DeleteAll();
            ReloadRifle();
            saveManager.Save(statistic);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = other.transform.position;
        {
            Debug.Log(Vector3.Dot(transform.forward, direction));
        }

    }

    // Открыть установки
    public void OpenTheAim()
    {
        foreach (Targert100 target in listOfTargets)
        {
            if (target.closer != null)
            {
                target.closer.isMovingToDefult = true;
            }

        }
    }

    public void ReloadRifle()
    {
        bullet = 5;
    }
}
