using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class Wave_Script : MonoBehaviour
{
    public int wave = 1;
    private bool Start_Wave = false;
    public float timer_limit;
    public float timer_time;
    public bool start = true;
    public bool WaveAdd = true;

    public GameObject Dog1;
    public GameObject Dog2;
    public GameObject Health_Potion;
    public GameObject Speed_Potion;
    public GameObject Immunity_Potion;
    public GameObject Trap;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject Spawner5;
    public GameObject Spawner6;

    public TextMeshProUGUI Wave_Big;
    public TextMeshProUGUI Wave_Small;

    public bool[] SpawnLoaction = new bool[6];
    // Start is called before the first frame update
    void Start()
    {
        timer_time = timer_limit;
    }

    // Update is called once per frame
    void Update()
    {
        int rand1 = 0, rand2 = 0; //rand1 is the random number of a spawner | rand 2 is the number that was used to randomize what spawns
        int Count_Dog1 = 0, Count_Dog2 = 0;
        for (int i = 0;i<6;i++) //reset arr
        {
            SpawnLoaction[i] = false;
        }

        if(wave == 1 && start) //wave 1 title
        {
            Wave_Small.text = "";
            Wave_Big.text = "wave 1";
            if (timer_time < 0)
            {
                Wave_Big.text = "";
                Wave_Small.text = "wave 1";
                timer_time = timer_limit;
                Start_Wave = true;
                start = false;
            }
            else
            {
                timer_time = timer_time - 1f * Time.deltaTime;
            }
        }

        if (wave == 1 && Start_Wave) //wave 1
        {
            Start_Wave = false;
            Instantiate(Dog1, SpawnPosition(Spawner5), Spawner5.transform.rotation);
            Instantiate(Health_Potion, SpawnPosition(Spawner2), Spawner2.transform.rotation);
        }

        if (wave == 2 && Start_Wave) //wave 2
        {
            WaveAdd = true;
            Start_Wave = false;
            Instantiate(Dog2, SpawnPosition(Spawner4), Spawner4.transform.rotation);
            Instantiate(Trap, SpawnPosition(Spawner2), Spawner2.transform.rotation);
            Instantiate(Speed_Potion, SpawnPosition(Spawner5), Spawner5.transform.rotation);
        }

        if (wave == 3 && Start_Wave) //wave 3
        {
            WaveAdd = true;
            Start_Wave = false;
            Instantiate(Dog1, SpawnPosition(Spawner6), Spawner6.transform.rotation);
            Instantiate(Dog2, SpawnPosition(Spawner3), Spawner3.transform.rotation);
            Instantiate(Immunity_Potion, SpawnPosition(Spawner2), Spawner2.transform.rotation);
        }
        
        if((wave == 4 || wave == 5 ) && Start_Wave) //wave 4, 5
        {
            WaveAdd = true;
            Start_Wave = false;
            while(TrueNum(SpawnLoaction) != 2) //spawn enemies
            {
                rand1 = Random.Range(0, 6);
                if (SpawnLoaction[rand1] == false)
                {
                    SpawnLoaction[rand1] = true;
                    rand2 = Random.Range(0, 3);
                    if(rand2 == 0)
                    {
                        Create(Dog1, rand1);
                    }
                    else
                        Create(Dog2, rand1);
                }

            }
            while (TrueNum(SpawnLoaction) != 3) //spawn booster
            {
                rand1 = Random.Range(0, 6);
                if (SpawnLoaction[rand1] == false)
                {
                    SpawnLoaction[rand1] = true;
                    rand2 = Random.Range(0, 100);
                    if (rand2 < 30)
                        Create(Health_Potion, rand1);
                    if (rand2 >= 30 && rand2 < 50)
                        Create(Speed_Potion, rand1);
                    if (rand2 >= 50 && rand2 < 70)
                        Create(Immunity_Potion, rand1);
                    if (rand2 >= 70)
                        Create(Trap, rand1);
                }
            }

        }

        if ((wave > 5 && wave < 9) && Start_Wave) //wave 6,7,8
        {
            WaveAdd = true;
            Start_Wave = false;
            while (TrueNum(SpawnLoaction) != 3) //spawn enemies
            {
                rand1 = Random.Range(0, 6);
                if (SpawnLoaction[rand1] == false)
                {
                    SpawnLoaction[rand1] = true;
                    rand2 = Random.Range(0, 3);
                    if (rand2 == 0)
                    {
                        Create(Dog1, rand1);
                    }
                    else
                        Create(Dog2, rand1);
                }

            }
            while (TrueNum(SpawnLoaction) != 4) //spawn booster
            {
                rand1 = Random.Range(0, 6);
                if (SpawnLoaction[rand1] == false)
                {
                    SpawnLoaction[rand1] = true;
                    rand2 = Random.Range(0, 100);
                    if (rand2 < 30)
                        Create(Health_Potion, rand1);
                    if (rand2 >= 30 && rand2 < 50)
                        Create(Speed_Potion, rand1);
                    if (rand2 >= 50 && rand2 < 70)
                        Create(Immunity_Potion, rand1);
                    if (rand2 >= 70)
                        Create(Trap, rand1);
                }
            }

        }

        if ((wave > 8 && wave < 12) && Start_Wave) //wave 9, 10, 11
        {
            WaveAdd = true;
            Start_Wave = false;
            while (TrueNum(SpawnLoaction) != 4) //spawn enemies
            {
                rand1 = Random.Range(0, 6);
                if (SpawnLoaction[rand1] == false)
                {
                    SpawnLoaction[rand1] = true;
                    rand2 = Random.Range(0, 3);
                    if (rand2 == 0)
                    {
                        Create(Dog1, rand1);
                    }
                    else
                        Create(Dog2, rand1);
                }

            } 
            while (TrueNum(SpawnLoaction) != 5) //spawn booster
            {
                rand1 = Random.Range(0, 6);
                if (SpawnLoaction[rand1] == false)
                {
                    SpawnLoaction[rand1] = true;
                    rand2 = Random.Range(0, 100);
                    if (rand2 < 30)
                        Create(Health_Potion, rand1);
                    if (rand2 >= 30 && rand2 < 50)
                        Create(Speed_Potion, rand1);
                    if (rand2 >= 50 && rand2 < 70)
                        Create(Immunity_Potion, rand1);
                    if (rand2 >= 70)
                        Create(Trap, rand1);
                }
            }

        }

        if ((wave >= 12) && Start_Wave) //wave 12+
        {
            WaveAdd = true;
            Start_Wave = false;
            while (TrueNum(SpawnLoaction) != 5) //spawn enemies
            {
                rand1 = Random.Range(0, 6);
                if (SpawnLoaction[rand1] == false)
                {
                    SpawnLoaction[rand1] = true;
                    rand2 = Random.Range(0, 3);
                    if (rand2 == 0)
                    {
                        Create(Dog1, rand1);
                    }
                    else
                        Create(Dog2, rand1);
                }

            }
        }

        GameObject[] fighters = GameObject.FindGameObjectsWithTag("Dog1"); //finds every dog1 - fighter
        GameObject[] archers = GameObject.FindGameObjectsWithTag("Dog2"); //finds every Dog2 - archer

        foreach (GameObject f in fighters)
            Count_Dog1++;

        foreach (GameObject a in archers)
            Count_Dog2++;

        if (Count_Dog1 == 0 && Count_Dog2 == 0 && !start) //if there are no more enemies and its not the start of the game
        {
            if (timer_time < 0) //timer (between all the enemies killed to Big_Title) is over
            {
                DestroyWave();
                if (WaveAdd)
                {
                    wave++;
                    WaveAdd = false;
                }
                Wave_Big.text = "wave" + wave;
                Wave_Small.text = "";
            }
            else
            {
                timer_time = timer_time -1f * Time.deltaTime;
            }

            if (timer_limit + timer_time < 0) //timer (Big_Title duration to new Wave)
            {
                Wave_Big.text = "";
                Wave_Small.text = "wave" + wave;
                timer_time = timer_limit;
                Start_Wave = true;
            }
            else
            {
                timer_time = timer_time - 1f * Time.deltaTime;
            }
            
        }
    }

    public void DestroyWave() //Destroys GameObjects that are not active
    {
        GameObject[] Fighters = GameObject.FindGameObjectsWithTag("Dog1");
        GameObject[] Archers = GameObject.FindGameObjectsWithTag("Dog2");
        GameObject[] HealPots = GameObject.FindGameObjectsWithTag("Health Potion");
        GameObject[] SpeedPots = GameObject.FindGameObjectsWithTag("Speed Potion");
        GameObject[] ImmPots = GameObject.FindGameObjectsWithTag("Immunity Potion");
        GameObject[] Traps = GameObject.FindGameObjectsWithTag("Trap");

        foreach (GameObject f in Fighters)
        {
            Destroy(f);
        }
        foreach (GameObject a in Archers)
        {
            Destroy(a);
        }
        foreach(GameObject h in HealPots)
        {
            Destroy(h);
        }
        foreach(GameObject s in SpeedPots)
        {
            if(!s.GetComponent<Speed_Potion_Script>().active)
                Destroy(s);
        }
        foreach(GameObject i in ImmPots)
        {
            if (!i.GetComponent<Immunity_Potion_Script>().active)
                Destroy(i);
        }
        foreach(GameObject t in Traps)
        {
            Destroy(t);
        }
    }
    public Vector3 SpawnPosition(GameObject Spawner) //puts the location it aboves the spawner so its visible
    {
        Vector3 spawn = new Vector3();
        spawn.Set(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z - 0.1f);
        return spawn;
    }

    public int TrueNum(bool[] arr) //Num of occupied spawner
    {
        int count = 0; 
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == true)
                count++;
        }
        return count;
    }
    public void Create(GameObject enemy, int num) //creting the gameobject in the correct spawner 
    {
        if (num == 0)
        {
            Instantiate(enemy, SpawnPosition(Spawner1), Spawner1.transform.rotation);
        }
        else if(num == 1)
        {
            Instantiate(enemy, SpawnPosition(Spawner2), Spawner2.transform.rotation);
        }
        else if (num == 2)
        {
            Instantiate(enemy, SpawnPosition(Spawner3), Spawner3.transform.rotation);
        }
        else if (num == 3)
        {
            Instantiate(enemy, SpawnPosition(Spawner4), Spawner4.transform.rotation);
        }
        else if (num == 4)
        {
            Instantiate(enemy, SpawnPosition(Spawner5), Spawner5.transform.rotation);
        }
        else if (num == 5)
        {
            Instantiate(enemy, SpawnPosition(Spawner6), Spawner6.transform.rotation);
        }
    }
}
