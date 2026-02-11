using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class ToggleButton : CheckBox
    {
        //constructor
        public ToggleButton() : base()
        {
            this.SuspendLayout();

            if (bmChecked == null) // If the static bitmaps haven't been constructed, create them.
            {
                System.Windows.Forms.CheckBox chkTemp = new System.Windows.Forms.CheckBox();

                chkTemp.AutoSize = true;
                chkTemp.BackColor = System.Drawing.Color.Transparent;
                chkTemp.Location = new System.Drawing.Point(123, 128);
                chkTemp.Name = "chkSmall";
                chkTemp.Size = chkTemp.PreferredSize;
                chkTemp.TabIndex = 2;
                chkTemp.UseVisualStyleBackColor = false;

                bmChecked = new Bitmap(chkTemp.Width, chkTemp.Height);
                bmUnChecked = new Bitmap(chkTemp.Width, chkTemp.Height);
                bmDisabled = new Bitmap(chkTemp.Width, chkTemp.Height);

                // Set checkbox false and capture bitmap.
                chkTemp.Checked = false;
                chkTemp.DrawToBitmap(bmUnChecked, new Rectangle(0, 0, chkTemp.Width, chkTemp.Height));

                // Set checkbox true and capture bitmap.
                chkTemp.Checked = true;
                chkTemp.DrawToBitmap(bmChecked, new Rectangle(0, 0, chkTemp.Width, chkTemp.Height));

                // Set checkbox false/disabled and capture bitmap.
                chkTemp.Checked = false;
                chkTemp.Enabled = false;
                chkTemp.DrawToBitmap(bmDisabled, new Rectangle(0, 0, chkTemp.Width, chkTemp.Height));

                chkTemp.Visible = false;

            }
            this.CheckedChanged += new System.EventHandler(this.btnToggleButton_Changed);
            this.EnabledChanged += new System.EventHandler(this.btnToggleButton_Changed);
            this.Image = this.Checked ? bmChecked : bmUnChecked;
            this.ResumeLayout(false);
            btnToggleButton_Changed(null, null);
        }


        private void btnToggleButton_Changed(object sender, EventArgs e)
        {
            Image =
               !Enabled ? bmDisabled :
               Checked ? bmChecked :
               bmUnChecked;
        }

        // Create 3 static bitmaps to swap-out when the button changes.
        // Static saves space (we don't need a copy for each instance of this class) but it seemed to break the design-time display.
        private static Bitmap bmChecked;
        private static Bitmap bmUnChecked;
        private static Bitmap bmDisabled;

    }
}
