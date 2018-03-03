using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.Math;

namespace BodyCountV
{
    public class BodyCountV : Script
    {
        int bodyCount = 0;

        public BodyCountV()
        {
            UI.Notify("Hello World");

            Tick += Update;
            KeyDown += Input;
            Interval = 1;
        }

        private void Update(object sender, EventArgs e)
        {

        }

        private void Input(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K)
            {
                Ped newPed = World.CreateRandomPed(Game.Player.Character.Position.Around(1.0f));
                newPed.CanRagdoll = true;
                newPed.Kill();
                newPed.ApplyForce(Vector3.WorldUp * 1.0f);

                bodyCount++;
                UI.Notify(bodyCount.ToString());
            }
            if (e.KeyCode == Keys.C)
            {
                UI.Notify(World.GetAllPeds().Count().ToString());
            }
        }
    }
}
