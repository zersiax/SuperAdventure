using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player player;

        public SuperAdventure()
        {
            InitializeComponent();

            player = new Player();
            player.CurrentHitPoints = 10;
            player.MaximumHitPoints = 10;
            player.Gold = 20;
            player.ExperiencePoints = 0;
            player.Level = 1;

            lblHitPoints.Text = player.CurrentHitPoints.ToString();
            lblGold.Text = player.Gold.ToString();
            lblExperience.Text = player.ExperiencePoints.ToString();
            lblLevel.Text = player.Level.ToString();

                
        }



    }
    
}
