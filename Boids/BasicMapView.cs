using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System;
using System.Collections.Generic;

using Boids.Interfaces;

namespace Boids
{
    /// <summary>
    /// The MapView class is responsible for providing a graphical representation of a map
    /// of cells.
    /// </summary>
    public class BasicMapView: MapView
    {
        private Control drawControl;
        
        //private HScrollBar sb_horiz;
        //private VScrollBar sb_vert;

        private IEnumerable<Flock_Interface> flocksToDraw;
        /// <summary>
        /// Adds a paintEventHandler to the Control
        /// </summary>
        /// <param name="drawControl">Control</param>
        public BasicMapView(Control drawControl)
        {
            this.drawControl = drawControl;       

            //// create scrollbars for map scrolling:
            //sb_horiz = new HScrollBar();
            //sb_horiz.Dock = DockStyle.Bottom;
            //sb_horiz.Maximum = drawControl.Width;
            //sb_horiz.LargeChange = drawControl.Width;

            //sb_vert = new VScrollBar();
            //sb_vert.Dock = DockStyle.Right;
            //sb_vert.Maximum = drawControl.Height;
            //sb_vert.LargeChange = drawControl.Height;

            //drawControl.Controls.Add(sb_horiz);
            //drawControl.Controls.Add(sb_vert);

            //// need event handlers to tell us when the scrollbars are moved:
            //sb_horiz.Scroll += new ScrollEventHandler(sb_horiz_Scroll);
            //sb_vert.Scroll += new ScrollEventHandler(sb_vert_Scroll);
            // event handler for whent he control needs redrawing.
            drawControl.Paint += new PaintEventHandler(drawControl_Paint);

            

            System.Reflection.PropertyInfo aProp =
                typeof(System.Windows.Forms.Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);

            aProp.SetValue(drawControl, true, null); 
        }

        //void sb_vert_Scroll(object sender, ScrollEventArgs e)
        //{
        //    this.drawControl.Invalidate();
        //}

        //void sb_horiz_Scroll(object sender, ScrollEventArgs e)
        //{
        //    this.drawControl.Invalidate();
        //}

        /// <summary>
        /// this eventhandler is responsible for painting all the boids to the attached Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void drawControl_Paint(object sender, PaintEventArgs e)
        {
            drawMap(e.Graphics);
        }

        /// <summary>
        /// This method is responsible for drawing all of the boid instances in 
        /// the application to the form graphics
        /// </summary>
        /// <param name="g">Graphics</param>
        public void drawMap(Graphics g)
        {
            int w = drawControl.Width;
            int h = drawControl.Height;

            if (flocksToDraw != null)
            {
                foreach (Flock_Interface f in flocksToDraw)
                {
                    //Pen p = new Pen(f.BoidColor);
                    Pen p = new Pen(f.BoidColor);
                    foreach (Boid b in f.getBoids())
                    {
                        int x,y;
                        if (b.Position.X < 0)
                            x = (w * Math.Abs((b.Position.X / w) + 1) ) % w;
                        else
                            x = b.Position.X % w;

                        if (b.Position.Y < 0)
                            y = (h * Math.Abs((b.Position.Y / h) + 1)) % h;
                        else
                            y = b.Position.Y % h;

                        //g.DrawEllipse(p, b.Position.X - 3, b.Position.Y - 3, 6, 6);
                        g.DrawEllipse(p, x, y - 3, 6, 6);
                        Point from = new Point(x, y);
                        Point to = from;
                        to.X += b.Velocity.X;
                        to.Y += b.Velocity.Y;
                        //g.DrawLine(p, b.Position.ToPoint(), (b.Position + b.Velocity).ToPoint());
                        g.DrawLine(p, from, to);
                    }
                }
            }
        }

        /// <summary>
        /// passes all of the boids to the map and forces a repaint
        /// </summary>
        /// <param name="flocks">IEnumerable<Flock_Interface></param>
        public void drawBoids(IEnumerable<Flock_Interface> flocks)
        {
            flocksToDraw = flocks;
            // force a repaint:
            drawControl.Invalidate();
        }
        
    }
}
