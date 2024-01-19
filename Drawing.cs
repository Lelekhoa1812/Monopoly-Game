using SplashKitSDK;
using static System.Net.Mime.MediaTypeNames;

namespace MonopolyGame
{
    public class Drawing
    {
        private Color _gridColor = Color.Black;

        private Color marker1;//= Color.Black;
        private Color marker2;//= Color.Black;
        private Color marker3;//= Color.Black;
        private Color marker4;//= Color.Black;

        private Color m1;
        private Color m2;
        private Color m3;
        private Color m4;

        public void DrawBoard(Window gameWindow)
        {
            gameWindow.FillRectangle(Color.White, 0, 0, 1000, 600);
            // Draw the corner squares
            DrawCornerSquare(gameWindow, 200, 500);
            SplashKit.DrawText("Start and Go", Color.OrangeRed, "Arial", 72, 200 + 3, 500 + 45);
            DrawCornerSquare(gameWindow, 700, 500);
            SplashKit.DrawText("Go to Jail", Color.OrangeRed, "Arial", 72, 700 + 12, 500 + 45);
            DrawCornerSquare(gameWindow, 200, 0);
            SplashKit.DrawText("Investment", Color.OrangeRed, "Arial", 72, 200 + 12, 0 + 45);
            DrawCornerSquare(gameWindow, 700, 0);
            SplashKit.DrawText("Free Parking", Color.OrangeRed, "Arial", 72, 700 + 3, 0 + 45);

            // Draw street component sets:
            // Math: 100 + 66.67*(row/col) [+200 for horizontal]
            // Street set 1: Sienna, DarkOrange
            SplashKit.DrawText("Luy Ban Bich", Color.Sienna, "Arial", 72, 200 + 3, 458); SplashKit.DrawText("$60", Color.Sienna, "Arial", 72, 200 + 38, 473);

            SplashKit.DrawText("Cong Hoa", Color.DarkOrange, "Arial", 72, 200 + 18, 259.34); SplashKit.DrawText("$100", Color.DarkOrange, "Arial", 72, 200 + 33, 274.34);
            SplashKit.DrawText("Quang Trung", Color.DarkOrange, "Arial", 72, 200 + 8, 125); SplashKit.DrawText("$120", Color.DarkOrange, "Arial", 72, 200 + 33, 140);

            // Street set 2: Goldenrod, LimeGreen
            SplashKit.DrawText("Truong", Color.Goldenrod, "Arial", 72, 367.67 + 10, 30); SplashKit.DrawText("Chinh", Color.Goldenrod, "Arial", 72, 367.67 + 14, 45); SplashKit.DrawText("$160", Color.Goldenrod, "Arial", 72, 367.67 + 16, 60);

            SplashKit.DrawText("Hoang", Color.LimeGreen, "Arial", 72, 500.01 + 14, 30); SplashKit.DrawText("Van Thu", Color.LimeGreen, "Arial", 72, 500.01 + 8, 45); SplashKit.DrawText("$180", Color.LimeGreen, "Arial", 72, 500.01 + 16, 60);
            SplashKit.DrawText("Kha", Color.LimeGreen, "Arial", 72, 633.35 + 22, 30); SplashKit.DrawText("Van Can", Color.LimeGreen, "Arial", 72, 633.35 + 8, 45); SplashKit.DrawText("$200", Color.LimeGreen, "Arial", 72, 633.35 + 16, 60);

            // Street set 3: Green, DarkCyan
            SplashKit.DrawText("Hung Vuong", Color.Green, "Arial", 72, 700 + 11, 125); SplashKit.DrawText("$240", Color.Green, "Arial", 72, 700 + 33, 140);

            SplashKit.DrawText("Nguyen Trai", Color.DarkCyan, "Arial", 72, 700 + 8, 330.01); SplashKit.DrawText("$260", Color.DarkCyan, "Arial", 72, 700 + 33, 345);
            SplashKit.DrawText("Pham Ngu Lao", Color.DarkCyan, "Arial", 72, 700 + 3, 463); SplashKit.DrawText("$280", Color.DarkCyan, "Arial", 72, 700 + 33, 478);

            // Street set 4:  DeepSkyBlue, Purple
            SplashKit.DrawText("Vo", Color.DeepSkyBlue, "Arial", 72, 565.68 + 27.5, 530); SplashKit.DrawText("Thi Sau", Color.DeepSkyBlue, "Arial", 72, 566.68 + 7, 545); SplashKit.DrawText("$320", Color.DeepSkyBlue, "Arial", 72, 567.68 + 16, 560);

            SplashKit.DrawText("Le Loi", Color.Purple, "Arial", 72, 433.34 + 11, 540); SplashKit.DrawText("$360", Color.Purple, "Arial", 72, 433.34 + 16, 555);
            SplashKit.DrawText("Nguyen", Color.Purple, "Arial", 72, 300 + 10, 530); SplashKit.DrawText("Hue", Color.Purple, "Arial", 72, 300 + 20, 545); SplashKit.DrawText("$380", Color.Purple, "Arial", 72, 300 + 16, 560);

            // Draw external component sets:
            // Bus stops: DarkBlue
            SplashKit.DrawText("Ben Xe", Color.DarkBlue, "Arial", 72, 200 + 26, 300 + 20); SplashKit.DrawText("Can Giuoc", Color.DarkBlue, "Arial", 72, 200 + 16, 300 + 35); SplashKit.DrawText("$100", Color.DarkBlue, "Arial", 72, 200 + 33, 300 + 50);
            SplashKit.DrawText("Ben Xe", Color.DarkBlue, "Arial", 72, 700 + 26, 233.34 + 20); SplashKit.DrawText("Mien Dong", Color.DarkBlue, "Arial", 72, 700 + 16, 233.34 + 35); SplashKit.DrawText("$100", Color.DarkBlue, "Arial", 72, 700 + 33, 233.34 + 50);
            SplashKit.DrawText("Ben Xe", Color.DarkBlue, "Arial", 72, 433.34 + 12.5, 30); SplashKit.DrawText("Cho Lon", Color.DarkBlue, "Arial", 72, 433.34 + 7.5, 45); SplashKit.DrawText("$100", Color.DarkBlue, "Arial", 72, 433.34 + 16, 60);
            SplashKit.DrawText("Ben Xe", Color.DarkBlue, "Arial", 72, 500.01 + 12.5, 530); SplashKit.DrawText("Mien Tay", Color.DarkBlue, "Arial", 72, 500.01 + 2, 545); SplashKit.DrawText("$100", Color.DarkBlue, "Arial", 72, 500.01 + 16, 560);

            // Chances, Luck and Opportuinities: DeepPink, IndianRed and DarkGray
            SplashKit.DrawText("Taxes Fee", Color.DarkGray, "Arial", 72, 200 + 14, 366.68 + 25); SplashKit.DrawText("Loss $100", Color.DarkGray, "Arial", 72, 200 + 14.5, 366.68 + 40);
            SplashKit.DrawText("Chance", Color.DeepPink, "Arial", 72, 200 + 28, 166.67 + 25); SplashKit.DrawText("Random?", Color.DeepPink, "Arial", 72, 200 + 24, 166.67 + 40);
            SplashKit.DrawText("Chance", Color.DeepPink, "Arial", 72, 700 + 28, 366.68 + 25); SplashKit.DrawText("Random?", Color.DeepPink, "Arial", 72, 700 + 24, 366.68 + 40);
            SplashKit.DrawText("Luck", Color.IndianRed, "Arial", 72, 566.68 + 17.5, 40); SplashKit.DrawText("Random!", Color.IndianRed, "Arial", 72, 566.68 + 8, 55);
            SplashKit.DrawText("Luck", Color.IndianRed, "Arial", 72, 366.67 + 17.5, 540); SplashKit.DrawText("Random!", Color.IndianRed, "Arial", 72, 366.67 + 8, 555);
            SplashKit.DrawText("Get a Job", Color.DarkGray, "Arial", 72, 700 + 12.5, 166.67 + 25); SplashKit.DrawText("Gain $100", Color.DarkGray, "Arial", 72, 700 + 14.5, 166.67 + 40);

            // Companies: CornflowerBlue
            SplashKit.DrawText("Cong Ty", Color.CornflowerBlue, "Arial", 72, 300 + 7, 30); SplashKit.DrawText("Dien Luc", Color.CornflowerBlue, "Arial", 72, 300 + 2, 45); SplashKit.DrawText("$100", Color.CornflowerBlue, "Arial", 72, 300 + 16, 60);
            SplashKit.DrawText("Cong Ty", Color.CornflowerBlue, "Arial", 72, 633.35 + 7, 530); SplashKit.DrawText("Cap Nuoc", Color.CornflowerBlue, "Arial", 72, 633.35 + 2, 545); SplashKit.DrawText("$100", Color.CornflowerBlue, "Arial", 72, 633.35 + 16, 560);

            // Draw the gameboard grids 
            DrawGrid1(gameWindow, 200, 100, 600, 400);
            DrawGrid2(gameWindow, 300, 0, 400, 600);
            DrawGrid3(gameWindow, 200, 0, 600, 599);
            DrawDiceGrid(gameWindow, 430, 420, 50, 50);
            DrawDiceGrid(gameWindow, 520, 420, 50, 50);

            // Draw a square in the middle of the board
            DrawMiddleSquare(gameWindow, 301, 101);
            SplashKit.DrawText("Monopoly Game made by Khoa Le", Color.SwinburneRed, "Arial", 1000, 385, 300);

            // Draw dice grid
            gameWindow.FillRectangle(Color.White, 430, 420, 50, 50);
            gameWindow.FillRectangle(Color.White, 518, 420, 50, 50);
            DrawDiceGrid(gameWindow, 430, 420, 50, 50);
            DrawDiceGrid(gameWindow, 518, 420, 50, 50);

        }

