using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace form_Test
{
    public partial class Form1 : Form
    {
        const int BUTTON_SIZE_X = 100;
        const int BUTTON_SIZE_Y = 100;

        const int BOARD_SIZE_X = 3;
        const int BOARD_SIZE_Y = 3;

        private TestButton[,] _buttonArray;
        public Form1()
        {
            InitializeComponent();

            _buttonArray = new TestButton[BOARD_SIZE_Y, BOARD_SIZE_X];

            
            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                {

                    TestButton testbutton =
                         new TestButton(
                            this,
                            i, j,BOARD_SIZE_X,BOARD_SIZE_Y,new Size(BUTTON_SIZE_X,BUTTON_SIZE_Y), "");

                    _buttonArray[j, i] = testbutton;

                    Controls.Add(testbutton);
                }

            }
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, BOARD_SIZE_X);
                int y = rand.Next(0, BOARD_SIZE_Y);

                GetTestButton(x, y)?.Toggle();
                GetTestButton(x + 1, y)?.Toggle();
                GetTestButton(x - 1, y)?.Toggle();
                GetTestButton(x, y + 1)?.Toggle();
                GetTestButton(x, y - 1)?.Toggle();
            }
        }


        public TestButton GetTestButton(int x, int y)
        {
            ///配列外参照対策
            if (x < 0 || x >= BOARD_SIZE_X) return null;
            if (y < 0 || y >= BOARD_SIZE_Y) return null;

            return _buttonArray[y,x];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        

    }
}
