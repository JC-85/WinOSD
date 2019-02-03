using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinOSD.Demo
{
    public partial class Demo : Form
    {
        private Point[] _pnt = new Point[4];
        private byte[] _alpha = new byte[4];
        private Color[] _textColor = new Color[4];
        private Font[] _textFont = new Font[4];
        private int[] _textTime = new int[4];
        private AnimateMode[] _mode = new AnimateMode[4];
        private uint[] _animateTime = new uint[4];
        private string[] _text = new string[4];
        private Rectangle _rScreen = Screen.PrimaryScreen.Bounds;

        List<Preset> presets = new List<Preset>(3);

        public Demo()
        {
            InitializeComponent();
            _numX.Maximum = _rScreen.Width;
            _numY.Maximum = _rScreen.Height;
            //--Demo Presets

            //Preset 1
            Preset preset = new Preset(
            location: new Point(20, 45),   //Location
            opacity: 120,   //Opacity
            textColor: Color.Lime,    //Text color
            font: new Font("Arial", 22f, FontStyle.Bold), //Font
            displayTime: 3000,   //Display time in ms
            animation: AnimateMode.ExpandCollapse, //Display animation
            animationTime: 200, //Animation time
            text: _txtText.Text //Text to display
            );
            presets.Add(preset);

            // Preset 2
            preset = new Preset(
             new Point(_rScreen.Width / 8, _rScreen.Height / 2),
             231,
             Color.DarkCyan,
             new Font("Microsoft Sans Serif", 28f, FontStyle.Regular),
             1800,
             AnimateMode.Blend,
             0,
            "Hello! I am OSD window..."
            );
            presets.Add(preset);

            // Preset 3
            preset = new Preset(
             new Point(_rScreen.Width / 6, _rScreen.Height / 2 - _rScreen.Height / 4),
             90,
             Color.RoyalBlue,
             new Font("Courier New", 36f, FontStyle.Bold | FontStyle.Underline),
             3900,
             AnimateMode.SlideLeftToRight,
             0,
             "OSD text can be semi-transparent!"
            );
            presets.Add(preset);
            // Preset 4
            preset = new Preset(
             new Point(100, _rScreen.Height / 2 - _rScreen.Height / 8),
             122,
             Color.DarkMagenta,
             new Font("Verdana", 26f, FontStyle.Bold | FontStyle.Italic),
             2400,
             AnimateMode.RollRightToLeft,
             370,
             "Also OSD can be animated in every way"
            );
            presets.Add(preset);
            //defaults for custom OSD
            _numX.Value = _pnt[0].X; _numY.Value = _pnt[0].Y;
            _numAlpha.Value = _alpha[0]; _numTextTime.Value = _textTime[0];
            _numAnimateTime.Value = _animateTime[0];
            _lbSample.ForeColor = _textColor[0]; _lbSample.Font = _textFont[0];
            _cbAnimate.Items.AddRange(Enum.GetNames(typeof(AnimateMode)));
            _cbAnimate.SelectedIndex = (int)_mode[0];
        }

        private void demo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void _all_Click(object sender, EventArgs e)
        {
            Preset p;
            switch ((sender as Button).Tag.ToString())
            {
                case "0": p = presets[0]; break;
                case "1": p = presets[1]; break;
                case "2": p = presets[2]; break;
                case "3": p = presets[3]; break;
                default:
                    p = new Preset(
               new Point((int)_numX.Value, (int)_numY.Value),
           (byte)_numAlpha.Value,
           _lbSample.ForeColor,
           _lbSample.Font,
           (int)_numTextTime.Value,
           (AnimateMode)_cbAnimate.SelectedIndex,
           (int)_numAnimateTime.Value,
           _txtText.Text);
                    break;
            }

            WinOSD.OSD.Display(p.Text, p.Location.X, p.Location.Y, p.Opacity, p.DisplayTime, p.Animation, p.AnimationTime);
        }

        private void _bColorPick_Click(object sender, EventArgs e)
        {
            _dlgColor.Color = _lbSample.ForeColor;
            if (_dlgColor.ShowDialog() == DialogResult.OK)
                _lbSample.ForeColor = _dlgColor.Color;
        }

        private void _bFontPick_Click(object sender, EventArgs e)
        {
            _dlgFont.Font = _lbSample.Font;
            if (_dlgFont.ShowDialog() == DialogResult.OK)
                _lbSample.Font = _dlgFont.Font;
        }

        struct Preset
        {
            private Point location;
            public Point Location => location;

            private int opacity;
            public int Opacity => opacity;

            private Color textColor;
            public Color TextColor => textColor;

            private Font font;
            public Font Font => font;

            private int displayTime;
            public int DisplayTime => displayTime;

            private AnimateMode animation;
            public AnimateMode Animation => animation;

            private int animationTime;
            public int AnimationTime => animationTime;

            private string text;
            public string Text => text;

            public Preset(Point location, int opacity, Color textColor, Font font, int displayTime, AnimateMode animation, int animationTime, string text)
            {
                this.location = location;
                this.opacity = opacity;
                this.textColor = textColor;
                this.font = font;
                this.displayTime = displayTime;
                this.animation = animation;
                this.animationTime = animationTime;
                this.text = text;
            }
        }
    }
}