using SplashKitSDK;

namespace MonopolyGame
{
    public class Menu
    {
        private Window _window;
        private Rectangle _Color1Button;
        private Rectangle _Color2Button;
        private Rectangle _Color3Button;
        private Rectangle _Color4Button;
        private Rectangle _Color5Button;
        private Rectangle _Color6Button;

        public Menu(int windowWidth, int windowHeight)
        {
            _window = new Window("Choose Color Menu", windowWidth, windowHeight);
            _Color1Button = new Rectangle()
            {
                X = 20,
                Y = 20,
                Width = 50,
                Height = 50
            };
            _Color2Button = new Rectangle()
            {
                X = 90,
                Y = 20,
                Width = 50,
                Height = 50
            };
            _Color3Button = new Rectangle()
            {
                X = 160,
                Y = 20,
                Width = 50,
                Height = 50
            };
            _Color4Button = new Rectangle()
            {
                X = 230,
                Y = 20,
                Width = 50,
                Height = 50
            };
            _Color5Button = new Rectangle()
            {
                X = 300,
                Y = 20,
                Width = 50,
                Height = 50
            };
            _Color6Button = new Rectangle()
            {
                X = 370,
                Y = 20,
                Width = 50,
                Height = 50
            };
        }

        public void DrawMenu()
        {
            _window.Clear(Color.Black);
            SplashKit.DrawCircle(Color.Lavender, 20, 20, 50);
            SplashKit.DrawCircle(Color.LightCoral, 90, 20, 50);
            SplashKit.DrawCircle(Color.LightSeaGreen, 160 + 10, 20, 50);
            SplashKit.DrawCircle(Color.BlanchedAlmond, 230, 20, 50);
            SplashKit.DrawCircle(Color.DeepPink, 300, 20, 50);
            SplashKit.DrawCircle(Color.CornflowerBlue, 370, 20, 50);
            SplashKit.DrawText("Please select your prefered marker color", Color.BlueViolet, "Arial", 72, 100, 120);
        }
    }
}