using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
namespace SB2RStatMockup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Gen Health
            textBox1.Text = Convert.ToString((3 * ChaBox.IntValue) + (2 * ConstBox.IntValue)+150);
            #endregion
            #region Attack
            textBox5.Text = Convert.ToString((StrBox.IntValue * .888) + (DexBox.IntValue / 2.5)+10);
            #endregion
            #region vigor
            VigTxt.Text = Convert.ToString(70 + (VitBox.IntValue / 5) + (DesBox.IntValue / 5) + (SexBox.IntValue / 10));
            #endregion
            #region combatCounter
            CouTxt.Text=Convert.ToString((DexBox.IntValue/10)+(AgiBox.IntValue/20)+1);
            #endregion
            #region MP
            MPtxt.Text = Convert.ToString(50 + wisBox.IntValue / 10 + KnoBox.IntValue / 5 + IntlBox.IntValue / 20);
            #endregion
            #region speed
            SpdTXT.Text = Convert.ToString(AgiBox.IntValue * .20);
            #endregion
        }
    }
    public class NumericTextBox : TextBox
    {
        bool allowSpace = false;
        
        // Restricts the entry of characters to digits (including hex), the negative sign,
        // the decimal point, and editing keystrokes (backspace).
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
             keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            //    {
            //     // Let the edit control handle control and alt key combinations
            //    }
            else if (this.allowSpace && e.KeyChar == ' ')
            {

            }
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }

        public int IntValue
        {
            get
            {
                return Int32.Parse(this.Text);
            }
        }

        public decimal DecimalValue
        {
            get
            {
                return Decimal.Parse(this.Text);
            }
        }

        public bool AllowSpace
        {
            set
            {
                this.allowSpace = value;
            }

            get
            {
                return this.allowSpace;
            }
        }
    }
}