        public void ChangeGridColor()
        {
            _gridColor = SplashKit.RandomRGBColor(255);
        }

        // Change marker's outline color
        public void Marker1Color(int eo1, int eo2, int eo3, int eo4, bool pris1, int money1)
        {
            if ((eo1 > eo2) && (eo1 > eo3) && (eo1 > eo4) && !pris1 && (money1 >= -100))
            {
                marker1 = Color.BlueViolet;
            }
            if (pris1 && (money1 >= -100))
            {
                marker1 = Color.Orange;
            }
            else if ((!(eo1 > eo2) || !(eo1 > eo3) || !(eo1 > eo4)) && !pris1 && (money1 >= -100))
            {
                marker1 = Color.Black;
            }
            else if (money1 < -100)
            {
                marker1 = Color.DarkGray;
            }
        }
        public void Marker2Color(int eo1, int eo2, int eo3, int eo4, bool pris2, int money2)
        {
            if ((eo2 > eo1) && (eo2 > eo3) && (eo2 > eo4) && !pris2 && (money2 >= -100))
            {
                marker2 = Color.BlueViolet;
            }
            if (pris2 && (money2 >= -100))
            {
                marker2 = Color.Orange;
            }
            else if ((!(eo2 > eo1) || !(eo2 > eo3) || !(eo2 > eo4)) && !pris2 && (money2 >= -100))
            {
                marker2 = Color.Black;
            }
            else if (money2 < -100)
            {
                marker2 = Color.DarkGray;
            }
        }
        public void Marker3Color(int eo1, int eo2, int eo3, int eo4, bool pris3, int money3)
        {
            if ((eo3 > eo1) && (eo3 > eo2) && (eo3 > eo4) && !pris3 && (money3 >= -100))
            {
                marker3 = Color.BlueViolet;
            }
            if (pris3 && (money3 >= -100))
            {
                marker3 = Color.Orange;
            }
            else if ((!(eo3 > eo1) || !(eo3 > eo2) || !(eo3 > eo4)) && !pris3 && (money3 >= -100))
            {
                marker3 = Color.Black;
            }
            else if (money3 < -100)
            {
                marker3 = Color.DarkGray;
            }
        }
        public void Marker4Color(int eo1, int eo2, int eo3, int eo4, bool pris4, int money4)
        {
            if ((eo4 > eo1) && (eo4 > eo2) && (eo4 > eo3) && !pris4 && (money4 >= -100))
            {
                marker4 = Color.BlueViolet;
            }
            if (pris4 && (money4 >= -100))
            {
                marker4 = Color.Orange;
            }
            else if ((!(eo4 > eo1) || !(eo4 > eo2) || !(eo4 > eo3)) && !pris4 && (money4 >= -100))
            {
                marker4 = Color.Black;
            }
            else if (money4 < -100)
            {
                marker4 = Color.DarkGray;
            }
        }

