namespace HEX
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        //Getting the value of slider and change the backgroudn color
        private void Sldr_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
        //settings color to the controls
        private void SetColor(Color color)
        {
            Container.BackgroundColor = color;
            lblHex.TextColor = color;
            lblHex.Text = color.ToHex();
            lblTitle.TextColor = color;
        }
        //Button randomizer 
        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            var rand = new Random();

            var color = Color.FromRgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;

        }

        //Input the color where the sliders and background changes 
        [Obsolete]
        private void inputcolor_TextChanged(object sender, TextChangedEventArgs e)
        {
            string hex = inputcolor.Text;
            if (IsValidHexColor(hex))
            {
                var color = Color.FromHex(hex);

                sldRed.Value = color.Red;
                sldGreen.Value = color.Green;
                sldBlue.Value = color.Blue;

                SetColor(color);
                lblHex.Text = hex;
            }
            else
            {
                //d
                lblHex.Text = "Invalid Color";
                Container.BackgroundColor = Colors.Black;
                lblHex.TextColor = Colors.Black;
                lblTitle.TextColor = Colors.Black;

                sldRed.Value = 0;
                sldGreen.Value = 0;
                sldBlue.Value = 0;
            }
        }

        private bool IsValidHexColor(string hex)
        {
            if (hex.StartsWith("#"))
            {
                hex = hex.Substring(1);
            }
            //lenght
            if (hex.Length != 6 && hex.Length != 8)
            {
                return false;
            }

            // Check if all characters are valid hex digits
            foreach (char c in hex)
            {
                bool isHexDigit =
                    (c >= '0' && c <= '9') ||
                    (c >= 'a' && c <= 'f') ||
                    (c >= 'A' && c <= 'F');

                if (!isHexDigit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
