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
        public Main()
        {
            Tick += Update;
            KeyDown += Input;

            Start();
        }

        void Start()
        {

        }

        void Update(object sender, EventArgs e)
        {

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
