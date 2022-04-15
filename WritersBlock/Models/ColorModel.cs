namespace WritersBlock.Models
{
    public class ColorModel
    {
        private int rgbValue;
        public int RGBValue {
            get { return rgbValue; }
            set { rgbValue = value > 255 ? 255 : (value < 0 ? 0 : value); }
        }

        private double alpha;
        public double Alpha {
            get { return alpha; }
            set {
                    alpha = value > 1 ? 1 : (value < 0 ? 0 : value);
                    alphaString = alpha.ToString().Replace(',', '.');
                }
        }
        private string alphaString;
        public string AlphaString {
            get { return alphaString; }
            private set { alphaString = alpha.ToString().Replace(',', '.'); }
        }
        public ColorModel()
        {
            SetDefaultValues();
        }
        public void SetDefaultValues()
        {
            RGBValue = 0;
            Alpha = 1;
            alphaString = string.Empty;
        }
    }
}