        // Set marker's colorway
        public void CheckMarkerColor1(string col1)
        {
            if (col1 == "1")
            {
                m1 = Color.Lavender;
            }
            if (col1 == "2")
            {
                m1 = Color.LightCoral;
            }
            if (col1 == "3")
            {
                m1 = Color.LightSeaGreen;
            }
            if (col1 == "4")
            {
                m1 = Color.BlanchedAlmond;
            }
            if (col1 == "5")
            {
                m1 = Color.LightPink;
            }
            if (col1 == "6")
            {
                m1 = Color.CornflowerBlue;
            }
            /*else
            {
                m1 = Color.Lavender;
            }*/
        }
        public void CheckMarkerColor2(string col2)
        {
            if (col2 == "1")
            {
                m2 = Color.Lavender;
            }
            if (col2 == "2")
            {
                m2 = Color.LightCoral;
            }
            if (col2 == "3")
            {
                m2 = Color.LightSeaGreen;
            }
            if (col2 == "4")
            {
                m2 = Color.BlanchedAlmond;
            }
            if (col2 == "5")
            {
                m2 = Color.LightPink;
            }
            if (col2 == "6")
            {
                m2 = Color.CornflowerBlue;
            }
            /*else
            {
                m2 = Color.LightCoral;
            }*/
        }
        public void CheckMarkerColor3(string col3)
        {
            if (col3 == "1")
            {
                m3 = Color.Lavender;
            }
            if (col3 == "2")
            {
                m3 = Color.LightCoral;
            }
            if (col3 == "3")
            {
                m3 = Color.LightSeaGreen;
            }
            if (col3 == "4")
            {
                m3 = Color.BlanchedAlmond;
            }
            if (col3 == "5")
            {
                m3 = Color.LightPink;
            }
            if (col3 == "6")
            {
                m3 = Color.CornflowerBlue;
            }
            /*else
            {
                m3 = Color.LightSeaGreen;
            }*/
        }
        public void CheckMarkerColor4(string col4)
        {
            if (col4 == "1")
            {
                m4 = Color.Lavender;
            }
            if (col4 == "2")
            {
                m4 = Color.LightCoral;
            }
            if (col4 == "3")
            {
                m4 = Color.LightSeaGreen;
            }
            if (col4 == "4")
            {
                m4 = Color.BlanchedAlmond;
            }
            if (col4 == "5")
            {
                m4 = Color.LightPink;
            }
            if (col4 == "6")
            {
                m4 = Color.CornflowerBlue;
            }
            /*else
            {
                m4 = Color.BlanchedAlmond;
            }*/
        }
        // Draw the game horizontal grids
        public void DrawGrid1(Window gameWindow, double x, double y, double width, double height)
        {
            int rows = 6; 
            int cols = 6; 

            // Calculate the spacing between lines
            double rowSpacing = height / rows;
            double colSpacing = width / cols;

            // Draw horizontal lines
            for (int i = 0; i <= rows; i++)
            {
                double lineY = y + i * rowSpacing;
                gameWindow.DrawLine(_gridColor, x, lineY, x + width, lineY);
            }

            // Draw vertical lines
            for (int i = 0; i <= cols; i++)
            {
                double lineX = x + i * colSpacing;
                gameWindow.DrawLine(_gridColor, lineX, y, lineX, y + height);
            }
        }

