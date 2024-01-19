using System;
using System.IO;
using System.Xml.Linq;
using SplashKitSDK;

namespace MonopolyGame
{
    public class Player : Object
    {
        // Players' name 
        public string Name { get; set; }

        // Players' money stats
        public int Money { get; set; }

        // Players' estate ownership stats
        public int EO { get; set; }

        // Players' status vitals
        public string Status { get; set; }

        // Players' position
        public int X { get; set; }
        public int Y { get; set; }

        private Random random;

        // Set of boolean checker
        private bool rand1 = false;
        private bool rand2 = false;
        private bool rand3 = false;
        private bool rand4 = false;

        private bool chance1 = false;
        private bool chance2 = false;
        private bool chance3 = false;
        private bool chance4 = false;

        private bool luck1 = false;
        private bool luck2 = false;
        private bool luck3 = false;
        private bool luck4 = false;

        private bool inv1 = false;
        private bool inv2 = false;
        private bool inv3 = false;
        private bool inv4 = false;

        // Game boolean constants
        // House and Street ownwerships
        private bool start = false; private bool st1 = false;
        private bool street1 = false; private bool street2 = false; private bool street3 = false; private bool street4 = false; private bool street5 = false; private bool street6 = false; private bool street7 = false; private bool street8 = false; private bool street9 = false; private bool street10 = false; private bool street11 = false; private bool street12 = false;
        private bool house1 = false; private bool house2 = false; private bool house3 = false; private bool house4 = false; private bool house5 = false; private bool house6 = false; private bool house7 = false; private bool house8 = false; private bool house9 = false; private bool house10 = false; private bool house11 = false; private bool house12 = false;
        private bool occ1 = false; private bool occ2 = false; private bool occ3 = false; private bool occ4 = false; private bool occ5 = false; private bool occ6 = false; private bool occ7 = false; private bool occ8 = false; private bool occ9 = false; private bool occ10 = false; private bool occ11 = false; private bool occ12 = false;
        private bool nohouse1 = false; private bool nohouse2 = false; private bool nohouse3 = false; private bool nohouse4 = false; private bool nohouse5 = false; private bool nohouse6 = false; private bool nohouse7 = false; private bool nohouse8 = false; private bool nohouse9 = false; private bool nohouse10 = false; private bool nohouse11 = false; private bool nohouse12 = false;
        private bool yeshouse1 = false; private bool yeshouse2 = false; private bool yeshouse3 = false; private bool yeshouse4 = false; private bool yeshouse5 = false; private bool yeshouse6 = false; private bool yeshouse7 = false; private bool yeshouse8 = false; private bool yeshouse9 = false; private bool yeshouse10 = false; private bool yeshouse11 = false; private bool yeshouse12 = false;
        // Companies ownerships
        private bool company1 = false; private bool company2 = false; private bool company3 = false; private bool company4 = false; private bool company5 = false; private bool company6 = false;
        private bool com1 = false; private bool com2 = false; private bool com3 = false; private bool com4 = false; private bool com5 = false; private bool com6 = false;

        // Control real estate ownership
        public string LBB { get; set; }
        public string CH { get; set; }
        public string QT { get; set; }
        public string TC { get; set; }
        public string HVT { get; set; }
        public string KVC { get; set; }
        public string HV { get; set; }
        public string NT { get; set; }
        public string PNL { get; set; }
        public string VTS { get; set; }
        public string LL { get; set; }
        public string NH { get; set; }

        // Control service companies ownership
        public string BXCG { get; set; }
        public string BXCL { get; set; }
        public string BXMD { get; set; }
        public string BXMT { get; set; }
        public string CTDL { get; set; }
        public string CTCN { get; set; }

        // Control estate worth total (street + housing cost)
        public int LBBW { get; set; }
        public int CHW { get; set; }
        public int QTW { get; set; }
        public int TCW { get; set; }
        public int HVTW { get; set; }
        public int KVCW { get; set; }
        public int HVW { get; set; }
        public int NTW { get; set; }
        public int PNLW { get; set; }
        public int VTSW { get; set; }
        public int LLW { get; set; }
        public int NHW { get; set; }

        // Control the total number of houses (not exceeding 2 houses per street)
        public int LBBH { get; set; }
        public int CHH { get; set; }
        public int QTH { get; set; }
        public int TCH { get; set; }
        public int HVTH { get; set; }
        public int KVCH { get; set; }
        public int HVH { get; set; }
        public int NTH { get; set; }
        public int PNLH { get; set; }
        public int VTSH { get; set; }
        public int LLH { get; set; }
        public int NHH { get; set; }

        public int P1M { get; set; }
        public int P2M { get; set; }
        public int P3M { get; set; }
        public int P4M { get; set; }

        // Control prisoner
        public bool Prisoned { get; set; }
        public bool EQDice { get; set; }

        public Player(string name, string stat, int money, int x, int y, string lbb, string ch, string qt, string tc, string hvt, string kvc, string hv, string nt, string pnl, string vts, string ll, string nh, int lbbh, int chh, int qth, int tch, int hvth, int kvch, int hvh, int nth, int pnlh, int vtsh, int llh, int nhh, int lbbw, int chw, int qtw, int tcw, int hvtw, int kvcw, int hvw, int ntw, int pnlw, int vtsw, int llw, int nhw, bool pris, bool eq, string bxcg, string bxcl, string bxmd, string bxmt, string ctdl, string ctcn, int eo, int pm1, int pm2, int pm3, int pm4) : base(name, stat, money, x, y, lbb, ch, qt, tc, hvt, kvc, hv, nt, pnl, vts, ll, nh, lbbh, chh, qth, tch, hvth, kvch, hvh, nth, pnlh, vtsh, llh, nhh, lbbw, chw, qtw, tcw, hvtw, kvcw, hvw, ntw, pnlw, vtsw, llw, nhw, pris, eq, bxcg, bxcl, bxmd, bxmt, ctdl, ctcn, eo, pm1, pm2, pm3, pm4)
        {
            Name = name;
            Money = money;
            Status = stat;
            X = x; Y = y;
            random = new Random();

            Prisoned = pris;
            EQDice = eq;
            EO = eo;

            P1M = pm1; P2M = pm2; P3M = pm3; P4M = pm4;

            LBB = lbb; CH = ch; QT = qt; TC = tc; HVT = hvt; KVC = kvc; HV = hv; NT = nt; PNL = pnl; VTS = vts; LL = ll; NH = nh;
            LBBH = lbbh; CHH = chh; QTH = qth; TCH = tch; HVTH = hvth; KVCH = kvch; HVH = hvh; NTH = nth; PNLH = pnlh; VTSH = vtsh; LLH = llh; NHH = nhh;
            LBBW = lbbw; CHW = chw; QTW = qtw; TCW = tcw; HVTW = hvtw; KVCW = kvcw; HVW = hvw; NTW = ntw; PNLW = pnlw; VTSW = vtsw; LLW = llw; NHW = nhw;

            BXCG = bxcg; BXCL = bxcl; BXMD = bxmd; BXMT = bxmt; CTDL = ctdl; CTCN = ctcn;
        }

