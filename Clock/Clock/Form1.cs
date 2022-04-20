namespace Clock;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    readonly int clockDiameter = 300;
    public Form1()
    {
        InitializeComponent();
        this.Paint += new PaintEventHandler(DrawClock!);
        SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.DoubleBuffer, true);
    }

    private void DrawClock(object sender, PaintEventArgs e)
    {
        Point centerPoint = new Point()
        {
            X = this.ClientRectangle.Width / 2,
            Y = this.ClientRectangle.Height / 2
        };

        Brush brush = new SolidBrush(Color.FromArgb(0xFF, 0xE0, 0xFA));
        //Pen pen = new Pen(Color.Black, 10);
        //e.Graphics.FillEllipse(brush, new Rectangle(centerPoint.X - clockDiameter / 2, centerPoint.Y - clockDiameter / 2, clockDiameter, clockDiameter));
        e.Graphics.DrawImage(Image.FromFile("../../../ussr.png"), new Rectangle(centerPoint.X - clockDiameter / 2, centerPoint.Y - clockDiameter / 2, clockDiameter, clockDiameter));
        //pen.Width = (float)5;
        //e.Graphics.DrawEllipse(pen, new Rectangle(centerPoint.X - clockDiameter / 2, centerPoint.Y - clockDiameter / 2, clockDiameter, clockDiameter));

        double secondsAngle = (2 * (Math.PI) * DateTime.Now.Second / 60);
        int secondsX = centerPoint.X + (int)Math.Round(Math.Sin(secondsAngle) * clockDiameter / 2);
        int secondsY = centerPoint.Y - (int)Math.Round(Math.Cos(secondsAngle) * clockDiameter / 2);
        e.Graphics.DrawLine(new Pen(Color.Pink, 3), centerPoint, new Point(secondsX, secondsY));

        double minuntesAngle = (2 * (Math.PI) * DateTime.Now.Minute / 60);
        int minuntesX = centerPoint.X + (int)Math.Round(Math.Sin(minuntesAngle) * (clockDiameter / 2 - 30));
        int minuntesY = centerPoint.Y - (int)Math.Round(Math.Cos(minuntesAngle) * (clockDiameter / 2 - 30));
        e.Graphics.DrawLine(new Pen(Color.Blue, 3), centerPoint, new Point(minuntesX, minuntesY));

        double hoursAngle = (2 * (Math.PI) * DateTime.Now.Hour / 12);
        int hoursX = centerPoint.X + (int)Math.Round(Math.Sin(hoursAngle) * (clockDiameter / 2 - 60));
        int hoursY = centerPoint.Y - (int)Math.Round(Math.Cos(hoursAngle) * (clockDiameter / 2 - 60));
        e.Graphics.DrawLine(new Pen(Color.Black, 3), centerPoint, new Point(hoursX, hoursY));

        Invalidate();
    }
}