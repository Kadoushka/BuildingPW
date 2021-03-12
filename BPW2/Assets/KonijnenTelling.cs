using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class KonijnenTelling : MonoBehaviour
{
    public int kills;
    public Text PuntenScore;
    public Text AntiGravity;
    private void Update()
    {
        PuntenScore.text = Mathf.Floor(MyGlobalSpeedController.SharedInstance.konijnen).ToString();
        //1 is herladen
        //2 is vol
        //3 is actief
        if (GravityController.SharedInstance.gravity == 1) { AntiGravity.text = "Anti-Gravity Reloading"; }
        if (GravityController.SharedInstance.gravity == 2) { AntiGravity.text = "Anti-Gravity Full"; }
        if (GravityController.SharedInstance.gravity == 3) { AntiGravity.text = "Anti-Gravity Active"; }
        Debug.Log(MyGlobalSpeedController.SharedInstance.konijnen);
        
    }
}


public class MyGlobalSpeedController //Deze class regelt de universele kill counter
{
    private static MyGlobalSpeedController instance = null;
    public static MyGlobalSpeedController SharedInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new MyGlobalSpeedController();
            }
            return instance;
        }
    }
    public float konijnen;
}
public class GravityController //Deze class regelt de universele kill counter
{
    private static GravityController instance = null;
    public static GravityController SharedInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new GravityController();
            }
            return instance;
        }
    }
    public int gravity;
    //1 is herladen
    //2 is vol
    //3 is actief
}