        // Draw the game vertical grids
        public void DrawGrid2(Window gameWindow, double x, double y, double width, double height)
        {
            int rows = 6;
            int cols = 6;

            // Calculate the spacing between lines
            double rowSpacing = height / rows;
            double colSpacing = width / cols;

            // Draw horizontal lines
            for (int i = 0; i <= rows; i++)
            {
                double lineY = y + i * rowSpacing;
                gameWindow.DrawLine(_gridColor, x, lineY, x + width, lineY);
            }

            // Draw vertical lines
            for (int i = 0; i <= cols; i++)
            {
                double lineX = x + i * colSpacing;
                gameWindow.DrawLine(_gridColor, lineX, y, lineX, y + height);
            }
        }

        // Draw outline grid for the board
        public void DrawGrid3(Window gameWindow, double x, double y, double width, double height)
        {
            int rows = 1;
            int cols = 1;

            // Calculate the spacing between lines
            double rowSpacing = height / rows;
            double colSpacing = width / cols;

            // Draw horizontal lines
            for (int i = 0; i <= rows; i++)
            {
                double lineY = y + i * rowSpacing;
                gameWindow.DrawLine(_gridColor, x, lineY, x + width, lineY);
            }

            // Draw vertical lines
            for (int i = 0; i <= cols; i++)
            {
                double lineX = x + i * colSpacing;
                gameWindow.DrawLine(_gridColor, lineX, y, lineX, y + height);
            }
        }

        public void DrawDiceGrid(Window gameWindow, double x, double y, double width, double height)
        {
            int rows = 1;
            int cols = 1;

            // Calculate the spacing between lines
            double rowSpacing = height / rows;
            double colSpacing = width / cols;

            // Draw horizontal lines
            for (int i = 0; i <= rows; i++)
            {
                double lineY = y + i * rowSpacing;
                gameWindow.DrawLine(_gridColor, x, lineY, x + width, lineY);
            }

            // Draw vertical lines
            for (int i = 0; i <= cols; i++)
            {
                double lineX = x + i * colSpacing;
                gameWindow.DrawLine(_gridColor, lineX, y, lineX, y + height);
            }
        }

