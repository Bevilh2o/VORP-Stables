﻿using CitizenFX.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vorpstables_cl
{
    public class Horse
    {
        private int ID;
        private string Name;
        private string HorseModel;

        private int XP;

        private JObject Status;

        private JObject Gear;

        private bool isDead;

        private bool isDefault;


        /*Timer*/
        private int deadTimeRest;

        public Horse(int id, string name, string horseModel, int xP, string status, string jsonGear, bool isdefault, bool isdead)
        {
            this.ID = id;
            Name = name;
            HorseModel = horseModel;
            XP = xP;
            Status = JObject.Parse(status);
            Gear = JObject.Parse(jsonGear);
            isDefault = isdefault;
            isDead = isdead;
        }

        public Horse()
        { 
            
        }

        public JObject status { get => Status; set => Status = value; }

        public int getHorseDeadTime()
        {
            
            return deadTimeRest;
        }

        public void setHorseDead(int time)
        {
            deadTimeRest = time;
        }

        public int getHorseId()
        {
            return ID;
        }

        public string getHorseModel()
        {
            return HorseModel;
        }
        public string getHorseName()
        {
            return Name;
        }
        public JObject getGear()
        {
            return Gear;
        }

        public bool IsDefault()
        {
            return this.isDefault;
        }
        public void setDefault(bool def)
        {
            if (!def)
            {
                this.isDefault = false;
            }
            else
            {
                for (int i = 0; i < HorseManagment.MyHorses.Count; i++)
                {
                    if (HorseManagment.MyHorses[i].ID != this.ID)
                    {
                        HorseManagment.MyHorses[i].setDefault(false);
                    }

                }
                this.isDefault = true;
                HorseManagment.spawnedHorse = new Tuple<int, Horse>(0, this);
                HorseManagment.SetDefaultHorseDB(this.ID);
            }

        }

    }
}
