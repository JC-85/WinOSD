using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinOSD
{
    public class OSD
    {
        public static void Display(string text, int x, int y, int opacity, int displayTime, AnimateMode animation, int animationTime)
        {
            if (opacity < 0) throw new ArgumentOutOfRangeException("Opacity can not be less than zero.");
            if (animationTime < 0) throw new ArgumentOutOfRangeException("AnimationTime can no be less than zero.");

            OSDForm form = new OSDForm();
            Point point = new Point(x, y);
            Font font = OSDForm.DefaultFont;
            Color textColor = Color.Blue;
            form.Show(text, point, (byte)opacity, textColor, font, displayTime, animation, (uint)animationTime);
        }

        public static void Display(string v)
        {
            OSDForm form = new OSDForm();
            var textWidth = OSDForm.MeasureString(v, OSDForm.DefaultFont, null);
            var dispSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

            Display(v, (int)( dispSize.Width / 2 - textWidth.Width / 2),(int)( dispSize.Height - textWidth.Height * 3), 255, 5000, AnimateMode.Blend, 100);
        }
    }
}