        public void DrawCornerSquare(Window gameWindow, double x, double y)
        {
            gameWindow.FillRectangle(Color.LightSkyBlue, x, y, 100, 100);
        }

        public void DrawMiddleSquare(Window gameWindow, double x, double y)
        {
            gameWindow.FillRectangle(Color.LightGreen, x, y, 399, 399);
        }

        // Method handle dice drawing
        public void DrawDice(Window gameWindow, double x, double y, int diceValue)
        {
            gameWindow.FillRectangle(Color.White, x+1, y+1, 49, 49);

            double dotSize = 10;
            double dotX = x + 5;
            double dotY = y + 5;

            switch (diceValue)
            {
                case 1:
                    DrawDot(gameWindow, dotX + 15, dotY + 15, dotSize, Color.Red);
                    break;
                case 2:
                    DrawDot(gameWindow, dotX + 5, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 25, dotSize, Color.Blue);
                    break;
                case 3:
                    DrawDot(gameWindow, dotX + 5, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 15, dotY + 15, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 25, dotSize, Color.Blue);
                    break;
                case 4:
                    DrawDot(gameWindow, dotX + 5, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 5, dotY + 25, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 25, dotSize, Color.Blue);
                    break;
                case 5:
                    DrawDot(gameWindow, dotX + 5, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 5, dotY + 25, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 25, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 15, dotY + 15, dotSize, Color.Blue);
                    break;
                case 6:
                    DrawDot(gameWindow, dotX + 5, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 5, dotY + 15, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 5, dotY + 25, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 5, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 15, dotSize, Color.Blue);
                    DrawDot(gameWindow, dotX + 25, dotY + 25, dotSize, Color.Blue);
                    break;
            }
        }

        private void DrawDot(Window gameWindow, double x, double y, double size, Color color)
        {
            gameWindow.FillEllipse(color, x, y, size, size);
        }

        public void DrawPlayersVitals(Window gameWindow, string name1, string name2, string name3, string name4, string stat1, string stat2, string stat3, string stat4)
        {
            gameWindow.FillRectangle(m1, 0, 0, 150, 80);
            gameWindow.FillRectangle(m2, 0, 520, 150, 80);
            gameWindow.FillRectangle(m3, 850, 0, 150, 80);
            gameWindow.FillRectangle(m4, 850, 520, 150, 80);

            // Lavender Vitals
            SplashKit.DrawText($"Player: {name1}", Color.Black, "Arial", 1000, 20, 15);
            SplashKit.DrawText($"Status: {stat1}", Color.Black, "Arial", 1000, 20, 45);

            // LightCoral Vitals
            SplashKit.DrawText($"Player: {name2}", Color.Black, "Arial", 1000, 20, 535);
            SplashKit.DrawText($"Status: {stat2}", Color.Black, "Arial", 1000, 20, 565);

            // LightSeaGreen Vitals
            SplashKit.DrawText($"Player: {name3}", Color.Black, "Arial", 1000, 870, 15);
            SplashKit.DrawText($"Status: {stat3}", Color.Black, "Arial", 1000, 870, 45);

            // BlanchedAlmond Vitals
            SplashKit.DrawText($"Player: {name4}", Color.Black, "Arial", 1000, 870, 535);
            SplashKit.DrawText($"Status: {stat4}", Color.Black, "Arial", 1000, 870, 565);
        }

        public void DrawMoney(int money1, int money2, int money3, int money4)
        {
            SplashKit.DrawText($"Money: {money1}", Color.Black, "Arial", 1000, 20, 30);
            SplashKit.DrawText($"Money: {money2}", Color.Black, "Arial", 1000, 20, 550);
            SplashKit.DrawText($"Money: {money3}", Color.Black, "Arial", 1000, 870, 30);
            SplashKit.DrawText($"Money: {money4}", Color.Black, "Arial", 1000, 870, 550);
        }

        public void DrawPlayerPosition(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            SplashKit.DrawText($"Position ({x1},{y1})", Color.Black, "Arial", 1000, 20, 60);
            SplashKit.DrawText($"Position ({x2},{y2})", Color.Black, "Arial", 1000, 20, 580);
            SplashKit.DrawText($"Position ({x3},{y3})", Color.Black, "Arial", 1000, 870, 60);
            SplashKit.DrawText($"Position ({x4},{y4})", Color.Black, "Arial", 1000, 870, 580);
        }

