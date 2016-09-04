using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Bubbles
{
    public partial class Form1 : Form
    {
        List<Bubble> bubbleList;
        List<Thread> threadList;
        Bubble bubble;
        public Form1()
        {
            InitializeComponent();
            bubbleList = new List<Bubble>();
            threadList = new List<Thread>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            bubble = new Bubble(e.X, e.Y);
            bubble.DrawBubble(this);
            bubbleList.Add(bubble);
            threadList.Add(new Thread (Run));
            threadList[threadList.Count-1].Start(this);
        }

        private void Run(Object form)
        {
            bubble.RunBubble((Form)form);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in threadList)
            {
                item.Abort();
            }
        }
    }
}
