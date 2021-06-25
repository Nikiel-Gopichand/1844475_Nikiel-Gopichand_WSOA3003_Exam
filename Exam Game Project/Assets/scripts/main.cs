using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class main : MonoBehaviour
{
    //ui elements
    //nums
    public Slider hbar;
    public Text ir;
    public Text st;
    public Text wd;
    public Text gd;
    public Text po;
    public Text preq;
    public Text dy;
    //blacksmith
    public GameObject bsm;
    public TextMeshProUGUI bsuT;
    public TextMeshProUGUI bspuT;

    //general store
    public GameObject gsm;
    public TextMeshProUGUI gsuT;


    // fletcher
    public GameObject fsm;
    public TextMeshProUGUI fsuT;
    public TextMeshProUGUI fspuT;

    //wall
    public GameObject wsm;
    public TextMeshProUGUI wsuT;
    public TextMeshProUGUI wspuT;

    //home
    public GameObject sl;
    public GameObject hTP;

    //door 
    public GameObject di;
    public GameObject outTP;

    //door 
    public GameObject dou;
    public GameObject inTP;

    //win wave
    public GameObject wn;
    public Text ddd;
    // win game
    public GameObject wnn;
    //lose game
    public GameObject lose;
    //
    public GameObject pl;
    public GameObject gob;
    public GameObject GK;
    int daysLeft = 2;
    int diff;
    int gold;
    int iron;
    int wood;
    int stone;
    int storelvl;
    int bslvl;
    int fletchlvl;
    int walllvl;
    int villH;
    int wallD;
    int archerD;
    int hlvl;
    int swordlvl;
    int bowlvl;
    int he;
    bool fatigued;
    int power;
    int boostC;
    bool boostO;
    // Start is called before the first frame update
    void Start()
    {
       hlvl = diff = storelvl = bslvl = fletchlvl = walllvl = swordlvl = bowlvl = he = 1;
        gold = iron = wood = stone = 0;
        villH = 100;
        wallD = 0;
        archerD = 0;
        daysLeft = 7;
        fatigued = false;
        boostO = false;
    }
    public void winRound()
    {
        wn.SetActive(true);
    }
    public void dismissW()
    {
        wn.SetActive(false);
    }
    public void Win()
    {
        wnn.SetActive(true);
    }
    public void backMain()
    {
        //load main menu
    }
    public void lo()
    {
        lose.SetActive(true);
    }
    public void sleep()
    {
        GameObject[] ens = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < ens.Length; i++)
        {
            GameObject.Destroy(ens[i].gameObject);
        }
        GetComponent<playerController>().fullHeal();
        pl.transform.position = hTP.transform.position;
        fatigued = false;
        daysLeft--;
        GameObject[] sps = GameObject.FindGameObjectsWithTag("spawn");
        for (int i = 0; i < sps.Length; i++)
        {
            Instantiate(gob, sps[i].transform.position, sps[i].transform.rotation);
        }
        if (daysLeft == 0)
        {
            towerDefense();
        }
    }
    public void gout()
    {
        if (fatigued == false)
        {
            fatigued = true;
            pl.transform.position = outTP.transform.position;
        }
    }
    public void gin()
    {
        pl.transform.position = inTP.transform.position;
    }
    public void enbs()
    {
        bsm.SetActive(true);
        bsuT.GetComponent<TextMeshProUGUI>().text = bsTS();
        bspuT.GetComponent<TextMeshProUGUI>().text = bsPs();
    }
    public void endo()
    {
        dou.SetActive(true);
    }
    public void dido()
    {
        dou.SetActive(false);
    }
    public void endi()
    {
        di.SetActive(true);
    }
    public void didi()
    {
        di.SetActive(false);
    }
    public void disbs()
    {
        bsm.SetActive(false);
    }
    public void enf()
    {
       fsm.SetActive(true);
       fsuT.GetComponent<TextMeshProUGUI>().text = fTS();
       fspuT.GetComponent<TextMeshProUGUI>().text =fPs();
    }
    public void disf()
    {
       fsm.SetActive(false);
    }
    public string fTS()
    {
        return "Effect: Power + 25 \nCost:\n" + (fletchlvl == 1 ? "5 Iron \n 10 Wood" : fletchlvl == 2 ? "10 Iron \n 15 Wood" : "20 Iron \n 25 Wood");
    }
    public string fPs()
    {
        return "Effect: Bow Damage + 25 \nCost:\n" + (fletchlvl >= 2 && bowlvl == 1 ? "20 Gold" : fletchlvl >= 3 && bowlvl == 2 ? "30 Gold" : fletchlvl == 4 && bowlvl == 3 ? "50 Gold" : "Upgrade Building to Unlock This Upgrade");
    }
    public void enh()
    {
        sl.SetActive(true);
    }
    public void dish()
    {
        sl.SetActive(false);
    }
    public void enw()
    {
        wsm.SetActive(true);
        wsuT.GetComponent<TextMeshProUGUI>().text = wTS();
        wspuT.GetComponent<TextMeshProUGUI>().text = wPs();
    }
    public void disw()
    {
        wsm.SetActive(false);
    }
    public void engs()
    {
        gsm.SetActive(true);
       gsuT.GetComponent<TextMeshProUGUI>().text = gTs();
    }
    public void disgs()
    {
        gsm.SetActive(false);
    }
    public string gTs()
    {
        return "Effect: Consumable Max + 1\nCost:\n" + (storelvl == 1 ? "5 Wood \n 10 Stone" : storelvl == 2 ? "10 Wood \n 20 Stone" : "20 Wood \n 40 Stone");
    }
    public string bsTS()
    {
        return "Effect: Power +" + (bslvl == 1 ? 15 : (bslvl == 2 ? 20 : 20)) +
            "\n Cost: \n" +
            (bslvl == 1 ? "5 Iron \n 10 Wood": (bslvl == 2 ? "10 Iron \n 15 Wood" : "20 Iron \n 25 Wood" ) );
    }
    public string bsPs()
    {
        return "Effect: " + (bslvl >= 1 && swordlvl == 1 ? "Sword Damage + 17" : bslvl >= 2 && swordlvl == 2 ? "Sword Damage + 20" : "Sword Damage + 20") + "\n"
            + "Cost: \n"+ (bslvl >= 2 && swordlvl == 1 ? "20 Gold" : bslvl >= 3 && swordlvl == 2 ? "30 Gold" : bslvl == 4 && swordlvl == 3 ? "50 Gold" : "Upgrade Building to Unlock This Upgrade");
    }
    public string wTS()
    {
        return "Effect: Power +" + (walllvl == 1 ? 20 : (walllvl == 2 ? 20 : 20)) +
            "\n Cost: \n" +
            (walllvl == 1 ? "5 Iron \n 10 Stone" : (walllvl == 2 ? "10 Iron \n 20 Stone" : "20 Iron \n 40 Stone"));
    }
    public string wPs()
    {
        return "Effect: " + (walllvl >= 1 && he == 1 ? "Max Health + 50" : walllvl >= 2 && he == 2 ? "Max Health + 50" : "Max Health + 25") + "\n"
            + "Cost: \n" + (walllvl >= 2 && he == 1 ? "20 Gold" : walllvl >= 3 && he == 2 ? "30 Gold" : walllvl == 4 && he == 3 ? "50 Gold" : "Upgrade Building to Unlock This Upgrade");
    }
    public void playerDie()
    {
        //tp to village
        //lose some resources
        sleep();
    }
    public void towerDefense()
    {
        if (diff == 1 && power >= 135)
        {
            //win
            diffUp();
            wn.SetActive(true);
            //day reset 8
            daysLeft = 8;
        }
       else if (diff == 2 && power >= 175)
        {
            //win
            diffUp();
            wn.SetActive(true);
            //day reset 9
            daysLeft = 9;
        }
       else if (diff == 3 && power >= 215)
        {
            //win game
            wnn.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
            //lose game
        }
    }
    public void diffUp()
    {
        if (diff == 3)
        {
            GetComponent<goblinStats>().difup(50, 10, 0, 0);
            diff++;
        }
        if (diff == 2)
        {
            GetComponent<goblinStats>().difup(50, 10, 75, 20);
            diff++;
        }
        if (diff == 1)
        {
            GetComponent<goblinStats>().difup(50, 10, 50 , 15);
            diff++;
        }
        
        
    }
    public void wallup()
    {
        if (iron >= 5 && stone >= 10 && walllvl == 1)
        {
            iron -= 5;
            stone -= 10;
            walllvl++;
            villH += 20;
        }
        if (iron >= 10 && stone >= 20 && walllvl == 2)
        {
            iron -= 10;
            stone -= 20;
            walllvl++;
            villH += 20;
        }
        if (iron >= 20 && stone >= 40 && walllvl == 3)
        {
            iron -= 20;
            stone -= 40;
            walllvl++;
            villH += 20;
        }


    }
    public void healthup()
    {
        if (walllvl >= 2 && he == 1 && gold >= 20)
        {
            gold -= 20;
            GetComponent<playerController>().maxHI(50);
            he++;
        }
        if (walllvl >= 3 && he == 2 && gold >=30)
        {
            gold -= 30;
            GetComponent<playerController>().maxHI(50);
            he++;
        }
        if (walllvl == 4 && he == 3 && gold >= 50)
        {
            gold -= 50;
            GetComponent<playerController>().maxHI(25);
            he++;
        }
  
    }
    public void loot()
    {
        if (boostO == true)
        {
            boostC--;
        }
        if (boostC == 0)
        {
            boostO = false;
            GetComponent<playerController>().offD();

        }
        int ac = Random.Range(0,1);
        int c1 = Random.Range(0, 1); 
        int c2 = Random.Range(0, 1); 
        if (ac <= 0.35)
        {
            if (c1 <= 0.33)
            {
                stone += diff;
                if (c2 <= 0.5)
                {
                    wood += diff;
                }
                else
                {
                    iron += diff;
                }
            }
            if (c1 > 0.33 && c1 <= 0.67)
            {
                wood+= diff;
                if (c2 <= 0.5)
                {
                    stone += diff;
                }
                else
                {
                    iron += diff;
                }
            }
            if (c1 > 0.67)
            {
                iron += diff;
                if (c2 <= 0.5)
                {
                    stone += diff;
                }
                else
                {
                    wood += diff;
                }
            }
        }
        else
        {
            if (c1 <= 0.33)
            {
                stone += diff;
            }
            if (c1 > 0.33 && c1 <= 0.67)
            {
                wood += diff;
            }
            else
            {
                iron += diff;
            }
        }
        gold += 4 * diff;
    }
    public void upgradeStore()
    {
        if (storelvl == 1 && wood >= 5 && stone >= 10)
        {
            wood -= 5;
            stone -= 10;
            GetComponent<playerController>().storeup();
            storelvl++;
        }
        if (storelvl == 2 && wood >= 10 && stone >= 20)
        {
            wood -= 10;
            stone -= 20;
            GetComponent<playerController>().storeup();
            storelvl++;
        }
        if (storelvl == 3 && wood >= 20 && stone >= 40)
        {
            wood -= 20;
            stone -= 40;
            GetComponent<playerController>().storeup();
            storelvl++;
        }
    }
    public void upgradeBS()
    {
        if (bslvl < 4)
        {
            if (bslvl == 1 && iron >= 5 && wood >= 10)
            {
                iron -= 5;
                wood -= 10;
                wallD += 15;
            }
            if (bslvl == 2 && iron >= 10 && wood >= 15)
            {
                iron -= 10;
                wood -= 15;
                wallD += 20;
            }
            if (bslvl == 3 && iron >= 20 && wood >= 25)
            {
                iron -= 20;
                wood -= 25;
                wallD += 20;
            }
            bslvl++;
        }
    }
    public void upSword()
    {
        if (bslvl >= 2 && swordlvl == 1 && gold >= 20)
        {
            gold -= 20;
            GetComponent<playerController>().sDI(17);
            swordlvl++;
        }
        if (bslvl >= 3 && swordlvl == 2 && gold >= 30)
        {
            gold -= 30;
            GetComponent<playerController>().sDI(20);
            swordlvl++;
        }
        if (bslvl == 4 && swordlvl == 3 && gold >= 50)
        {
            gold -= 50;
            GetComponent<playerController>().sDI(20);
            swordlvl++;
        }
    }
    public void fletchUp()
    {
        if (fletchlvl < 4)
        {
            if (fletchlvl == 1 && iron >= 5 && wood >= 10)
            {
                iron -= 5;
                wood -= 10;
                archerD += 25;
            }
            if (fletchlvl == 2 && iron >= 10 && wood >= 15)
            {
                iron -= 10;
                wood -= 15;
                archerD += 25;
            }
            else if (fletchlvl == 3 && iron >= 20 && wood >= 25)
            {
                iron -= 20;
                wood -= 25;
                archerD += 25;
            }
            fletchlvl++;
        }
    }
    public void upBow()
    {
        if (fletchlvl >= 2 && bowlvl == 1 && gold >= 20)
        {
            gold -= 20;
            GetComponent<playerController>().bDI(25);
            bowlvl++;
        }
        if (fletchlvl >= 3 && bowlvl == 2 && gold >= 30)
        {
            gold -= 30;
            GetComponent<playerController>().bDI(25);
            bowlvl++;
        }
        if (fletchlvl == 4 && bowlvl == 3 && gold >= 50)
        {
            gold -= 50;
            GetComponent<playerController>().bDI(25);
            bowlvl++;
        }
    }
    public void buyH()
    {
        if (gold >= 15)
        {
            gold -= 15;
            GetComponent<playerController>().buyH();
        }
    }
    public void buyD()
    {
        if (gold >= 20)
        {
            gold -= 20;
            GetComponent<playerController>().buyD();
        }
    }
    public void buyA()
    {
        if (gold >= 1)
        {
            gold -= 1;
            GetComponent<playerController>().buyA();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") == true)
        {
            GetComponent<playerController>().heal(20);
        }
        if (Input.GetKeyDown("r") == true && boostO == false)
        {
            GetComponent<playerController>().useD();
            boostO = true;
            boostC = 4;
        }
        if (Input.GetKeyDown("u"))
        {
            iron += 10;
            wood += 10;
            stone += 10;
            gold += 10;
        }
        power = villH + archerD + wallD;
        hbar.value = GetComponent<playerController>().h();
        ir.text = "" + iron;
        st.text = "" + stone;
        wd.text = "" + wood;
        gd.text = "" + gold;
        po.text = "" + power;
        preq.text = (diff == 1 ? "135" : diff == 2 ? "175" : "215");
        dy.text = "" + daysLeft;
    }
}