        public void NoPosition()
        {
            SplashKit.DrawText($"You are P1", Color.Black, "Arial", 1000, 20, 60);
            SplashKit.DrawText($"You are P2", Color.Black, "Arial", 1000, 20, 580);
            SplashKit.DrawText($"You are P3", Color.Black, "Arial", 1000, 870, 60);
            SplashKit.DrawText($"You are P4", Color.Black, "Arial", 1000, 870, 580);
        }

        public void DrawStreet (string lbb, string ch, string qt, string tc, string hvt, string kvc, string hv, string nt, string pnl, string vts, string ll, string nh, int lbbh, int chh, int qth, int tch, int hvth, int kvch, int hvh, int nth, int pnlh, int vtsh, int llh, int nhh)
        {
            SplashKit.DrawText($"LBB: {lbb}, house: {lbbh}", Color.Black, "Arial", 10, 5, 120);
            SplashKit.DrawText($"CH: {ch}, house: {chh}", Color.Black, "Arial", 10, 5, 150);
            SplashKit.DrawText($"QT: {qt}, house: {qth}", Color.Black, "Arial", 10, 5, 180);
            SplashKit.DrawText($"TC: {tc}, house: {tch}", Color.Black, "Arial", 10, 5, 210);
            SplashKit.DrawText($"HVT: {hvt}, house: {hvth}", Color.Black, "Arial", 10, 5, 240);
            SplashKit.DrawText($"KVC: {kvc}, house: {kvch}", Color.Black, "Arial", 10, 5, 270);
            SplashKit.DrawText($"HV: {hv}, house: {hvh}", Color.Black, "Arial", 10, 5, 300);
            SplashKit.DrawText($"NT: {nt}, house: {nth}", Color.Black, "Arial", 10, 5, 330);
            SplashKit.DrawText($"PNL: {pnl}, house: {pnlh}", Color.Black, "Arial", 10, 5, 360);
            SplashKit.DrawText($"VTS: {vts}, house: {vtsh}", Color.Black, "Arial", 10, 5, 390);
            SplashKit.DrawText($"LL: {ll}, house: {llh}", Color.Black, "Arial", 10, 5, 420);
            SplashKit.DrawText($"NH: {nh}, house: {nhh}", Color.Black, "Arial", 10, 5, 450);
        }

        public void DrawCom(string bxcg, string bxcl, string bxmd, string bxmt, string ctdl, string ctcn)
        {
            SplashKit.DrawText($"BXCG: {bxcg}", Color.Black, "Arial", 10, 885, 210);
            SplashKit.DrawText($"BXCL: {bxcl}", Color.Black, "Arial", 10, 885, 240);
            SplashKit.DrawText($"BXMD: {bxmd}", Color.Black, "Arial", 10, 885, 270);
            SplashKit.DrawText($"BXMT: {bxmt}", Color.Black, "Arial", 10, 885, 300);
            SplashKit.DrawText($"CTDL: {ctdl}", Color.Black, "Arial", 10, 885, 330);
            SplashKit.DrawText($"CTCN: {ctcn}", Color.Black, "Arial", 10, 885, 360);
        }

        public void DrawP1(int X, int Y, int m, string s)
        {
            int x = 205; int y = 505;

            // Up
            if (X == 0 && Y >= 0 && Y < 7)
            {
                if (Y == 0)
                {
                    x = 205; y = 505;
                }

                if (Y == 1)
                {
                    x = 205; y = 438; 
                }

                if (Y == 2)
                {
                    x = 205; y = 372;
                }

                if (Y == 3)
                {
                    x = 205; y = 305;
                }

                if (Y == 4)
                {
                    x = 205; y = 238;
                }

                if (Y == 5)
                {
                    x = 205; y = 172;
                }

                if (Y == 6)
                {
                    x = 205; y = 105;
                }
            }
            // Right
            if (X >= 0 && Y == 7 && X < 7)
            {
                if (X == 0)
                {
                    x = 205; y = 5;
                }

                if (X == 1)
                {
                    x = 305; y = 5;
                }

                if (X == 2)
                {
                    x = 372; y = 5;
                }

                if (X == 3)
                {
                    x = 438; y = 5;
                }

                if (X == 4)
                {
                    x = 505; y = 5;
                }

                if (X == 5)
                {
                    x = 572; y = 5;
                }

                if (X == 6)
                {
                    x = 638; y = 5;
                }
            }
            // Down
            if (X == 7 && Y <= 7 && Y > 0)
            {
               if (Y == 7)
                {
                    x = 705; y = 5;
                }

                if (Y == 6)
                {
                    x = 705; y = 105;
                }

                if (Y == 5)
                {
                    x = 705; y = 172;
                }

                if (Y == 4)
                {
                    x = 705; y = 238;
                }

                if (Y == 3)
                {
                    x = 705; y = 305;
                }

                if (Y == 2)
                {
                    x = 705; y = 372;
                }

                if (Y == 1)
                {
                    x = 705; y = 438;
                }
            }
            // Left
            if (X <= 7 && Y == 0 && X > 0)
            {
                if (X == 7)
                {
                    x = 705; y = 505;
                }

                if (X == 6)
                {
                    x = 638; y = 505;
                }

                if (X == 5)
                {
                    x = 572; y = 505;
                }

                if (X == 4)
                {
                    x = 505; y = 505;
                }

                if (X == 3)
                {
                    x = 438; y = 505;
                }

                if (X == 2)
                {
                    x = 372; y = 505;
                }

                if (X == 1)
                {
                    x = 305; y = 505;
                }
            }

            SplashKit.FillCircle(m1, x + 10, y + 10, 12);
            SplashKit.DrawCircle(marker1, x + 10, y + 10, 12);
        }

