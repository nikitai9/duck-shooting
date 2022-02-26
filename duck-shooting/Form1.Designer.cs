using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Data;
namespace lechiz

namespace duck_shooting
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Duck_hunter";
            this.TopMost = true;
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove1;
            this.Click += Form1_Click;
            this.duck_image = Image.FromFile("duck.png");

            this.check.Size = new Size(50, 50);
            this.check.Location = new Point(50, 50);
            this.Controls.Add(check);
            this.Cursor.Dispose();

            this.duck_position.X = 350;
            this.duck_position.Y = 350;
            this.duck_position.Width = 50;
            this.duck_position.Height = 50;

            this.DoubleBuffered = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            cord_point.Add(new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10));
            duck_colection.Add(new C_duck(duck_image, 1, rand_duck.Next(0, 500), rand_duck.Next(0, 500)));

        }

        Random rand_duck = new Random();
        Point elipse_location = new Point();
        Rectangle duck_position = new Rectangle();
        Rectangle shut_position = new Rectangle();
        Image duck_image;


        Point mouse_location = new Point();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Flush();
            GC.Collect();
            DrawImage2FloatRectF(e);
            Pen pen = new Pen(Color.Green, 5);

            e.Graphics.DrawLine(pen, elipse_location.X + 30, elipse_location.Y + 20, elipse_location.X + 60, elipse_location.Y + 20);
            e.Graphics.DrawLine(pen, elipse_location.X + 10, elipse_location.Y + 20, elipse_location.X - 20, elipse_location.Y + 20);
            e.Graphics.DrawLine(pen, elipse_location.X + 20, elipse_location.Y + 30, elipse_location.X + 20, elipse_location.Y + 60);
            e.Graphics.DrawLine(pen, elipse_location.X + 20, elipse_location.Y + 10, elipse_location.X + 20, elipse_location.Y - 20);
            e.Graphics.DrawEllipse(Pens.Red,
                elipse_location.X, elipse_location.Y, 40, 40);

            foreach (Point point in cord_point)
            {
                e.Graphics.FillEllipse(Brushes.Red,
                point.X, point.Y, 20, 20);
                shut_position.X = point.X;
                shut_position.Y = point.Y;
                shut_position.Width = 20;
                shut_position.Height = 20;
            }
        }

        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
            elipse_location.X = e.Location.X;
            elipse_location.Y = e.Location.Y;
            this.Invalidate();
        }

        public void DrawImage2FloatRectF(PaintEventArgs e)
        {
            foreach (C_duck duck in duck_colection)
            {
                if (check_kill(duck) == true)
                {
                    duck_colection.Remove(duck);
                    break;
                }
                e.Graphics.DrawImage(duck.duck_img, duck.cords);
            }
            if (duck_colection.Count >= MAX_DUCK)
            {
                MakeScreenshot();
                MessageBox.Show("END GAME");
                this.Close();
            }

            GC.Collect();
        }

        public void MakeScreenshot()
        {
            string names = DateTime.Now.ToString().Replace(".", "_").Replace(":", "_");
            names += ".jpg";
            Rectangle bounds = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);


            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(this.Location, Point.Empty, bounds.Size);
                }
                bitmap.Save(names, ImageFormat.Jpeg);
            }
        }
        void new_duck()
        {
            this.duck_position.X = duck_position.X + 100;
            this.duck_position.Y = duck_position.Y + 100;
            //isAlive = true;

        }

        bool check_kill(C_duck duck)
        {

            if (shut_position.IntersectsWith(duck.cords))
            {
                MessageBox.Show("Kill duck!");
                GC.Collect(GC.GetGeneration(duck));
                return true;
            }
            return false;
        }

        readonly int MAX_DUCK = 10;
        List<Point> cord_point = new List<Point>();
        List<C_duck> duck_colection = new List<C_duck>();
        Label check = new Label();
        #endregion
    }
}

