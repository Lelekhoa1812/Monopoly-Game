using System;
using System.Net.NetworkInformation;
using SplashKitSDK;

namespace MonopolyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Booleans control players' names
            bool quit = false;
            bool changename = true;
            bool needname = true;

            // Vital variables
            string name1 = "", name2 = "", name3 = "", name4 = "";

            // Players' turn variable
            int p_turn = 1;
            
            // Display ownerships request
            bool display = false;

            // Require number of player boolean
            bool fullplayer = true;

            // Pause game boolean
            bool paused = true;

            // Ask for number of players
            Console.WriteLine("How many players are there ([3] or [4])?");
            string numplayer = Console.ReadLine();

            if (numplayer == "4")
            {
                fullplayer = true;
            }
            else if (numplayer == "3")
            {
                fullplayer = false;
            }
            else
            {
                Console.WriteLine("Error in typo, but I would suggest to set it at default (4 players).");
                Console.WriteLine("If you would like to change back to 3 players, please restart the game.");
                Console.WriteLine("");
                fullplayer = true;
            }

            // Require players' names
            if (fullplayer)
            {
                while (needname)
                {
                    Console.WriteLine("Enter names of the 4 players, separated by a comma:");
                    string input = Console.ReadLine();

                    string[] playerNames = input.Split(',');
                    if (playerNames.Length == 4)
                    {
                        name1 = playerNames[0].Trim();
                        name2 = playerNames[1].Trim();
                        name3 = playerNames[2].Trim();
                        name4 = playerNames[3].Trim();
                        needname = false;
                    }
                    else if (playerNames.Length != 4)
                    {
                        Console.WriteLine("Please enter exactly 4 names and separated by commas.");
                        needname = true;
                        //return;
                    }
                }

                Console.WriteLine($"Welcome players {name1}, {name2}, {name3}, {name4}.");
            }
            else
            {
                while (needname)
                {
                    Console.WriteLine("Enter names of the 3 players, separated by a comma:");
                    string input = Console.ReadLine();

                    string[] playerNames = input.Split(',');
                    if (playerNames.Length == 3)
                    {
                        name1 = playerNames[0].Trim();
                        name2 = playerNames[1].Trim();
                        name3 = playerNames[2].Trim();
                        name4 = "Empty";
                        needname = false;
                    }
                    if (playerNames.Length != 3)
                    {
                        Console.WriteLine("Please enter exactly 3 names and separated by commas.");
                        needname = true;
                        //return;
                    }                    
                }

                Console.WriteLine($"Welcome players {name1}, {name2}, {name3}.");
            }

            // Require markers' prefered color
            bool custcolor;
            Console.WriteLine("Do you want to customize the markers colors? [Y] or [N]");
            string color = Console.ReadLine();
            if (color == "Y" || color == "y")
            {
                custcolor = true;
            }
            else if (color == "N" || color == "n")
            {
                custcolor = false;
            }
            else
            {
                custcolor = false;
                Console.WriteLine("Error in typo. Assume to set at default colorways.");
            }
            string col1 = "1"; string col2 = "2"; string col3 = "3"; string col4 = "4";
            if (custcolor)
            {
                Console.WriteLine("Please select from this list of colorway options:");
                Console.WriteLine("1. Lavender (purple)");
                Console.WriteLine("2. Coral (red)");
                Console.WriteLine("3. Green");
                Console.WriteLine("4. Sand (yellow)");
                Console.WriteLine("5. Pink");
                Console.WriteLine("6. Cornflower (blue)");
                Console.WriteLine("");
                Console.WriteLine("You will have to choose a color ID (required 1 to 6, the name or the color shade).");
                if (fullplayer)
                {
                    bool r1 = false;  bool r2 = false; bool r3 = false; bool r4 = false;
                    while (!r1)
                    {
                        Console.WriteLine($"Which color would you choose, {name1}?");
                        string c1 = Console.ReadLine();
                        c1 = c1.ToLower();
                        if (c1 == "1" || c1 == "lavender" || c1 == "purple") { col1 = "1"; r1 = true; }
                        if (c1 == "2" || c1 == "coral" || c1 == "red") { col1 = "2"; r1 = true; }
                        if (c1 == "3" || c1 == "green") { col1 = "3"; r1 = true; }
                        if (c1 == "4" || c1 == "sand" || c1 == "yellow") { col1 = "4"; r1 = true; }
                        if (c1 == "5" || c1 == "pink") { col1 = "5"; r1 = true; }
                        if (c1 == "6" || c1 == "cornflower" || c1 == "blue") { col1 = "6"; r1 = true; }
                        else if (!(c1 == "1" || c1 == "lavender" || c1 == "purple") && !(c1 == "2" || c1 == "coral" || c1 == "red") && !(c1 == "3" || c1 == "green") && !(c1 == "4" || c1 == "sand" || c1 == "yellow") && !(c1 == "5" || c1 == "pink") && !(c1 == "6" || c1 == "cornflower" || c1 == "blue")) { Console.WriteLine("Invalid typo, try again."); r1 = false; }
                    }
                    while (!r2)
                    {
                        Console.WriteLine($"Which color would you choose, {name2}?");
                        string c2 = Console.ReadLine();
                        c2 = c2.ToLower();
                        if ((c2 == "1" || c2 == "lavender" || c2 == "purple") && col1 != "1") { col2 = "1"; r2 = true; }
                        if ((c2 == "2" || c2 == "coral" || c2 == "red") && col1 != "2") { col2 = "2"; r2 = true; }
                        if ((c2 == "3" || c2 == "green") && col1 != "3") { col2 = "3"; r2 = true; }
                        if ((c2 == "4" || c2 == "sand" || c2 == "yellow") && col1 != "4") { col2 = "4"; r2 = true; }
                        if ((c2 == "5" || c2 == "pink") && col1 != "5") { col2 = "5"; r2 = true; }
                        if ((c2 == "6" || c2 == "cornflower" || c2 == "blue") && col1 != "6") { col2 = "6"; r2 = true; }
                        else if (!((c2 == "1" || c2 == "lavender" || c2 == "purple") && col1 != "1") && !((c2 == "2" || c2 == "coral" || c2 == "red") && col1 != "2") && !((c2 == "3" || c2 == "green") && col1 != "3") && !((c2 == "4" || c2 == "sand" || c2 == "yellow") && col1 != "4") && !((c2 == "5" || c2 == "pink") && col1 != "5") && !((c2 == "6" || c2 == "cornflower" || c2 == "blue") && col1 != "6")) { Console.WriteLine("It is either invalid typo or your color already being picked."); r2 = false; }
                    }
                    while (!r3)
                    {
                        Console.WriteLine($"Which color would you choose, {name3}?");
                        string c3 = Console.ReadLine();
                        c3 = c3.ToLower();
                        if ((c3 == "1" || c3 == "lavender" || c3 == "purple") && col1 != "1" && col2 != "1") { col3 = "1"; r3 = true; }
                        if ((c3 == "2" || c3 == "coral" || c3 == "red") && col1 != "2" && col2 != "2") { col3 = "2"; r3 = true; }
                        if ((c3 == "3" || c3 == "green") && col1 != "3" && col2 != "3") { col3 = "3"; r3 = true; }
                        if ((c3 == "4" || c3 == "sand" || c3 == "yellow") && col1 != "4" && col2 != "4") { col3 = "4"; r3 = true; }
                        if ((c3 == "5" || c3 == "pink") && col1 != "5" && col2 != "5") { col3 = "5"; r3 = true; }
                        if ((c3 == "6" || c3 == "cornflower" || c3 == "blue") && col1 != "6" && col2 != "6") { col3 = "6"; r3 = true; }
                        else if (!((c3 == "1" || c3 == "lavender" || c3 == "purple") && col1 != "1" && col2 != "1") && !((c3 == "2" || c3 == "coral" || c3 == "red") && col1 != "2" && col2 != "2") && !((c3 == "3" || c3 == "green") && col1 != "3" && col2 != "3") && !((c3 == "4" || c3 == "sand" || c3 == "yellow") && col1 != "4" && col2 != "4") && !((c3 == "5" || c3 == "pink") && col1 != "5" && col2 != "5") && !((c3 == "6" || c3 == "cornflower" || c3 == "blue") && col1 != "6" && col2 != "6")) { Console.WriteLine("It is either invalid typo or your color already being picked."); r3 = false; }
                    }
                    while (!r4)
                    {
                        Console.WriteLine($"Which color would you choose, {name4}?");
                        string c4 = Console.ReadLine();
                        c4 = c4.ToLower();
                        if ((c4 == "1" || c4 == "lavender" || c4 == "purple") && col1 != "1" && col2 != "1" && col3 != "1") { col4 = "1"; r4 = true; }
                        if ((c4 == "2" || c4 == "coral" || c4 == "red") && col1 != "2" && col2 != "2" && col3 != "2") { col4 = "2"; r4 = true; }
                        if ((c4 == "3" || c4 == "green") && col1 != "3" && col2 != "3" && col3 != "3") { col4 = "3"; r4 = true; }
                        if ((c4 == "4" || c4 == "sand" || c4 == "yellow") && col1 != "4" && col2 != "4" && col3 != "4") { col4 = "4"; r4 = true; }
                        if ((c4 == "5" || c4 == "pink") && col1 != "5" && col2 != "5" && col3 != "5") { col4 = "5"; r4 = true; }
                        if ((c4 == "6" || c4 == "cornflower" || c4 == "blue") && col1 != "6" && col2 != "6" && col3 != "6") { col4 = "6"; r4 = true; }
                        else if (!((c4 == "1" || c4 == "lavender" || c4 == "purple") && col1 != "1" && col2 != "1" && col3 != "1") && !((c4 == "2" || c4 == "coral" || c4 == "red") && col1 != "2" && col2 != "2" && col3 != "2") && !((c4 == "3" || c4 == "green") && col1 != "3" && col2 != "3" && col3 != "3") && !((c4 == "4" || c4 == "sand" || c4 == "yellow") && col1 != "4" && col2 != "4" && col3 != "4") && !((c4 == "5" || c4 == "pink") && col1 != "5" && col2 != "5" && col3 != "5") && !((c4 == "6" || c4 == "cornflower" || c4 == "blue") && col1 != "6" && col2 != "6" && col3 != "6")) { Console.WriteLine("It is either invalid typo or your color already being picked."); r4 = false; }
                    }
                }
                else if (!fullplayer)
                {
                    bool r1 = false; bool r2 = false; bool r3 = false;
                    while (!r1)
                    {
                        Console.WriteLine($"Which color would you choose, {name1}?");
                        string c1 = Console.ReadLine();
                        c1 = c1.ToLower();
                        if (c1 == "1" || c1 == "lavender" || c1 == "purple") { col1 = "1"; r1 = true; }
                        if (c1 == "2" || c1 == "coral" || c1 == "red") { col1 = "2"; r1 = true; }
                        if (c1 == "3" || c1 == "green") { col1 = "3"; r1 = true; }
                        if (c1 == "4" || c1 == "sand" || c1 == "yellow") { col1 = "4"; r1 = true; }
                        if (c1 == "5" || c1 == "pink") { col1 = "5"; r1 = true; }
                        if (c1 == "6" || c1 == "cornflower" || c1 == "blue") { col1 = "6"; r1 = true; }
                        else if (!(c1 == "1" || c1 == "lavender" || c1 == "purple") && !(c1 == "2" || c1 == "coral" || c1 == "red") && !(c1 == "3" || c1 == "green") && !(c1 == "4" || c1 == "sand" || c1 == "yellow") && !(c1 == "5" || c1 == "pink") && !(c1 == "6" || c1 == "cornflower" || c1 == "blue")) { Console.WriteLine("Invalid typo, try again."); r1 = false; }
                    }
                    while (!r2)
                    {
                        Console.WriteLine($"Which color would you choose, {name2}?");
                        string c2 = Console.ReadLine();
                        c2 = c2.ToLower();
                        if ((c2 == "1" || c2 == "lavender" || c2 == "purple") && col1 != "1") { col2 = "1"; r2 = true; }
                        if ((c2 == "2" || c2 == "coral" || c2 == "red") && col1 != "2") { col2 = "2"; r2 = true; }
                        if ((c2 == "3" || c2 == "green") && col1 != "3") { col2 = "3"; r2 = true; }
                        if ((c2 == "4" || c2 == "sand" || c2 == "yellow") && col1 != "4") { col2 = "4"; r2 = true; }
                        if ((c2 == "5" || c2 == "pink") && col1 != "5") { col2 = "5"; r2 = true; }
                        if ((c2 == "6" || c2 == "cornflower" || c2 == "blue") && col1 != "6") { col2 = "6"; r2 = true; }
                        else if (!((c2 == "1" || c2 == "lavender" || c2 == "purple") && col1 != "1") && !((c2 == "2" || c2 == "coral" || c2 == "red") && col1 != "2") && !((c2 == "3" || c2 == "green") && col1 != "3") && !((c2 == "4" || c2 == "sand" || c2 == "yellow") && col1 != "4") && !((c2 == "5" || c2 == "pink") && col1 != "5") && !((c2 == "6" || c2 == "cornflower" || c2 == "blue") && col1 != "6")) { Console.WriteLine("It is either invalid typo or your color already being picked."); r2 = false; }
                    }
                    while (!r3)
                    {
                        Console.WriteLine($"Which color would you choose, {name3}?");
                        string c3 = Console.ReadLine();
                        c3 = c3.ToLower();
                        if ((c3 == "1" || c3 == "lavender" || c3 == "purple") && col1 != "1" && col2 != "1") { col3 = "1"; r3 = true; }
                        if ((c3 == "2" || c3 == "coral" || c3 == "red") && col1 != "2" && col2 != "2") { col3 = "2"; r3 = true; }
                        if ((c3 == "3" || c3 == "green") && col1 != "3" && col2 != "3") { col3 = "3"; r3 = true; }
                        if ((c3 == "4" || c3 == "sand" || c3 == "yellow") && col1 != "4" && col2 != "4") { col3 = "4"; r3 = true; }
                        if ((c3 == "5" || c3 == "pink") && col1 != "5" && col2 != "5") { col3 = "5"; r3 = true; }
                        if ((c3 == "6" || c3 == "cornflower" || c3 == "blue") && col1 != "6" && col2 != "6") { col3 = "6"; r3 = true; }
                        else if (!((c3 == "1" || c3 == "lavender" || c3 == "purple") && col1 != "1" && col2 != "1") && !((c3 == "2" || c3 == "coral" || c3 == "red") && col1 != "2" && col2 != "2") && !((c3 == "3" || c3 == "green") && col1 != "3" && col2 != "3") && !((c3 == "4" || c3 == "sand" || c3 == "yellow") && col1 != "4" && col2 != "4") && !((c3 == "5" || c3 == "pink") && col1 != "5" && col2 != "5") && !((c3 == "6" || c3 == "cornflower" || c3 == "blue") && col1 != "6" && col2 != "6")) { Console.WriteLine("It is either invalid typo or your color already being picked."); r3 = false; }
                    }
                }
            }
            else if (!custcolor)
            {
                col1 = "1";
                col2 = "2";
                col3 = "3";
                col4 = "4";
            }

            // Toggle Menu for player's color choices
            bool start = true;
            /*if (!start)
            {
                Menu menu = new Menu(460, 200);
                menu.DrawMenu();
            }*/
            if (start)
            {
                Console.WriteLine("Would you like to display ownership variables? [Y] or [N]");
                string dis = Console.ReadLine();

                if (dis == "Y" || dis == "y")
                {
                    display = true;
                }
                else if (dis == "N" || dis == "n")
                {
                    display = false;
                }
                else
                {
                    Console.WriteLine("Error in typo. Would suggest to set at default.");
                    display = true;
                }

                Window gameWindow = new Window("Monopoly", 1000, 600);
                Drawing board = new Drawing();

                Dice dice1 = new Dice();
                Dice dice2 = new Dice();

                Player p1;
                Player p2;
                Player p3;
                Player p4;

                p1 = new Player(name1, "Idle", 100, 0, 0, "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false, "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0);
                p2 = new Player(name2, "Idle", 100, 0, 0, "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false, "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0);
                p3 = new Player(name3, "Idle", 100, 0, 0, "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false, "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0);
                p4 = new Player(name4, "Idle", 100, 0, 0, "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false, "player0", "player0", "player0", "player0", "player0", "player0", 0, 0, 0, 0, 0);

                // Street house number ints
                //int lbbh1 = p1.LBBH; int chh1 = p1.CHH; int qth1 = p1.QTH; int tch1 = p1.TCH; int hvth1 = p1.HVTH; int kvch1 = p1.KVCH; int hvh1 = p1.HVH; int nth1 = p1.NTH; int pnlh1 = p1.PNLH; int vtsh1 = p1.VTSH; int llh1 = p1.LLH; int nhh1 = p1.NHH;
                //int lbbh2 = p2.LBBH; int chh2 = p2.CHH; int qth2 = p2.QTH; int tch2 = p2.TCH; int hvth2 = p2.HVTH; int kvch2 = p2.KVCH; int hvh2 = p2.HVH; int nth2 = p2.NTH; int pnlh2 = p2.PNLH; int vtsh2 = p2.VTSH; int llh2 = p2.LLH; int nhh2 = p2.NHH;
                //int lbbh3 = p3.LBBH; int chh3 = p3.CHH; int qth3 = p3.QTH; int tch3 = p3.TCH; int hvth3 = p3.HVTH; int kvch3 = p3.KVCH; int hvh3 = p3.HVH; int nth3 = p3.NTH; int pnlh3 = p3.PNLH; int vtsh3 = p3.VTSH; int llh3 = p3.LLH; int nhh3 = p3.NHH;
                //int lbbh4 = p4.LBBH; int chh4 = p4.CHH; int qth4 = p4.QTH; int tch4 = p4.TCH; int hvth4 = p4.HVTH; int kvch4 = p4.KVCH; int hvh4 = p4.HVH; int nth4 = p4.NTH; int pnlh4 = p4.PNLH; int vtsh4 = p4.VTSH; int llh4 = p4.LLH; int nhh4 = p4.NHH;

                // Estate total worth ints
                int lbbw1 = p1.LBBW; int chw1 = p1.CHW; int qtw1 = p1.QTW; int tcw1 = p1.TCW; int hvtw1 = p1.HVTW; int kvcw1 = p1.KVCW; int hvw1 = p1.HVW; int ntw1 = p1.NTW; int pnlw1 = p1.PNLW; int vtsw1 = p1.VTSW; int llw1 = p1.LLW; int nhw1 = p1.NHW;
                int lbbw2 = p2.LBBW; int chw2 = p2.CHW; int qtw2 = p2.QTW; int tcw2 = p2.TCW; int hvtw2 = p2.HVTW; int kvcw2 = p2.KVCW; int hvw2 = p2.HVW; int ntw2 = p2.NTW; int pnlw2 = p2.PNLW; int vtsw2 = p2.VTSW; int llw2 = p2.LLW; int nhw2 = p2.NHW;
                int lbbw3 = p3.LBBW; int chw3 = p3.CHW; int qtw3 = p3.QTW; int tcw3 = p3.TCW; int hvtw3 = p3.HVTW; int kvcw3 = p3.KVCW; int hvw3 = p3.HVW; int ntw3 = p3.NTW; int pnlw3 = p3.PNLW; int vtsw3 = p3.VTSW; int llw3 = p3.LLW; int nhw3 = p3.NHW;
                int lbbw4 = p4.LBBW; int chw4 = p4.CHW; int qtw4 = p4.QTW; int tcw4 = p4.TCW; int hvtw4 = p4.HVTW; int kvcw4 = p4.KVCW; int hvw4 = p4.HVW; int ntw4 = p4.NTW; int pnlw4 = p4.PNLW; int vtsw4 = p4.VTSW; int llw4 = p4.LLW; int nhw4 = p4.NHW;


                string stat1 = p1.Status;
                string stat2 = p2.Status;
                string stat3 = p3.Status;
                string stat4 = p4.Status;

                int money1 = p1.Money;
                int money2 = p2.Money;
                int money3 = p3.Money;
                int money4 = p4.Money;

                // Players' marker positional monitoring (x,y)
                int x1 = p1.X, y1 = p1.Y;
                int x2 = p2.X, y2 = p1.Y;
                int x3 = p3.X, y3 = p1.Y;
                int x4 = p4.X, y4 = p1.Y;

                int totDice = 0;

                Console.WriteLine("This is the Monopoly game. Made by Khoa Le, inspired by the famous 'Co Ty Phu' board game.");
                Console.WriteLine("The game is especially made for 3 to 4 players, suitable to play with friends and family.");
                Console.WriteLine("");
                Console.WriteLine("Instruction:");
                Console.WriteLine("Press [SPACE] to change the grid color randomly.");
                Console.WriteLine("Press [I] to see (more) game's Information and Instruction.");
                Console.WriteLine("Press [P] to pause the game.");
                Console.WriteLine("The game contains 4 players, represented as the 4 colored markers.");
                Console.WriteLine("Passing or entering the \"Start\" square to receive $100.");
                Console.WriteLine("");
                Console.WriteLine("Click on the 2 dices to roll your move (or press [Z] and [X] key).");
                Console.WriteLine("Click on the 'Start and Go' squared cell (or press [ENTER] key) to reset dices.");
                Console.WriteLine("");
                Console.WriteLine("You are given $200 initially.");
                Console.WriteLine("");
                Console.WriteLine("Buy and own as many companies and streets (with houses) as you can, with a maximum number of 2 houses.");
                Console.WriteLine("");
                Console.WriteLine("Once you failed below your balance, you can loan the bank some money.");
                Console.WriteLine("Once you owe the bank more than $100, you are set to bankrupcy (and eliminated).");
                Console.WriteLine("Rich players (balance above $500) get taxed by 10 dollars per moves.");
                Console.WriteLine("");
                Console.WriteLine("Once you move to the 'Go to Jail' cell, you are jailed until you draw 2 identical dices or a pair of 1 and 6 dices.");
                Console.WriteLine("");
                Console.WriteLine("Players can sell their estate and buy from other, by verbal agreement - bank loaning is also eligible for buyers. Press [ESC] to fill in the form");
                Console.WriteLine("");

                // Booleans control the dice
                bool alDice1 = false;
                bool alDice2 = false;
                bool resetDice = true;
                bool eqDice = false;
                bool esc = false;

                // Control tax rate
                bool tax = false;

                // Control prisoners
                bool pris1 = false;
                bool pris2 = false;
                bool pris3 = false;
                bool pris4 = false;

                // Control moves accuracy
                bool m1 = false; bool m2 = false; bool m3 = false; bool m4 = false;
                bool am1 = false; bool am2 = false; bool am3 = false; bool am4 = false;
                bool p3o = false;

                // Control number of house variables
                int lbb0 = 0; int ch0 = 0; int qt0 = 0; int tc0 = 0; int hvt0 = 0; int kvc0 = 0; int hv0 = 0; int nt0 = 0; int pnl0 = 0; int vts0 = 0; int ll0 = 0; int nh0 = 0;
                bool occ1 = false; bool occ2 = false; bool occ3 = false; bool occ4 = false; bool occ5 = false; bool occ6 = false; bool occ7 = false; bool occ8 = false; bool occ9 = false; bool occ10 = false; bool occ11 = false; bool occ12 = false;
                bool occ011 = false; bool occ012 = false; bool occ013 = false; bool occ014 = false;
                bool occ021 = false; bool occ022 = false; bool occ023 = false; bool occ024 = false;
                bool occ031 = false; bool occ032 = false; bool occ033 = false; bool occ034 = false;
                bool occ041 = false; bool occ042 = false; bool occ043 = false; bool occ044 = false;
                bool occ051 = false; bool occ052 = false; bool occ053 = false; bool occ054 = false;
                bool occ061 = false; bool occ062 = false; bool occ063 = false; bool occ064 = false;
                bool occ071 = false; bool occ072 = false; bool occ073 = false; bool occ074 = false;
                bool occ081 = false; bool occ082 = false; bool occ083 = false; bool occ084 = false;
                bool occ091 = false; bool occ092 = false; bool occ093 = false; bool occ094 = false;
                bool occ101 = false; bool occ102 = false; bool occ103 = false; bool occ104 = false;
                bool occ111 = false; bool occ112 = false; bool occ113 = false; bool occ114 = false;
                bool occ121 = false; bool occ122 = false; bool occ123 = false; bool occ124 = false;

                while (!gameWindow.CloseRequested)
                {
                    board.DrawBoard(gameWindow);
                    if (fullplayer)
                    {
                        board.DrawPlayersVitals(gameWindow, p1.Name, p2.Name, p3.Name, p4.Name, stat1, stat2, stat3, stat4);
                    }
                    if (!fullplayer)
                    {
                        board.DrawPlayersVitals(gameWindow, p1.Name, p2.Name, p3.Name, "Empty", stat1, stat2, stat3, "Empty");
                    }

                    // Set markers' colorway
                    board.CheckMarkerColor1(col1);
                    board.CheckMarkerColor2(col2);
                    board.CheckMarkerColor3(col3);
                    board.CheckMarkerColor4(col4);

                    // Control number of house accross classes
                    if (p1.LBBH != 0 && !occ1) { occ011 = true; occ1 = true; }
                    if (p2.LBBH != 0 && !occ1) { occ012 = true; occ1 = true; }
                    if (p3.LBBH != 0 && !occ1) { occ013 = true; occ1 = true; }
                    if (p4.LBBH != 0 && !occ1) { occ014 = true; occ1 = true; }
                    if (p1.CHH != 0 && !occ2) { occ021 = true; occ2 = true; }
                    if (p2.CHH != 0 && !occ2) { occ022 = true; occ2 = true; }
                    if (p3.CHH != 0 && !occ2) { occ023 = true; occ2 = true; }
                    if (p4.CHH != 0 && !occ2) { occ024 = true; occ2 = true; }
                    if (p1.QTH != 0 && !occ3) { occ031 = true; occ3 = true; }
                    if (p2.QTH != 0 && !occ3) { occ032 = true; occ3 = true; }
                    if (p3.QTH != 0 && !occ3) { occ033 = true; occ3 = true; }
                    if (p4.QTH != 0 && !occ3) { occ034 = true; occ3 = true; }
                    if (p1.TCH != 0 && !occ4) { occ041 = true; occ4 = true; }
                    if (p2.TCH != 0 && !occ4) { occ042 = true; occ4 = true; }
                    if (p3.TCH != 0 && !occ4) { occ043 = true; occ4 = true; }
                    if (p4.TCH != 0 && !occ4) { occ044 = true; occ4 = true; }
                    if (p1.HVTH != 0 && !occ5) { occ051 = true; occ5 = true; }
                    if (p2.HVTH != 0 && !occ5) { occ052 = true; occ5 = true; }
                    if (p3.HVTH != 0 && !occ5) { occ053 = true; occ5 = true; }
                    if (p4.HVTH != 0 && !occ5) { occ054 = true; occ5 = true; }
                    if (p1.KVCH != 0 && !occ6) { occ061 = true; occ6 = true; }
                    if (p2.KVCH != 0 && !occ6) { occ062 = true; occ6 = true; }
                    if (p3.KVCH != 0 && !occ6) { occ063 = true; occ6 = true; }
                    if (p4.KVCH != 0 && !occ6) { occ064 = true; occ6 = true; }
                    if (p1.HVH != 0 && !occ7) { occ071 = true; occ7 = true; }
                    if (p2.HVH != 0 && !occ7) { occ072 = true; occ7 = true; }
                    if (p3.HVH != 0 && !occ7) { occ073 = true; occ7 = true; }
                    if (p4.HVH != 0 && !occ7) { occ074 = true; occ7 = true; }
                    if (p1.NTH != 0 && !occ8) { occ081 = true; occ8 = true; }
                    if (p2.NTH != 0 && !occ8) { occ082 = true; occ8 = true; }
                    if (p3.NTH != 0 && !occ8) { occ083 = true; occ8 = true; }
                    if (p4.NTH != 0 && !occ8) { occ084 = true; occ8 = true; }
                    if (p1.PNLH != 0 && !occ9) { occ091 = true; occ9 = true; }
                    if (p2.PNLH != 0 && !occ9) { occ092 = true; occ9 = true; }
                    if (p3.PNLH != 0 && !occ9) { occ093 = true; occ9 = true; }
                    if (p4.PNLH != 0 && !occ9) { occ094 = true; occ9 = true; }
                    if (p1.VTSH != 0 && !occ10) { occ101 = true; occ10 = true; }
                    if (p2.VTSH != 0 && !occ10) { occ102 = true; occ10 = true; }
                    if (p3.VTSH != 0 && !occ10) { occ103 = true; occ10 = true; }
                    if (p4.VTSH != 0 && !occ10) { occ104 = true; occ10 = true; }
                    if (p1.LLH != 0 && !occ11) { occ111 = true; occ11 = true; }
                    if (p2.LLH != 0 && !occ11) { occ112 = true; occ11 = true; }
                    if (p3.LLH != 0 && !occ11) { occ113 = true; occ11 = true; }
                    if (p4.LLH != 0 && !occ11) { occ114 = true; occ11 = true; }
                    if (p1.NHH != 0 && !occ12) { occ121 = true; occ12 = true; }
                    if (p2.NHH != 0 && !occ12) { occ122 = true; occ12 = true; }
                    if (p3.NHH != 0 && !occ12) { occ123 = true; occ12 = true; }
                    if (p4.NHH != 0 && !occ12) { occ124 = true; occ12 = true; }
                    if (occ011) { p2.LBBH = p1.LBBH; p3.LBBH = p1.LBBH; p4.LBBH = p1.LBBH; lbb0 = p1.LBBH; }
                    if (occ012) { p1.LBBH = p2.LBBH; p3.LBBH = p2.LBBH; p4.LBBH = p2.LBBH; lbb0 = p2.LBBH; }
                    if (occ013) { p1.LBBH = p3.LBBH; p2.LBBH = p3.LBBH; p4.LBBH = p3.LBBH; lbb0 = p3.LBBH; }
                    if (occ014) { p1.LBBH = p4.LBBH; p2.LBBH = p4.LBBH; p3.LBBH = p4.LBBH; lbb0 = p4.LBBH; }
                    if (occ021) { p2.CHH = p1.CHH; p3.CHH = p1.CHH; p4.CHH = p1.CHH; ch0 = p1.CHH; }
                    if (occ022) { p1.CHH = p2.CHH; p3.CHH = p2.CHH; p4.CHH = p2.CHH; ch0 = p2.CHH; }
                    if (occ023) { p1.CHH = p3.CHH; p2.CHH = p3.CHH; p4.CHH = p3.CHH; ch0 = p3.CHH; }
                    if (occ024) { p1.CHH = p4.CHH; p2.CHH = p4.CHH; p3.CHH = p4.CHH; ch0 = p4.CHH; }
                    if (occ031) { p2.QTH = p1.QTH; p3.QTH = p1.QTH; p4.QTH = p1.QTH; qt0 = p1.QTH; }
                    if (occ032) { p1.QTH = p2.QTH; p3.QTH = p2.QTH; p4.QTH = p2.QTH; qt0 = p2.QTH; }
                    if (occ033) { p1.QTH = p3.QTH; p2.QTH = p3.QTH; p4.QTH = p3.QTH; qt0 = p3.QTH; }
                    if (occ034) { p1.QTH = p4.QTH; p2.QTH = p4.QTH; p3.QTH = p4.QTH; qt0 = p4.QTH; }
                    if (occ041) { p2.TCH = p1.TCH; p3.TCH = p1.TCH; p4.TCH = p1.TCH; tc0 = p1.TCH; }
                    if (occ042) { p1.TCH = p2.TCH; p3.TCH = p2.TCH; p4.TCH = p2.TCH; tc0 = p2.TCH; }
                    if (occ043) { p1.TCH = p3.TCH; p2.TCH = p3.TCH; p4.TCH = p3.TCH; tc0 = p3.TCH; }
                    if (occ044) { p1.TCH = p4.TCH; p2.TCH = p4.TCH; p3.TCH = p4.TCH; tc0 = p4.TCH; }
                    if (occ051) { p2.HVTH = p1.HVTH; p3.HVTH = p1.HVTH; p4.HVTH = p1.HVTH; hvt0 = p1.HVTH; }
                    if (occ052) { p1.HVTH = p2.HVTH; p3.HVTH = p2.HVTH; p4.HVTH = p2.HVTH; hvt0 = p2.HVTH; }
                    if (occ053) { p1.HVTH = p3.HVTH; p2.HVTH = p3.HVTH; p4.HVTH = p3.HVTH; hvt0 = p3.HVTH; }
                    if (occ054) { p1.HVTH = p4.HVTH; p2.HVTH = p4.HVTH; p3.HVTH = p4.HVTH; hvt0 = p4.HVTH; }
                    if (occ061) { p2.KVCH = p1.KVCH; p3.KVCH = p1.KVCH; p4.KVCH = p1.KVCH; kvc0 = p1.KVCH; }
                    if (occ062) { p1.KVCH = p2.KVCH; p3.KVCH = p2.KVCH; p4.KVCH = p2.KVCH; kvc0 = p2.KVCH; }
                    if (occ063) { p1.KVCH = p3.KVCH; p2.KVCH = p3.KVCH; p4.KVCH = p3.KVCH; kvc0 = p3.KVCH; }
                    if (occ064) { p1.KVCH = p4.KVCH; p2.KVCH = p4.KVCH; p3.KVCH = p4.KVCH; kvc0 = p4.KVCH; }
                    if (occ071) { p2.HVH = p1.HVH; p3.HVH = p1.HVH; p4.HVH = p1.HVH; hv0 = p1.HVH; }
                    if (occ072) { p1.HVH = p2.HVH; p3.HVH = p2.HVH; p4.HVH = p2.HVH; hv0 = p2.HVH; }
                    if (occ073) { p1.HVH = p3.HVH; p2.HVH = p3.HVH; p4.HVH = p3.HVH; hv0 = p3.HVH; }
                    if (occ074) { p1.HVH = p4.HVH; p2.HVH = p4.HVH; p3.HVH = p4.HVH; hv0 = p4.HVH; }
                    if (occ081) { p2.NTH = p1.NTH; p3.NTH = p1.NTH; p4.NTH = p1.NTH; nt0 = p1.NTH; }
                    if (occ082) { p1.NTH = p2.NTH; p3.NTH = p2.NTH; p4.NTH = p2.NTH; nt0 = p2.NTH; }
                    if (occ083) { p1.NTH = p3.NTH; p2.NTH = p3.NTH; p4.NTH = p3.NTH; nt0 = p3.NTH; }
                    if (occ084) { p1.NTH = p4.NTH; p2.NTH = p4.NTH; p3.NTH = p4.NTH; nt0 = p4.NTH; }
                    if (occ091) { p2.PNLH = p1.PNLH; p3.PNLH = p1.PNLH; p4.PNLH = p1.PNLH; pnl0 = p1.PNLH; }
                    if (occ092) { p1.PNLH = p2.PNLH; p3.PNLH = p2.PNLH; p4.PNLH = p2.PNLH; pnl0 = p2.PNLH; }
                    if (occ093) { p1.PNLH = p3.PNLH; p2.PNLH = p3.PNLH; p4.PNLH = p3.PNLH; pnl0 = p3.PNLH; }
                    if (occ094) { p1.PNLH = p4.PNLH; p2.PNLH = p4.PNLH; p3.PNLH = p4.PNLH; pnl0 = p4.PNLH; }
                    if (occ101) { p2.VTSH = p1.VTSH; p3.VTSH = p1.VTSH; p4.VTSH = p1.VTSH; vts0 = p1.VTSH; }
                    if (occ102) { p1.VTSH = p2.VTSH; p3.VTSH = p2.VTSH; p4.VTSH = p2.VTSH; vts0 = p2.VTSH; }
                    if (occ103) { p1.VTSH = p3.VTSH; p2.VTSH = p3.VTSH; p4.VTSH = p3.VTSH; vts0 = p3.VTSH; }
                    if (occ104) { p1.VTSH = p4.VTSH; p2.VTSH = p4.VTSH; p3.VTSH = p4.VTSH; vts0 = p4.VTSH; }
                    if (occ111) { p2.LLH = p1.LLH; p3.LLH = p1.LLH; p4.LLH = p1.LLH; ll0 = p1.LLH; }
                    if (occ112) { p1.LLH = p2.LLH; p3.LLH = p2.LLH; p4.LLH = p2.LLH; ll0 = p2.LLH; }
                    if (occ113) { p1.LLH = p3.LLH; p2.LLH = p3.LLH; p4.LLH = p3.LLH; ll0 = p3.LLH; }
                    if (occ114) { p1.LLH = p4.LLH; p2.LLH = p4.LLH; p3.LLH = p4.LLH; ll0 = p4.LLH; }
                    if (occ121) { p2.NHH = p1.NHH; p3.NHH = p1.NHH; p4.NHH = p1.NHH; nh0 = p1.NHH; }
                    if (occ122) { p1.NHH = p2.NHH; p3.NHH = p2.NHH; p4.NHH = p2.NHH; nh0 = p2.NHH; }
                    if (occ123) { p1.NHH = p3.NHH; p2.NHH = p3.NHH; p4.NHH = p3.NHH; nh0 = p3.NHH; }
                    if (occ124) { p1.NHH = p4.NHH; p2.NHH = p4.NHH; p3.NHH = p4.NHH; nh0 = p4.NHH; }

                    if (display)
                    {
                        //board.DrawStreet(p1.LBB, p1.CH, p1.QT, p1.TC, p1.HVT, p1.KVC, p1.HV, p1.NT, p1.PNL, p1.VTS, p1.LL, p1.NH, p1.LBBH, p1.CHH, p1.QTH, p1.TCH, p1.HVTH, p1.KVCH, p1.HVH, p1.NTH, p1.PNLH, p1.VTSH, p1.LLH, p1.NHH);
                        board.DrawStreet(p1.LBB, p1.CH, p1.QT, p1.TC, p1.HVT, p1.KVC, p1.HV, p1.NT, p1.PNL, p1.VTS, p1.LL, p1.NH, lbb0, ch0, qt0, tc0, hvt0, kvc0, hv0, nt0, pnl0, vts0, ll0, nh0);
                        board.DrawCom(p1.BXCG, p1.BXCL, p1.BXMD, p1.BXMT, p1.CTDL, p1.CTCN);
                        board.DrawPlayerPosition(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, p4.X, p4.Y);
                    }
                    else if (!display)
                    {
                        //board.DrawPlayerPosition(0, 0, 0, 0, 0, 0, 0, 0);
                        board.NoPosition();
                    }

                    // Draw markers
                    board.DrawP1(p1.X, p1.Y, money1, p1.Status);
                    board.DrawP2(p2.X, p2.Y, money2, p2.Status);
                    board.DrawP3(p3.X, p3.Y, money3, p3.Status);
                    if (fullplayer)
                    {
                        board.DrawP4(p4.X, p4.Y, money4, p4.Status);
                    }

                    // Display the players' bank (money) balance
                    if (fullplayer)
                    {
                        board.DrawMoney(p1.Money, p2.Money, p3.Money, p4.Money);
                    }
                    else if (!fullplayer)
                    {
                        board.DrawMoney(p1.Money, p2.Money, p3.Money, 0);
                    }

                    // Check if player(s) go to jail
                    p1.Jailed(p1.X, p1.Y, p1.Prisoned, p1.EQDice);
                    p2.Jailed(p2.X, p2.Y, p2.Prisoned, p2.EQDice);
                    p3.Jailed(p3.X, p3.Y, p3.Prisoned, p3.EQDice);
                    p4.Jailed(p4.X, p4.Y, p4.Prisoned, p4.EQDice);

                    // Control street occupation accross classes
                    if (p1.LBB == "player1")
                    {
                        p2.LBB = "player1"; p3.LBB = "player1"; p4.LBB = "player1";
                    }
                    if (p2.LBB == "player2")
                    {
                        p1.LBB = "player2"; p3.LBB = "player2"; p4.LBB = "player2";
                    }
                    if (p3.LBB == "player3")
                    {
                        p1.LBB = "player3"; p2.LBB = "player3"; p4.LBB = "player3";
                    }
                    if (p4.LBB == "player4")
                    {
                        p1.LBB = "player4"; p2.LBB = "player4"; p3.LBB = "player4";
                    }
                    if (p1.CH == "player1")
                    {
                        p2.CH = "player1"; p3.CH = "player1"; p4.CH = "player1";
                    }
                    if (p2.CH == "player2")
                    {
                        p1.CH = "player2"; p3.CH = "player2"; p4.CH = "player2";
                    }
                    if (p3.CH == "player3")
                    {
                        p1.CH = "player3"; p2.CH = "player3"; p4.CH = "player3";
                    }
                    if (p4.CH == "player4")
                    {
                        p1.CH = "player4"; p2.CH = "player4"; p3.CH = "player4";
                    }
                    if (p1.QT == "player1")
                    {
                        p2.QT = "player1"; p3.QT = "player1"; p4.QT = "player1";
                    }
                    if (p2.QT == "player2")
                    {
                        p1.QT = "player2"; p3.QT = "player2"; p4.QT = "player2";
                    }
                    if (p3.QT == "player3")
                    {
                        p1.QT = "player3"; p2.QT = "player3"; p4.QT = "player3";
                    }
                    if (p4.QT == "player4")
                    {
                        p1.QT = "player4"; p2.QT = "player4"; p3.QT = "player4";
                    }
                    if (p1.TC == "player1")
                    {
                        p2.TC = "player1"; p3.TC = "player1"; p4.TC = "player1";
                    }
                    if (p2.TC == "player2")
                    {
                        p1.TC = "player2"; p3.TC = "player2"; p4.TC = "player2";
                    }
                    if (p3.TC == "player3")
                    {
                        p1.TC = "player3"; p2.TC = "player3"; p4.TC = "player3";
                    }
                    if (p4.TC == "player4")
                    {
                        p1.TC = "player4"; p2.TC = "player4"; p3.TC = "player4";
                    }
                    if (p1.HVT == "player1")
                    {
                        p2.HVT = "player1"; p3.HVT = "player1"; p4.HVT = "player1";
                    }
                    if (p2.HVT == "player2")
                    {
                        p1.HVT = "player2"; p3.HVT = "player2"; p4.HVT = "player2";
                    }
                    if (p3.HVT == "player3")
                    {
                        p1.HVT = "player3"; p2.HVT = "player3"; p4.HVT = "player3";
                    }
                    if (p4.HVT == "player4")
                    {
                        p1.HVT = "player4"; p2.HVT = "player4"; p3.HVT = "player4";
                    }
                    if (p1.KVC == "player1")
                    {
                        p2.KVC = "player1"; p3.KVC = "player1"; p4.KVC = "player1";
                    }
                    if (p2.KVC == "player2")
                    {
                        p1.KVC = "player2"; p3.KVC = "player2"; p4.KVC = "player2";
                    }
                    if (p3.KVC == "player3")
                    {
                        p1.KVC = "player3"; p2.KVC = "player3"; p4.KVC = "player3";
                    }
                    if (p4.KVC == "player4")
                    {
                        p1.KVC = "player4"; p2.KVC = "player4"; p3.KVC = "player4";
                    }
                    if (p1.HV == "player1")
                    {
                        p2.HV = "player1"; p3.HV = "player1"; p4.HV = "player1";
                    }
                    if (p2.HV == "player2")
                    {
                        p1.HV = "player2"; p3.HV = "player2"; p4.HV = "player2";
                    }
                    if (p3.HV == "player3")
                    {
                        p1.HV = "player3"; p2.HV = "player3"; p4.HV = "player3";
                    }
                    if (p4.HV == "player4")
                    {
                        p1.HV = "player4"; p2.HV = "player4"; p3.HV = "player4";
                    }
                    if (p1.NT == "player1")
                    {
                        p2.NT = "player1"; p3.NT = "player1"; p4.NT = "player1";
                    }
                    if (p2.NT == "player2")
                    {
                        p1.NT = "player2"; p3.NT = "player2"; p4.NT = "player2";
                    }
                    if (p3.NT == "player3")
                    {
                        p1.NT = "player3"; p2.NT = "player3"; p4.NT = "player3";
                    }
                    if (p4.NT == "player4")
                    {
                        p1.NT = "player4"; p2.NT = "player4"; p3.NT = "player4";
                    }
                    if (p1.PNL == "player1")
                    {
                        p2.PNL = "player1"; p3.PNL = "player1"; p4.PNL = "player1";
                    }
                    if (p2.PNL == "player2")
                    {
                        p1.PNL = "player2"; p3.PNL = "player2"; p4.PNL = "player2";
                    }
                    if (p3.PNL == "player3")
                    {
                        p1.PNL = "player3"; p2.PNL = "player3"; p4.PNL = "player3";
                    }
                    if (p4.PNL == "player4")
                    {
                        p1.PNL = "player4"; p2.PNL = "player4"; p3.PNL = "player4";
                    }
                    if (p1.VTS == "player1")
                    {
                        p2.VTS = "player1"; p3.VTS = "player1"; p4.VTS = "player1";
                    }
                    if (p2.VTS == "player2")
                    {
                        p1.VTS = "player2"; p3.VTS = "player2"; p4.VTS = "player2";
                    }
                    if (p3.VTS == "player3")
                    {
                        p1.VTS = "player3"; p2.VTS = "player3"; p4.VTS = "player3";
                    }
                    if (p4.VTS == "player4")
                    {
                        p1.VTS = "player4"; p2.VTS = "player4"; p3.VTS = "player4";
                    }
                    if (p1.LL == "player1")
                    {
                        p2.LL = "player1"; p3.LL = "player1"; p4.LL = "player1";
                    }
                    if (p2.LL == "player2")
                    {
                        p1.LL = "player2"; p3.LL = "player2"; p4.LL = "player2";
                    }
                    if (p3.LL == "player3")
                    {
                        p1.LL = "player3"; p2.LL = "player3"; p4.LL = "player3";
                    }
                    if (p4.LL == "player4")
                    {
                        p1.LL = "player4"; p2.LL = "player4"; p3.LL = "player4";
                    }
                    if (p1.NH == "player1")
                    {
                        p2.NH = "player1"; p3.NH = "player1"; p4.NH = "player1";
                    }
                    if (p2.NH == "player2")
                    {
                        p1.NH = "player2"; p3.NH = "player2"; p4.NH = "player2";
                    }
                    if (p3.NH == "player3")
                    {
                        p1.NH = "player3"; p2.NH = "player3"; p4.NH = "player3";
                    }
                    if (p4.NH == "player4")
                    {
                        p1.NH = "player4"; p2.NH = "player4"; p3.NH = "player4";
                    }

                    // Control company ownership accross classes
                    if (p1.BXCG == "player1")
                    {
                        p2.BXCG = "player1"; p3.BXCG = "player1"; p4.BXCG = "player1";
                    }
                    if (p2.BXCG == "player2")
                    {
                        p1.BXCG = "player2"; p3.BXCG = "player2"; p4.BXCG = "player2";
                    }
                    if (p3.BXCG == "player3")
                    {
                        p1.BXCG = "player3"; p2.BXCG = "player3"; p4.BXCG = "player3";
                    }
                    if (p4.BXCG == "player4")
                    {
                        p1.BXCG = "player4"; p2.BXCG = "player4"; p3.BXCG = "player4";
                    }
                    if (p1.BXCL == "player1")
                    {
                        p2.BXCL = "player1"; p3.BXCL = "player1"; p4.BXCL = "player1";
                    }
                    if (p2.BXCL == "player2")
                    {
                        p1.BXCL = "player2"; p3.BXCL = "player2"; p4.BXCL = "player2";
                    }
                    if (p3.BXCL == "player3")
                    {
                        p1.BXCL = "player3"; p2.BXCL = "player3"; p4.BXCL = "player3";
                    }
                    if (p4.BXCL == "player4")
                    {
                        p1.BXCL = "player4"; p2.BXCL = "player4"; p3.BXCL = "player4";
                    }
                    if (p1.BXMD == "player1")
                    {
                        p2.BXMD = "player1"; p3.BXMD = "player1"; p4.BXMD = "player1";
                    }
                    if (p2.BXMD == "player2")
                    {
                        p1.BXMD = "player2"; p3.BXMD = "player2"; p4.BXMD = "player2";
                    }
                    if (p3.BXMD == "player3")
                    {
                        p1.BXMD = "player3"; p2.BXMD = "player3"; p4.BXMD = "player3";
                    }
                    if (p4.BXMD == "player4")
                    {
                        p1.BXMD = "player4"; p2.BXMD = "player4"; p3.BXMD = "player4";
                    }
                    if (p1.BXMT == "player1")
                    {
                        p2.BXMT = "player1"; p3.BXMT = "player1"; p4.BXMT = "player1";
                    }
                    if (p2.BXMT == "player2")
                    {
                        p1.BXMT = "player2"; p3.BXMT = "player2"; p4.BXMT = "player2";
                    }
                    if (p3.BXMT == "player3")
                    {
                        p1.BXMT = "player3"; p2.BXMT = "player3"; p4.BXMT = "player3";
                    }
                    if (p4.BXMT == "player4")
                    {
                        p1.BXMT = "player4"; p2.BXMT = "player4"; p3.BXMT = "player4";
                    }
                    if (p1.CTDL == "player1")
                    {
                        p2.CTDL = "player1"; p3.CTDL = "player1"; p4.CTDL = "player1";
                    }
                    if (p2.CTDL == "player2")
                    {
                        p1.CTDL = "player2"; p3.CTDL = "player2"; p4.CTDL = "player2";
                    }
                    if (p3.CTDL == "player3")
                    {
                        p1.CTDL = "player3"; p2.CTDL = "player3"; p4.CTDL = "player3";
                    }
                    if (p4.CTDL == "player4")
                    {
                        p1.CTDL = "player4"; p2.CTDL = "player4"; p3.CTDL = "player4";
                    }
                    if (p1.CTCN == "player1")
                    {
                        p2.CTCN = "player1"; p3.CTCN = "player1"; p4.CTCN = "player1";
                    }
                    if (p2.CTCN == "player2")
                    {
                        p1.CTCN = "player2"; p3.CTCN = "player2"; p4.CTCN = "player2";
                    }
                    if (p3.CTCN == "player3")
                    {
                        p1.CTCN = "player3"; p2.CTCN = "player3"; p4.CTCN = "player3";
                    }
                    if (p4.CTCN == "player4")
                    {
                        p1.CTCN = "player4"; p2.CTCN = "player4"; p3.CTCN = "player4";
                    }

                    // Roll dice
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        // Check if Dice 1 is clicked
                        if (resetDice && !alDice1 && IsMouseInRectangle(SplashKit.MousePosition(), 430, 420, 50, 50))
                        {
                            dice1.RollDice();
                            alDice1 = true;
                        }

                        // Check if Dice 2 is clicked
                        if (resetDice && !alDice2 && IsMouseInRectangle(SplashKit.MousePosition(), 518, 420, 50, 50))
                        {
                            dice2.RollDice();
                            alDice2 = true;
                        }
                    }
                    else if (resetDice && (!alDice1 || !alDice2))
                    {
                        if (SplashKit.KeyTyped(KeyCode.ZKey))
                        {
                            dice1.RollDice();
                            alDice1 = true;
                        }
                        else if (SplashKit.KeyTyped(KeyCode.XKey))
                        {
                            dice2.RollDice();
                            alDice2 = true;
                        }
                    }

                    // Reset dices
                    if (alDice1 && alDice2)
                    {
                        resetDice = false;
                    }

                    // Total dices value
                    if (dice1.DiceValue1 == 0 || dice2.DiceValue2 == 0)
                    {
                        totDice = 0;
                    }
                    if (dice1.DiceValue1 > 0 && dice2.DiceValue2 > 0)
                    {
                        totDice = dice1.DiceValue1 + dice2.DiceValue2;
                    }

                    // Switch player's move
                    switch (p_turn)
                    {
                        case 1:
                            if (!p1.Prisoned && !m1)
                            {
                                p1.EQDice = false;

                                if (p1.Money >= 0)
                                {
                                    stat1 = "on Turn";
                                    stat2 = "Idle";
                                    stat3 = "Idle";
                                    stat4 = "Idle";
                                    p1.Move(p1.Name, totDice, x1, y1, p1.Money);
                                    p1.P1RE(p1.Money, p1.X, p1.Y, p1.LBB, p1.CH, p1.QT, p1.TC, p1.HVT, p1.KVC, p1.HV, p1.NT, p1.PNL, p1.VTS, p1.LL, p1.NH, p1.LBBH, p1.CHH, p1.QTH, p1.TCH, p1.HVTH, p1.KVCH, p1.HVH, p1.NTH, p1.PNLH, p1.VTSH, p1.LLH, p1.NHH, p1.LBBW, p1.CHW, p1.QTW, p1.TCW, p1.HVTW, p1.KVCW, p1.HVW, p1.NTW, p1.PNLW, p1.VTSW, p1.LLW, p1.NHW, p1.P1M, p1.P2M, p1.P3M, p1.P4M);
                                    p1.P1SC(p1.Money, p1.X, p1.Y, p1.BXCG, p1.BXCL, p1.BXMD, p1.BXMT, p1.CTDL, p1.CTCN, p1.P1M, p1.P2M, p1.P3M, p1.P4M);
                                    if (p1.Money < 500)
                                    {
                                        tax = false;
                                    }
                                }
                                if (p1.Money >= 500) // Taxing rich players
                                {
                                    if (!tax)
                                    {
                                        p1.Money = p1.Money - 10;
                                        tax = true;
                                    }
                                }
                                else if (p1.Money < 0 && p1.Money >= -100) // Pay the bank interest
                                {
                                    stat1 = "on Turn";
                                    stat2 = "Idle";
                                    stat3 = "Idle";
                                    stat4 = "Idle";
                                    p1.Move(p1.Name, totDice, x1, y1, p1.Money);
                                    p1.P1RE(p1.Money, p1.X, p1.Y, p1.LBB, p1.CH, p1.QT, p1.TC, p1.HVT, p1.KVC, p1.HV, p1.NT, p1.PNL, p1.VTS, p1.LL, p1.NH, p1.LBBH, p1.CHH, p1.QTH, p1.TCH, p1.HVTH, p1.KVCH, p1.HVH, p1.NTH, p1.PNLH, p1.VTSH, p1.LLH, p1.NHH, p1.LBBW, p1.CHW, p1.QTW, p1.TCW, p1.HVTW, p1.KVCW, p1.HVW, p1.NTW, p1.PNLW, p1.VTSW, p1.LLW, p1.NHW, p1.P1M, p1.P2M, p1.P3M, p1.P4M);
                                    p1.P1SC(p1.Money, p1.X, p1.Y, p1.BXCG, p1.BXCL, p1.BXMD, p1.BXMT, p1.CTDL, p1.CTCN, p1.P1M, p1.P2M, p1.P3M, p1.P4M);
                                    if (!tax)
                                    {
                                        p1.Money = p1.Money - 5;
                                        tax = true;
                                    }
                                }
                                else if (p1.Money < -100)
                                {
                                    stat1 = "Bankrupt";
                                    stat2 = "Idle";
                                    stat3 = "Idle";
                                    stat4 = "Idle";
                                    resetDice = false;
                                    tax = false;
                                }
                            }
                            else if (p1.Prisoned && !m1)
                            {
                                stat1 = "Jailed";
                                stat2 = "Idle";
                                stat3 = "Idle";
                                stat4 = "Idle";
                                tax = false;
                                if (!pris1 && ((dice1.DiceValue1 == 1 && dice2.DiceValue2 == 1) || (dice1.DiceValue1 == 2 && dice2.DiceValue2 == 2) || (dice1.DiceValue1 == 3 && dice2.DiceValue2 == 3) || (dice1.DiceValue1 == 4 && dice2.DiceValue2 == 4) || (dice1.DiceValue1 == 5 && dice2.DiceValue2 == 5) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 1 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 1)))
                                {
                                    p1.EQDice = true;
                                    p1.Prisoned = false;
                                    Console.WriteLine($"{p1.Name} is set free.");
                                    p1.Move(p1.Name, totDice, x1, y1, p1.Money);
                                    p1.P1RE(p1.Money, p1.X, p1.Y, p1.LBB, p1.CH, p1.QT, p1.TC, p1.HVT, p1.KVC, p1.HV, p1.NT, p1.PNL, p1.VTS, p1.LL, p1.NH, p1.LBBH, p1.CHH, p1.QTH, p1.TCH, p1.HVTH, p1.KVCH, p1.HVH, p1.NTH, p1.PNLH, p1.VTSH, p1.LLH, p1.NHH, p1.LBBW, p1.CHW, p1.QTW, p1.TCW, p1.HVTW, p1.KVCW, p1.HVW, p1.NTW, p1.PNLW, p1.VTSW, p1.LLW, p1.NHW, p1.P1M, p1.P2M, p1.P3M, p1.P4M);
                                    p1.P1SC(p1.Money, p1.X, p1.Y, p1.BXCG, p1.BXCL, p1.BXMD, p1.BXMT, p1.CTDL, p1.CTCN, p1.P1M, p1.P2M, p1.P3M, p1.P4M);
                                    pris1 = true;
                                }
                                else { p1.EQDice = false; }
                            }
                            break;

                        case 2:
                            if (!p2.Prisoned && !m2)
                            {
                                p2.EQDice = false;

                                if (p2.Money >= 0)
                                {
                                    stat1 = "Idle";
                                    stat2 = "on Turn";
                                    stat3 = "Idle";
                                    stat4 = "Idle";
                                    p2.Move(p2.Name, totDice, x2, y2, p2.Money);
                                    p2.P2RE(p2.Money, p2.X, p2.Y, p2.LBB, p2.CH, p2.QT, p2.TC, p2.HVT, p2.KVC, p2.HV, p2.NT, p2.PNL, p2.VTS, p2.LL, p2.NH, p2.LBBH, p2.CHH, p2.QTH, p2.TCH, p2.HVTH, p2.KVCH, p2.HVH, p2.NTH, p2.PNLH, p2.VTSH, p2.LLH, p2.NHH, p2.LBBW, p2.CHW, p2.QTW, p2.TCW, p2.HVTW, p2.KVCW, p2.HVW, p2.NTW, p2.PNLW, p2.VTSW, p2.LLW, p2.NHW, p2.P1M, p2.P2M, p2.P3M, p2.P4M);
                                    p2.P2SC(p2.Money, p2.X, p2.Y, p2.BXCG, p2.BXCL, p2.BXMD, p2.BXMT, p2.CTDL, p2.CTCN, p2.P1M, p2.P2M, p2.P3M, p2.P4M);
                                    if (p2.Money < 500)
                                    {
                                        tax = false;
                                    }
                                }
                                if (p2.Money >= 500) // Taxing rich players
                                {
                                    if (!tax)
                                    {
                                        p2.Money = p2.Money - 10;
                                        tax = true;
                                    }
                                }
                                else if (p2.Money < 0 && p2.Money >= -100) // Pay the bank interest
                                {
                                    stat1 = "Idle";
                                    stat2 = "on Turn";
                                    stat3 = "Idle";
                                    stat4 = "Idle";
                                    p2.Move(p2.Name, totDice, x2, y2, p2.Money);
                                    p2.P2RE(p2.Money, p2.X, p2.Y, p2.LBB, p2.CH, p2.QT, p2.TC, p2.HVT, p2.KVC, p2.HV, p2.NT, p2.PNL, p2.VTS, p2.LL, p2.NH, p2.LBBH, p2.CHH, p2.QTH, p2.TCH, p2.HVTH, p2.KVCH, p2.HVH, p2.NTH, p2.PNLH, p2.VTSH, p2.LLH, p2.NHH, p2.LBBW, p2.CHW, p2.QTW, p2.TCW, p2.HVTW, p2.KVCW, p2.HVW, p2.NTW, p2.PNLW, p2.VTSW, p2.LLW, p2.NHW, p2.P1M, p2.P2M, p2.P3M, p2.P4M);
                                    p2.P2SC(p2.Money, p2.X, p2.Y, p2.BXCG, p2.BXCL, p2.BXMD, p2.BXMT, p2.CTDL, p2.CTCN, p2.P1M, p2.P2M, p2.P3M, p2.P4M);
                                    if (!tax)
                                    {
                                        p2.Money = p2.Money - 5;
                                        tax = true;
                                    }
                                }
                                else if (p2.Money < -100)
                                {
                                    stat1 = "Idle";
                                    stat2 = "Bankrupt";
                                    stat3 = "Idle";
                                    stat4 = "Idle";
                                    resetDice = false;
                                    tax = false;
                                }
                            }
                            if (p2.Prisoned && !m2)
                            {
                                stat1 = "Idle";
                                stat2 = "Jailed";
                                stat3 = "Idle";
                                stat4 = "Idle";
                                tax = false;
                                if (!pris2 && ((dice1.DiceValue1 == 1 && dice2.DiceValue2 == 1) || (dice1.DiceValue1 == 2 && dice2.DiceValue2 == 2) || (dice1.DiceValue1 == 3 && dice2.DiceValue2 == 3) || (dice1.DiceValue1 == 4 && dice2.DiceValue2 == 4) || (dice1.DiceValue1 == 5 && dice2.DiceValue2 == 5) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 1 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 1)))
                                {
                                    p2.EQDice = true;
                                    p2.Prisoned = false;
                                    Console.WriteLine($"{p2.Name} is set free.");
                                    p2.Move(p2.Name, totDice, x2, y2, p2.Money);
                                    p2.P2RE(p2.Money, p2.X, p2.Y, p2.LBB, p2.CH, p2.QT, p2.TC, p2.HVT, p2.KVC, p2.HV, p2.NT, p2.PNL, p2.VTS, p2.LL, p2.NH, p2.LBBH, p2.CHH, p2.QTH, p2.TCH, p2.HVTH, p2.KVCH, p2.HVH, p2.NTH, p2.PNLH, p2.VTSH, p2.LLH, p2.NHH, p2.LBBW, p2.CHW, p2.QTW, p2.TCW, p2.HVTW, p2.KVCW, p2.HVW, p2.NTW, p2.PNLW, p2.VTSW, p2.LLW, p2.NHW, p2.P1M, p2.P2M, p2.P3M, p2.P4M);
                                    p2.P2SC(p2.Money, p2.X, p2.Y, p2.BXCG, p2.BXCL, p2.BXMD, p2.BXMT, p2.CTDL, p2.CTCN, p2.P1M, p2.P2M, p2.P3M, p2.P4M);
                                    pris2 = true;
                                }
                                else { p2.EQDice = false; }
                            }
                            break;

                        case 3:
                            if (!p3.Prisoned && !m3)
                            {
                                p3.EQDice = false;

                                if (p3.Money >= 0)
                                {
                                    stat1 = "Idle";
                                    stat2 = "Idle";
                                    stat3 = "on Turn";
                                    stat4 = "Idle";
                                    p3.Move(p3.Name, totDice, x3, y3, p3.Money);
                                    p3.P3RE(p3.Money, p3.X, p3.Y, p3.LBB, p3.CH, p3.QT, p3.TC, p3.HVT, p3.KVC, p3.HV, p3.NT, p3.PNL, p3.VTS, p3.LL, p3.NH, p3.LBBH, p3.CHH, p3.QTH, p3.TCH, p3.HVTH, p3.KVCH, p3.HVH, p3.NTH, p3.PNLH, p3.VTSH, p3.LLH, p3.NHH, p3.LBBW, p3.CHW, p3.QTW, p3.TCW, p3.HVTW, p3.KVCW, p3.HVW, p3.NTW, p3.PNLW, p3.VTSW, p3.LLW, p3.NHW, p3.P1M, p3.P2M, p3.P3M, p3.P4M);
                                    p3.P3SC(p3.Money, p3.X, p3.Y, p3.BXCG, p3.BXCL, p3.BXMD, p3.BXMT, p3.CTDL, p3.CTCN, p3.P1M, p3.P2M, p3.P3M, p3.P4M);
                                    if (p3.Money < 500)
                                    {
                                        tax = false;
                                    }
                                }
                                if (p3.Money >= 500) // Taxing rich players
                                {
                                    if (!tax)
                                    {
                                        p3.Money = p3.Money - 10;
                                        tax = true;
                                    }
                                }
                                else if (p3.Money < 0 && p3.Money >= -100) // Pay the bank interest
                                {
                                    stat1 = "Idle";
                                    stat2 = "Idle";
                                    stat3 = "on Turn";
                                    stat4 = "Idle";
                                    p3.Move(p3.Name, totDice, x3, y3, p3.Money);
                                    p3.P3RE(p3.Money, p3.X, p3.Y, p3.LBB, p3.CH, p3.QT, p3.TC, p3.HVT, p3.KVC, p3.HV, p3.NT, p3.PNL, p3.VTS, p3.LL, p3.NH, p3.LBBH, p3.CHH, p3.QTH, p3.TCH, p3.HVTH, p3.KVCH, p3.HVH, p3.NTH, p3.PNLH, p3.VTSH, p3.LLH, p3.NHH, p3.LBBW, p3.CHW, p3.QTW, p3.TCW, p3.HVTW, p3.KVCW, p3.HVW, p3.NTW, p3.PNLW, p3.VTSW, p3.LLW, p3.NHW, p3.P1M, p3.P2M, p3.P3M, p3.P4M);
                                    p3.P3SC(p3.Money, p3.X, p3.Y, p3.BXCG, p3.BXCL, p3.BXMD, p3.BXMT, p3.CTDL, p3.CTCN, p3.P1M, p3.P2M, p3.P3M, p3.P4M);
                                    if (!tax)
                                    {
                                        p3.Money = p3.Money - 5;
                                        tax = true;
                                    }
                                }
                                else if (p3.Money < -100)
                                {
                                    stat1 = "Idle";
                                    stat2 = "Idle";
                                    stat3 = "Bankrupt";
                                    stat4 = "Idle";
                                    resetDice = false;
                                    tax = false;
                                }
                            }
                            else if (p3.Prisoned && !m3)
                            {
                                stat1 = "Idle";
                                stat2 = "Idle";
                                stat3 = "Jailed";
                                stat4 = "Idle";
                                tax = false;
                                if (!pris3 && ((dice1.DiceValue1 == 1 && dice2.DiceValue2 == 1) || (dice1.DiceValue1 == 2 && dice2.DiceValue2 == 2) || (dice1.DiceValue1 == 3 && dice2.DiceValue2 == 3) || (dice1.DiceValue1 == 4 && dice2.DiceValue2 == 4) || (dice1.DiceValue1 == 5 && dice2.DiceValue2 == 5) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 1 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 1)))
                                {
                                    p3.EQDice = true;
                                    p3.Prisoned = false;
                                    Console.WriteLine($"{p3.Name} is set free.");
                                    p3.Move(p3.Name, totDice, x3, y3, p3.Money);
                                    p3.P3RE(p3.Money, p3.X, p3.Y, p3.LBB, p3.CH, p3.QT, p3.TC, p3.HVT, p3.KVC, p3.HV, p3.NT, p3.PNL, p3.VTS, p3.LL, p3.NH, p3.LBBH, p3.CHH, p3.QTH, p3.TCH, p3.HVTH, p3.KVCH, p3.HVH, p3.NTH, p3.PNLH, p3.VTSH, p3.LLH, p3.NHH, p3.LBBW, p3.CHW, p3.QTW, p3.TCW, p3.HVTW, p3.KVCW, p3.HVW, p3.NTW, p3.PNLW, p3.VTSW, p3.LLW, p3.NHW, p3.P1M, p3.P2M, p3.P3M, p3.P4M);
                                    p3.P3SC(p3.Money, p3.X, p3.Y, p3.BXCG, p3.BXCL, p3.BXMD, p3.BXMT, p3.CTDL, p3.CTCN, p3.P1M, p3.P2M, p3.P3M, p3.P4M);
                                    pris3 = true;
                                }
                                else { p3.EQDice = false; }
                            }
                            break;

                        case 4:
                            if (!p4.Prisoned && !m4)
                            {
                                p4.EQDice = false;

                                if (p4.Money >= 0)

                                {
                                    stat1 = "Idle";
                                    stat2 = "Idle";
                                    stat3 = "Idle";
                                    stat4 = "on Turn";
                                    p4.Move(p4.Name, totDice, x4, y4, p4.Money);
                                    p4.P4RE(p4.Money, p4.X, p4.Y, p4.LBB, p4.CH, p4.QT, p4.TC, p4.HVT, p4.KVC, p4.HV, p4.NT, p4.PNL, p4.VTS, p4.LL, p4.NH, p4.LBBH, p4.CHH, p4.QTH, p4.TCH, p4.HVTH, p4.KVCH, p4.HVH, p4.NTH, p4.PNLH, p4.VTSH, p4.LLH, p4.NHH, p4.LBBW, p4.CHW, p4.QTW, p4.TCW, p4.HVTW, p4.KVCW, p4.HVW, p4.NTW, p4.PNLW, p4.VTSW, p4.LLW, p4.NHW, p4.P1M, p4.P2M, p4.P3M, p4.P4M);
                                    p4.P4SC(p4.Money, p4.X, p4.Y, p4.BXCG, p4.BXCL, p4.BXMD, p4.BXMT, p4.CTDL, p4.CTCN, p4.P1M, p4.P2M, p4.P3M, p4.P4M);
                                    if (p4.Money < 500)
                                    {
                                        tax = false;
                                    }
                                }
                                if (p4.Money >= 500) // Taxing rich players
                                {
                                    if (!tax)
                                    {
                                        p4.Money = p4.Money - 10;
                                        tax = true;
                                    }
                                }
                                else if (p4.Money < 0 && p4.Money >= -100) // Pay the bank interest
                                {
                                    stat1 = "Idle";
                                    stat2 = "Idle";
                                    stat3 = "Idle";
                                    stat4 = "on Turn";
                                    p4.Move(p4.Name, totDice, x4, y4, p4.Money);
                                    p4.P4RE(p4.Money, p4.X, p4.Y, p4.LBB, p4.CH, p4.QT, p4.TC, p4.HVT, p4.KVC, p4.HV, p4.NT, p4.PNL, p4.VTS, p4.LL, p4.NH, p4.LBBH, p4.CHH, p4.QTH, p4.TCH, p4.HVTH, p4.KVCH, p4.HVH, p4.NTH, p4.PNLH, p4.VTSH, p4.LLH, p4.NHH, p4.LBBW, p4.CHW, p4.QTW, p4.TCW, p4.HVTW, p4.KVCW, p4.HVW, p4.NTW, p4.PNLW, p4.VTSW, p4.LLW, p4.NHW, p4.P1M, p4.P2M, p4.P3M, p4.P4M);
                                    p4.P4SC(p4.Money, p4.X, p4.Y, p4.BXCG, p4.BXCL, p4.BXMD, p4.BXMT, p4.CTDL, p4.CTCN, p4.P1M, p4.P2M, p4.P3M, p4.P4M);
                                    if (!tax)
                                    {
                                        p4.Money = p4.Money - 5;
                                        tax = true;
                                    }
                                }
                                else if (p4.Money < -100)
                                {
                                    stat1 = "Idle";
                                    stat2 = "Idle";
                                    stat3 = "Idle";
                                    stat4 = "Bankrupt";
                                    resetDice = false;
                                    tax = true;
                                }
                            }
                            else if (p4.Prisoned && !m4)
                            {
                                stat1 = "Idle";
                                stat2 = "Idle";
                                stat3 = "Idle";
                                stat4 = "Jailed";
                                tax = false;
                                if (!pris4 && ((dice1.DiceValue1 == 1 && dice2.DiceValue2 == 1) || (dice1.DiceValue1 == 2 && dice2.DiceValue2 == 2) || (dice1.DiceValue1 == 3 && dice2.DiceValue2 == 3) || (dice1.DiceValue1 == 4 && dice2.DiceValue2 == 4) || (dice1.DiceValue1 == 5 && dice2.DiceValue2 == 5) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 1 && dice2.DiceValue2 == 6) || (dice1.DiceValue1 == 6 && dice2.DiceValue2 == 1)))
                                {
                                    p4.EQDice = true;
                                    p4.Prisoned = false;
                                    Console.WriteLine($"{p4.Name} is set free.");
                                    p4.Move(p4.Name, totDice, x4, y4, p4.Money);
                                    p4.P4RE(p4.Money, p4.X, p4.Y, p4.LBB, p4.CH, p4.QT, p4.TC, p4.HVT, p4.KVC, p4.HV, p4.NT, p4.PNL, p4.VTS, p4.LL, p4.NH, p4.LBBH, p4.CHH, p4.QTH, p4.TCH, p4.HVTH, p4.KVCH, p4.HVH, p4.NTH, p4.PNLH, p4.VTSH, p4.LLH, p4.NHH, p4.LBBW, p4.CHW, p4.QTW, p4.TCW, p4.HVTW, p4.KVCW, p4.HVW, p4.NTW, p4.PNLW, p4.VTSW, p4.LLW, p4.NHW, p4.P1M, p4.P2M, p4.P3M, p4.P4M);
                                    p4.P4SC(p4.Money, p4.X, p4.Y, p4.BXCG, p4.BXCL, p4.BXMD, p4.BXMT, p4.CTDL, p4.CTCN, p4.P1M, p4.P2M, p4.P3M, p4.P4M);
                                    pris4 = true;
                                }
                                else { p4.EQDice = false; }
                            }
                            break;
                    }

                    // Check conditions
                    p1.ConditionCheck1(p1.Money, p1.X, p1.Y, p1.P1M, p1.P2M, p1.P3M, p1.P4M);
                    p2.ConditionCheck2(p2.Money, p2.X, p2.Y, p2.P1M, p2.P2M, p2.P3M, p2.P4M);
                    p3.ConditionCheck3(p3.Money, p3.X, p3.Y, p3.P1M, p3.P2M, p3.P3M, p3.P4M);
                    p4.ConditionCheck4(p4.Money, p4.X, p4.Y, p4.P1M, p4.P2M, p4.P3M, p4.P4M);

                    // Control moves as condtional checkers
                    if (((p1.X == 0 && p1.Y == 2) || (p1.X == 0 && p1.Y == 7) || (p1.X == 7 && p1.Y == 5) || (p1.X == 7 && p1.Y == 0)) && !am1)
                    {
                        m1 = true;
                        am1 = true;
                    }
                    if (((p2.X == 0 && p2.Y == 2) || (p2.X == 0 && p2.Y == 7) || (p2.X == 7 && p2.Y == 5) || (p2.X == 7 && p2.Y == 0)) && !am2)
                    {
                        m2 = true;
                        am2 = true;
                    }
                    if (((p3.X == 0 && p3.Y == 2) || (p3.X == 0 && p3.Y == 7) || (p3.X == 7 && p3.Y == 5) || (p3.X == 7 && p3.Y == 0)) && !am3)
                    {
                        m3 = true;
                        am3 = true;
                    }
                    if (((p4.X == 0 && p4.Y == 2) || (p4.X == 0 && p4.Y == 7) || (p4.X == 7 && p4.Y == 5) || (p4.X == 7 && p4.Y == 0)) && !am4)
                    {
                        m4 = true;
                        am4 = true;
                    }
                    if (!(p1.X == 0 && p1.Y == 2) && !(p1.X == 0 && p1.Y == 7) && !(p1.X == 7 && p1.Y == 5) && !(p1.X == 7 && p1.Y == 0))
                    {
                        am1 = false;
                    }
                    if (!(p2.X == 0 && p2.Y == 2) && !(p2.X == 0 && p2.Y == 7) && !(p2.X == 7 && p2.Y == 5) && !(p2.X == 7 && p2.Y == 0))
                    {
                        am2 = false;
                    }
                    if (!(p3.X == 0 && p3.Y == 2) && !(p3.X == 0 && p3.Y == 7) && !(p3.X == 7 && p3.Y == 5) && !(p3.X == 7 && p3.Y == 0))
                    {
                        am3 = false;
                    }
                    if (!(p4.X == 0 && p4.Y == 2) && !(p4.X == 0 && p4.Y == 7) && !(p4.X == 7 && p4.Y == 5) && !(p4.X == 7 && p4.Y == 0))
                    {
                        am4 = false;
                    }

                    if (!resetDice && (SplashKit.KeyTyped(KeyCode.ReturnKey) || (SplashKit.MouseClicked(MouseButton.LeftButton) && IsMouseInRectangle(SplashKit.MousePosition(), 200, 500, 100, 100))))
                    {
                        resetDice = true;
                        esc = false;
                        alDice1 = false;
                        alDice2 = false;
                        p_turn = p_turn + 1;
                        pris1 = false; pris2 = false; pris3 = false; pris4 = false;
                        m1 = false; m2 = false; m3 = false; m4 = false;
                        tax = false;
                        p3o = false;
                        changename = true;
                        paused = true;

                        if (!eqDice && dice1.DiceValue1 == dice2.DiceValue2)
                        {
                            // Method to escape from jail
                            eqDice = true;
                        }

                        dice1.ResetDiceValues();
                        dice2.ResetDiceValues();

                        //Console.WriteLine($"Dice total: {totDice}");
                        //Console.WriteLine("");

                        // Reset turn
                        if (fullplayer)
                        {
                            if (p_turn > 4)
                            {
                                x1 = p1.X; y1 = p1.Y;
                                x2 = p2.X; y2 = p2.Y;
                                x3 = p3.X; y3 = p3.Y;
                                x4 = p4.X; y4 = p4.Y;
                                p_turn = 1;
                            }
                        }
                        else if (!fullplayer)
                        {
                            if (p_turn > 3)
                            {
                                x1 = p1.X; y1 = p1.Y;
                                x2 = p2.X; y2 = p2.Y;
                                x3 = p3.X; y3 = p3.Y;
                                p_turn = 1;
                            }
                        }

                    }

                    // Update dices' value method
                    if (alDice1)
                    {
                        board.DrawDice(gameWindow, 430, 420, dice1.DiceValue1);
                    }
                    if (alDice2)
                    {
                        board.DrawDice(gameWindow, 518, 420, dice2.DiceValue2);
                    }

                    // Control player's revenues across different player classes
                    if (p2.P1M != 0) { p1.Money = p1.Money + p2.P1M; p2.P1M = 0; }
                    if (p3.P1M != 0) { p1.Money = p1.Money + p3.P1M; p3.P1M = 0; }
                    if (p4.P1M != 0) { p1.Money = p1.Money + p4.P1M; p4.P1M = 0; }

                    if (p1.P2M != 0) { p2.Money = p2.Money + p1.P2M; p1.P2M = 0; }
                    if (p3.P2M != 0) { p2.Money = p2.Money + p3.P2M; p3.P2M = 0; }
                    if (p4.P2M != 0) { p2.Money = p2.Money + p4.P2M; p4.P2M = 0; }

                    if (p1.P3M != 0) { p3.Money = p3.Money + p1.P3M; p1.P3M = 0; }
                    if (p2.P3M != 0) { p3.Money = p3.Money + p2.P3M; p2.P3M = 0; }
                    if (p4.P3M != 0) { p3.Money = p3.Money + p4.P3M; p4.P3M = 0; }

                    if (p1.P4M != 0) { p4.Money = p4.Money + p1.P4M; p1.P4M = 0; }
                    if (p2.P4M != 0) { p4.Money = p4.Money + p2.P4M; p2.P4M = 0; }
                    if (p3.P4M != 0) { p4.Money = p4.Money + p3.P4M; p3.P4M = 0; }

                    // Update player's revenue from rental
                    /*if (p1.P1M > 0)
                    {
                        p1.Money = p1.Money + p1.P1M;
                        p1.P1M = 0;
                    }
                    if (p2.P2M > 0)
                    {
                        p2.Money = p2.Money + p2.P2M;
                        p2.P2M = 0;
                    }
                    if (p3.P3M > 0)
                    {
                        p3.Money = p3.Money + p3.P3M;
                        p3.P3M = 0;
                    }
                    if (p4.P4M > 0)
                    {
                        p4.Money = p4.Money + p4.P4M;
                        p4.P4M = 0;
                    }*/

                    // Change grid color by SPACE key
                    if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                    {
                        board.ChangeGridColor();
                    }

                    // Game guidelines
                    if (SplashKit.KeyTyped(KeyCode.IKey))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Instruction and Information:");
                        Console.WriteLine("Click on the 2 dices to roll your move (or press [Z] and [X] key).");
                        Console.WriteLine("Click on the 'Start and Go' squared cell (or [ENTER] key) to reset dices.");
                        Console.WriteLine("Press [I] to see this Instruction and Information panel back again.");
                        Console.WriteLine("Press [P] to pause the game.");
                        Console.WriteLine("Press [C] to list out all conditions and sequences (Chance and Luck).");
                        Console.WriteLine("Press [M] to learn more about marker's outline color rules.");
                        Console.WriteLine("Press [N] to change your name.");
                        Console.WriteLine("");
                        Console.WriteLine("Buy and own as many companies and streets (with houses) as you can, with a maximum number of 2 houses.");
                        Console.WriteLine("The cost to build 1 house is equivalent to 20% of the street's worth.");
                        Console.WriteLine("Once having 2 houses, you can buy a hotel which is equivalent to 20% of the street's worth.");
                        Console.WriteLine("Renting on your opponent's estate cost you 10% of their estate's total worth.");
                        Console.WriteLine("");
                        Console.WriteLine("Once you failed below your balance (less than $0), you can loan the bank some money.");
                        Console.WriteLine("Once owing the bank, you will have to pay them $5 each move.");
                        Console.WriteLine("Once you owe the bank more than $100, you are set to bankrupcy (and eliminated).");
                        Console.WriteLine("Rich players (balance above $500) get taxed by 10 dollars per moves.");
                        Console.WriteLine("");
                        Console.WriteLine("Once you move to the 'Go to Jail' cell, you are jailed until you draw 2 identical dices or a pair of 1 and 6 dices.");
                        Console.WriteLine("");
                        Console.WriteLine("Players can sell their estate and buy from other, by verbal agreement - bank loaning is also eligible for buyers.");
                        Console.WriteLine("Press [ESC] key to fill in the estate transfer form, notice that player cannot transfer the house (if there may be).");
                        Console.WriteLine("Estate seller have to pay $10 tax to the Goverment when selling their property to the other.");
                        Console.WriteLine("");
                        Console.WriteLine("Most input requests are not case-sensitive unless it ask you so.");
                        Console.WriteLine("");
                    }
                    if (SplashKit.KeyTyped(KeyCode.CKey))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Condition:");
                        Console.WriteLine("You work after hour, gained 30 dollars");
                        Console.WriteLine("You got ill, loss 30 dollars");
                        Console.WriteLine("You got a car accident, loss 100 dollars");
                        Console.WriteLine("You inherit family wealth, gained 100 dollars");
                        Console.WriteLine("You loss a poker game, loss 50 dollars");
                        Console.WriteLine("You get caught from graffiti, fined by 20 dollars");
                        Console.WriteLine("Go forward 2 steps");
                        Console.WriteLine("Go backward 3 steps");
                        Console.WriteLine("");
                        Console.WriteLine("Luck:");
                        Console.WriteLine("Someone dropped their wallet, gained 20 dollars");
                        Console.WriteLine("Won in the Casino, gained 50 dollars");
                        Console.WriteLine("Your children needed tuition fees, loss 20 dollars");
                        Console.WriteLine("You became a pop star, gained 50 dollars");
                        Console.WriteLine("Your estate raised, gained 100 dollars");
                        Console.WriteLine("You did some gambling / Your football team became champion, plus 50 dollars");
                        Console.WriteLine("You did some gambling / The horse you bet loos, minus 50 dollars");
                        Console.WriteLine("You robbed the bank and eventually get caught, gained 100 dollars and go to jail");
                        Console.WriteLine("Biggest Robbery in the Town, which player you would like to steal $50 from? (Enter 1 to 4, else go to jail)");
                        Console.WriteLine("");
                    }
                    if (SplashKit.KeyTyped(KeyCode.MKey))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("At default, all marker outlines are black.");
                        Console.WriteLine("Marker outline turns violet when you are the Monopoly (owned most streets).");
                        Console.WriteLine("Marker outline turns orange when you go to jail.");
                        Console.WriteLine("Marker turns grey if you are bankrupted.");
                        Console.WriteLine("");
                    }
                    if (SplashKit.KeyTyped(KeyCode.PKey))
                    {
                        Console.WriteLine("THE GAME IS PAUSING");
                        Console.WriteLine("Maybe your friend is going to the toilet or grabbing some snacks so we are at this pausing stage :/");
                        Console.WriteLine("If you would like to come back and continue the game, please press [Y], or choosing any options (from 1 to 6) below.");
                        Console.WriteLine("");
                        Console.WriteLine("Fun options for your leisure time:");
                        Console.WriteLine("1. Who am I? What is this game?");
                        Console.WriteLine("2. Any tips or advices?");
                        Console.WriteLine("3. Show me the instructions.");
                        Console.WriteLine("4. Making faces.");
                        Console.WriteLine("5. Copyright.");
                        Console.WriteLine("6. Play the 'Rock Paper Scissor' minigame.");
                        Console.WriteLine("7. Play the 'Tic Tac Toe' minigame.");
                        Console.WriteLine("8. Show this list of options again.");
                        Console.WriteLine("");
                        while (paused)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Input your option below:");
                            string option = Console.ReadLine();
                            option = option.ToLower();
                            if (option == "y")
                            {
                                paused = false;
                            }
                            else if (option == "1")
                            {
                                Console.WriteLine("This is the Monopoly game. Made by Khoa Le, inspired by the famous 'Co Ty Phu' board game.");
                                Console.WriteLine("The game uses some famous streets in HCM city, Vietnam, English is set as the default language.");
                                Console.WriteLine("It is especially made for 3 to 4 players, suitable to play with friends and family.");
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("While this game is mostly based on your luck, here can be the 7 ideal strategies:");
                                Console.WriteLine("1. Try to buy and own as many streets, houses and companies as you can before everyone else.");
                                Console.WriteLine("2. It's best to buy properties that are closed together, hence more chance for your friends to get on your lands.");
                                Console.WriteLine("3. Luck and Chances are not always financial-friendly.");
                                Console.WriteLine("4. Crossing the Start cell is the most reliable way to gain money.");
                                Console.WriteLine("5. Avoid the Jail as you loose your chance moving around.");
                                Console.WriteLine("6. Don't risk your money balance too low, you can either have to pay bank interest or get bankrupted.");
                                Console.WriteLine("7. Bus stops are not the best property to buy, the streets are.");
                            }
                            else if (option == "3")
                            {
                                Console.WriteLine("Instruction and Information:");
                                Console.WriteLine("Click on the 2 dices to roll your move (or press [Z] and [X] key).");
                                Console.WriteLine("Click on the 'Start and Go' squared cell (or [ENTER] key) to reset dices.");
                                Console.WriteLine("Press [I] to see this Instruction and Information panel back again.");
                                Console.WriteLine("Press [P] to pause the game.");
                                Console.WriteLine("Press [C] to list out all conditions and sequences (Chance and Luck).");
                                Console.WriteLine("Press [M] to learn more about marker's outline color rules.");
                                Console.WriteLine("Press [N] to change your name.");
                                Console.WriteLine("");
                                Console.WriteLine("Buy and own as many companies and streets (with houses) as you can, with a maximum number of 2 houses.");
                                Console.WriteLine("The cost to build 1 house is equivalent to 20% of the street's worth.");
                                Console.WriteLine("Once having 2 houses, you can buy a hotel which is equivalent to 20% of the street's worth.");
                                Console.WriteLine("Renting on your opponent's estate cost you 10% of their estate's total worth.");
                                Console.WriteLine("");
                                Console.WriteLine("Once you failed below your balance (less than $0), you can loan the bank some money.");
                                Console.WriteLine("Once owing the bank, you will have to pay them $5 each move.");
                                Console.WriteLine("Once you owe the bank more than $100, you are set to bankrupcy (and eliminated).");
                                Console.WriteLine("Rich players (balance above $500) get taxed by 10 dollars per moves.");
                                Console.WriteLine("");
                                Console.WriteLine("Once you move to the 'Go to Jail' cell, you are jailed until you draw 2 identical dices or a pair of 1 and 6 dices.");
                                Console.WriteLine("");
                                Console.WriteLine("Players can sell their estate and buy from other, by verbal agreement - bank loaning is also eligible for buyers.");
                                Console.WriteLine("Press [ESC] key to fill in the estate transfer form, notice that player cannot transfer the house (if there may be).");
                                Console.WriteLine("Estate seller have to pay $10 tax to the Goverment when selling their property to the other.");
                                Console.WriteLine("");
                                Console.WriteLine("Most input requests are not case-sensitive unless it ask you so.");
                            }
                            else if (option == "4")
                            {
                                Console.WriteLine("Choose from the list of available faces below:");
                                Console.WriteLine("1. Happy faces");
                                Console.WriteLine("2. Sad faces");
                                Console.WriteLine("3. Crying faces");
                                Console.WriteLine("4. Confused faces");
                                Console.WriteLine("5. Angry faces");
                                Console.WriteLine("6. Laughing faces");
                                Console.WriteLine("7. Sarcastic faces");
                                Console.WriteLine("8. Cute faces");
                                Console.WriteLine("9. Amazed faces");
                                Console.WriteLine("10. Wink faces");

                                string face = Console.ReadLine();
                                if (face == "1")
                                {
                                    Console.WriteLine(":)");
                                }
                                if (face == "2")
                                {
                                    Console.WriteLine(":(");
                                }
                                if (face == "3")
                                {
                                    Console.WriteLine("T.T");
                                }
                                if (face == "4")
                                {
                                    Console.WriteLine(":/");
                                }
                                if (face == "5")
                                {
                                    Console.WriteLine(">:(");
                                }
                                if (face == "6")
                                {
                                    Console.WriteLine(":D");
                                }
                                if (face == "7")
                                {
                                    Console.WriteLine(":v");
                                }
                                if (face == "8")
                                {
                                    Console.WriteLine(":3");
                                }
                                if (face == "9")
                                {
                                    Console.WriteLine(":o");
                                }
                                if (face == "10")
                                {
                                    Console.WriteLine(";)");
                                }
                                if (face == "Y")
                                {
                                    paused = false;
                                }
                            }
                            else if (option == "5")
                            {
                                Console.WriteLine("This is the offline, codebased Monopoly game. Made by Khoa Le, inspired by the famous 'Co Ty Phu' board game.");
                                Console.WriteLine("The game is based on C# language and powered by SplashKitSDK, Visual Studio preferable.");
                                Console.WriteLine("Developing period: End of Oct - End of Dec, 2023.");
                                Console.WriteLine("DO NOT copy without the permission from owner, Khoa Le.");
                            }
                            else if (option == "6")
                            {
                                Console.WriteLine("This is the 'Rock Paper Scissor' minigame.");
                                Console.WriteLine("Don't worry, the game is fair, machine will only pick randomly.");
                                bool rps = true;
                                while (rps)
                                {
                                    Dice dice3 = new Dice();
                                    Console.WriteLine("");
                                    Console.WriteLine("What is your pick? Press [E] to exit.");
                                    Console.WriteLine("1. Rock.");
                                    Console.WriteLine("2. Paper.");
                                    Console.WriteLine("3. Scissor.");

                                    string c = Console.ReadLine();
                                    c = c.ToLower();

                                    if (c == "1") // You pick rock
                                    {
                                        dice3.RPS(true, false, false);
                                    }
                                    if (c == "2") // You pick paper
                                    {
                                        dice3.RPS(false, true, false);
                                    }
                                    if (c == "3") // You pick scissor
                                    {
                                        dice3.RPS(false, false, true);
                                    }
                                    if (c == "e")
                                    {
                                        rps = false;
                                    }
                                    if (c == "y")
                                    {
                                        rps = false; paused = false;
                                    }
                                    else if (!(c == "1") && !(c == "2") && !(c == "3") && !(c == "e") && !(c == "y"))
                                    {
                                        Console.WriteLine("Wrong input, please choose correctly.");
                                    }
                                }
                            }
                            else if (option == "7")
                            {
                                Console.WriteLine("This is the 'Tic Tac Toe' minigame.");
                                Console.WriteLine("This game will be played on a 5x5 cell board, please choose (from 1-3) as the gamemode options below.");
                                bool ttt = true;
                                while (ttt)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("What is your pick? Press [E] to exit at anytime.");
                                    Console.WriteLine("1. Player vs Player Mode (PvP).");
                                    Console.WriteLine("2. Player vs Machine Mode (PvM).");
                                    Console.WriteLine("3. 3 Player mode (3P).");
                                    Console.WriteLine("Developer note: at this stage, PvM mode may occurs errors that could devastate your Monopoly game.");
                                    string t = Console.ReadLine();
                                    t = t.ToLower();

                                    // Control player gamemode selection
                                    bool pvp = false; bool pvm = false; bool p3p = false;
                                    if (t == "1")
                                    {
                                        Console.WriteLine("This is the Tic Tac Toe - Player vs Player gamemode by 5x5 grid.");
                                        pvp = true;
                                    }
                                    if (t == "2")
                                    {
                                        Console.WriteLine("This is the Tic Tac Toe - Player vs Machine gamemode by 5x5 grid.");
                                        pvm = true;
                                    }
                                    if (t == "3")
                                    {
                                        Console.WriteLine("This is the Tic Tac Toe - 3 Player gamemode by 5x5 grid.");
                                        p3p = true;
                                    }
                                    if (t == "e")
                                    {
                                        pvp = false; pvm = false; p3p = false; ttt = false;
                                    }
                                    if (t == "y")
                                    {
                                        pvp = false; pvm = false; p3p = false; ttt = false; paused = false;
                                    }
                                    else if (!(t == "1") && !(t == "2") && !(t == "3") && !(t == "e") && !(t == "y"))
                                    {
                                        Console.WriteLine("Wrong input, please choose correctly.");
                                    }
                                    while (pvp || pvm || p3p)
                                    {
                                        const int WindowWidth = 500;
                                        const int WindowHeight = 500;
                                        const int Rows = 5;
                                        const int Cols = 5;     

                                        Window TicTacToeWindow = new Window("Tic Tac Toe", WindowWidth, WindowHeight);
                                        TicTacToeDrawBoard draw = new TicTacToeDrawBoard(WindowWidth, WindowHeight, Rows, Cols);

                                        // Initialize the winner flag
                                        bool inGame = false;
                                        bool gameOver = true;
                                        bool gameOver3 = true;
                                       
                                        while (!TicTacToeWindow.CloseRequested)
                                        {
                                            if (SplashKit.KeyTyped(KeyCode.EKey))
                                            {
                                                pvp = false; pvm = false; p3p = false; ttt = false;
                                            }
                                            if (!inGame)
                                            {
                                                SplashKit.ProcessEvents();

                                                if (pvm)
                                                {
                                                    inGame = true;
                                                    gameOver = false;
                                                    draw.SwitchToPlayerVsMachineMode();
                                                }
                                                else if (pvp)
                                                {
                                                    inGame = true;
                                                    gameOver = false;
                                                    draw.SwitchToPlayerVsPlayerMode();
                                                }
                                                else if (p3p)
                                                {
                                                    inGame = true;
                                                    gameOver3 = false;
                                                    draw.SwitchToThreePlayerMode();
                                                }
                                            }
                                            else
                                            {
                                                SplashKit.ProcessEvents();

                                                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                                                {
                                                    draw.ChangeGridColor();
                                                }
                                                if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                                                {
                                                    draw.Reset();
                                                    if (draw.IsPlayerVsMachineMode() || draw.IsPlayerVsPlayerMode())
                                                    {
                                                        gameOver = false;
                                                    }

                                                    if (draw.IsThreePlayerMode())
                                                    {
                                                        gameOver3 = false;
                                                    }
                                                }

                                                if (!gameOver)
                                                {
                                                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                                                    {
                                                        draw.PlaceMarker();
                                                        var winner = draw.CheckForWinner();
                                                        if (winner != PlayerType.Empty)
                                                        {
                                                            draw.UpdateScores(winner);

                                                            if (draw.IsPlayerVsMachineMode() || draw.IsPlayerVsPlayerMode())
                                                            {
                                                                Console.WriteLine($"The Winner is {winner} side.");
                                                                Console.WriteLine($"[X] {draw.XScore} - {draw.OScore} [O]");
                                                            }
                                                            gameOver = true;
                                                        }
                                                    }
                                                }

                                                if (!gameOver3)
                                                {
                                                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                                                    {
                                                        draw.PlaceMarker();
                                                        var winner3 = draw.ThreePlayerWinnerCheck();

                                                        if (winner3 != PlayerType.Empty)
                                                        {
                                                            draw.UpdateScores3P(winner3);

                                                            if (draw.IsThreePlayerMode())
                                                            {
                                                                Console.WriteLine($"The Winner is {winner3} side.");
                                                                Console.WriteLine($"[X] {draw.XScore} - {draw.OScore} [O] - {draw.ZScore} [Z]");
                                                            }

                                                            gameOver3 = true;
                                                        }
                                                    }
                                                }
                                                
                                                TicTacToeWindow.Clear(Color.White);
                                                draw.Draw();
                                                TicTacToeWindow.Refresh();
                                            }
                                        }
                                    }
                                }
                            }
                            else if (option == "8")
                            {
                                Console.WriteLine("Fun options for your leisure time:");
                                Console.WriteLine("1. Who am I? What is this game?");
                                Console.WriteLine("2. Any tips or advices?");
                                Console.WriteLine("3. Show me the instructions.");
                                Console.WriteLine("4. Making faces.");
                                Console.WriteLine("5. Copyright.");
                                Console.WriteLine("6. Play the 'Rock Paper Scissor' minigame.");
                                Console.WriteLine("7. Play the 'Tic Tac Toe' minigame.");
                                Console.WriteLine("8. Show this list of options again.");
                            }
                            else if (!(option == "1") && !(option == "2") && !(option == "3") && !(option == "4") && !(option == "5") && !(option == "6") && !(option == "7") && !(option == "8") && !(option == "y"))
                            {
                                Console.WriteLine("Invalid input, please try again.");
                            }
                        }
                    }
                    // Change player's name request
                    if (SplashKit.KeyTyped(KeyCode.NKey))
                    {
                        while (changename)
                        {
                            Console.WriteLine("Which player would like to change their name? (required id 1 to 4 or player's current name, press [C] to cancel)");
                            string changefrom = Console.ReadLine();
                            changefrom = changefrom.ToLower();
                            Console.WriteLine("What name would you like to change to? (or press [C] to cancel)");
                            string changeto = Console.ReadLine();
                            string a1 = p1.Name, a2 = p2.Name, a3 = p3.Name, a4 = p4.Name;
                            if (changefrom == "1" || changefrom == name1.ToLower() || changefrom == a1.ToLower())
                            {
                                p1.Name = changeto; name1 = changeto;
                                changename = false;
                            }
                            if (changefrom == "2" || changefrom == name2.ToLower() || changefrom == a2.ToLower())
                            {
                                p2.Name = changeto; name2 = changeto;
                                changename = false;
                            }
                            if (changefrom == "3" || changefrom == name3.ToLower() || changefrom == a3.ToLower())
                            {
                                p3.Name = changeto; name3 = changeto;
                                changename = false;
                            }
                            if (changefrom == "4" || changefrom == name4.ToLower() || changefrom == a4.ToLower())
                            {
                                p4.Name = changeto; name4 = changeto;
                                changename = false;
                            }
                            else if (changefrom == "c" || changeto == "c" || changeto == "C")
                            {
                                changename = false;
                            }
                            else if (!(changefrom == "1" || changefrom == name1.ToLower() || changefrom == a1.ToLower()) && !(changefrom == "2" || changefrom == name2.ToLower() || changefrom == a2.ToLower()) && !(changefrom == "3" || changefrom == name3.ToLower()) || changefrom == a3.ToLower() && !(changefrom == "4" || changefrom == name4.ToLower() || changefrom == a4.ToLower()) && !(changefrom == "c" || changeto == "c" || changeto == "C"))
                            {
                                Console.WriteLine("Wrong input request, try again.");
                                changename = true;
                            }
                        }
                    }
                    // Buy or Sell estates (trade ownership) by ESC key.
                    if (SplashKit.KeyTyped(KeyCode.EscapeKey))
                    {
                        while (!esc)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Please fill in this Estate Transfer form:");
                            Console.WriteLine("Which player would like to sell their property? (required id 1 to 4 or player's name)");
                            string seller = Console.ReadLine();
                            seller = seller.ToLower();
                            Console.WriteLine("Which property (street) is it? (enter name in printed-abbreviated form) <Case Sensitive>");
                            string estate = Console.ReadLine();
                            Console.WriteLine("Which player would like to buy this property? (required id 1 to 4 or player's name)");
                            string buyer = Console.ReadLine();
                            buyer = buyer.ToLower();
                            Console.WriteLine($"Just confirming that player '{seller}' will sell property at the '{estate}' street to '{buyer}'?");

                            Console.WriteLine($"Please enter [A] key if you accept it, else enter [C] key to cancel this transfer.");
                            string option = Console.ReadLine();
                            if (option == "A" || option == "a")
                            {
                                /*if ((seller != "1" || seller != "2" || seller != "3" || seller != "4") && (buyer != "1" || buyer != "2" || buyer != "3" || buyer != "4"))
                                {
                                    Console.WriteLine("Unidentified buyer's, seller's or estate's name. Please try again later.");
                                    esc = true;
                                }*/
                                string b1 = p1.Name, b2 = p2.Name, b3 = p3.Name, b4 = p4.Name;
                                if (estate == "LBB")
                                {
                                    p1.LBBH = 0; p2.LBBH = 0; p3.LBBH = 0; p4.LBBH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 50; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 50; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 50; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 50; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 60; p1.LBB = "player1"; p2.LBB = "player1"; p3.LBB = "player1"; p4.LBB = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 60; p1.LBB = "player2"; p2.LBB = "player2"; p3.LBB = "player2"; p4.LBB = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 60; p1.LBB = "player3"; p2.LBB = "player3"; p3.LBB = "player3"; p4.LBB = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 60; p1.LBB = "player4"; p2.LBB = "player4"; p3.LBB = "player4"; p4.LBB = "player4"; p4.EO = p4.EO + 1; }
                                    occ1 = false;
                                    esc = true;
                                }
                                else if (estate == "CH")
                                {
                                    p1.CHH = 0; p2.CHH = 0; p3.CHH = 0; p4.CHH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 90; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 90; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 90; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 90; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 100; p1.CH = "player1"; p2.CH = "player1"; p3.CH = "player1"; p4.CH = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 100; p1.CH = "player2"; p2.CH = "player2"; p3.CH = "player2"; p4.CH = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 100; p1.CH = "player3"; p2.CH = "player3"; p3.CH = "player3"; p4.CH = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 100; p1.CH = "player4"; p2.CH = "player4"; p3.CH = "player4"; p4.CH = "player4"; p4.EO = p4.EO + 1; }
                                    occ2 = false;
                                    esc = true;
                                }
                                else if (estate == "QT")
                                {
                                    p1.QTH = 0; p2.QTH = 0; p3.QTH = 0; p4.QTH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 110; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 110; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 110; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 110; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 120; p1.QT = "player1"; p2.QT = "player1"; p3.QT = "player1"; p4.QT = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 120; p1.QT = "player2"; p2.QT = "player2"; p3.QT = "player2"; p4.QT = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 120; p1.QT = "player3"; p2.QT = "player3"; p3.QT = "player3"; p4.QT = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 120; p1.QT = "player4"; p2.QT = "player4"; p3.QT = "player4"; p4.QT = "player4"; p4.EO = p4.EO + 1; }
                                    occ3 = false;
                                    esc = true;
                                }
                                else if (estate == "TC")
                                {
                                    p1.TCH = 0; p2.TCH = 0; p3.TCH = 0; p4.TCH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 150; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 150; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 150; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 150; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 160; p1.TC = "player1"; p2.TC = "player1"; p3.TC = "player1"; p4.TC = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 160; p1.TC = "player2"; p2.TC = "player2"; p3.TC = "player2"; p4.TC = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 160; p1.TC = "player3"; p2.TC = "player3"; p3.TC = "player3"; p4.TC = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 160; p1.TC = "player4"; p2.TC = "player4"; p3.TC = "player4"; p4.TC = "player4"; p4.EO = p4.EO + 1; }
                                    occ4 = false;
                                    esc = true;
                                }
                                else if (estate == "HVT")
                                {
                                    p1.HVTH = 0; p2.HVTH = 0; p3.HVTH = 0; p4.HVTH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 170; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 170; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 170; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 170; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 180; p1.HVT = "player1"; p2.HVT = "player1"; p3.HVT = "player1"; p4.HVT = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 180; p1.HVT = "player2"; p2.HVT = "player2"; p3.HVT = "player2"; p4.HVT = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 180; p1.HVT = "player3"; p2.HVT = "player3"; p3.HVT = "player3"; p4.HVT = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 180; p1.HVT = "player4"; p2.HVT = "player4"; p3.HVT = "player4"; p4.HVT = "player4"; p4.EO = p4.EO + 1; }
                                    occ5 = false;
                                    esc = true;
                                }
                                else if (estate == "KVC")
                                {
                                    p1.KVCH = 0; p2.KVCH = 0; p3.KVCH = 0; p4.KVCH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 190; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 190; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 190; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 190; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 200; p1.KVC = "player1"; p2.KVC = "player1"; p3.KVC = "player1"; p4.KVC = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 200; p1.KVC = "player2"; p2.KVC = "player2"; p3.KVC = "player2"; p4.KVC = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 200; p1.KVC = "player3"; p2.KVC = "player3"; p3.KVC = "player3"; p4.KVC = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 200; p1.KVC = "player4"; p2.KVC = "player4"; p3.KVC = "player4"; p4.KVC = "player4"; p4.EO = p4.EO + 1; }
                                    occ6 = false;
                                    esc = true;
                                }
                                else if (estate == "HV")
                                {
                                    p1.HVH = 0; p2.HVH = 0; p3.HVH = 0; p4.HVH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 230; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 230; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 230; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 230; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 240; p1.HV = "player1"; p2.HV = "player1"; p3.HV = "player1"; p4.HV = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 240; p1.HV = "player2"; p2.HV = "player2"; p3.HV = "player2"; p4.HV = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 240; p1.HV = "player3"; p2.HV = "player3"; p3.HV = "player3"; p4.HV = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 240; p1.HV = "player4"; p2.HV = "player4"; p3.HV = "player4"; p4.HV = "player4"; p4.EO = p4.EO + 1; }
                                    occ7 = false;
                                    esc = true;
                                }
                                else if (estate == "NT")
                                {
                                    p1.NTH = 0; p2.NTH = 0; p3.NTH = 0; p4.NTH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 250; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 250; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 250; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 250; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 260; p1.NT = "player1"; p2.NT = "player1"; p3.NT = "player1"; p4.NT = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 260; p1.NT = "player2"; p2.NT = "player2"; p3.NT = "player2"; p4.NT = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 260; p1.NT = "player3"; p2.NT = "player3"; p3.NT = "player3"; p4.NT = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 260; p1.NT = "player4"; p2.NT = "player4"; p3.NT = "player4"; p4.NT = "player4"; p4.EO = p4.EO + 1; }
                                    occ8 = false;
                                    esc = true;
                                }
                                else if (estate == "PNL")
                                {
                                    p1.PNLH = 0; p2.PNLH = 0; p3.PNLH = 0; p4.PNLH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 270; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 270; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 270; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 270; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 280; p1.PNL = "player1"; p2.PNL = "player1"; p3.PNL = "player1"; p4.PNL = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 280; p1.PNL = "player2"; p2.PNL = "player2"; p3.PNL = "player2"; p4.PNL = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 280; p1.PNL = "player3"; p2.PNL = "player3"; p3.PNL = "player3"; p4.PNL = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 280; p1.PNL = "player4"; p2.PNL = "player4"; p3.PNL = "player4"; p4.PNL = "player4"; p4.EO = p4.EO + 1; }
                                    occ9 = false;
                                    esc = true;
                                }
                                else if (estate == "VTS")
                                {
                                    p1.VTSH = 0; p2.VTSH = 0; p3.VTSH = 0; p4.VTSH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 310; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 310; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 310; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 310; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 320; p1.VTS = "player1"; p2.VTS = "player1"; p3.VTS = "player1"; p4.VTS = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 320; p1.VTS = "player2"; p2.VTS = "player2"; p3.VTS = "player2"; p4.VTS = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 320; p1.VTS = "player3"; p2.VTS = "player3"; p3.VTS = "player3"; p4.VTS = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 320; p1.VTS = "player4"; p2.VTS = "player4"; p3.VTS = "player4"; p4.VTS = "player4"; p4.EO = p4.EO + 1; }
                                    occ10 = false;
                                    esc = true;
                                }
                                else if (estate == "LL")
                                {
                                    p1.LLH = 0; p2.LLH = 0; p3.LLH = 0; p4.LLH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 310; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 310; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 310; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 310; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 320; p1.LL = "player1"; p2.LL = "player1"; p3.LL = "player1"; p4.LL = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 320; p1.LL = "player2"; p2.LL = "player2"; p3.LL = "player2"; p4.LL = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 320; p1.LL = "player3"; p2.LL = "player3"; p3.LL = "player3"; p4.LL = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 320; p1.LL = "player4"; p2.LL = "player4"; p3.LL = "player4"; p4.LL = "player4"; p4.EO = p4.EO + 1; }
                                    occ11 = false;
                                    esc = true;
                                }
                                else if (estate == "NH")
                                {
                                    p1.NHH = 0; p2.NHH = 0; p3.NHH = 0; p4.NHH = 0;
                                    if (seller == "1" || seller == name1.ToLower() || seller == b1.ToLower()) { p1.Money = p1.Money + 370; p1.EO = p1.EO - 1; }
                                    if (seller == "2" || seller == name2.ToLower() || seller == b2.ToLower()) { p2.Money = p2.Money + 370; p2.EO = p2.EO - 1; }
                                    if (seller == "3" || seller == name3.ToLower() || seller == b3.ToLower()) { p3.Money = p3.Money + 370; p3.EO = p3.EO - 1; }
                                    if (seller == "4" || seller == name4.ToLower() || seller == b4.ToLower()) { p4.Money = p4.Money + 370; p4.EO = p4.EO - 1; }

                                    if (buyer == "1" || buyer == name1.ToLower() || buyer == b1.ToLower()) { p1.Money = p1.Money - 380; p1.NH = "player1"; p2.NH = "player1"; p3.NH = "player1"; p4.NH = "player1"; p1.EO = p1.EO + 1; }
                                    if (buyer == "2" || buyer == name2.ToLower() || buyer == b2.ToLower()) { p2.Money = p2.Money - 380; p1.NH = "player2"; p2.NH = "player2"; p3.NH = "player2"; p4.NH = "player2"; p2.EO = p2.EO + 1; }
                                    if (buyer == "3" || buyer == name3.ToLower() || buyer == b3.ToLower()) { p3.Money = p3.Money - 380; p1.NH = "player3"; p2.NH = "player3"; p3.NH = "player3"; p4.NH = "player3"; p3.EO = p3.EO + 1; }
                                    if (buyer == "4" || buyer == name4.ToLower() || buyer == b4.ToLower()) { p4.Money = p4.Money - 380; p1.NH = "player4"; p2.NH = "player4"; p3.NH = "player4"; p4.NH = "player4"; p4.EO = p4.EO + 1; }
                                    occ12 = false;
                                    esc = true;
                                }
                                else
                                {
                                    Console.WriteLine("Unidentified buyer's, seller's or estate's name. Please try again later.");
                                    esc = true;
                                }
                            }
                            else if (option == "C" || option == "c")
                            {
                                esc = true;
                            }
                            else
                            {
                                Console.WriteLine("Wrong key typo, but I will assume you have cancelled it.");
                                esc = true;
                            }
                        }
                    }

                    // Change marker's outline color
                    board.Marker1Color(p1.EO, p2.EO, p3.EO, p4.EO, p1.Prisoned, p1.Money);
                    board.Marker2Color(p1.EO, p2.EO, p3.EO, p4.EO, p2.Prisoned, p2.Money);
                    board.Marker3Color(p1.EO, p2.EO, p3.EO, p4.EO, p3.Prisoned, p3.Money);
                    board.Marker4Color(p1.EO, p2.EO, p3.EO, p4.EO, p4.Prisoned, p4.Money);

                    gameWindow.Refresh(100);
                    SplashKit.ProcessEvents();
                }
            }
        }
        

        static bool IsMouseInRectangle(Point2D mousePos, double x, double y, double width, double height)
        {
            return (mousePos.X >= x && mousePos.X <= x + width && mousePos.Y >= y && mousePos.Y <= y + height);
        }
    }

    public enum PlayerType
    {
        X,
        O,
        Z,
        W,
        Empty
    }
}