        public void DrawP2(int X, int Y, int m, string s)
        {
            int x = 205; int y = 575;

            // Up
            if (X == 0 && Y >= 0 && Y < 7)
            {
                if (Y == 0)
                {
                    x = 205; y = 575;
                }

                if (Y == 1)
                {
                    x = 205; y = 475;
                }

                if (Y == 2)
                {
                    x = 205; y = 408;
                }

                if (Y == 3)
                {
                    x = 205; y = 342;
                }

                if (Y == 4)
                {
                    x = 205; y = 275;
                }

                if (Y == 5)
                {
                    x = 205; y = 208;
                }

                if (Y == 6)
                {
                    x = 205; y = 142;
                }
            }
            // Right
            if (X >= 0 && Y == 7 && X < 7)
            {
                if (X == 0)
                {
                    x = 205; y = 75;
                }

                if (X == 1)
                {
                    x = 305; y = 75;
                }

                if (X == 2)
                {
                    x = 372; y = 75;
                }

                if (X == 3)
                {
                    x = 438; y = 75;
                }

                if (X == 4)
                {
                    x = 505; y = 75;
                }

                if (X == 5)
                {
                    x = 572; y = 75;
                }

                if (X == 6)
                {
                    x = 638; y = 75;
                }
            }
            // Down
            if (X == 7 && Y <= 7 && Y > 0)
            {
                if (Y == 7)
                {
                    x = 705; y = 75;
                }

                if (Y == 6)
                {
                    x = 705; y = 142;
                }

                if (Y == 5)
                {
                    x = 705; y = 208;
                }

                if (Y == 4)
                {
                    x = 705; y = 275;
                }

                if (Y == 3)
                {
                    x = 705; y = 342;
                }

                if (Y == 2)
                {
                    x = 705; y = 408;
                }

                if (Y == 1)
                {
                    x = 705; y = 475;
                }
            }
            // Left
            if (X <= 7 && Y == 0 && X > 0)
            {
                if (X == 7)
                {
                    x = 705; y = 575;
                }

                if (X == 6)
                {
                    x = 638; y = 575;
                }

                if (X == 5)
                {
                    x = 572; y = 575;
                }

                if (X == 4)
                {
                    x = 505; y = 575;
                }

                if (X == 3)
                {
                    x = 438; y = 575;
                }

                if (X == 2)
                {
                    x = 372; y = 575;
                }

                if (X == 1)
                {
                    x = 305; y = 575;
                }
            }
            SplashKit.FillCircle(m2, x + 10, y + 10, 12);
            SplashKit.DrawCircle(marker2, x + 10, y + 10, 12);
        }

