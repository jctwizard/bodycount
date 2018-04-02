using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GTA;
using GTA.Native;
using GTA.Math;


namespace BodyCount
{
    public class Main : Script
    {
        Random random;
        float killTimer = 0.0f;
        double killDelay;
        double killDelayMax = 30.0f;
        double killDelayMin = 10.0f;

        public Main()
        {
            Tick += Update;
            KeyDown += Input;

            Start();
        }

        void Start()
        {
            random = new Random();

            killDelay = (killDelayMax - killDelayMin) * random.NextDouble() + killDelayMin;
        }

        void Update(object sender, EventArgs e)
        {
            killTimer += Game.LastFrameTime;

            if (killTimer > killDelay)
            {
                killTimer = 0.0f;
                killDelay = (killDelayMax - killDelayMin) * random.NextDouble() + killDelayMin;
                IncreaseBodyCount();
            }
        }

        void IncreaseBodyCount()
        {
            Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 10.0f);

            if (peds.Length > 0)
            {
                int randomIndex = random.Next(0, peds.Length);

                Ped randomPed = peds[randomIndex];
                randomPed.Weapons.Give(WeaponHash.AssaultRifle, 24, false, false);
                randomPed.Task.FightAgainst(peds[random.Next(0, peds.Length)]);
            }
        }

        void Input(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K)
            {
                Ped ped = World.CreateRandomPed(Game.Player.Character.Position.Around(2.0f));

                if (ped.Exists() == false)
                {
                    UI.Notify("Ped not spawned");
                }

                UI.ShowSubtitle("Body Count: " + World.GetAllPeds().Count().ToString());
            }
        }
    }
}
