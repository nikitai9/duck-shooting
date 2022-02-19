using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
            this.Text = "Form1";

            this.DoubleBuffered = false;
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove1;
            this.Cursor.Dispose();

        }

        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
            mouse_location.X = e.Location.X;
            mouse_location.Y = e.Location.Y;
            this.Invalidate();
        }

        Point mouse_location = new Point();
     
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Green, 3);
            e.Graphics.Clear(Color.AliceBlue);
            e.Graphics.Flush();
            GC.Collect();
            e.Graphics.DrawEllipse(pen,
             new Rectangle(
                     new Point(Location.X, Location.Y),
                     new Size(30, 30)
                ));
            e.Graphics.DrawLine(pen, Location.X + 15, Location.Y - 10, Location.X + 15, Location.Y + 40);
            e.Graphics.DrawLine(pen, Location.X - 10, Location.Y + 15, Location.X + 40, Location.Y + 15);

        }


        #endregion
    }
}

