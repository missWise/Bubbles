using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Bubbles
{
    class Bubble
    {
        public float centerX { set; get; }
        public float centerY { set; get; }
        public float dx { set; get; }
        public float dy { set; get; }

        private const float difference = 5;
        private const float radius = 20;
        private Brush brush;

        public Bubble() { }
        public Bubble(float x, float y)
        {
            centerX = x;
            centerY = y;
            dx = difference;
            dy = difference;
            Random rand = new Random();
            brush = new SolidBrush(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255)));
        }
        public void DrawBubble(Form form)
        {
            Graphics graphics = form.CreateGraphics();
            graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius*2, radius*2);
        }

        public void EraseBubble(Form form)
        {
            Graphics graphics = form.CreateGraphics();
            graphics.FillEllipse(new SolidBrush(form.BackColor), centerX - radius, centerY - radius, radius * 2, radius * 2);
        }

        public void MoveBubble(Form form)
        {
            if (dx > 0)
            {
                if (centerX + radius + dx >= form.Size.Width)
                {
                    dx = -dx;
                }
                
            }
            else if (dx < 0)
            {
                if (centerX - radius - dx <= 0)
                {
                    dx = -dx;
                }
            }
            if (dy > 0)
            {
                if (centerY + radius + dy + 20 >= form.Size.Height)
                {
                    dy = -dy;
                }

            }
            else if (dy < 0)
            {
                if (centerY - radius - dy <= 0)
                {
                    dy = -dy;
                }
            }
            EraseBubble(form);
            centerX += dx;
            centerY += dy;
            DrawBubble(form);
        }

        public void RunBubble(Form form)
        {
            
            while (true)
            {
                Thread.Sleep(25);
                MoveBubble(form);
            }
        }
    }
}
