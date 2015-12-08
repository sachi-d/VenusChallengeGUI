using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VenusChallengeGUI
{
    class Init
    {
        Client2 cli;
        Game1 game;
        public Init()
        {
            Thread gui = new Thread(new ThreadStart(StartGUI));
            gui.Start();
            Thread form = new Thread(new ThreadStart(StartForm));
            form.Start();
            
        }
       
        private void StartGUI()
        {
            game = new Game1();
            using (game)
            {
                game.Run();

            }
        }
        public void StartForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            cli = new Client2(game);
            Application.Run(cli);
        }
    }
}
