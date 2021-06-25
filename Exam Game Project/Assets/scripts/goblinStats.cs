using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinStats : MonoBehaviour
{
    int health = 50;
    int maxH = 50;
    int damage = 10;
    int kH = 75;
    int kD = 15;
    // Start is called before the first frame update
    void Start()
    {
        health = maxH;
    }
    public void difup(int health,int damage,int kh, int kd)
    {
        maxH += health;
        damage += damage;
        kH += kh;
        kD += kd;
    }
    public int getH()
    {
        return maxH;
    }
    public int getD()
    {
        return damage;
    }
    public int getKH()
    {
        return kH;
    }
    public int getKD()
    {
        return kD;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
