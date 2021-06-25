using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    public Text poth;
    public Text potD;
    int health;
    int maxHealth;
    int swordDmg;
    int bowDmg;
    int hPots;
    int dPots;
    int hpotsmax;
    int dpotsmax;
    int healA;
    int dA;
    int arrows;
    bool dboost;
    public Text ar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth = 100;
        swordDmg = 13;
        bowDmg = 25;
        arrows = 5;
        dboost = false;
        hpotsmax = 4;
        dpotsmax = 2;
        hPots = 4;
        dPots = 2;
    }
    public void takeDMG(int amount)
    {

        health -= amount;


    }
    public float h()
    {
        float hea = health;
        float maxHea = maxHealth;
        return (hea/maxHea)*100;
    }
    public int ds()
    {
        return (dboost == true ? swordDmg*2 : swordDmg);
    }
    public int db()
    {
        return (dboost == true ? bowDmg*2 : bowDmg);
    }
    public void buyH()
    {
        if (hPots < hpotsmax)
        {
            hPots++;
        }
    }
    public void buyD()
    {
        if (dPots < dpotsmax)
        {
            dPots++;
        }
    }
    public void buyA()
    {
        arrows++;
    }
    public int anum()
    {
        return arrows;
    }
    public void useA()
    {
        arrows--;
    }
    public void storeup()
    {
        hpotsmax++;
        dpotsmax++;
        hPots = hpotsmax;
        dPots = dpotsmax;
    }
    public void useD()
    {
        if (dPots > 0 && dboost == false)
        {
            dboost = true;
            dPots--;
        }
    }
    public void offD()
    {
        dboost = false;
    }
    public void maxHI(int amount)
    {
        maxHealth += amount;
        fullHeal();
    }
    public void sDI(int amount)
    {
        swordDmg += amount;
    }
    public void bDI(int amount)
    {

        bowDmg += amount;

    }
    public void heal(int amount)
    {
        if (health < maxHealth && hPots > 0)
        {
            hPots--;
            health += 20;
        }
    }
    public void fullHeal()
    {
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        ar.text = "" + arrows;
        if (health <=0)
        {
            GetComponent<main>().sleep();
        }
        potD.text = ""+dPots;
        poth.text = ""+hPots;
    }
}