        // Control players' real estates data
        public void P1RE(int bm, int X, int Y, string lbb, string ch, string qt, string tc, string hvt, string kvc, string hv, string nt, string pnl, string vts, string ll, string nh, int lbbh, int chh, int qth, int tch, int hvth, int kvch, int hvh, int nth, int pnlh, int vtsh, int llh, int nhh, int lbbw, int chw, int qtw, int tcw, int hvtw, int kvcw, int hvw, int ntw, int pnlw, int vtsw, int llw, int nhw, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 1)
            {
                if (lbb == "player0" && !street1 && bm >= 60)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse1 = true;
                    street1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player1" && !house1 && bm >= 12 && lbbh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player1" && !house1 && bm >= 30 && lbbh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house1 = true;
                }
                // Occupied
                else if (!occ1 && lbb == "player2")
                {
                    if (LBBH == 0)
                    {
                        p2m = 6;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p2m = 7;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p2m = 8;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p2m = 11;
                        m = bm - p2m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player3")
                {
                    if (LBBH == 0)
                    {
                        p3m = 6;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p3m = 7;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p3m = 8;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p3m = 11;
                        m = bm - p3m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player4")
                {
                    if (LBBH == 0)
                    {
                        p4m = 6;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p4m = 7;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p4m = 8;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p4m = 11;
                        m = bm - p4m;
                        occ1 = true;
                    }
                }
                if (street1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60)
                {
                    m = bm - 60;
                    lbb = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    lbbw = 60;
                    street1 = false;
                    yeshouse1 = true;
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 12 && lbbh < 2)
                {
                    m = bm - 12;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (lbbh == 0)
                    {
                        lbbh = 1;
                        lbbw = 72;
                        house1 = false;
                        yeshouse1 = true;
                    }
                    else if (lbbh == 1)
                    {
                        lbbh = 2;
                        lbbw = 84;
                        house1 = false;
                        yeshouse1 = true;
                    }
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 30 && lbbh == 2)
                {
                    m = bm - 30;
                    Console.WriteLine("You own a hotel, please note it");
                    lbbh = 3;
                    house1 = false;
                    yeshouse1 = true;
                }
                else if ((street1 || house1) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street1 = true;
                    house1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 4)
            {
                if (ch == "player0" && !street2 && bm >= 100)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse2 = true;
                    street2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player1" && !house2 && bm >= 20 && chh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player1" && !house2 && bm >= 50 && chh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house2 = true;
                }
                // Occupied
                else if (!occ2 && ch == "player2")
                {
                    if (CHH == 0)
                    {
                        p2m = 10;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p2m = 12;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p2m = 14;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p2m = 19;
                        m = bm - p2m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player3")
                {
                    if (CHH == 0)
                    {
                        p3m = 10;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p3m = 12;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p3m = 14;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p3m = 19;
                        m = bm - p3m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player4")
                {
                    if (CHH == 0)
                    {
                        p4m = 10;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p4m = 12;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p4m = 14;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p4m = 19;
                        m = bm - p4m;
                        occ2 = true;
                    }
                }
                if (street2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ch = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    chw = 100;
                    street2 = false;
                    yeshouse2 = true;
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 20 && chh < 2)
                {
                    m = bm - 20;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (chh == 0)
                    {
                        chh = 1;
                        chw = 120;
                        house2 = false;
                        yeshouse2 = true;
                    }
                    else if (chh == 1)
                    {
                        chh = 2;
                        chw = 140;
                        house2 = false;
                        yeshouse2 = true;
                    }
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 50 && chh == 2)
                {
                    m = bm - 50;
                    Console.WriteLine("You own a hotel, please note it");
                    chh = 3;
                    house2 = false;
                    yeshouse2 = true;
                }
                else if ((street2 || house2) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street2 = true;
                    house2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 6)
            {
                if (qt == "player0" && !street3 && bm >= 120)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse3 = true;
                    street3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player1" && !house3 && bm >= 24 && qth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player1" && !house3 && bm >= 60 && qth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house3 = true;
                }
                // Occupied
                else if (!occ3 && qt == "player2")
                {
                    if (QTH == 0)
                    {
                        p2m = 12;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p2m = 14;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p2m = 17;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player3")
                {
                    if (QTH == 0)
                    {
                        p3m = 12;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p3m = 14;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p3m = 17;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player4")
                {
                    if (QTH == 0)
                    {
                        p4m = 12;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p4m = 14;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p4m = 17;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ3 = true;
                    }
                }
                if (street3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120)
                {
                    m = bm - 120;
                    qt = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    qtw = 120;
                    street3 = false;
                    yeshouse3 = true;
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 24 && qth < 2)
                {
                    m = bm - 24;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (qth == 0)
                    {
                        qth = 1;
                        qtw = 144;
                        house3 = false;
                        yeshouse3 = true;
                    }
                    else if (qth == 1)
                    {
                        qth = 2;
                        qtw = 166;
                        house3 = false;
                        yeshouse3 = true;
                    }
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60 && qth == 2)
                {
                    m = bm - 60;
                    Console.WriteLine("You own a hotel, please note it");
                    qth = 3;
                    house3 = false;
                    yeshouse3 = true;
                }
                else if ((street3 || house3) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street3 = true;
                    house3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 2 && Y == 7)
            {
                if (tc == "player0" && !street4 && bm >= 160)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse4 = true;
                    street4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player1" && !house4 && bm >= 32 && tch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player1" && !house4 && bm >= 80 && tch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house4 = true;
                }
                // Occupied
                else if (!occ4 && tc == "player2")
                {
                    if (TCH == 0)
                    {
                        p2m = 16;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p2m = 19;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p2m = 30;
                        m = bm - p2m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player3")
                {
                    if (TCH == 0)
                    {
                        p3m = 16;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p3m = 19;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p3m = 30;
                        m = bm - p3m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player4")
                {
                    if (TCH == 0)
                    {
                        p4m = 16;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p4m = 19;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p4m = 30;
                        m = bm - p4m;
                        occ4 = true;
                    }
                }
                if (street4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160)
                {
                    m = bm - 160;
                    tc = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    tcw = 160;
                    street4 = false;
                    yeshouse4 = true;
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 32 && tch < 2)
                {
                    m = bm - 32;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (tch == 0)
                    {
                        tch = 1;
                        tcw = 192;
                        house4 = false;
                        yeshouse4 = true;
                    }
                    else if (tch == 1)
                    {
                        tch = 2;
                        tcw = 224;
                        house4 = false;
                        yeshouse4 = true;
                    }
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 80 && tch == 2)
                {
                    m = bm - 80;
                    Console.WriteLine("You own a hotel, please note it");
                    tch = 3;
                    house4 = false;
                    yeshouse4 = true;
                }
                else if ((street4 || house4) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street4 = true;
                    house4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 7)
            {
                if (hvt == "player0" && !street5 && bm >= 180)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse5 = true;
                    street5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player1" && !house5 && bm >= 36 && hvth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player1" && !house5 && bm >= 90 && hvth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house5 = true;
                }
                // Occupied
                else if (!occ5 && hvt == "player2")
                {
                    if (HVTH == 0)
                    {
                        p2m = 18;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p2m = 25;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player3")
                {
                    if (HVTH == 0)
                    {
                        p3m = 18;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p3m = 25;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player4")
                {
                    if (HVTH == 0)
                    {
                        p4m = 18;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p4m = 25;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ5 = true;
                    }
                }
                if (street5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180)
                {
                    m = bm - 180;
                    hvt = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvtw = 180;
                    street5 = false;
                    yeshouse5 = true;
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 36 && hvth < 2)
                {
                    m = bm - 36;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvth == 0)
                    {
                        hvth = 1;
                        hvtw = 216;
                        house5 = false;
                        yeshouse5 = true;
                    }
                    else if (hvth == 1)
                    {
                        hvth = 2;
                        hvtw = 249;
                        house5 = false;
                        yeshouse5 = true;
                    }
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 90 && hvth == 2)
                {
                    m = bm - 90;
                    Console.WriteLine("You own a hotel, please note it");
                    hvth = 3;
                    house5 = false;
                    yeshouse5 = true;
                }

                else if ((street5 || house5) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street5 = true;
                    house5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 7)
            {
                if (kvc == "player0" && !street6 && bm >= 200)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse6 = true;
                    street6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player1" && !house6 && bm >= 40 && kvch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player1" && !house6 && bm >= 100 && kvch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house6 = true;
                }
                // Occupied
                else if (!occ6 && kvc == "player2")
                {
                    if (KVCH == 0)
                    {
                        p2m = 20;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p2m = 24;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p2m = 28;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p2m = 38;
                        m = bm - p2m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player3")
                {
                    if (KVCH == 0)
                    {
                        p3m = 20;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p3m = 24;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p3m = 28;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p3m = 38;
                        m = bm - p3m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player4")
                {
                    if (KVCH == 0)
                    {
                        p4m = 20;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p4m = 24;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p4m = 28;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p4m = 38;
                        m = bm - p4m;
                        occ6 = true;
                    }
                }
                if (street6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 200)
                {
                    m = bm - 200;
                    kvc = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    kvcw = 200;
                    street6 = false;
                    yeshouse6 = true;
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 40 && kvch < 2)
                {
                    m = bm - 40;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (kvch == 0)
                    {
                        kvch = 1;
                        kvcw = 240;
                        house6 = false;
                        yeshouse6 = true;
                    }
                    else if (kvch == 1)
                    {
                        kvch = 2;
                        kvcw = 280;
                        house6 = false;
                        yeshouse6 = true;
                    }
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100 && kvch == 2)
                {
                    m = bm - 100;
                    Console.WriteLine("You own a hotel, please note it");
                    kvch = 3;
                    house6 = false;
                    yeshouse6 = true;
                }
                else if ((street6 || house6) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street6 = true;
                    house6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 6)
            {
                if (hv == "player0" && !street7 && bm >= 240)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse7 = true;
                    street7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player1" && !house7 && bm >= 48 && hvh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player1" && !house7 && bm >= 120 && hvh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house7 = true;
                }
                // Occupied
                else if (!occ7 && hv == "player2")
                {
                    if (HVH == 0)
                    {
                        p2m = 24;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p2m = 29;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p2m = 46;
                        m = bm - p2m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player3")
                {
                    if (HVH == 0)
                    {
                        p3m = 24;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p3m = 29;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p3m = 46;
                        m = bm - p3m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player4")
                {
                    if (HVH == 0)
                    {
                        p4m = 24;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p4m = 29;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p4m = 46;
                        m = bm - p4m;
                        occ7 = true;
                    }
                }
                if (street7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 240)
                {
                    m = bm - 240;
                    hv = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvw = 240;
                    street7 = false;
                    yeshouse7 = true;
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 48 && hvh < 2)
                {
                    m = bm - 48;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvh == 0)
                    {
                        hvh = 1;
                        hvw = 240;
                        house7 = false;
                        yeshouse7 = true;
                    }
                    else if (hvh == 1)
                    {
                        hvh = 2;
                        hvw = 280;
                        house7 = false;
                        yeshouse7 = true;
                    }
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120 && hvh == 2)
                {
                    m = bm - 120;
                    Console.WriteLine("You own a hotel, please note it");
                    hvh = 3;
                    house7 = false;
                    yeshouse7 = true;
                }
                else if ((street7 || house7) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street7 = true;
                    house7 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 3)
            {
                if (nt == "player0" && !street8 && bm >= 260)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse8 = true;
                    street8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player1" && !house8 && bm >= 52 && nth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player1" && !house8 && bm >= 130 && nth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house8 = true;
                }

                // Occupied
                else if (!occ8 && nt == "player2")
                {
                    if (NTH == 0)
                    {
                        p2m = 26;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p2m = 31;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p2m = 36;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p2m = 49;
                        m = bm - p2m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player3")
                {
                    if (NTH == 0)
                    {
                        p3m = 26;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p3m = 31;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p3m = 36;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p3m = 49;
                        m = bm - p3m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player4")
                {
                    if (NTH == 0)
                    {
                        p4m = 26;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p4m = 31;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p4m = 36;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p4m = 49;
                        m = bm - p4m;
                        occ8 = true;
                    }
                }
                if (street8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 260)
                {
                    m = bm - 260;
                    nt = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    ntw = 260;
                    street8 = false;
                    yeshouse8 = true;
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 52 && nth < 2)
                {
                    m = bm - 52;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nth == 0)
                    {
                        nth = 1;
                        ntw = 312;
                        house8 = false;
                        yeshouse8 = true;
                    }
                    else if (nth == 1)
                    {
                        nth = 2;
                        ntw = 364;
                        house8 = false;
                        yeshouse8 = true;
                    }
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 130 && nth == 2)
                {
                    m = bm - 130;
                    Console.WriteLine("You own a hotel, please note it");
                    nth = 3;
                    house8 = false;
                    yeshouse8 = true;
                }
                else if ((street8 || house8) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street8 = true;
                    house8 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 1)
            {
                if (pnl == "player0" && !street9 && bm >= 280)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse9 = true;
                    street9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player1" && !house9 && bm >= 56 && pnlh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player1" && !house9 && bm >= 140 && pnlh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house9 = true;
                }

                // Occupied
                else if (!occ9 && pnl == "player2")
                {
                    if (PNLH == 0)
                    {
                        p2m = 28;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p2m = 39;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p2m = 53;
                        m = bm - p2m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player3")
                {
                    if (PNLH == 0)
                    {
                        p3m = 28;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p3m = 39;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p3m = 53;
                        m = bm - p3m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player4")
                {
                    if (PNLH == 0)
                    {
                        p4m = 28;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p4m = 39;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p4m = 53;
                        m = bm - p4m;
                        occ9 = true;
                    }
                }
                if (street9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 280)
                {
                    m = bm - 280;
                    pnl = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    pnlw = 280;
                    street9 = false;
                    yeshouse9 = true;
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 56 && pnlh < 2)
                {
                    m = bm - 56;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (pnlh == 0)
                    {
                        pnlh = 1;
                        pnlw = 336;
                        house9 = false;
                        yeshouse9 = true;
                    }
                    else if (pnlh == 1)
                    {
                        pnlh = 2;
                        pnlw = 392;
                        house9 = false;
                        yeshouse9 = true;
                    }
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 140 && pnlh == 2)
                {
                    m = bm - 140;
                    Console.WriteLine("You own a hotel, please note it");
                    pnlh = 3;
                    house9 = false;
                    yeshouse9 = true;
                }
                else if ((street9 || house9) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street9 = true;
                    house9 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 5 && Y == 0)
            {
                if (vts == "player0" && !street10 && bm >= 320)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse10 = true;
                    street10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player1" && !house10 && bm >= 64 && vtsh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player1" && !house10 && bm >= 160 && vtsh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house10 = true;
                }
                // Occupied
                else if (!occ10 && vts == "player2")
                {
                    if (VTSH == 0)
                    {
                        p2m = 32;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p2m = 38;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p2m = 45;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p2m = 61;
                        m = bm - p2m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player3")
                {
                    if (VTSH == 0)
                    {
                        p3m = 32;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p3m = 38;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p3m = 45;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p3m = 61;
                        m = bm - p3m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player4")
                {
                    if (VTSH == 0)
                    {
                        p4m = 32;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p4m = 38;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p4m = 45;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p4m = 61;
                        m = bm - p4m;
                        occ10 = true;
                    }
                }
                if (street10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 320)
                {
                    m = bm - 320;
                    vts = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    vtsw = 320;
                    street10 = false;
                    yeshouse10 = true;
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 64 && vtsh < 2)
                {
                    m = bm - 64;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (vtsh == 0)
                    {
                        vtsh = 1;
                        vtsw = 384;
                        house10 = false;
                        yeshouse10 = true;
                    }
                    else if (vtsh == 1)
                    {
                        vtsh = 2;
                        vtsw = 448;
                        house10 = false;
                        yeshouse10 = true;
                    }
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160 && vtsh == 2)
                {
                    m = bm - 160;
                    Console.WriteLine("You own a hotel, please note it");
                    vtsh = 3;
                    house10 = false;
                    yeshouse10 = true;
                }
                else if ((street10 || house10) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street10 = true;
                    house10 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 0)
            {
                if (ll == "player0" && !street11 && bm >= 360)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse11 = true;
                    street11 = true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player1" && !house11 && bm >= 72 && llh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house11= true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player1" && !house11 && bm >= 180 && llh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house11 = true;
                }

                // Occupied
                else if (!occ11 && ll == "player2")
                {
                    if (LLH == 0)
                    {
                        p2m = 36;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p2m = 43;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p2m = 50;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p2m = 68;
                        m = bm - p2m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player3")
                {
                    if (LLH == 0)
                    {
                        p3m = 36;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p3m = 43;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p3m = 50;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p3m = 68;
                        m = bm - p3m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player4")
                {
                    if (LLH == 0)
                    {
                        p4m = 36;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p4m = 43;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p4m = 50;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p4m = 68;
                        m = bm - p4m;
                        occ11 = true;
                    }
                }
                if (street11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 360)
                {
                    m = bm - 360;
                    ll = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    llw = 360;
                    street11 = false;
                    yeshouse11 = true;
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 72 && llh < 2)
                {
                    m = bm - 72;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (llh == 0)
                    {
                        llh = 1;
                        llw = 432;
                        house11 = false;
                        yeshouse11 = true;
                    }
                    else if (llh == 1)
                    {
                        llh = 2;
                        llw = 594;
                        house11 = false;
                        yeshouse11 = true;
                    }
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180 && llh == 2)
                {
                    m = bm - 180;
                    Console.WriteLine("You own a hotel, please note it");
                    llh = 3;
                    house11 = false;
                    yeshouse11 = true;
                }
                else if ((street11 || house11) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street11 = true;
                    house11 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 0)
            {
                if (nh == "player0" && !street12 && bm >= 380)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse12 = true;
                    street12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player1" && !house12 && bm >= 76 && nhh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player1" && !house12 && bm >= 190 && nhh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house12 = true;
                }

                // Occupied
                else if (!occ12 && nh == "player2")
                {
                    if (NHH == 0)
                    {
                        p2m = 380;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p2m = 46;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p2m = 53;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p2m = 72;
                        m = bm - p2m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player3")
                {
                    if (NHH == 0)
                    {
                        p3m = 380;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p3m = 46;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p3m = 53;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p3m = 72;
                        m = bm - p3m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player4")
                {
                    if (NHH == 0)
                    {
                        p4m = 380;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p4m = 46;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p4m = 53;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p4m = 72;
                        m = bm - p4m;
                        occ12 = true;
                    }
                }
                if (street12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 380)
                {
                    m = bm - 380;
                    nh = "player1";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    nhw = 380;
                    street12 = false;
                    yeshouse12 = true;
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 76 && nhh < 2)
                {
                    m = bm - 76;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nhh == 0)
                    {
                        nhh = 1;
                        nhw = 432;
                        house12 = false;
                        yeshouse12 = true;
                    }
                    else if (nhh == 1)
                    {
                        nhh = 2;
                        nhw = 594;
                        house12 = false;
                        yeshouse12 = true;
                    }
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 190 && nhh == 2)
                {
                    m = bm - 190;
                    Console.WriteLine("You own a hotel, please note it");
                    nhh = 3;
                    house12 = false;
                    yeshouse12 = true;
                }
                else if ((street12 || house12) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street12 = true;
                    house12 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (!(X == 0 && Y == 1))
            {
                occ1 = false;
                nohouse1 = false;
                yeshouse1 = false;
                street1 = false; house1 = false;
            }
            if (!(X == 0 && Y == 4))
            {
                occ2 = false;
                nohouse2 = false;
                yeshouse2 = false;
                street2 = false; house2 = false;
            }
            if (!(X == 0 && Y == 6))
            {
                occ3 = false;
                nohouse3 = false;
                yeshouse3 = false;
                street3 = false; house3 = false;
            }
            if (!(X == 2 && Y == 7))
            {
                occ4 = false;
                nohouse4 = false;
                yeshouse4 = false;
                street4 = false; house4 = false;
            }
            if (!(X == 4 && Y == 7))
            {
                occ5 = false;
                nohouse5 = false;
                yeshouse5 = false;
                street5 = false; house5 = false;
            }
            if (!(X == 6 && Y == 7))
            {
                occ6 = false;
                nohouse6 = false;
                yeshouse6 = false;
                street6 = false; house6 = false;
            }
            if (!(X == 7 && Y == 6))
            {
                occ7 = false;
                nohouse7 = false;
                yeshouse7 = false;
                street7 = false; house7 = false;
            }
            if (!(X == 7 && Y == 3))
            {
                occ8 = false;
                nohouse8 = false;
                yeshouse8 = false;
                street8 = false; house8 = false;
            }
            if (!(X == 7 && Y == 1))
            {
                occ9 = false;
                nohouse9 = false;
                yeshouse9 = false;
                street9 = false; house9 = false;
            }
            if (!(X == 5 && Y == 0))
            {
                occ10 = false;
                nohouse10 = false;
                yeshouse10 = false;
                street10 = false; house10 = false;
            }
            if (!(X == 3 && Y == 0))
            {
                occ11 = false;
                nohouse11 = false;
                yeshouse11 = false;
                street11 = false; house11 = false;
            }
            if (!(X == 1 && Y == 0))
            {
                occ12 = false;
                nohouse12 = false;
                yeshouse12 = false;
                street12 = false; house12 = false;
            }
            /*if (!occ1 && !occ2 && !occ3 && !occ4 && !occ5 && !occ6 && !occ7 && !occ8 && !occ9 && !occ10 && !occ11 && !occ12)
            {
                p1m = 0; p2m = 0; p3m = 0; p4m = 0;
            }*/
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            LBB = lbb; CH = ch; QT = qt; TC = tc; HVT = hvt; KVC = kvc; HV = hv; NT = nt; PNL = pnl; VTS = vts; LL = ll; NH = nh;
            LBBH = lbbh; CHH = chh; QTH = qth; TCH = tch; HVTH = hvth; KVCH = kvch; HVH = hvh; NTH = nth; PNLH = pnlh; VTSH = vtsh; LLH = llh; NHH = nhh;
            LBBW = lbbw; CHW = chw; QTW = qtw; TCW = tcw; HVTW = hvtw; KVCW = kvcw; HVW = hvw; NTW = ntw; PNLW = pnlw; VTSW = vtsw; LLW = llw; NHW = nhw;

        }

        public void P2RE(int bm, int X, int Y, string lbb, string ch, string qt, string tc, string hvt, string kvc, string hv, string nt, string pnl, string vts, string ll, string nh, int lbbh, int chh, int qth, int tch, int hvth, int kvch, int hvh, int nth, int pnlh, int vtsh, int llh, int nhh, int lbbw, int chw, int qtw, int tcw, int hvtw, int kvcw, int hvw, int ntw, int pnlw, int vtsw, int llw, int nhw, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 1)
            {
                if (lbb == "player0" && !street1 && bm >= 60)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse1 = true;
                    street1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player2" && !house1 && bm >= 12 && lbbh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player2" && !house1 && bm >= 30 && lbbh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house1 = true;
                }
                // Occupied
                else if (!occ1 && lbb == "player1")
                {
                    if (LBBH == 0)
                    {
                        p1m = 6;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p1m = 7;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p1m = 8;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p1m = 11;
                        m = bm - p1m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player3")
                {
                    if (LBBH == 0)
                    {
                        p3m = 6;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p3m = 7;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p3m = 8;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p3m = 11;
                        m = bm - p3m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player4")
                {
                    if (LBBH == 0)
                    {
                        p4m = 6;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p4m = 7;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p4m = 8;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p4m = 11;
                        m = bm - p4m;
                        occ1 = true;
                    }
                }
                if (street1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60)
                {
                    m = bm - 60;
                    lbb = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    lbbw = 60;
                    street1 = false;
                    yeshouse1 = true;
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 12 && lbbh < 2)
                {
                    m = bm - 12;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (lbbh == 0)
                    {
                        lbbh = 1;
                        lbbw = 72;
                        house1 = false;
                        yeshouse1 = true;
                    }
                    else if (lbbh == 1)
                    {
                        lbbh = 2;
                        lbbw = 84;
                        house1 = false;
                        yeshouse1 = true;
                    }
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 30 && lbbh == 2)
                {
                    m = bm - 30;
                    Console.WriteLine("You own a hotel, please note it");
                    lbbh = 3;
                    house1 = false;
                    yeshouse1 = true;
                }
                else if ((street1 || house1) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street1 = true;
                    house1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 4)
            {
                if (ch == "player0" && !street2 && bm >= 100)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse2 = true;
                    street2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player2" && !house2 && bm >= 20 && chh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player2" && !house2 && bm >= 50 && chh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house2 = true;
                }
                // Occupied
                else if (!occ2 && ch == "player1")
                {
                    if (CHH == 0)
                    {
                        p1m = 10;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p1m = 12;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p1m = 14;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p1m = 19;
                        m = bm - p1m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player3")
                {
                    if (CHH == 0)
                    {
                        p3m = 10;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p3m = 12;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p3m = 14;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p3m = 19;
                        m = bm - p3m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player4")
                {
                    if (CHH == 0)
                    {
                        p4m = 10;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p4m = 12;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p4m = 14;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p4m = 19;
                        m = bm - p4m;
                        occ2 = true;
                    }
                }
                if (street2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ch = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    chw = 100;
                    street2 = false;
                    yeshouse2 = true;
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 20 && chh < 2)
                {
                    m = bm - 20;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (chh == 0)
                    {
                        chh = 1;
                        chw = 120;
                        house2 = false;
                        yeshouse2 = true;
                    }
                    else if (chh == 1)
                    {
                        chh = 2;
                        chw = 140;
                        house2 = false;
                        yeshouse2 = true;
                    }
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 50 && chh == 2)
                {
                    m = bm - 50;
                    Console.WriteLine("You own a hotel, please note it");
                    chh = 3;
                    house2 = false;
                    yeshouse2 = true;
                }
                else if ((street2 || house2) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street2 = true;
                    house2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 6)
            {
                if (qt == "player0" && !street3 && bm >= 120)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse3 = true;
                    street3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player2" && !house3 && bm >= 24 && qth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player2" && !house3 && bm >= 60 && qth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house3 = true;
                }
                // Occupied
                else if (!occ3 && qt == "player1")
                {
                    if (QTH == 0)
                    {
                        p1m = 12;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p1m = 14;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p1m = 17;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player3")
                {
                    if (QTH == 0)
                    {
                        p3m = 12;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p3m = 14;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p3m = 17;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player4")
                {
                    if (QTH == 0)
                    {
                        p4m = 12;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p4m = 14;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p4m = 17;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ3 = true;
                    }
                }
                if (street3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120)
                {
                    m = bm - 120;
                    qt = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    qtw = 120;
                    street3 = false;
                    yeshouse3 = true;
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 24 && qth < 2)
                {
                    m = bm - 24;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (qth == 0)
                    {
                        qth = 1;
                        qtw = 144;
                        house3 = false;
                        yeshouse3 = true;
                    }
                    else if (qth == 1)
                    {
                        qth = 2;
                        qtw = 166;
                        house3 = false;
                        yeshouse3 = true;
                    }
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60 && qth == 2)
                {
                    m = bm - 60;
                    Console.WriteLine("You own a hotel, please note it");
                    qth = 3;
                    house3 = false;
                    yeshouse3 = true;
                }
                else if ((street3 || house3) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street3 = true;
                    house3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 2 && Y == 7)
            {
                if (tc == "player0" && !street4 && bm >= 160)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse4 = true;
                    street4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player2" && !house4 && bm >= 32 && tch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player2" && !house4 && bm >= 80 && tch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house4 = true;
                }
                // Occupied
                else if (!occ4 && tc == "player1")
                {
                    if (TCH == 0)
                    {
                        p1m = 16;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p1m = 19;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p1m = 30;
                        m = bm - p1m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player3")
                {
                    if (TCH == 0)
                    {
                        p3m = 16;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p3m = 19;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p3m = 30;
                        m = bm - p3m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player4")
                {
                    if (TCH == 0)
                    {
                        p4m = 16;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p4m = 19;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p4m = 30;
                        m = bm - p4m;
                        occ4 = true;
                    }
                }
                if (street4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160)
                {
                    m = bm - 160;
                    tc = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    tcw = 160;
                    street4 = false;
                    yeshouse4 = true;
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 32 && tch < 2)
                {
                    m = bm - 32;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (tch == 0)
                    {
                        tch = 1;
                        tcw = 192;
                        house4 = false;
                        yeshouse4 = true;
                    }
                    else if (tch == 1)
                    {
                        tch = 2;
                        tcw = 224;
                        house4 = false;
                        yeshouse4 = true;
                    }
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 80 && tch == 2)
                {
                    m = bm - 80;
                    Console.WriteLine("You own a hotel, please note it");
                    tch = 3;
                    house4 = false;
                    yeshouse4 = true;
                }
                else if ((street4 || house4) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street4 = true;
                    house4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 7)
            {
                if (hvt == "player0" && !street5 && bm >= 180)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse5 = true;
                    street5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player2" && !house5 && bm >= 36 && hvth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player2" && !house5 && bm >= 90 && hvth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house5 = true;
                }
                // Occupied
                else if (!occ5 && hvt == "player1")
                {
                    if (HVTH == 0)
                    {
                        p1m = 18;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p1m = 25;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player3")
                {
                    if (HVTH == 0)
                    {
                        p3m = 18;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p3m = 25;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player4")
                {
                    if (HVTH == 0)
                    {
                        p4m = 18;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p4m = 25;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ5 = true;
                    }
                }
                if (street5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180)
                {
                    m = bm - 180;
                    hvt = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvtw = 180;
                    street5 = false;
                    yeshouse5 = true;
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 36 && hvth < 2)
                {
                    m = bm - 36;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvth == 0)
                    {
                        hvth = 1;
                        hvtw = 216;
                        house5 = false;
                        yeshouse5 = true;
                    }
                    else if (hvth == 1)
                    {
                        hvth = 2;
                        hvtw = 249;
                        house5 = false;
                        yeshouse5 = true;
                    }
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 90 && hvth == 2)
                {
                    m = bm - 90;
                    Console.WriteLine("You own a hotel, please note it");
                    hvth = 3;
                    house5 = false;
                    yeshouse5 = true;
                }
                else if ((street5 || house5) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street5 = true;
                    house5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 7)
            {
                if (kvc == "player0" && !street6 && bm >= 200)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse6 = true;
                    street6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player2" && !house6 && bm >= 40 && kvch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player2" && !house6 && bm >= 100 && kvch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house6 = true;
                }
                // Occupied
                else if (!occ6 && kvc == "player1")
                {
                    if (KVCH == 0)
                    {
                        p1m = 20;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p1m = 24;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p1m = 28;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p1m = 38;
                        m = bm - p1m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player3")
                {
                    if (KVCH == 0)
                    {
                        p3m = 20;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p3m = 24;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p3m = 28;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p3m = 38;
                        m = bm - p3m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player4")
                {
                    if (KVCH == 0)
                    {
                        p4m = 20;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p4m = 24;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p4m = 28;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p4m = 38;
                        m = bm - p4m;
                        occ6 = true;
                    }
                }
                if (street6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 200)
                {
                    m = bm - 200;
                    kvc = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    kvcw = 200;
                    street6 = false;
                    yeshouse6 = true;
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 40 && kvch < 2)
                {
                    m = bm - 40;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (kvch == 0)
                    {
                        kvch = 1;
                        kvcw = 240;
                        house6 = false;
                        yeshouse6 = true;
                    }
                    else if (kvch == 1)
                    {
                        kvch = 2;
                        kvcw = 280;
                        house6 = false;
                        yeshouse6 = true;
                    }
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100 && kvch == 2)
                {
                    m = bm - 100;
                    Console.WriteLine("You own a hotel, please note it");
                    kvch = 3;
                    house6 = false;
                    yeshouse6 = true;
                }
                else if ((street6 || house6) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street6 = true;
                    house6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 6)
            {
                if (hv == "player0" && !street7 && bm >= 240)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse7 = true;
                    street7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player2" && !house7 && bm >= 48 && hvh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player2" && !house7 && bm >= 120 && hvh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house7 = true;
                }
                // Occupied
                else if (!occ7 && hv == "player1")
                {
                    if (HVH == 0)
                    {
                        p1m = 24;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p1m = 29;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p1m = 46;
                        m = bm - p1m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player3")
                {
                    if (HVH == 0)
                    {
                        p3m = 24;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p3m = 29;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p3m = 46;
                        m = bm - p3m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player4")
                {
                    if (HVH == 0)
                    {
                        p4m = 24;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p4m = 29;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p4m = 46;
                        m = bm - p4m;
                        occ7 = true;
                    }
                }
                if (street7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 240)
                {
                    m = bm - 240;
                    hv = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvw = 240;
                    street7 = false;
                    yeshouse7 = true;
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 48 && hvh < 2)
                {
                    m = bm - 48;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvh == 0)
                    {
                        hvh = 1;
                        hvw = 240;
                        house7 = false;
                        yeshouse7 = true;
                    }
                    else if (hvh == 1)
                    {
                        hvh = 2;
                        hvw = 280;
                        house7 = false;
                        yeshouse7 = true;
                    }
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120 && hvh == 2)
                {
                    m = bm - 120;
                    Console.WriteLine("You own a hotel, please note it");
                    hvh = 3;
                    house7 = false;
                    yeshouse7 = true;
                }
                else if ((street7 || house7) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street7 = true;
                    house7 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 3)
            {
                if (nt == "player0" && !street8 && bm >= 260)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse8 = true;
                    street8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player2" && !house8 && bm >= 52 && nth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player2" && !house8 && bm >= 130 && nth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house8 = true;
                }
                // Occupied
                else if (!occ8 && nt == "player1")
                {
                    if (NTH == 0)
                    {
                        p1m = 26;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p1m = 31;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p1m = 36;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p1m = 49;
                        m = bm - p1m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player3")
                {
                    if (NTH == 0)
                    {
                        p3m = 26;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p3m = 31;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p3m = 36;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p3m = 49;
                        m = bm - p3m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player4")
                {
                    if (NTH == 0)
                    {
                        p4m = 26;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p4m = 31;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p4m = 36;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p4m = 49;
                        m = bm - p4m;
                        occ8 = true;
                    }
                }
                if (street8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 260)
                {
                    m = bm - 260;
                    nt = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    ntw = 260;
                    street8 = false;
                    yeshouse8 = true;
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 52 && nth < 2)
                {
                    m = bm - 52;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nth == 0)
                    {
                        nth = 1;
                        ntw = 312;
                        house8 = false;
                        yeshouse8 = true;
                    }
                    else if (nth == 1)
                    {
                        nth = 2;
                        ntw = 364;
                        house8 = false;
                        yeshouse8 = true;
                    }
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 130 && nth == 2)
                {
                    m = bm - 130;
                    Console.WriteLine("You own a hotel, please note it");
                    nth = 3;
                    house8 = false;
                    yeshouse8 = true;
                }
                else if ((street8 || house8) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street8 = true;
                    house8 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 1)
            {
                if (pnl == "player0" && !street9 && bm >= 280)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse9 = true;
                    street9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player2" && !house9 && bm >= 56 && pnlh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player2" && !house9 && bm >= 140 && pnlh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house9 = true;
                }
                // Occupied
                else if (!occ9 && pnl == "player1")
                {
                    if (PNLH == 0)
                    {
                        p1m = 28;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p1m = 39;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p1m = 53;
                        m = bm - p1m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player3")
                {
                    if (PNLH == 0)
                    {
                        p3m = 28;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p3m = 39;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p3m = 53;
                        m = bm - p3m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player4")
                {
                    if (PNLH == 0)
                    {
                        p4m = 28;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p4m = 39;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p4m = 53;
                        m = bm - p4m;
                        occ9 = true;
                    }
                }
                if (street9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 280)
                {
                    m = bm - 280;
                    pnl = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    pnlw = 280;
                    street9 = false;
                    yeshouse9 = true;
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 56 && pnlh < 2)
                {
                    m = bm - 56;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (pnlh == 0)
                    {
                        pnlh = 1;
                        pnlw = 336;
                        house9 = false;
                        yeshouse9 = true;
                    }
                    else if (pnlh == 1)
                    {
                        pnlh = 2;
                        pnlw = 392;
                        house9 = false;
                        yeshouse9 = true;
                    }
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 140 && pnlh == 2)
                {
                    m = bm - 140;
                    Console.WriteLine("You own a hotel, please note it");
                    pnlh = 3;
                    house9 = false;
                    yeshouse9 = true;
                }
                else if ((street9 || house9) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street9 = true;
                    house9 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 5 && Y == 0)
            {
                if (vts == "player0" && !street10 && bm >= 320)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse10 = true;
                    street10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player2" && !house10 && bm >= 64 && vtsh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player2" && !house10 && bm >= 160 && vtsh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house10 = true;
                }
                // Occupied
                else if (!occ10 && vts == "player1")
                {
                    if (VTSH == 0)
                    {
                        p1m = 32;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p1m = 38;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p1m = 45;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p1m = 61;
                        m = bm - p1m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player3")
                {
                    if (VTSH == 0)
                    {
                        p3m = 32;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p3m = 38;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p3m = 45;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p3m = 61;
                        m = bm - p3m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player4")
                {
                    if (VTSH == 0)
                    {
                        p4m = 32;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p4m = 38;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p4m = 45;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p4m = 61;
                        m = bm - p4m;
                        occ10 = true;
                    }
                }
                if (street10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 320)
                {
                    m = bm - 320;
                    vts = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    vtsw = 320;
                    street10 = false;
                    yeshouse10 = true;
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 64 && vtsh < 2)
                {
                    m = bm - 64;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (vtsh == 0)
                    {
                        vtsh = 1;
                        vtsw = 384;
                        house10 = false;
                        yeshouse10 = true;
                    }
                    else if (vtsh == 1)
                    {
                        vtsh = 2;
                        vtsw = 448;
                        house10 = false;
                        yeshouse10 = true;
                    }
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160 && vtsh == 2)
                {
                    m = bm - 160;
                    Console.WriteLine("You own a hotel, please note it");
                    vtsh = 3;
                    house10 = false;
                    yeshouse10 = true;
                }
                else if ((street10 || house10) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street10 = true;
                    house10 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 0)
            {
                if (ll == "player0" && !street11 && bm >= 360)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse11 = true;
                    street11 = true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player2" && !house11 && bm >= 72 && llh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house11 = true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player2" && !house11 && bm >= 180 && llh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house11 = true;
                }
                // Occupied
                else if (!occ11 && ll == "player1")
                {
                    if (LLH == 0)
                    {
                        p1m = 36;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p1m = 43;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p1m = 50;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p1m = 68;
                        m = bm - p1m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player3")
                {
                    if (LLH == 0)
                    {
                        p3m = 36;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p3m = 43;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p3m = 50;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p3m = 68;
                        m = bm - p3m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player4")
                {
                    if (LLH == 0)
                    {
                        p4m = 36;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p4m = 43;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p4m = 50;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p4m = 68;
                        m = bm - p4m;
                        occ11 = true;
                    }
                }
                if (street11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 360)
                {
                    m = bm - 360;
                    ll = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    llw = 360;
                    street11 = false;
                    yeshouse11 = true;
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 72 && llh < 2)
                {
                    m = bm - 72;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (llh == 0)
                    {
                        llh = 1;
                        llw = 432;
                        house11 = false;
                        yeshouse11 = true;
                    }
                    else if (llh == 1)
                    {
                        llh = 2;
                        llw = 594;
                        house11 = false;
                        yeshouse11 = true;
                    }
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180 && llh == 2)
                {
                    m = bm - 180;
                    Console.WriteLine("You own a hotel, please note it");
                    llh = 3;
                    house11 = false;
                    yeshouse11 = true;
                }
                else if ((street11 || house11) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street11 = true;
                    house11 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 0)
            {
                if (nh == "player0" && !street12 && bm >= 380)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse12 = true;
                    street12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player2" && !house12 && bm >= 76 && nhh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player2" && !house12 && bm >= 190 && nhh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house12 = true;
                }
                // Occupied
                else if (!occ12 && nh == "player1")
                {
                    if (NHH == 0)
                    {
                        p1m = 38;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p1m = 46;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p1m = 53;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p1m = 72;
                        m = bm - p1m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player3")
                {
                    if (NHH == 0)
                    {
                        p3m = 38;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p3m = 46;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p3m = 53;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p3m = 72;
                        m = bm - p3m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player4")
                {
                    if (NHH == 0)
                    {
                        p4m = 38;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p4m = 46;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p4m = 53;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p4m = 72;
                        m = bm - p4m;
                        occ12 = true;
                    }
                }
                if (street12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 380)
                {
                    m = bm - 380;
                    nh = "player2";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    nhw = 380;
                    street12 = false;
                    yeshouse12 = true;
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 76 && nhh < 2)
                {
                    m = bm - 76;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nhh == 0)
                    {
                        nhh = 1;
                        nhw = 432;
                        house12 = false;
                        yeshouse12 = true;
                    }
                    else if (nhh == 1)
                    {
                        nhh = 2;
                        nhw = 594;
                        house12 = false;
                        yeshouse12 = true;
                    }
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 190 && nhh == 2)
                {
                    m = bm - 190;
                    Console.WriteLine("You own a hotel, please note it");
                    nhh = 3;
                    house12 = false;
                    yeshouse12 = true;
                }
                else if ((street12 || house12) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street12 = true;
                    house12 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (!(X == 0 && Y == 1))
            {
                occ1 = false;
                nohouse1 = false;
                yeshouse1 = false;
                street1 = false; house1 = false;
            }
            if (!(X == 0 && Y == 4))
            {
                occ2 = false;
                nohouse2 = false;
                yeshouse2 = false;
                street2 = false; house2 = false;
            }
            if (!(X == 0 && Y == 6))
            {
                occ3 = false;
                nohouse3 = false;
                yeshouse3 = false;
                street3 = false; house3 = false;
            }
            if (!(X == 2 && Y == 7))
            {
                occ4 = false;
                nohouse4 = false;
                yeshouse4 = false;
                street4 = false; house4 = false;
            }
            if (!(X == 4 && Y == 7))
            {
                occ5 = false;
                nohouse5 = false;
                yeshouse5 = false;
                street5 = false; house5 = false;
            }
            if (!(X == 6 && Y == 7))
            {
                occ6 = false;
                nohouse6 = false;
                yeshouse6 = false;
                street6 = false; house6 = false;
            }
            if (!(X == 7 && Y == 6))
            {
                occ7 = false;
                nohouse7 = false;
                yeshouse7 = false;
                street7 = false; house7 = false;
            }
            if (!(X == 7 && Y == 3))
            {
                occ8 = false;
                nohouse8 = false;
                yeshouse8 = false;
                street8 = false; house8 = false;
            }
            if (!(X == 7 && Y == 1))
            {
                occ9 = false;
                nohouse9 = false;
                yeshouse9 = false;
                street9 = false; house9 = false;
            }
            if (!(X == 5 && Y == 0))
            {
                occ10 = false;
                nohouse10 = false;
                yeshouse10 = false;
                street10 = false; house10 = false;
            }
            if (!(X == 3 && Y == 0))
            {
                occ11 = false;
                nohouse11 = false;
                yeshouse11 = false;
                street11 = false; house11 = false;
            }
            if (!(X == 1 && Y == 0))
            {
                occ12 = false;
                nohouse12 = false;
                yeshouse12 = false;
                street12 = false; house12 = false;
            }
            // Deduct balance from rent fare
            /*if (!occ1 && !occ2 && !occ3 && !occ4 && !occ5 && !occ6 && !occ7 && !occ8 && !occ9 && !occ10 && !occ11 && !occ12)
            {
                p1m = 0; p2m = 0; p3m = 0; p4m = 0;
            }*/
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            LBB = lbb; CH = ch; QT = qt; TC = tc; HVT = hvt; KVC = kvc; HV = hv; NT = nt; PNL = pnl; VTS = vts; LL = ll; NH = nh;
            LBBH = lbbh; CHH = chh; QTH = qth; TCH = tch; HVTH = hvth; KVCH = kvch; HVH = hvh; NTH = nth; PNLH = pnlh; VTSH = vtsh; LLH = llh; NHH = nhh;
            LBBW = lbbw; CHW = chw; QTW = qtw; TCW = tcw; HVTW = hvtw; KVCW = kvcw; HVW = hvw; NTW = ntw; PNLW = pnlw; VTSW = vtsw; LLW = llw; NHW = nhw;

        }

        public void P3RE(int bm, int X, int Y, string lbb, string ch, string qt, string tc, string hvt, string kvc, string hv, string nt, string pnl, string vts, string ll, string nh, int lbbh, int chh, int qth, int tch, int hvth, int kvch, int hvh, int nth, int pnlh, int vtsh, int llh, int nhh, int lbbw, int chw, int qtw, int tcw, int hvtw, int kvcw, int hvw, int ntw, int pnlw, int vtsw, int llw, int nhw, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 1)
            {
                if (lbb == "player0" && !street1 && bm >= 60)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse1 = true;
                    street1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player3" && !house1 && bm >= 12 && lbbh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player3" && !house1 && bm >= 30 && lbbh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house1 = true;
                }
                // Occupied
                else if (!occ1 && lbb == "player2")
                {
                    if (LBBH == 0)
                    {
                        p2m = 6;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p2m = 7;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p2m = 8;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p2m = 11;
                        m = bm - p2m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player1")
                {
                    if (LBBH == 0)
                    {
                        p1m = 6;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p1m = 7;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p1m = 8;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p1m = 11;
                        m = bm - p1m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player4")
                {
                    if (LBBH == 0)
                    {
                        p4m = 6;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p4m = 7;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p4m = 8;
                        m = bm - p4m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p4m = 11;
                        m = bm - p4m;
                        occ1 = true;
                    }
                }
                if (street1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60)
                {
                    m = bm - 60;
                    lbb = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    lbbw = 60;
                    street1 = false;
                    yeshouse1 = true;
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 12 && lbbh < 2)
                {
                    m = bm - 12;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (lbbh == 0)
                    {
                        lbbh = 1;
                        lbbw = 72;
                        house1 = false;
                        yeshouse1 = true;
                    }
                    else if (lbbh == 1)
                    {
                        lbbh = 2;
                        lbbw = 84;
                        house1 = false;
                        yeshouse1 = true;
                    }
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 30 && lbbh == 2)
                {
                    m = bm - 30;
                    Console.WriteLine("You own a hotel, please note it");
                    lbbh = 3;
                    house1 = false;
                    yeshouse1 = true;
                }
                else if ((street1 || house1) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street1 = true;
                    house1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 4)
            {
                if (ch == "player0" && !street2 && bm >= 100)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse2 = true;
                    street2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player3" && !house2 && bm >= 20 && chh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player3" && !house2 && bm >= 50 && chh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house2 = true;
                }
                // Occupied
                else if (!occ2 && ch == "player2")
                {
                    if (CHH == 0)
                    {
                        p2m = 10;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p2m = 12;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p2m = 14;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p2m = 19;
                        m = bm - p2m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player1")
                {
                    if (CHH == 0)
                    {
                        p1m = 10;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p1m = 12;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p1m = 14;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p1m = 19;
                        m = bm - p1m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player4")
                {
                    if (CHH == 0)
                    {
                        p4m = 10;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p4m = 12;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p4m = 14;
                        m = bm - p4m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p4m = 19;
                        m = bm - p4m;
                        occ2 = true;
                    }
                }
                if (street2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ch = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    chw = 100;
                    street2 = false;
                    yeshouse2 = true;
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 20 && chh < 2)
                {
                    m = bm - 20;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (chh == 0)
                    {
                        chh = 1;
                        chw = 120;
                        house2 = false;
                        yeshouse2 = true;
                    }
                    else if (chh == 1)
                    {
                        chh = 2;
                        chw = 140;
                        house2 = false;
                        yeshouse2 = true;
                    }
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 50 && chh == 2)
                {
                    m = bm - 50;
                    Console.WriteLine("You own a hotel, please note it");
                    chh = 3;
                    house2 = false;
                    yeshouse2 = true;
                }
                else if ((street2 || house2) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street2 = true;
                    house2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 6)
            {
                if (qt == "player0" && !street3 && bm >= 120)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse3 = true;
                    street3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player3" && !house3 && bm >= 24 && qth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player3" && !house3 && bm >= 60 && qth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house3 = true;
                }
                // Occupied
                else if (!occ3 && qt == "player2")
                {
                    if (QTH == 0)
                    {
                        p2m = 12;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p2m = 14;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p2m = 17;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player1")
                {
                    if (QTH == 0)
                    {
                        p1m = 12;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p1m = 14;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p1m = 17;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player4")
                {
                    if (QTH == 0)
                    {
                        p4m = 12;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p4m = 14;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p4m = 17;
                        m = bm - p4m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ3 = true;
                    }
                }
                if (street3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120)
                {
                    m = bm - 120;
                    qt = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    qtw = 120;
                    street3 = false;
                    yeshouse3 = true;
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 24 && qth < 2)
                {
                    m = bm - 24;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (qth == 0)
                    {
                        qth = 1;
                        qtw = 144;
                        house3 = false;
                        yeshouse3 = true;
                    }
                    else if (qth == 1)
                    {
                        qth = 2;
                        qtw = 166;
                        house3 = false;
                        yeshouse3 = true;
                    }
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60 && qth == 2)
                {
                    m = bm - 60;
                    Console.WriteLine("You own a hotel, please note it");
                    qth = 3;
                    house3 = false;
                    yeshouse3 = true;
                }
                else if ((street3 || house3) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street3 = true;
                    house3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 2 && Y == 7)
            {
                if (tc == "player0" && !street4 && bm >= 160)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse4 = true;
                    street4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player3" && !house4 && bm >= 32 && tch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player3" && !house4 && bm >= 80 && tch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house4 = true;
                }
                // Occupied
                else if (!occ4 && tc == "player2")
                {
                    if (TCH == 0)
                    {
                        p2m = 16;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p2m = 19;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p2m = 30;
                        m = bm - p2m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player1")
                {
                    if (TCH == 0)
                    {
                        p1m = 16;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p1m = 19;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p1m = 30;
                        m = bm - p1m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player4")
                {
                    if (TCH == 0)
                    {
                        p4m = 16;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p4m = 19;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p4m = 30;
                        m = bm - p4m;
                        occ4 = true;
                    }
                }
                if (street4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160)
                {
                    m = bm - 160;
                    tc = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    tcw = 160;
                    street4 = false;
                    yeshouse4 = true;
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 32 && tch < 2)
                {
                    m = bm - 32;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (tch == 0)
                    {
                        tch = 1;
                        tcw = 192;
                        house4 = false;
                        yeshouse4 = true;
                    }
                    else if (tch == 1)
                    {
                        tch = 2;
                        tcw = 224;
                        house4 = false;
                        yeshouse4 = true;
                    }
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 80 && tch == 2)
                {
                    m = bm - 80;
                    Console.WriteLine("You own a hotel, please note it");
                    tch = 3;
                    house4 = false;
                    yeshouse4 = true;
                }
                else if ((street4 || house4) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street4 = true;
                    house4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 7)
            {
                if (hvt == "player0" && !street5 && bm >= 180)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse5 = true;
                    street5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player3" && !house5 && bm >= 36 && hvth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player3" && !house5 && bm >= 90 && hvth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house5 = true;
                }
                // Occupied
                else if (!occ5 && hvt == "player2")
                {
                    if (HVTH == 0)
                    {
                        p2m = 18;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p2m = 25;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player1")
                {
                    if (HVTH == 0)
                    {
                        p1m = 18;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p1m = 25;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player4")
                {
                    if (HVTH == 0)
                    {
                        p4m = 18;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p4m = 22;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p4m = 25;
                        m = bm - p4m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ5 = true;
                    }
                }
                if (street5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180)
                {
                    m = bm - 180;
                    hvt = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvtw = 180;
                    street5 = false;
                    yeshouse5 = true;
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 36 && hvth < 2)
                {
                    m = bm - 36;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvth == 0)
                    {
                        hvth = 1;
                        hvtw = 216;
                        house5 = false;
                        yeshouse5 = true;
                    }
                    else if (hvth == 1)
                    {
                        hvth = 2;
                        hvtw = 249;
                        house5 = false;
                        yeshouse5 = true;
                    }
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 90 && hvth == 2)
                {
                    m = bm - 90;
                    Console.WriteLine("You own a hotel, please note it");
                    hvth = 3;
                    house5 = false;
                    yeshouse5 = true;
                }

                else if ((street5 || house5) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street5 = true;
                    house5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 7)
            {
                if (kvc == "player0" && !street6 && bm >= 200)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse6 = true;
                    street6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player3" && !house6 && bm >= 40 && kvch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player3" && !house6 && bm >= 100 && kvch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house6 = true;
                }
                // Occupied
                else if (!occ6 && kvc == "player2")
                {
                    if (KVCH == 0)
                    {
                        p2m = 20;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p2m = 24;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p2m = 28;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p2m = 38;
                        m = bm - p2m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player1")
                {
                    if (KVCH == 0)
                    {
                        p1m = 20;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p1m = 24;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p1m = 28;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p1m = 38;
                        m = bm - p1m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player4")
                {
                    if (KVCH == 0)
                    {
                        p4m = 20;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p4m = 24;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p4m = 28;
                        m = bm - p4m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p4m = 38;
                        m = bm - p4m;
                        occ6 = true;
                    }
                }
                if (street6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 200)
                {
                    m = bm - 200;
                    kvc = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    kvcw = 200;
                    street6 = false;
                    yeshouse6 = true;
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 40 && kvch < 2)
                {
                    m = bm - 40;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (kvch == 0)
                    {
                        kvch = 1;
                        kvcw = 240;
                        house6 = false;
                        yeshouse6 = true;
                    }
                    else if (kvch == 1)
                    {
                        kvch = 2;
                        kvcw = 280;
                        house6 = false;
                        yeshouse6 = true;
                    }
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100 && kvch == 2)
                {
                    m = bm - 100;
                    Console.WriteLine("You own a hotel, please note it");
                    kvch = 3;
                    house6 = false;
                    yeshouse6 = true;
                }
                else if ((street6 || house6) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street6 = true;
                    house6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 6)
            {
                if (hv == "player0" && !street7 && bm >= 240)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse7 = true;
                    street7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player3" && !house7 && bm >= 48 && hvh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player3" && !house7 && bm >= 120 && hvh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house7 = true;
                }
                // Occupied
                else if (!occ7 && hv == "player2")
                {
                    if (HVH == 0)
                    {
                        p2m = 24;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p2m = 29;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p2m = 46;
                        m = bm - p2m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player1")
                {
                    if (HVH == 0)
                    {
                        p1m = 24;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p1m = 29;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p1m = 46;
                        m = bm - p1m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player4")
                {
                    if (HVH == 0)
                    {
                        p4m = 24;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p4m = 29;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p4m = 46;
                        m = bm - p4m;
                        occ7 = true;
                    }
                }
                if (street7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 240)
                {
                    m = bm - 240;
                    hv = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvw = 240;
                    street7 = false;
                    yeshouse7 = true;
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 48 && hvh < 2)
                {
                    m = bm - 48;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvh == 0)
                    {
                        hvh = 1;
                        hvw = 240;
                        house7 = false;
                        yeshouse7 = true;
                    }
                    else if (hvh == 1)
                    {
                        hvh = 2;
                        hvw = 280;
                        house7 = false;
                        yeshouse7 = true;
                    }
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120 && hvh == 2)
                {
                    m = bm - 120;
                    Console.WriteLine("You own a hotel, please note it");
                    hvh = 3;
                    house7 = false;
                    yeshouse7 = true;
                }
                else if ((street7 || house7) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street7 = true;
                    house7 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 3)
            {
                if (nt == "player0" && !street8 && bm >= 260)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse8 = true;
                    street8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player3" && !house8 && bm >= 52 && nth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player3" && !house8 && bm >= 130 && nth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house8 = true;
                }

                // Occupied
                else if (!occ8 && nt == "player2")
                {
                    if (NTH == 0)
                    {
                        p2m = 26;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p2m = 31;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p2m = 36;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p2m = 49;
                        m = bm - p2m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player1")
                {
                    if (NTH == 0)
                    {
                        p1m = 26;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p1m = 31;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p1m = 36;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p1m = 49;
                        m = bm - p1m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player4")
                {
                    if (NTH == 0)
                    {
                        p4m = 26;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p4m = 31;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p4m = 36;
                        m = bm - p4m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p4m = 49;
                        m = bm - p4m;
                        occ8 = true;
                    }
                }
                if (street8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 260)
                {
                    m = bm - 260;
                    nt = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    ntw = 260;
                    street8 = false;
                    yeshouse8 = true;
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 52 && nth < 2)
                {
                    m = bm - 52;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nth == 0)
                    {
                        nth = 1;
                        ntw = 312;
                        house8 = false;
                        yeshouse8 = true;
                    }
                    else if (nth == 1)
                    {
                        nth = 2;
                        ntw = 364;
                        house8 = false;
                        yeshouse8 = true;
                    }
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 130 && nth == 2)
                {
                    m = bm - 130;
                    Console.WriteLine("You own a hotel, please note it");
                    nth = 3;
                    house8 = false;
                    yeshouse8 = true;
                }
                else if ((street8 || house8) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street8 = true;
                    house8 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 1)
            {
                if (pnl == "player0" && !street9 && bm >= 280)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse9 = true;
                    street9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player3" && !house9 && bm >= 56 && pnlh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player3" && !house9 && bm >= 140 && pnlh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house9 = true;
                }

                // Occupied
                else if (!occ9 && pnl == "player2")
                {
                    if (PNLH == 0)
                    {
                        p2m = 28;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p2m = 39;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p2m = 53;
                        m = bm - p2m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player1")
                {
                    if (PNLH == 0)
                    {
                        p1m = 28;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p1m = 39;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p1m = 53;
                        m = bm - p1m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player4")
                {
                    if (PNLH == 0)
                    {
                        p4m = 28;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p4m = 34;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p4m = 39;
                        m = bm - p4m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p4m = 53;
                        m = bm - p4m;
                        occ9 = true;
                    }
                }
                if (street9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 280)
                {
                    m = bm - 280;
                    pnl = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    pnlw = 280;
                    street9 = false;
                    yeshouse9 = true;
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 56 && pnlh < 2)
                {
                    m = bm - 56;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (pnlh == 0)
                    {
                        pnlh = 1;
                        pnlw = 336;
                        house9 = false;
                        yeshouse9 = true;
                    }
                    else if (pnlh == 1)
                    {
                        pnlh = 2;
                        pnlw = 392;
                        house9 = false;
                        yeshouse9 = true;
                    }
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 140 && pnlh == 2)
                {
                    m = bm - 140;
                    Console.WriteLine("You own a hotel, please note it");
                    pnlh = 3;
                    house9 = false;
                    yeshouse9 = true;
                }
                else if ((street9 || house9) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street9 = true;
                    house9 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 5 && Y == 0)
            {
                if (vts == "player0" && !street10 && bm >= 320)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse10 = true;
                    street10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player3" && !house10 && bm >= 64 && vtsh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player3" && !house10 && bm >= 160 && vtsh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house10 = true;
                }
                // Occupied
                else if (!occ10 && vts == "player2")
                {
                    if (VTSH == 0)
                    {
                        p2m = 32;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p2m = 38;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p2m = 45;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p2m = 61;
                        m = bm - p2m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player1")
                {
                    if (VTSH == 0)
                    {
                        p1m = 32;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p1m = 38;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p1m = 45;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p1m = 61;
                        m = bm - p1m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player4")
                {
                    if (VTSH == 0)
                    {
                        p4m = 32;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p4m = 38;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p4m = 45;
                        m = bm - p4m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p4m = 61;
                        m = bm - p4m;
                        occ10 = true;
                    }
                }
                if (street10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 320)
                {
                    m = bm - 320;
                    vts = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    vtsw = 320;
                    street10 = false;
                    yeshouse10 = true;
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 64 && vtsh < 2)
                {
                    m = bm - 64;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (vtsh == 0)
                    {
                        vtsh = 1;
                        vtsw = 384;
                        house10 = false;
                        yeshouse10 = true;
                    }
                    else if (vtsh == 1)
                    {
                        vtsh = 2;
                        vtsw = 448;
                        house10 = false;
                        yeshouse10 = true;
                    }
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160 && vtsh == 2)
                {
                    m = bm - 160;
                    Console.WriteLine("You own a hotel, please note it");
                    vtsh = 3;
                    house10 = false;
                    yeshouse10 = true;
                }
                else if ((street10 || house10) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street10 = true;
                    house10 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 0)
            {
                if (ll == "player0" && !street11 && bm >= 360)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse11 = true;
                    street11 = true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player3" && !house11 && bm >= 72 && llh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house11 = true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player3" && !house11 && bm >= 180 && llh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house11 = true;
                }

                // Occupied
                else if (!occ11 && ll == "player2")
                {
                    if (LLH == 0)
                    {
                        p2m = 36;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p2m = 43;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p2m = 50;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p2m = 68;
                        m = bm - p2m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player1")
                {
                    if (LLH == 0)
                    {
                        p1m = 36;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p1m = 43;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p1m = 50;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p1m = 68;
                        m = bm - p1m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player4")
                {
                    if (LLH == 0)
                    {
                        p4m = 36;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p4m = 43;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p4m = 50;
                        m = bm - p4m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p4m = 68;
                        m = bm - p4m;
                        occ11 = true;
                    }
                }
                if (street11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 360)
                {
                    m = bm - 360;
                    ll = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    llw = 360;
                    street11 = false;
                    yeshouse11 = true;
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 72 && llh < 2)
                {
                    m = bm - 72;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (llh == 0)
                    {
                        llh = 1;
                        llw = 432;
                        house11 = false;
                        yeshouse11 = true;
                    }
                    else if (llh == 1)
                    {
                        llh = 2;
                        llw = 594;
                        house11 = false;
                        yeshouse11 = true;
                    }
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180 && llh == 2)
                {
                    m = bm - 180;
                    Console.WriteLine("You own a hotel, please note it");
                    llh = 3;
                    house11 = false;
                    yeshouse11 = true;
                }
                else if ((street11 || house11) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street11 = true;
                    house11 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 0)
            {
                if (nh == "player0" && !street12 && bm >= 380)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse12 = true;
                    street12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player3" && !house12 && bm >= 76 && nhh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player3" && !house12 && bm >= 190 && nhh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house12 = true;
                }

                // Occupied
                else if (!occ12 && nh == "player2")
                {
                    if (NHH == 0)
                    {
                        p2m = 380;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p2m = 46;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p2m = 53;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p2m = 72;
                        m = bm - p2m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player1")
                {
                    if (NHH == 0)
                    {
                        p1m = 380;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p1m = 46;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p1m = 53;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p1m = 72;
                        m = bm - p1m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player4")
                {
                    if (NHH == 0)
                    {
                        p4m = 380;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p4m = 46;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p4m = 53;
                        m = bm - p4m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p4m = 72;
                        m = bm - p4m;
                        occ12 = true;
                    }
                }
                if (street12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 380)
                {
                    m = bm - 380;
                    nh = "player3";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    nhw = 380;
                    street12 = false;
                    yeshouse12 = true;
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 76 && nhh < 2)
                {
                    m = bm - 76;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nhh == 0)
                    {
                        nhh = 1;
                        nhw = 432;
                        house12 = false;
                        yeshouse12 = true;
                    }
                    else if (nhh == 1)
                    {
                        nhh = 2;
                        nhw = 594;
                        house12 = false;
                        yeshouse12 = true;
                    }
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 190 && nhh == 2)
                {
                    m = bm - 190;
                    Console.WriteLine("You own a hotel, please note it");
                    nhh = 3;
                    house12 = false;
                    yeshouse12 = true;
                }
                else if ((street12 || house12) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street12 = true;
                    house12 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (!(X == 0 && Y == 1))
            {
                occ1 = false;
                nohouse1 = false;
                yeshouse1 = false;
                street1 = false; house1 = false;
            }
            if (!(X == 0 && Y == 4))
            {
                occ2 = false;
                nohouse2 = false;
                yeshouse2 = false;
                street2 = false; house2 = false;
            }
            if (!(X == 0 && Y == 6))
            {
                occ3 = false;
                nohouse3 = false;
                yeshouse3 = false;
                street3 = false; house3 = false;
            }
            if (!(X == 2 && Y == 7))
            {
                occ4 = false;
                nohouse4 = false;
                yeshouse4 = false;
                street4 = false; house4 = false;
            }
            if (!(X == 4 && Y == 7))
            {
                occ5 = false;
                nohouse5 = false;
                yeshouse5 = false;
                street5 = false; house5 = false;
            }
            if (!(X == 6 && Y == 7))
            {
                occ6 = false;
                nohouse6 = false;
                yeshouse6 = false;
                street6 = false; house6 = false;
            }
            if (!(X == 7 && Y == 6))
            {
                occ7 = false;
                nohouse7 = false;
                yeshouse7 = false;
                street7 = false; house7 = false;
            }
            if (!(X == 7 && Y == 3))
            {
                occ8 = false;
                nohouse8 = false;
                yeshouse8 = false;
                street8 = false; house8 = false;
            }
            if (!(X == 7 && Y == 1))
            {
                occ9 = false;
                nohouse9 = false;
                yeshouse9 = false;
                street9 = false; house9 = false;
            }
            if (!(X == 5 && Y == 0))
            {
                occ10 = false;
                nohouse10 = false;
                yeshouse10 = false;
                street10 = false; house10 = false;
            }
            if (!(X == 3 && Y == 0))
            {
                occ11 = false;
                nohouse11 = false;
                yeshouse11 = false;
                street11 = false; house11 = false;
            }
            if (!(X == 1 && Y == 0))
            {
                occ12 = false;
                nohouse12 = false;
                yeshouse12 = false;
                street12 = false; house12 = false;
            }
            /*if (!occ1 && !occ2 && !occ3 && !occ4 && !occ5 && !occ6 && !occ7 && !occ8 && !occ9 && !occ10 && !occ11 && !occ12)
            {
                p1m = 0; p2m = 0; p3m = 0; p4m = 0;
            }*/
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            LBB = lbb; CH = ch; QT = qt; TC = tc; HVT = hvt; KVC = kvc; HV = hv; NT = nt; PNL = pnl; VTS = vts; LL = ll; NH = nh;
            LBBH = lbbh; CHH = chh; QTH = qth; TCH = tch; HVTH = hvth; KVCH = kvch; HVH = hvh; NTH = nth; PNLH = pnlh; VTSH = vtsh; LLH = llh; NHH = nhh;
            LBBW = lbbw; CHW = chw; QTW = qtw; TCW = tcw; HVTW = hvtw; KVCW = kvcw; HVW = hvw; NTW = ntw; PNLW = pnlw; VTSW = vtsw; LLW = llw; NHW = nhw;

        }

        public void P4RE(int bm, int X, int Y, string lbb, string ch, string qt, string tc, string hvt, string kvc, string hv, string nt, string pnl, string vts, string ll, string nh, int lbbh, int chh, int qth, int tch, int hvth, int kvch, int hvh, int nth, int pnlh, int vtsh, int llh, int nhh, int lbbw, int chw, int qtw, int tcw, int hvtw, int kvcw, int hvw, int ntw, int pnlw, int vtsw, int llw, int nhw, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 1)
            {
                if (lbb == "player0" && !street1 && bm >= 60)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse1 = true;
                    street1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player4" && !house1 && bm >= 12 && lbbh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house1 = true;
                }
                if (!yeshouse1 && !nohouse1 && lbb == "player4" && !house1 && bm >= 30 && lbbh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house1 = true;
                }
                // Occupied
                else if (!occ1 && lbb == "player2")
                {
                    if (LBBH == 0)
                    {
                        p2m = 6;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p2m = 7;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p2m = 8;
                        m = bm - p2m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p2m = 11;
                        m = bm - p2m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player3")
                {
                    if (LBBH == 0)
                    {
                        p3m = 6;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p3m = 7;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p3m = 8;
                        m = bm - p3m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p3m = 11;
                        m = bm - p3m;
                        occ1 = true;
                    }
                }
                else if (!occ1 && lbb == "player1")
                {
                    if (LBBH == 0)
                    {
                        p1m = 6;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 1)
                    {
                        p1m = 7;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 2)
                    {
                        p1m = 8;
                        m = bm - p1m;
                        occ1 = true;
                    }
                    else if (LBBH == 3)
                    {
                        p1m = 11;
                        m = bm - p1m;
                        occ1 = true;
                    }
                }
                if (street1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60)
                {
                    m = bm - 60;
                    lbb = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    lbbw = 60;
                    street1 = false;
                    yeshouse1 = true;
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 12 && lbbh < 2)
                {
                    m = bm - 12;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (lbbh == 0)
                    {
                        lbbh = 1;
                        lbbw = 72;
                        house1 = false;
                        yeshouse1 = true;
                    }
                    else if (lbbh == 1)
                    {
                        lbbh = 2;
                        lbbw = 84;
                        house1 = false;
                        yeshouse1 = true;
                    }
                }
                if (house1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 30 && lbbh == 2)
                {
                    m = bm - 30;
                    Console.WriteLine("You own a hotel, please note it");
                    lbbh = 3;
                    house1 = false;
                    yeshouse1 = true;
                }
                else if ((street1 || house1) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street1 = true;
                    house1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 4)
            {
                if (ch == "player0" && !street2 && bm >= 100)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse2 = true;
                    street2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player4" && !house2 && bm >= 20 && chh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house or [N] to skip");
                    house2 = true;
                }
                if (!yeshouse2 && !nohouse2 && ch == "player4" && !house2 && bm >= 50 && chh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house2 = true;
                }
                // Occupied
                else if (!occ2 && ch == "player2")
                {
                    if (CHH == 0)
                    {
                        p2m = 10;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p2m = 12;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p2m = 14;
                        m = bm - p2m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p2m = 19;
                        m = bm - p2m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player3")
                {
                    if (CHH == 0)
                    {
                        p3m = 10;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p3m = 12;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p3m = 14;
                        m = bm - p3m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p3m = 19;
                        m = bm - p3m;
                        occ2 = true;
                    }
                }
                else if (!occ2 && ch == "player1")
                {
                    if (CHH == 0)
                    {
                        p1m = 10;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 1)
                    {
                        p1m = 12;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 2)
                    {
                        p1m = 14;
                        m = bm - p1m;
                        occ2 = true;
                    }
                    else if (CHH == 3)
                    {
                        p1m = 19;
                        m = bm - p1m;
                        occ2 = true;
                    }
                }
                if (street2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ch = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    chw = 100;
                    street2 = false;
                    yeshouse2 = true;
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 20 && chh < 2)
                {
                    m = bm - 20;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (chh == 0)
                    {
                        chh = 1;
                        chw = 120;
                        house2 = false;
                        yeshouse2 = true;
                    }
                    else if (chh == 1)
                    {
                        chh = 2;
                        chw = 140;
                        house2 = false;
                        yeshouse2 = true;
                    }
                }
                if (house2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 50 && chh == 2)
                {
                    m = bm - 50;
                    Console.WriteLine("You own a hotel, please note it");
                    chh = 3;
                    house2 = false;
                    yeshouse2 = true;
                }
                else if ((street2 || house2) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street2 = true;
                    house2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 0 && Y == 6)
            {
                if (qt == "player0" && !street3 && bm >= 120)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse3 = true;
                    street3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player4" && !house3 && bm >= 24 && qth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house3 = true;
                }
                if (!yeshouse3 && !nohouse3 && qt == "player4" && !house3 && bm >= 60 && qth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house3 = true;
                }
                // Occupied
                else if (!occ3 && qt == "player2")
                {
                    if (QTH == 0)
                    {
                        p2m = 12;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p2m = 14;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p2m = 17;
                        m = bm - p2m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player3")
                {
                    if (QTH == 0)
                    {
                        p3m = 12;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p3m = 14;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p3m = 17;
                        m = bm - p3m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ3 = true;
                    }
                }
                else if (!occ3 && qt == "player1")
                {
                    if (QTH == 0)
                    {
                        p1m = 12;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 1)
                    {
                        p1m = 14;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 2)
                    {
                        p1m = 17;
                        m = bm - p1m;
                        occ3 = true;
                    }
                    else if (QTH == 3)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ3 = true;
                    }
                }
                if (street3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120)
                {
                    m = bm - 120;
                    qt = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    qtw = 120;
                    street3 = false;
                    yeshouse3 = true;
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 24 && qth < 2)
                {
                    m = bm - 24;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (qth == 0)
                    {
                        qth = 1;
                        qtw = 144;
                        house3 = false;
                        yeshouse3 = true;
                    }
                    else if (qth == 1)
                    {
                        qth = 2;
                        qtw = 166;
                        house3 = false;
                        yeshouse3 = true;
                    }
                }
                if (house3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 60 && qth == 2)
                {
                    m = bm - 60;
                    Console.WriteLine("You own a hotel, please note it");
                    qth = 3;
                    house3 = false;
                    yeshouse3 = true;
                }
                else if ((street3 || house3) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street3 = true;
                    house3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 2 && Y == 7)
            {
                if (tc == "player0" && !street4 && bm >= 160)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse4 = true;
                    street4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player4" && !house4 && bm >= 32 && tch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house4 = true;
                }
                if (!yeshouse4 && !nohouse4 && tc == "player4" && !house4 && bm >= 80 && tch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house4 = true;
                }
                // Occupied
                else if (!occ4 && tc == "player2")
                {
                    if (TCH == 0)
                    {
                        p2m = 16;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p2m = 19;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p2m = 30;
                        m = bm - p2m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player3")
                {
                    if (TCH == 0)
                    {
                        p3m = 16;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p3m = 19;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p3m = 30;
                        m = bm - p3m;
                        occ4 = true;
                    }
                }
                else if (!occ4 && tc == "player1")
                {
                    if (TCH == 0)
                    {
                        p1m = 16;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 1)
                    {
                        p1m = 19;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 2)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ4 = true;
                    }
                    else if (TCH == 3)
                    {
                        p1m = 30;
                        m = bm - p1m;
                        occ4 = true;
                    }
                }
                if (street4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160)
                {
                    m = bm - 160;
                    tc = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    tcw = 160;
                    street4 = false;
                    yeshouse4 = true;
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 32 && tch < 2)
                {
                    m = bm - 32;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (tch == 0)
                    {
                        tch = 1;
                        tcw = 192;
                        house4 = false;
                        yeshouse4 = true;
                    }
                    else if (tch == 1)
                    {
                        tch = 2;
                        tcw = 224;
                        house4 = false;
                        yeshouse4 = true;
                    }
                }
                if (house4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 80 && tch == 2)
                {
                    m = bm - 80;
                    Console.WriteLine("You own a hotel, please note it");
                    tch = 3;
                    house4 = false;
                    yeshouse4 = true;
                }
                else if ((street4 || house4) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street4 = true;
                    house4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 7)
            {
                if (hvt == "player0" && !street5 && bm >= 180)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse5 = true;
                    street5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player4" && !house5 && bm >= 36 && hvth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house5 = true;
                }
                if (!yeshouse5 && !nohouse5 && hvt == "player4" && !house5 && bm >= 90 && hvth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house5 = true;
                }
                // Occupied
                else if (!occ5 && hvt == "player2")
                {
                    if (HVTH == 0)
                    {
                        p2m = 18;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p2m = 22;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p2m = 25;
                        m = bm - p2m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player3")
                {
                    if (HVTH == 0)
                    {
                        p3m = 18;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p3m = 22;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p3m = 25;
                        m = bm - p3m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ5 = true;
                    }
                }
                else if (!occ5 && hvt == "player1")
                {
                    if (HVTH == 0)
                    {
                        p1m = 18;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 1)
                    {
                        p1m = 22;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 2)
                    {
                        p1m = 25;
                        m = bm - p1m;
                        occ5 = true;
                    }
                    else if (HVTH == 3)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ5 = true;
                    }
                }
                if (street5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180)
                {
                    m = bm - 180;
                    hvt = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvtw = 180;
                    street5 = false;
                    yeshouse5 = true;
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 36 && hvth < 2)
                {
                    m = bm - 36;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvth == 0)
                    {
                        hvth = 1;
                        hvtw = 216;
                        house5 = false;
                        yeshouse5 = true;
                    }
                    else if (hvth == 1)
                    {
                        hvth = 2;
                        hvtw = 249;
                        house5 = false;
                        yeshouse5 = true;
                    }
                }
                if (house5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 90 && hvth == 2)
                {
                    m = bm - 90;
                    Console.WriteLine("You own a hotel, please note it");
                    hvth = 3;
                    house5 = false;
                    yeshouse5 = true;
                }

                else if ((street5 || house5) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street5 = true;
                    house5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 7)
            {
                if (kvc == "player0" && !street6 && bm >= 200)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse6 = true;
                    street6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player4" && !house6 && bm >= 40 && kvch < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house6 = true;
                }
                if (!yeshouse6 && !nohouse6 && kvc == "player4" && !house6 && bm >= 100 && kvch == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house6 = true;
                }
                // Occupied
                else if (!occ6 && kvc == "player2")
                {
                    if (KVCH == 0)
                    {
                        p2m = 20;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p2m = 24;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p2m = 28;
                        m = bm - p2m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p2m = 38;
                        m = bm - p2m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player3")
                {
                    if (KVCH == 0)
                    {
                        p3m = 20;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p3m = 24;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p3m = 28;
                        m = bm - p3m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p3m = 38;
                        m = bm - p3m;
                        occ6 = true;
                    }
                }
                else if (!occ6 && kvc == "player1")
                {
                    if (KVCH == 0)
                    {
                        p1m = 20;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 1)
                    {
                        p1m = 24;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 2)
                    {
                        p1m = 28;
                        m = bm - p1m;
                        occ6 = true;
                    }
                    else if (KVCH == 3)
                    {
                        p1m = 38;
                        m = bm - p1m;
                        occ6 = true;
                    }
                }
                if (street6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 200)
                {
                    m = bm - 200;
                    kvc = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    kvcw = 200;
                    street6 = false;
                    yeshouse6 = true;
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 40 && kvch < 2)
                {
                    m = bm - 40;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (kvch == 0)
                    {
                        kvch = 1;
                        kvcw = 240;
                        house6 = false;
                        yeshouse6 = true;
                    }
                    else if (kvch == 1)
                    {
                        kvch = 2;
                        kvcw = 280;
                        house6 = false;
                        yeshouse6 = true;
                    }
                }
                if (house6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100 && kvch == 2)
                {
                    m = bm - 100;
                    Console.WriteLine("You own a hotel, please note it");
                    kvch = 3;
                    house6 = false;
                    yeshouse6 = true;
                }
                else if ((street6 || house6) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street6 = true;
                    house6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 6)
            {
                if (hv == "player0" && !street7 && bm >= 240)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse7 = true;
                    street7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player4" && !house7 && bm >= 48 && hvh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house7 = true;
                }
                if (!yeshouse7 && !nohouse7 && hv == "player4" && !house7 && bm >= 120 && hvh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house7 = true;
                }
                // Occupied
                else if (!occ7 && hv == "player2")
                {
                    if (HVH == 0)
                    {
                        p2m = 24;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p2m = 29;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p2m = 46;
                        m = bm - p2m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player3")
                {
                    if (HVH == 0)
                    {
                        p3m = 24;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p3m = 29;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p3m = 46;
                        m = bm - p3m;
                        occ7 = true;
                    }
                }
                else if (!occ7 && hv == "player1")
                {
                    if (HVH == 0)
                    {
                        p1m = 24;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 1)
                    {
                        p1m = 29;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 2)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ7 = true;
                    }
                    else if (HVH == 3)
                    {
                        p1m = 46;
                        m = bm - p1m;
                        occ7 = true;
                    }
                }
                if (street7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 240)
                {
                    m = bm - 240;
                    hv = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    hvw = 240;
                    street7 = false;
                    yeshouse7 = true;
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 48 && hvh < 2)
                {
                    m = bm - 48;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (hvh == 0)
                    {
                        hvh = 1;
                        hvw = 240;
                        house7 = false;
                        yeshouse7 = true;
                    }
                    else if (hvh == 1)
                    {
                        hvh = 2;
                        hvw = 280;
                        house7 = false;
                        yeshouse7 = true;
                    }
                }
                if (house7 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 120 && hvh == 2)
                {
                    m = bm - 120;
                    Console.WriteLine("You own a hotel, please note it");
                    hvh = 3;
                    house7 = false;
                    yeshouse7 = true;
                }
                else if ((street7 || house7) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street7 = true;
                    house7 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 3)
            {
                if (nt == "player0" && !street8 && bm >= 260)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse8 = true;
                    street8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player4" && !house8 && bm >= 52 && nth < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house8 = true;
                }
                if (!yeshouse8 && !nohouse8 && nt == "player4" && !house8 && bm >= 130 && nth == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house8 = true;
                }

                // Occupied
                else if (!occ8 && nt == "player2")
                {
                    if (NTH == 0)
                    {
                        p2m = 26;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p2m = 31;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p2m = 36;
                        m = bm - p2m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p2m = 49;
                        m = bm - p2m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player3")
                {
                    if (NTH == 0)
                    {
                        p3m = 26;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p3m = 31;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p3m = 36;
                        m = bm - p3m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p3m = 49;
                        m = bm - p3m;
                        occ8 = true;
                    }
                }
                else if (!occ8 && nt == "player1")
                {
                    if (NTH == 0)
                    {
                        p1m = 26;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 1)
                    {
                        p1m = 31;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 2)
                    {
                        p1m = 36;
                        m = bm - p1m;
                        occ8 = true;
                    }
                    else if (NTH == 3)
                    {
                        p1m = 49;
                        m = bm - p1m;
                        occ8 = true;
                    }
                }
                if (street8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 260)
                {
                    m = bm - 260;
                    nt = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    ntw = 260;
                    street8 = false;
                    yeshouse8 = true;
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 52 && nth < 2)
                {
                    m = bm - 52;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nth == 0)
                    {
                        nth = 1;
                        ntw = 312;
                        house8 = false;
                        yeshouse8 = true;
                    }
                    else if (nth == 1)
                    {
                        nth = 2;
                        ntw = 364;
                        house8 = false;
                        yeshouse8 = true;
                    }
                }
                if (house8 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 130 && nth == 2)
                {
                    m = bm - 130;
                    Console.WriteLine("You own a hotel, please note it");
                    nth = 3;
                    house8 = false;
                    yeshouse8 = true;
                }
                else if ((street8 || house8) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street8 = true;
                    house8 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 1)
            {
                if (pnl == "player0" && !street9 && bm >= 280)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse9 = true;
                    street9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player4" && !house9 && bm >= 56 && pnlh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house9 = true;
                }
                if (!yeshouse9 && !nohouse9 && pnl == "player4" && !house9 && bm >= 140 && pnlh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house9 = true;
                }

                // Occupied
                else if (!occ9 && pnl == "player2")
                {
                    if (PNLH == 0)
                    {
                        p2m = 28;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p2m = 34;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p2m = 39;
                        m = bm - p2m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p2m = 53;
                        m = bm - p2m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player3")
                {
                    if (PNLH == 0)
                    {
                        p3m = 28;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p3m = 34;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p3m = 39;
                        m = bm - p3m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p3m = 53;
                        m = bm - p3m;
                        occ9 = true;
                    }
                }
                else if (!occ9 && pnl == "player1")
                {
                    if (PNLH == 0)
                    {
                        p1m = 28;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 1)
                    {
                        p1m = 34;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 2)
                    {
                        p1m = 39;
                        m = bm - p1m;
                        occ9 = true;
                    }
                    else if (PNLH == 3)
                    {
                        p1m = 53;
                        m = bm - p1m;
                        occ9 = true;
                    }
                }
                if (street9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 280)
                {
                    m = bm - 280;
                    pnl = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    pnlw = 280;
                    street9 = false;
                    yeshouse9 = true;
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 56 && pnlh < 2)
                {
                    m = bm - 56;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (pnlh == 0)
                    {
                        pnlh = 1;
                        pnlw = 336;
                        house9 = false;
                        yeshouse9 = true;
                    }
                    else if (pnlh == 1)
                    {
                        pnlh = 2;
                        pnlw = 392;
                        house9 = false;
                        yeshouse9 = true;
                    }
                }
                if (house9 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 140 && pnlh == 2)
                {
                    m = bm - 140;
                    Console.WriteLine("You own a hotel, please note it");
                    pnlh = 3;
                    house9 = false;
                    yeshouse9 = true;
                }
                else if ((street9 || house9) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street9 = true;
                    house9 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 5 && Y == 0)
            {
                if (vts == "player0" && !street10 && bm >= 320)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse10 = true;
                    street10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player4" && !house10 && bm >= 64 && vtsh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house10 = true;
                }
                if (!yeshouse10 && !nohouse10 && vts == "player4" && !house10 && bm >= 160 && vtsh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house10 = true;
                }
                // Occupied
                else if (!occ10 && vts == "player2")
                {
                    if (VTSH == 0)
                    {
                        p2m = 32;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p2m = 38;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p2m = 45;
                        m = bm - p2m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p2m = 61;
                        m = bm - p2m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player3")
                {
                    if (VTSH == 0)
                    {
                        p3m = 32;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p3m = 38;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p3m = 45;
                        m = bm - p3m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p3m = 61;
                        m = bm - p3m;
                        occ10 = true;
                    }
                }
                else if (!occ10 && vts == "player1")
                {
                    if (VTSH == 0)
                    {
                        p1m = 32;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 1)
                    {
                        p1m = 38;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 2)
                    {
                        p1m = 45;
                        m = bm - p1m;
                        occ10 = true;
                    }
                    else if (VTSH == 3)
                    {
                        p1m = 61;
                        m = bm - p1m;
                        occ10 = true;
                    }
                }
                if (street10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 320)
                {
                    m = bm - 320;
                    vts = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    vtsw = 320;
                    street10 = false;
                    yeshouse10 = true;
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 64 && vtsh < 2)
                {
                    m = bm - 64;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (vtsh == 0)
                    {
                        vtsh = 1;
                        vtsw = 384;
                        house10 = false;
                        yeshouse10 = true;
                    }
                    else if (vtsh == 1)
                    {
                        vtsh = 2;
                        vtsw = 448;
                        house10 = false;
                        yeshouse10 = true;
                    }
                }
                if (house10 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 160 && vtsh == 2)
                {
                    m = bm - 160;
                    Console.WriteLine("You own a hotel, please note it");
                    vtsh = 3;
                    house10 = false;
                    yeshouse10 = true;
                }
                else if ((street10 || house10) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street10 = true;
                    house10 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 0)
            {
                if (ll == "player0" && !street11 && bm >= 360)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse11 = true;
                    street11 = true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player4" && !house11 && bm >= 72 && llh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house11 = true;
                }
                if (!yeshouse11 && !nohouse11 && ll == "player4" && !house11 && bm >= 180 && llh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house11 = true;
                }

                // Occupied
                else if (!occ11 && ll == "player2")
                {
                    if (LLH == 0)
                    {
                        p2m = 36;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p2m = 43;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p2m = 50;
                        m = bm - p2m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p2m = 68;
                        m = bm - p2m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player3")
                {
                    if (LLH == 0)
                    {
                        p3m = 36;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p3m = 43;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p3m = 50;
                        m = bm - p3m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p3m = 68;
                        m = bm - p3m;
                        occ11 = true;
                    }
                }
                else if (!occ11 && ll == "player1")
                {
                    if (LLH == 0)
                    {
                        p1m = 36;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 1)
                    {
                        p1m = 43;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 2)
                    {
                        p1m = 50;
                        m = bm - p1m;
                        occ11 = true;
                    }
                    else if (LLH == 3)
                    {
                        p1m = 68;
                        m = bm - p1m;
                        occ11 = true;
                    }
                }
                if (street11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 360)
                {
                    m = bm - 360;
                    ll = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    llw = 360;
                    street11 = false;
                    yeshouse11 = true;
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 72 && llh < 2)
                {
                    m = bm - 72;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (llh == 0)
                    {
                        llh = 1;
                        llw = 432;
                        house11 = false;
                        yeshouse11 = true;
                    }
                    else if (llh == 1)
                    {
                        llh = 2;
                        llw = 594;
                        house11 = false;
                        yeshouse11 = true;
                    }
                }
                if (house11 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 180 && llh == 2)
                {
                    m = bm - 180;
                    Console.WriteLine("You own a hotel, please note it");
                    llh = 3;
                    house11 = false;
                    yeshouse11 = true;
                }
                else if ((street11 || house11) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street11 = true;
                    house11 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 0)
            {
                if (nh == "player0" && !street12 && bm >= 380)
                {
                    Console.WriteLine("This street hasn't been occupied, press [Y] to buy it or [N] to skip");
                    nohouse12 = true;
                    street12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player4" && !house12 && bm >= 76 && nhh < 2)
                {
                    Console.WriteLine("You already owned the street, press [Y] to buy house it or [N] to skip");
                    house12 = true;
                }
                if (!yeshouse12 && !nohouse12 && nh == "player4" && !house12 && bm >= 190 && nhh == 2)
                {
                    Console.WriteLine("You already owned 2 houses , press [Y] to buy a hotel or [N] to skip");
                    house12 = true;
                }

                // Occupied
                else if (!occ12 && nh == "player2")
                {
                    if (NHH == 0)
                    {
                        p2m = 380;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p2m = 46;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p2m = 53;
                        m = bm - p2m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p2m = 72;
                        m = bm - p2m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player3")
                {
                    if (NHH == 0)
                    {
                        p3m = 380;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p3m = 46;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p3m = 53;
                        m = bm - p3m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p3m = 72;
                        m = bm - p3m;
                        occ12 = true;
                    }
                }
                else if (!occ12 && nh == "player1")
                {
                    if (NHH == 0)
                    {
                        p1m = 380;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 1)
                    {
                        p1m = 46;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 2)
                    {
                        p1m = 53;
                        m = bm - p1m;
                        occ12 = true;
                    }
                    else if (NHH == 3)
                    {
                        p1m = 72;
                        m = bm - p1m;
                        occ12 = true;
                    }
                }
                if (street12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 380)
                {
                    m = bm - 380;
                    nh = "player4";
                    Console.WriteLine("You own this street, please note it");
                    EO = EO + 1;
                    nhw = 380;
                    street12 = false;
                    yeshouse12 = true;
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 76 && nhh < 2)
                {
                    m = bm - 76;
                    Console.WriteLine("You own (one more)/(the) house, please note it");
                    if (nhh == 0)
                    {
                        nhh = 1;
                        nhw = 432;
                        house12 = false;
                        yeshouse12 = true;
                    }
                    else if (nhh == 1)
                    {
                        nhh = 2;
                        nhw = 594;
                        house12 = false;
                        yeshouse12 = true;
                    }
                }
                if (house12 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 190 && nhh == 2)
                {
                    m = bm - 190;
                    Console.WriteLine("You own a hotel, please note it");
                    nhh = 3;
                    house12 = false;
                    yeshouse12 = true;
                }
                else if ((street12 || house12) && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    street12 = true;
                    house12 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (!(X == 0 && Y == 1))
            {
                occ1 = false;
                nohouse1 = false;
                yeshouse1 = false;
                street1 = false; house1 = false;
            }
            if (!(X == 0 && Y == 4))
            {
                occ2 = false;
                nohouse2 = false;
                yeshouse2 = false;
                street2 = false; house2 = false;
            }
            if (!(X == 0 && Y == 6))
            {
                occ3 = false;
                nohouse3 = false;
                yeshouse3 = false;
                street3 = false; house3 = false;
            }
            if (!(X == 2 && Y == 7))
            {
                occ4 = false;
                nohouse4 = false;
                yeshouse4 = false;
                street4 = false; house4 = false;
            }
            if (!(X == 4 && Y == 7))
            {
                occ5 = false;
                nohouse5 = false;
                yeshouse5 = false;
                street5 = false; house5 = false;
            }
            if (!(X == 6 && Y == 7))
            {
                occ6 = false;
                nohouse6 = false;
                yeshouse6 = false;
                street6 = false; house6 = false;
            }
            if (!(X == 7 && Y == 6))
            {
                occ7 = false;
                nohouse7 = false;
                yeshouse7 = false;
                street7 = false; house7 = false;
            }
            if (!(X == 7 && Y == 3))
            {
                occ8 = false;
                nohouse8 = false;
                yeshouse8 = false;
                street8 = false; house8 = false;
            }
            if (!(X == 7 && Y == 1))
            {
                occ9 = false;
                nohouse9 = false;
                yeshouse9 = false;
                street9 = false; house9 = false;
            }
            if (!(X == 5 && Y == 0))
            {
                occ10 = false;
                nohouse10 = false;
                yeshouse10 = false;
                street10 = false; house10 = false;
            }
            if (!(X == 3 && Y == 0))
            {
                occ11 = false;
                nohouse11 = false;
                yeshouse11 = false;
                street11 = false; house11 = false;
            }
            if (!(X == 1 && Y == 0))
            {
                occ12 = false;
                nohouse12 = false;
                yeshouse12 = false;
                street12 = false; house12 = false;
            }
            /*if (!occ1 && !occ2 && !occ3 && !occ4 && !occ5 && !occ6 && !occ7 && !occ8 && !occ9 && !occ10 && !occ11 && !occ12)
            {
                p1m = 0; p2m = 0; p3m = 0; p4m = 0;
            }*/
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            LBB = lbb; CH = ch; QT = qt; TC = tc; HVT = hvt; KVC = kvc; HV = hv; NT = nt; PNL = pnl; VTS = vts; LL = ll; NH = nh;
            LBBH = lbbh; CHH = chh; QTH = qth; TCH = tch; HVTH = hvth; KVCH = kvch; HVH = hvh; NTH = nth; PNLH = pnlh; VTSH = vtsh; LLH = llh; NHH = nhh;
            LBBW = lbbw; CHW = chw; QTW = qtw; TCW = tcw; HVTW = hvtw; KVCW = kvcw; HVW = hvw; NTW = ntw; PNLW = pnlw; VTSW = vtsw; LLW = llw; NHW = nhw;

        }

        //Control services company ownership
        public void P1SC(int bm, int X, int Y, string bxcg, string bxcl, string bxmd, string bxmt, string ctdl, string ctcn, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 3)
            {
                if (bxcg == "player0" && !company1 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company1 = true;
                }
                // Occupied
                else if (!com1 && bxcg == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com1 = true;
                }
                if (company1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcg = "player1";
                    Console.WriteLine("You own this bus service, please note it");
                    company1 = false;
                }
                else if (company1 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 7)
            {
                if (bxcl == "player0" && !company2 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company2 = true;
                }
                // Occupied
                else if (!com2 && bxcl == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com2 = true;
                }
                if (company2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcl = "player1";
                    Console.WriteLine("You own this bus service, please note it");
                    company2 = false;
                }
                else if (company2 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 4)
            {
                if (bxmd == "player0" && !company3 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company3 = true;
                }
                // Occupied
                else if (!com3 && bxmd == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com3 = true;
                }
                if (company3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmd = "player1";
                    Console.WriteLine("You own this bus service, please note it");
                    company3 = false;
                }
                else if (company3 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 0)
            {
                if (bxmt == "player0" && !company4 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company4 = true;
                }
                // Occupied
                else if (!com4 && bxmt == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com4 = true;
                }
                if (company4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmt = "player1";
                    Console.WriteLine("You own this bus service, please note it");
                    company4 = false;
                }
                else if (company4 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 7)
            {
                if (ctdl == "player0" && !company5 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company5 = true;
                }
                // Occupied
                else if (!com5 && ctdl == "player2")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p2m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p2m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p2m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p2m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player3")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p3m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p3m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p3m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p3m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player4")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p4m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p4m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p4m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p4m = 20;
                        com5 = true;
                    }
                }
                if (company5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctdl = "player1";
                    Console.WriteLine("You own this electrical service, please note it");
                    company5 = false;
                }
                else if (company5 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 0)
            {
                if (ctcn == "player0" && !company6 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company6 = true;
                }
                // Occupied
                else if (!com6 && ctcn == "player2")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p2m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p2m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p2m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p2m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player3")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p3m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p3m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p3m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p3m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player4")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p4m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p4m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p4m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p4m = 20;
                        com6 = true;
                    }
                }
                if (company6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctcn = "player1";
                    Console.WriteLine("You own this water service, please note it");
                    company6 = false;
                }
                else if (company6 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            else if (!(X == 0 && Y == 3))
            {
                company1 = false;
                com1 = false;
            }
            else if (!(X == 3 && Y == 7))
            {
                company2 = false;
                com2 = false;
            }
            else if (!(X == 7 && Y == 4))
            {
                company3 = false;
                com3 = false;
            }
            else if (!(X == 4 && Y == 0))
            {
                company4 = false;
                com4 = false;
            }
            else if (!(X == 1 && Y == 7))
            {
                company5 = false;
                com5 = false;
            }
            else if (!(X == 6 && Y == 0))
            {
                company6 = false;
                com6 = false;
            }
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            BXCG = bxcg; BXCL = bxcl; BXMD = bxmd; BXMT = bxmt; CTDL = ctdl; CTCN = ctcn; 
        }

        public void P2SC(int bm, int X, int Y, string bxcg, string bxcl, string bxmd, string bxmt, string ctdl, string ctcn, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 3)
            {
                if (bxcg == "player0" && !company1 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company1 = true;
                }
                // Occupied
                else if (!com1 && bxcg == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com1 = true;
                }
                if (company1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcg = "player2";
                    Console.WriteLine("You own this bus service, please note it");
                    company1 = false;
                }
                else if (company1 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 7)
            {
                if (bxcl == "player0" && !company2 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company2 = true;
                }
                // Occupied
                else if (!com2 && bxcl == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com2 = true;
                }
                if (company2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcl = "player2";
                    Console.WriteLine("You own this bus service, please note it");
                    company2 = false;
                }
                else if (company2 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 4)
            {
                if (bxmd == "player0" && !company3 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company3 = true;
                }
                // Occupied
                else if (!com3 && bxmd == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com3 = true;
                }
                if (company3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmd = "player2";
                    Console.WriteLine("You own this bus service, please note it");
                    company3 = false;
                }
                else if (company3 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 0)
            {
                if (bxmt == "player0" && !company4 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company4 = true;
                }
                // Occupied
                else if (!com4 && bxmt == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com4 = true;
                }
                if (company4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmt = "player2";
                    Console.WriteLine("You own this bus service, please note it");
                    company4 = false;
                }
                else if (company4 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 7)
            {
                if (ctdl == "player0" && !company5 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company5 = true;
                }
                // Occupied
                else if (!com5 && ctdl == "player1")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p1m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p1m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p1m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p1m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player3")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p3m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p3m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p3m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p3m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player4")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p4m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p4m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p4m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p4m = 20;
                        com5 = true;
                    }
                }
                if (company5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctdl = "player2";
                    Console.WriteLine("You own this electrical service, please note it");
                    company5 = false;
                }
                else if (company5 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 0)
            {
                int sn = 0;
                if (ctcn == "player0" && !company6 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company6 = true;
                }
                // Occupied
                else if (!com6 && ctcn == "player1")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p1m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p1m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p1m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p1m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player3")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p3m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p3m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p3m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p3m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player4")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p4m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p4m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p4m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p4m = 20;
                        com6 = true;
                    }
                }
                if (company6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctcn = "player2";
                    Console.WriteLine("You own this water service, please note it");
                    company6 = false;
                }
                else if (company6 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            else if (!(X == 0 && Y == 3))
            {
                company1 = false;
                com1 = false;
            }
            else if (!(X == 3 && Y == 7))
            {
                company2 = false;
                com2 = false;
            }
            else if (!(X == 7 && Y == 4))
            {
                company3 = false;
                com3 = false;
            }
            else if (!(X == 4 && Y == 0))
            {
                company4 = false;
                com4 = false;
            }
            else if (!(X == 1 && Y == 7))
            {
                company5 = false;
                com5 = false;
            }
            else if (!(X == 6 && Y == 0))
            {
                company6 = false;
                com6 = false;
            }
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            BXCG = bxcg; BXCL = bxcl; BXMD = bxmd; BXMT = bxmt; CTDL = ctdl; CTCN = ctcn;
        }

        public void P3SC(int bm, int X, int Y, string bxcg, string bxcl, string bxmd, string bxmt, string ctdl, string ctcn, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 3)
            {
                if (bxcg == "player0" && !company1 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company1 = true;
                }
                // Occupied
                else if (!com1 && bxcg == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com1 = true;
                }
                if (company1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcg = "player3";
                    Console.WriteLine("You own this bus service, please note it");
                    company1 = false;
                }
                else if (company1 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 7)
            {
                if (bxcl == "player0" && !company2 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company2 = true;
                }
                // Occupied
                else if (!com2 && bxcl == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com2 = true;
                }
                if (company2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcl = "player3";
                    Console.WriteLine("You own this bus service, please note it");
                    company2 = false;
                }
                else if (company2 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 4)
            {
                if (bxmd == "player0" && !company3 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company3 = true;
                }
                // Occupied
                else if (!com3 && bxmd == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com3 = true;
                }
                if (company3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmd = "player3";
                    Console.WriteLine("You own this bus service, please note it");
                    company3 = false;
                }
                else if (company3 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 0)
            {
                if (bxmt == "player0" && !company4 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company4 = true;
                }
                // Occupied
                else if (!com4 && bxmt == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player4")
                {
                    m = bm - 10;
                    p4m = 10;
                    com4 = true;
                }
                if (company4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmt = "player3";
                    Console.WriteLine("You own this bus service, please note it");
                    company4 = false;
                }
                else if (company4 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 7)
            {
                if (ctdl == "player0" && !company5 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company5 = true;
                }
                // Occupied
                else if (!com5 && ctdl == "player2")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p2m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p2m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p2m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p2m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player1")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p1m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p1m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p1m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p1m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player4")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p4m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p4m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p4m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p4m = 20;
                        com5 = true;
                    }
                }
                if (company5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctdl = "player3";
                    Console.WriteLine("You own this electrical service, please note it");
                    company5 = false;
                }
                else if (company5 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 0)
            {
                int sn = 0;
                if (ctcn == "player0" && !company6 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company6 = true;
                }
                // Occupied
                else if (!com6 && ctcn == "player2")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p2m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p2m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p2m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p2m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player1")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p1m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p1m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p1m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p1m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player4")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p4m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p4m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p4m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p4m = 20;
                        com6 = true;
                    }
                }
                if (company6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctcn = "player3";
                    Console.WriteLine("You own this water service, please note it");
                    company6 = false;
                }
                else if (company6 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            else if (!(X == 0 && Y == 3))
            {
                company1 = false;
                com1 = false;
            }
            else if (!(X == 3 && Y == 7))
            {
                company2 = false;
                com2 = false;
            }
            else if (!(X == 7 && Y == 4))
            {
                company3 = false;
                com3 = false;
            }
            else if (!(X == 4 && Y == 0))
            {
                company4 = false;
                com4 = false;
            }
            else if (!(X == 1 && Y == 7))
            {
                company5 = false;
                com5 = false;
            }
            else if (!(X == 6 && Y == 0))
            {
                company6 = false;
                com6 = false;
            }
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            BXCG = bxcg; BXCL = bxcl; BXMD = bxmd; BXMT = bxmt; CTDL = ctdl; CTCN = ctcn;
        }

        public void P4SC(int bm, int X, int Y, string bxcg, string bxcl, string bxmd, string bxmt, string ctdl, string ctcn, int p1m, int p2m, int p3m, int p4m)
        {
            int m = bm;

            if (X == 0 && Y == 3)
            {
                if (bxcg == "player0" && !company1 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company1 = true;
                }
                // Occupied
                else if (!com1 && bxcg == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com1 = true;
                }
                else if (!com1 && bxcg == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com1 = true;
                }
                if (company1 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcg = "player4";
                    Console.WriteLine("You own this bus service, please note it");
                    company1 = false;
                }
                else if (company1 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company1 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 3 && Y == 7)
            {
                if (bxcl == "player0" && !company2 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company2 = true;
                }
                // Occupied
                else if (!com2 && bxcl == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com2 = true;
                }
                else if (!com2 && bxcl == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com2 = true;
                }
                if (company2 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxcl = "player4";
                    Console.WriteLine("You own this bus service, please note it");
                    company2 = false;
                }
                else if (company2 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company2 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 7 && Y == 4)
            {
                if (bxmd == "player0" && !company3 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company3 = true;
                }
                // Occupied
                else if (!com3 && bxmd == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com3 = true;
                }
                else if (!com3 && bxmd == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com3 = true;
                }
                if (company3 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmd = "player4";
                    Console.WriteLine("You own this bus service, please note it");
                    company3 = false;
                }
                else if (company3 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company3 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 4 && Y == 0)
            {
                if (bxmt == "player0" && !company4 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company4 = true;
                }
                // Occupied
                else if (!com4 && bxmt == "player2")
                {
                    m = bm - 10;
                    p2m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player3")
                {
                    m = bm - 10;
                    p3m = 10;
                    com4 = true;
                }
                else if (!com4 && bxmt == "player1")
                {
                    m = bm - 10;
                    p1m = 10;
                    com4 = true;
                }
                if (company4 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    bxmt = "player4";
                    Console.WriteLine("You own this bus service, please note it");
                    company4 = false;
                }
                else if (company4 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company4 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 1 && Y == 7)
            {
                if (ctdl == "player0" && !company5 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company5 = true;
                }
                // Occupied
                else if (!com5 && ctdl == "player2")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p2m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p2m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p2m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20; 
                        p2m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player3")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p3m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p3m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p3m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p3m = 20;
                        com5 = true;
                    }
                }
                else if (!com5 && ctdl == "player1")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p1m = 8;
                        com5 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p1m = 12;
                        com5 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p1m = 16;
                        com5 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p1m = 20;
                        com5 = true;
                    }
                }
                if (company5 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctdl = "player4";
                    Console.WriteLine("You own this electrical service, please note it");
                    company5 = false;
                }
                else if (company5 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company5 = true;
                    Console.WriteLine("You skip it");
                }
            }
            if (X == 6 && Y == 0)
            {
                int sn = 0;
                if (ctcn == "player0" && !company6 && bm >= 100)
                {
                    Console.WriteLine("You can buy this services comapny, press [Y] to buy it or [N] to skip");
                    company6 = true;
                }
                // Occupied
                else if (!com6 && ctcn == "player2")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p2m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p2m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p2m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p2m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player3")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p3m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p3m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p3m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p3m = 20;
                        com6 = true;
                    }
                }
                else if (!com6 && ctcn == "player1")
                {
                    if (EO >= 1 && EO <= 3)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 8;
                        p4m = 8;
                        com6 = true;
                    }
                    if (EO >= 3 && EO <= 6)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 12;
                        p4m = 12;
                        com6 = true;
                    }
                    if (EO >= 7 && EO <= 9)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 16;
                        p4m = 16;
                        com6 = true;
                    }
                    if (EO >= 10 && EO <= 12)
                    {
                        Console.WriteLine("You have to pay fare to this service company by the number of property that you own.");
                        m = bm - 20;
                        p4m = 20;
                        com6 = true;
                    }
                }
                if (company6 && SplashKit.KeyTyped(KeyCode.YKey) && bm >= 100)
                {
                    m = bm - 100;
                    ctcn = "player4";
                    Console.WriteLine("You own this water service, please note it");
                    company6 = false;
                }
                else if (company6 && SplashKit.KeyTyped(KeyCode.NKey))
                {
                    company6 = true;
                    Console.WriteLine("You skip it");
                }
            }
            else if (!(X == 0 && Y == 3))
            {
                company1 = false;
                com1 = false;
            }
            else if (!(X == 3 && Y == 7))
            {
                company2 = false;
                com2 = false;
            }
            else if (!(X == 7 && Y == 4))
            {
                company3 = false;
                com3 = false;
            }
            else if (!(X == 4 && Y == 0))
            {
                company4 = false;
                com4 = false;
            }
            else if (!(X == 1 && Y == 7))
            {
                company5 = false;
                com5 = false;
            }
            else if (!(X == 6 && Y == 0))
            {
                company6 = false;
                com6 = false;
            }
            Money = m;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;

            BXCG = bxcg; BXCL = bxcl; BXMD = bxmd; BXMT = bxmt; CTDL = ctdl; CTCN = ctcn;
        }

        // Strategical logic controls players position in game.
        public void Move(string name, int totDice, int x, int y, int wm)
        {
            int mx = x; int my = y;
            int m = wm;

            // Up
            if (x == 0 && y > 0)
            {
                my = y + totDice;

                start = false;

                if (my > 7)
                {
                    mx = x + (my - 7);
                    my = 7;

                    if (mx > 7)
                    {
                        my = y - (mx - 7);
                        mx = 7;
                    }
                }

            }

            // Right
            else if (x >= 0 && y == 7)
            {
                mx = x + totDice;
                start = false;

                if (mx > 7)
                {
                    my = y - (mx - 7);
                    mx = 7;

                    if (my < 0)
                    {
                        mx = x - (0 - my);
                        my = 0;
                    }
                }
            }

            // Down
            else if (x == 7 && y <= 7)
            {
                my = y - totDice;

                if (my < 0)
                {
                    mx = x - (0 - my);
                    my = 0;
                    if (mx < 0)
                    {
                        my = y + (0 - mx);
                        mx = 0;

                        if (!start)
                        {
                            m = wm + 100;
                            Console.WriteLine($"player {name} complete a full round.");
                            //Console.WriteLine($"player {name} has {Money} dollars.");
                            start = true;
                        }
                    }
                }

            }

            // Left
            else if (x <= 7 && y == 0)
            {
                mx = x - totDice;

                if (mx < 0)
                {
                    my = y + (0 - mx);
                    mx = 0;

                    if (!start)
                    {
                        m = wm + 100;
                        Console.WriteLine($"player {name} complete a full round.");
                        //Console.WriteLine($"player {name} has {Money} dollars.");
                        start = true;
                    }

                    if (my > 7)
                    {
                        mx = x + (my - 7);
                        my = 7;
                    }
                }
            }

            if (x == 0 && y == 0 && !start)
            {
                m = wm + 100;
                if (st1)
                {
                    Console.WriteLine($"player {name} complete a full round.");
                }
                //Console.WriteLine($"player {name} has {Money} dollars.");
                start = true;
                st1 = true;
            } 

            X = mx;
            Y = my;
            Money = m;
        }

        // Conditional checkers based on 4 players' real-time position
        public void ConditionCheck1(int wm, int WX, int WY, int p1m, int p2m, int p3m, int p4m)
        {
            int m = wm;
            int MX = WX; int MY = WY;
            // Tax
            if ((WX == 0 && WY == 2) && !rand1)
            {
                m = wm - 100;
                Console.WriteLine("Pay income tax, minus 100 dollars");
                rand1 = true;
            }
            // Job
            if ((WX == 7 && WY == 5) && !rand1)
            {
                m = wm + 100;
                Console.WriteLine("Get a job, plus 100 dollars");
                rand1 = true;
            }
            // Investment
            if ((WX == 0 && WY == 7) && !inv1)
            {
                int c;
                c = random.Next(1, 5);

                if (c == 1)
                {
                    m = wm - 100;
                    Console.WriteLine("You invested in crypto, minus 100 dollars");
                    inv1 = true;
                }

                if (c == 2)
                {
                    m = wm + 100;
                    Console.WriteLine("You invested in estate, plus 100 dollars");
                    inv1 = true;
                }

                if (c == 3)
                {
                    m = wm - 50;
                    Console.WriteLine("You invested in stock, minus 50 dollars");
                    inv1 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You invested in gold, plus 50 dollars");
                    inv1 = true;
                }
            }
            // Chance
            if (((WX == 0 && WY == 5) || WX == 7 && WY == 2) && !chance1)
            {
                int c;
                c = random.Next(1, 8);
                //c = 7; (for testing)

                if (c == 1)
                {
                    m = wm + 30;
                    Console.WriteLine("You work after hour, gained 30 dollars");
                    chance1 = true;
                }

                if (c == 2)
                {
                    m = wm - 30;
                    Console.WriteLine("You got ill, loss 30 dollars");
                    chance1 = true;
                }

                if (c == 3)
                {
                    m = wm - 100;
                    Console.WriteLine("You got a car accident, loss 100 dollars");
                    chance1 = true;
                }

                if (c == 4)
                {
                    m = wm + 100;
                    Console.WriteLine("You inherit family wealth, gained 100 dollars");
                    chance1 = true;
                }

                if (c == 5)
                {
                    m = wm - 50;
                    Console.WriteLine("You loss a poker game, loss 50 dollars");
                    chance1 = true;
                }

                if (c == 6)
                {
                    m = wm - 20;
                    Console.WriteLine("You get caught from graffiti, fined by 20 dollars");
                    chance1 = true;
                }
                if (c == 7)
                {
                    int b;
                    b = random.Next(1, 3);

                    if (b == 1)
                    {
                        if (WY == 5)
                        {
                            MY = WY + 2;
                            if (MY == 7)
                            {
                                Console.WriteLine("Go forward 2 steps");
                                chance1 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY - 2;
                            if (MY == 0)
                            {
                                Console.WriteLine("Go forward 2 steps");
                                chance1 = true;
                            }
                        }
                    }
                    if (b == 2)
                    {
                        if (WY == 5)
                        {
                            MY = WY - 3;
                            if (MY == 2)
                            {
                                Console.WriteLine("Go backward 3 steps");
                                chance1 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY + 3;
                            if (MY == 5)
                            {
                                Console.WriteLine("Go backward 3 steps");
                                chance1 = true;
                            }
                        }
                    }
                }
            }
            // Luck
            if (((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && !luck1)
            {
                int c;
                c = random.Next(1, 9);
                //c = 8; 

                if (c == 1)
                {
                    m = wm + 20;
                    Console.WriteLine("Someone dropped their wallet, gained 20 dollars");
                    luck1 = true;
                }

                if (c == 2)
                {
                    m = wm + 50;
                    Console.WriteLine("Won in the Casino, gained 50 dollars");
                    luck1 = true;
                }

                if (c == 3)
                {
                    m = wm - 20;
                    Console.WriteLine("Your children needed tuition fees, loss 20 dollars");
                    luck1 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You became a pop star, gained 50 dollars");
                    luck1 = true;
                }

                if (c == 5)
                {
                    m = wm + 100;
                    Console.WriteLine("Your estate raised, gained 100 dollars");
                    luck1 = true;
                }

                if (c == 6)
                {
                    Console.WriteLine("You did some gambling");

                    int d = random.Next(1, 3);

                    if (d == 1)
                    {
                        m = wm + 50;
                        Console.WriteLine("Your football team became champion, plus 50 dollars");
                        luck1 = true;
                    }
                    if (d == 2)
                    {
                        m = wm - 50;
                        Console.WriteLine("The horse you bet loos, minus 50 dollars");
                        luck1 = true;
                    }
                }

                if (c == 7)
                {
                    m = wm + 100;
                    MY = 0; MX = 7;
                    if (MY == 0 && MX == 7)
                    {
                        Console.WriteLine("You robbed the bank and eventually get caught, gained 100 dollars and go to jail");
                        luck1 = true;
                    }                   
                }

                if (c == 8)
                {
                    Console.WriteLine("Biggest Robbery in the Town, which player you would like to steal $50 from? (Enter 2, 3 or 4)");
                    string rob = Console.ReadLine();
                    if (rob == "1")
                    {
                        Console.WriteLine("You refused to rob today.");
                    }
                    if (rob == "2")
                    {
                        m = wm + 50;
                        p2m = -50;
                        Console.WriteLine("Successfully robbed from player 2.");
                    }
                    if (rob == "3")
                    {
                        m = wm + 50;
                        p3m = -50;
                        Console.WriteLine("Successfully robbed from player 3.");
                    }
                    if (rob == "4")
                    {
                        m = wm + 50;
                        p4m = -50;
                        Console.WriteLine("Successfully robbed from player 4.");
                    }
                    else if ((rob != "1") && (rob != "2") && (rob != "3") && (rob != "4"))
                    {
                        Console.WriteLine("Failed to rob this time, caught in jail.");
                        MY = 0; MX = 7;
                    }
                    luck1 = true;
                }
            }
            else if (!(WX == 0 && WY == 2) && !(WX == 7 && WY == 5) && rand1)
            {
                rand1 = false;
            }
            else if (!((WX == 0 && WY == 5) || (WX == 7 && WY == 2)) && chance1)
            {
                chance1 = false;
            }
            else if (!((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && luck1)
            {
                luck1 = false;
            }
            else if (!(WX == 0 && WY == 7) && inv1)
            {
                inv1 = false;
            }
            Money = m;
            X = MX; Y = MY;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;
        }

        public void ConditionCheck2(int wm, int WX, int WY, int p1m, int p2m, int p3m, int p4m)
        {
            int m = wm;
            int MX = X; int MY = Y;
            // Tax
            if ((WX == 0 && WY == 2) && !rand2)
            {
                m = wm - 100;
                Console.WriteLine("Pay income tax, minus 100 dollars");
                rand2 = true;
            }
            // Job
            if ((WX == 7 && WY == 5) && !rand2)
            {
                m = wm + 100;
                Console.WriteLine("Get a job, plus 100 dollars");
                rand2 = true;
            }
            // Investment
            if ((WX == 0 && WY == 7) && !inv2)
            {
                int c;
                c = random.Next(1, 5);

                if (c == 1)
                {
                    m = wm - 100;
                    Console.WriteLine("You invested in crypto, minus 100 dollars");
                    inv2 = true;
                }

                if (c == 2)
                {
                    m = wm + 100;
                    Console.WriteLine("You invested in estate, plus 100 dollars");
                    inv2 = true;
                }

                if (c == 3)
                {
                    m = wm - 50;
                    Console.WriteLine("You invested in stock, minus 50 dollars");
                    inv2 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You invested in gold, plus 50 dollars");
                    inv2 = true;
                }
            }
            // Chance
            if (((WX == 0 && WY == 5) || WX == 7 && WY == 2) && !chance2)
            {
                int c;
                c = random.Next(1, 8);
                //c = 7; (for testing)

                if (c == 1)
                {
                    m = wm + 30;
                    Console.WriteLine("You work after hour, gained 30 dollars");
                    chance2 = true;
                }

                if (c == 2)
                {
                    m = wm - 30;
                    Console.WriteLine("You got ill, loss 30 dollars");
                    chance2 = true;
                }

                if (c == 3)
                {
                    m = wm - 100;
                    Console.WriteLine("You got a car accident, loss 100 dollars");
                    chance2 = true;
                }

                if (c == 4)
                {
                    m = wm + 100;
                    Console.WriteLine("You inherit family wealth, gained 100 dollars");
                    chance2 = true;
                }

                if (c == 5)
                {
                    m = wm - 50;
                    Console.WriteLine("You loss a poker game, loss 50 dollars");
                    chance2 = true;
                }

                if (c == 6)
                {
                    m = wm - 20;
                    Console.WriteLine("You get caught from graffiti, fined by 20 dollars");
                    chance2 = true;
                }
                if (c == 7)
                {
                    int b;
                    b = random.Next(1, 3);

                    if (b == 1)
                    {
                        if (WY == 5)
                        {
                            MY = WY + 2;
                            Console.WriteLine("Go forward 2 steps");
                            if (MY == 7)
                            {
                                chance2 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY - 2;
                            Console.WriteLine("Go forward 2 steps");
                            if (MY == 0)
                            {
                                chance2 = true;
                            }
                        }
                    }
                    if (b == 2)
                    {
                        if (WY == 5)
                        {
                            MY = WY - 3;
                            Console.WriteLine("Go backward 3 steps");
                            if (MY == 2)
                            {
                                chance2 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY + 3;
                            Console.WriteLine("Go backward 3 steps");
                            if (MY == 5)
                            {
                                chance2 = true;
                            }
                        }
                    }
                }
            }
            // Luck
            if (((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && !luck2)
            {
                int c;
                c = random.Next(1, 9);

                if (c == 1)
                {
                    m = wm + 20;
                    Console.WriteLine("Someone dropped their wallet, gained 20 dollars");
                    luck2 = true;
                }

                if (c == 2)
                {
                    m = wm + 50;
                    Console.WriteLine("Won in the Casino, gained 50 dollars");
                    luck2 = true;
                }

                if (c == 3)
                {
                    m = wm - 20;
                    Console.WriteLine("Your children needed tuition fees, loss 20 dollars");
                    luck2 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You became a pop star, gained 50 dollars");
                    luck2 = true;
                }

                if (c == 5)
                {
                    m = wm + 100;
                    Console.WriteLine("Your estate raised, gained 100 dollars");
                    luck2 = true;
                }

                if (c == 6)
                {
                    Console.WriteLine("You did some gambling");

                    int d = random.Next(1, 3);

                    if (d == 1)
                    {
                        m = wm + 50;
                        Console.WriteLine("Your football team became champion, plus 50 dollars");
                        luck2 = true;
                    }
                    if (d == 2)
                    {
                        m = wm - 50;
                        Console.WriteLine("The horse you bet loos, minus 50 dollars");
                        luck2 = true;
                    }
                }

                if (c == 7)
                {
                    m = wm + 100;
                    MY = 0; MX = 7;
                    if (MY == 0 && MX == 7)
                    {
                        Console.WriteLine("You robbed the bank and eventually get caught, gained 100 dollars and go to jail");
                        luck2 = true;
                    }
                }

                if (c == 8)
                {
                    Console.WriteLine("Biggest Robbery in the Town, which player you would like to steal $50 from? (Enter 1, 3 or 4)");
                    string rob = Console.ReadLine();
                    if (rob == "1")
                    {
                        m = wm + 50;
                        p1m = -50;
                        Console.WriteLine("Successfully robbed from player 1.");
                    }
                    if (rob == "2")
                    {
                        Console.WriteLine("You refused to rob today.");
                    }
                    if (rob == "3")
                    {
                        m = wm + 50;
                        p3m = -50;
                        Console.WriteLine("Successfully robbed from player 3.");
                    }
                    if (rob == "4")
                    {
                        m = wm + 50;
                        p4m = -50;
                        Console.WriteLine("Successfully robbed from player 4.");
                    }
                    else if ((rob != "1") && (rob != "2") && (rob != "3") && (rob != "4"))
                    {
                        Console.WriteLine("Failed to rob this time, caught in jail.");
                        MY = 0; MX = 7;
                    }
                    luck2 = true;
                }
            }
            else if (!(WX == 0 && WY == 2) && !(WX == 7 && WY == 5) && rand2)
            {
                rand2 = false;
            }
            else if (!((WX == 0 && WY == 5) || (WX == 7 && WY == 2)) && chance2)
            {
                chance2 = false;
            }
            else if (!((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && luck2)
            {
                luck2 = false;
            }
            else if (!(WX == 0 && WY == 7) && inv2)
            {
                inv2 = false;
            }
            Money = m;
            Y = MY; X = MX;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;
        }

        public void ConditionCheck3(int wm, int WX, int WY,int p1m, int p2m, int p3m, int p4m)
        {
            int m = wm;
            int MY = Y; int MX = X;
            // Tax
            if ((WX == 0 && WY == 2) && !rand3)
            {
                m = wm - 100;
                Console.WriteLine("Pay income tax, minus 100 dollars");
                rand3 = true;
            }
            // Job
            if ((WX == 7 && WY == 5) && !rand3)
            {
                m = wm + 100;
                Console.WriteLine("Get a job, plus 100 dollars");
                rand3 = true;
            }
            // Investment
            if ((WX == 0 && WY == 7) && !inv3)
            {
                int c;
                c = random.Next(1, 5);

                if (c == 1)
                {
                    m = wm - 100;
                    Console.WriteLine("You invested in crypto, minus 100 dollars");
                    inv3 = true;
                }

                if (c == 2)
                {
                    m = wm + 100;
                    Console.WriteLine("You invested in estate, plus 100 dollars");
                    inv3 = true;
                }

                if (c == 3)
                {
                    m = wm - 50;
                    Console.WriteLine("You invested in stock, minus 50 dollars");
                    inv3 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You invested in gold, plus 50 dollars");
                    inv3 = true;
                }
            }
            // Chance
            if (((WX == 0 && WY == 5) || WX == 7 && WY == 2) && !chance3)
            {
                int c;
                c = random.Next(1, 8);
                //c = 7; (for testing)

                if (c == 1)
                {
                    m = wm + 30;
                    Console.WriteLine("You work after hour, gained 30 dollars");
                    chance3 = true;
                }

                if (c == 2)
                {
                    m = wm - 30;
                    Console.WriteLine("You got ill, loss 30 dollars");
                    chance3 = true;
                }

                if (c == 3)
                {
                    m = wm - 100;
                    Console.WriteLine("You got a car accident, loss 100 dollars");
                    chance3 = true;
                }

                if (c == 4)
                {
                    m = wm + 100;
                    Console.WriteLine("You inherit family wealth, gained 100 dollars");
                    chance3 = true;
                }

                if (c == 5)
                {
                    m = wm - 50;
                    Console.WriteLine("You loss a poker game, loss 50 dollars");
                    chance3 = true;
                }

                if (c == 6)
                {
                    m = wm - 20;
                    Console.WriteLine("You get caught from graffiti, fined by 20 dollars");
                    chance3 = true;
                }
                if (c == 7)
                {
                    int b;
                    b = random.Next(1, 3);

                    if (b == 1)
                    {
                        if (WY == 5)
                        {
                            MY = WY + 2;
                            Console.WriteLine("Go forward 2 steps");
                            if (MY == 7)
                            {
                                chance3 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY - 2;
                            Console.WriteLine("Go forward 2 steps");
                            if (MY == 0)
                            {
                                chance3 = true;
                            }
                        }
                    }
                    if (b == 2)
                    {
                        if (WY == 5)
                        {
                            MY = WY - 3;
                            Console.WriteLine("Go backward 3 steps");
                            if (MY == 2)
                            {
                                chance3 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY + 3;
                            Console.WriteLine("Go backward 3 steps");
                            if (MY == 5)
                            {
                                chance3 = true;
                            }
                        }
                    }
                }
            }
            // Luck
            if (((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && !luck3)
            {
                int c;
                c = random.Next(1, 9);

                if (c == 1)
                {
                    m = wm + 20;
                    Console.WriteLine("Someone dropped their wallet, gained 20 dollars");
                    luck3 = true;
                }

                if (c == 2)
                {
                    m = wm + 50;
                    Console.WriteLine("Won in the Casino, gained 50 dollars");
                    luck3 = true;
                }

                if (c == 3)
                {
                    m = wm - 20;
                    Console.WriteLine("Your children needed tuition fees, loss 20 dollars");
                    luck3 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You became a pop star, gained 50 dollars");
                    luck3 = true;
                }

                if (c == 5)
                {
                    m = wm + 100;
                    Console.WriteLine("Your estate raised, gained 100 dollars");
                    luck3 = true;
                }

                if (c == 6)
                {
                    Console.WriteLine("You did some gambling");

                    int d = random.Next(1, 3);

                    if (d == 1)
                    {
                        m = wm + 50;
                        Console.WriteLine("Your football team became champion, plus 50 dollars");
                        luck3 = true;
                    }
                    if (d == 2)
                    {
                        m = wm - 50;
                        Console.WriteLine("The horse you bet loos, minus 50 dollars");
                        luck3 = true;
                    }
                }

                if (c == 7)
                {
                    m = wm + 100;
                    MY = 0; MX = 7;
                    if (MY == 0 && MX == 7)
                    {
                        Console.WriteLine("You robbed the bank and eventually get caught, gained 100 dollars and go to jail");
                        luck3 = true;
                    }
                }

                if (c == 8)
                {
                    Console.WriteLine("Biggest Robbery in the Town, which player you would like to steal $50 from? (Enter 1, 2 or 4)");
                    string rob = Console.ReadLine();
                    if (rob == "1")
                    {
                        m = wm + 50;
                        p1m = -50;
                        Console.WriteLine("Successfully robbed from player 1.");
                    }
                    if (rob == "2")
                    {
                        m = wm + 50;
                        p2m = -50;
                        Console.WriteLine("Successfully robbed from player 2.");
                    }
                    if (rob == "3")
                    {
                        Console.WriteLine("You refused to rob today.");
                    }
                    if (rob == "4")
                    {
                        m = wm + 50;
                        p4m = -50;
                        Console.WriteLine("Successfully robbed from player 4.");
                    }
                    else if ((rob != "1") && (rob != "2") && (rob != "3") && (rob != "4"))
                    {
                        Console.WriteLine("Failed to rob this time, caught in jail.");
                        MY = 0; MX = 7;
                    }
                    luck3 = true;
                }
            }
            else if (!(WX == 0 && WY == 2) && !(WX == 7 && WY == 5) && rand3)
            {
                rand3 = false;
            }
            else if (!((WX == 0 && WY == 5) || (WX == 7 && WY == 2)) && chance3)
            {
                chance3 = false;
            }
            else if (!((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && luck3)
            {
                luck3 = false;
            }
            else if (!(WX == 0 && WY == 7) && inv3)
            {
                inv3 = false;
            }
            Money = m;
            Y = MY; X = MX;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;
        }

        public void ConditionCheck4(int wm, int WX, int WY, int p1m, int p2m, int p3m, int p4m)
        {
            int m = wm;
            int MY = Y; int MX = X;
            // Tax
            if ((WX == 0 && WY == 2) && !rand4)
            {
                m = wm - 100;
                Console.WriteLine("Pay income tax, minus 100 dollars");
                rand4 = true;
            }
            // Job
            if ((WX == 7 && WY == 5) && !rand4)
            {
                m = wm + 100;
                Console.WriteLine("Get a job, plus 100 dollars");
                rand4 = true;
            }
            // Investment
            if ((WX == 0 && WY == 7) && !inv4)
            {
                int c;
                c = random.Next(1, 5);

                if (c == 1)
                {
                    m = wm - 100;
                    Console.WriteLine("You invested in crypto, minus 100 dollars");
                    inv4 = true;
                }

                if (c == 2)
                {
                    m = wm + 100;
                    Console.WriteLine("You invested in estate, plus 100 dollars");
                    inv4 = true;
                }

                if (c == 3)
                {
                    m = wm - 50;
                    Console.WriteLine("You invested in stock, minus 50 dollars");
                    inv4 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You invested in gold, plus 50 dollars");
                    inv4 = true;
                }
            }
            // Chance
            if (((WX == 0 && WY == 5) || WX == 7 && WY == 2) && !chance4)
            {
                int c;
                c = random.Next(1, 8);
                //c = 7; (for testing)

                if (c == 1)
                {
                    m = wm + 30;
                    Console.WriteLine("You work after hour, gained 30 dollars");
                    chance4 = true;
                }

                if (c == 2)
                {
                    m = wm - 30;
                    Console.WriteLine("You got ill, loss 30 dollars");
                    chance4 = true;
                }

                if (c == 3)
                {
                    m = wm - 100;
                    Console.WriteLine("You got a car accident, loss 100 dollars");
                    chance4 = true;
                }

                if (c == 4)
                {
                    m = wm + 100;
                    Console.WriteLine("You inherit family wealth, gained 100 dollars");
                    chance4 = true;
                }

                if (c == 5)
                {
                    m = wm - 50;
                    Console.WriteLine("You loss a poker game, loss 50 dollars");
                    chance4 = true;
                }

                if (c == 6)
                {
                    m = wm - 20;
                    Console.WriteLine("You get caught from graffiti, fined by 20 dollars");
                    chance4 = true;
                }
                if (c == 7)
                {
                    int b;
                    b = random.Next(1, 3);

                    if (b == 1)
                    {
                        if (WY == 5)
                        {
                            MY = WY + 2;
                            Console.WriteLine("Go forward 2 steps");
                            if (MY == 7)
                            {
                                chance4 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY - 2;
                            Console.WriteLine("Go forward 2 steps");
                            if (MY == 0)
                            {
                                chance4 = true;
                            }
                        }
                    }
                    if (b == 2)
                    {
                        if (WY == 5)
                        {
                            MY = WY - 3;
                            Console.WriteLine("Go backward 3 steps");
                            if (MY == 2)
                            {
                                chance4 = true;
                            }
                        }
                        if (WY == 2)
                        {
                            MY = WY + 3;
                            Console.WriteLine("Go backward 3 steps");
                            if (MY == 5)
                            {
                                chance4 = true;
                            }
                        }
                    }
                }
            }
            // Luck
            if (((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && !luck4)
            {
                int c;
                c = random.Next(1, 9);

                if (c == 1)
                {
                    m = wm + 20;
                    Console.WriteLine("Someone dropped their wallet, gained 20 dollars");
                    luck4 = true;
                }

                if (c == 2)
                {
                    m = wm + 50;
                    Console.WriteLine("Won in the Casino, gained 50 dollars");
                    luck4 = true;
                }

                if (c == 3)
                {
                    m = wm - 20;
                    Console.WriteLine("Your children needed tuition fees, loss 20 dollars");
                    luck4 = true;
                }

                if (c == 4)
                {
                    m = wm + 50;
                    Console.WriteLine("You became a pop star, gained 50 dollars");
                    luck4 = true;
                }

                if (c == 5)
                {
                    m = wm + 100;
                    Console.WriteLine("Your estate raised, gained 100 dollars");
                    luck4 = true;
                }

                if (c == 6)
                {
                    Console.WriteLine("You did some gambling");

                    int d = random.Next(1, 3);

                    if (d == 1)
                    {
                        m = wm + 50;
                        Console.WriteLine("Your football team became champion, plus 50 dollars");
                        luck4 = true;
                    }
                    if (d == 2)
                    {
                        m = wm - 50;
                        Console.WriteLine("The horse you bet loos, minus 50 dollars");
                        luck4 = true;
                    }
                }

                if (c == 7)
                {
                    m = wm + 100;
                    MY = 0; MX = 7;
                    if (MY == 0 && MX == 7)
                    {
                        Console.WriteLine("You robbed the bank and eventually get caught, gained 100 dollars and go to jail");
                        luck4 = true;
                    }
                }

                if (c == 8)
                {
                    Console.WriteLine("Biggest Robbery in the Town, which player you would like to steal $50 from? (Enter 1, 2 or 3)");
                    string rob = Console.ReadLine();
                    if (rob == "1")
                    {
                        m = wm + 50;
                        p1m = -50;
                        Console.WriteLine("Successfully robbed from player 1.");
                    }
                    if (rob == "2")
                    {
                        m = wm + 50;
                        p2m = -50;
                        Console.WriteLine("Successfully robbed from player 2.");
                    }
                    if (rob == "3")
                    {
                        m = wm + 50;
                        p3m = -50;
                        Console.WriteLine("Successfully robbed from player 3.");
                    }
                    if (rob == "4")
                    {
                        Console.WriteLine("You refused to rob today.");
                    }
                    else if ((rob != "1") && (rob != "2") && (rob != "3") && (rob != "4"))
                    {
                        Console.WriteLine("Failed to rob this time, caught in jail.");
                        MY = 0; MX = 7;
                    }
                    luck4 = true;
                }
            }
            else if (!(WX == 0 && WY == 2) && !(WX == 7 && WY == 5) && rand4)
            {
                rand4 = false;
            }
            else if (!((WX == 0 && WY == 5) || (WX == 7 && WY == 2)) && chance4)
            {
                chance4 = false;
            }
            else if (!((WX == 5 && WY == 7) || (WX == 2 && WY == 0)) && luck4)
            {
                luck4 = false;
            }
            else if (!(WX == 0 && WY == 7) && inv4)
            {
                inv4 = false;
            }
            Money = m;
            Y = MY; X = MX;
            P1M = p1m; P2M = p2m; P3M = p3m; P4M = p4m;
        }

        public void Jailed(int x, int y, bool pris, bool eq)
        {
            if (!EQDice && (X == 7 && Y == 0))
            {
                pris = true;
            }
            if (EQDice && (X == 7 && Y == 0))
            {
                pris = false;
            }

            X = x;
            Y = y;
            Prisoned = pris;
        }

    }
}