        public void DrawP3(int X, int Y, int m, string s)
        {
            int x = 275; int y = 505;

            // Up
            if (X == 0 && Y >= 0 && Y < 7)
            {
                if (Y == 0)
                {
                    x = 275; y = 505;
                }

                if (Y == 1)
                {
                    x = 275; y = 438;
                }

                if (Y == 2)
                {
                    x = 275; y = 372;
                }

                if (Y == 3)
                {
                    x = 275; y = 305;
                }

                if (Y == 4)
                {
                    x = 275; y = 238;
                }

                if (Y == 5)
                {
                    x = 275; y = 172;
                }

                if (Y == 6)
                {
                    x = 275; y = 105;
                }
            }
            // Right
            if (X >= 0 && Y == 7 && X < 7)
            {
                if (X == 0)
                {
                    x = 275; y = 5;
                }

                if (X == 1)
                {
                    x = 342; y = 5;
                }

                if (X == 2)
                {
                    x = 408; y = 5;
                }

                if (X == 3)
                {
                    x = 475; y = 5;
                }

                if (X == 4)
                {
                    x = 542; y = 5;
                }

                if (X == 5)
                {
                    x = 608; y = 5;
                }

                if (X == 6)
                {
                    x = 675; y = 5;
                }
            }
            // Down
            if (X == 7 && Y <= 7 && Y > 0)
            {
                if (Y == 7)
                {
                    x = 775; y = 5;
                }

                if (Y == 6)
                {
                    x = 775; y = 105;
                }

                if (Y == 5)
                {
                    x = 775; y = 172;
                }

                if (Y == 4)
                {
                    x = 775; y = 238;
                }

                if (Y == 3)
                {
                    x = 775; y = 305;
                }

                if (Y == 2)
                {
                    x = 775; y = 372;
                }

                if (Y == 1)
                {
                    x = 775; y = 438;
                }
            }
            // Left
            if (X <= 7 && Y == 0 && X > 0)
            {
                if (X == 7)
                {
                    x = 775; y = 505;
                }

                if (X == 6)
                {
                    x = 675; y = 505;
                }

                if (X == 5)
                {
                    x = 608; y = 505;
                }

                if (X == 4)
                {
                    x = 542; y = 505;
                }

                if (X == 3)
                {
                    x = 475; y = 505;
                }

                if (X == 2)
                {
                    x = 408; y = 505;
                }

                if (X == 1)
                {
                    x = 342; y = 505;
                }
            }
            SplashKit.FillCircle(m3, x + 10, y + 10, 12);
            SplashKit.DrawCircle(marker3, x + 10, y + 10, 12);
        }

        public void DrawP4(int X, int Y, int m, string s)
        {
            int x = 275; int y = 575;

            // Up
            if (X == 0 && Y >= 0 && Y < 7)
            {
                if (Y == 0)
                {
                    x = 275; y = 575;
                }

                if (Y == 1)
                {
                    x = 275; y = 475;
                }

                if (Y == 2)
                {
                    x = 275; y = 408;
                }

                if (Y == 3)
                {
                    x = 275; y = 342;
                }

                if (Y == 4)
                {
                    x = 275; y = 275;
                }

                if (Y == 5)
                {
                    x = 275; y = 208;
                }

                if (Y == 6)
                {
                    x = 275; y = 142;
                }
            }
            // Right
            if (X >= 0 && Y == 7 && X < 7)
            {
                if (X == 0)
                {
                    x = 275; y = 75;
                }

                if (X == 1)
                {
                    x = 342; y = 75;
                }

                if (X == 2)
                {
                    x = 408; y = 75;
                }

                if (X == 3)
                {
                    x = 475; y = 75;
                }

                if (X == 4)
                {
                    x = 542; y = 75;
                }

                if (X == 5)
                {
                    x = 608; y = 75;
                }

                if (X == 6)
                {
                    x = 675; y = 75;
                }
            }
            // Down
            if (X == 7 && Y <= 7 && Y > 0)
            {
                if (Y == 7)
                {
                    x = 775; y = 75;
                }

                if (Y == 6)
                {
                    x = 775; y = 142;
                }

                if (Y == 5)
                {
                    x = 775; y = 208;
                }

                if (Y == 4)
                {
                    x = 775; y = 275;
                }

                if (Y == 3)
                {
                    x = 775; y = 342;
                }

                if (Y == 2)
                {
                    x = 775; y = 408;
                }

                if (Y == 1)
                {
                    x = 775; y = 475;
                }
            }
            // Left
            if (X <= 7 && Y == 0 && X > 0)
            {
                if (X == 7)
                {
                    x = 775; y = 575;
                }

                if (X == 6)
                {
                    x = 675; y = 575;
                }

                if (X == 5)
                {
                    x = 608; y = 575;
                }

                if (X == 4)
                {
                    x = 542; y = 575;
                }

                if (X == 3)
                {
                    x = 475; y = 575;
                }

                if (X == 2)
                {
                    x = 408; y = 575;
                }

                if (X == 1)
                {
                    x = 342; y = 575;
                }
            }
            SplashKit.FillCircle(m4, x + 10, y + 10, 12);
            SplashKit.DrawCircle(marker4, x + 10, y + 10, 12);
        }

    }
}
