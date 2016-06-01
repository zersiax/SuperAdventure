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

            Location location = new Location(1, "home", "This is your home");





            player = new Player(10, 10, 20, 0, 1);



            lblHitPoints.Text = player.CurrentHitPoints.ToString();
            lblGold.Text = player.Gold.ToString();
            lblExperience.Text = player.ExperiencePoints.ToString();
            lblLevel.Text = player.Level.ToString();

                
        }



    }
    
}
