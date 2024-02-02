using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string m_Text1;
        Font m_TextFont;
        Color m_TextColor;
        Color m_barColor;
        Brush m_TextBrush;
        Brush m_barBrush;


        string m_Text2;

        Color m_RectColor;
        Pen m_RectPen;
        Rectangle[] m_Rect;
        string[] TableDataC1;
        string[] TableDataC2;
        Font m_TextFont2;

        Pen m_penXYchart;
        Pen m_penXYchart2;
        float x1;
        float y1;
        float x2;
        float y2;
        float xArrow;
        float yArrow;
        string ChartData;
        Rectangle[] BarCharts;
        SolidBrush Brush;
        float[] highcharts;
        float[] savedataX ;
        float[] savedataY;






        public Form1()
        {
            InitializeComponent();

            this.Paint += Form1_Paint;

            //Header
            m_Text1 = "ABC company";
            m_Text2 = "Annoual Revenue";
            m_TextFont = new Font("Times New Roman", 24, FontStyle.Underline);
            m_TextColor = Color.Black;
            m_barColor = Color.Red;
            m_TextBrush = new SolidBrush(m_TextColor);
            m_barBrush = new SolidBrush(m_barColor);


            //table
            m_RectColor = Color.Red;
            m_RectPen = new Pen(m_RectColor, 3);
            float centerX = this.ClientSize.Width / 3f;
            Rectangle[] m_Rect;
            TableDataC1 = new string[11] { "Year", " 1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997" };
            TableDataC2 = new string[11] { "Revenue", "150", "170", "180", "175", "200", "250", "210", "240", "280", "140" };
            m_TextFont2 = new Font("Times New Roman", 11);

            m_penXYchart = new Pen(Color.Black, 3);
            m_penXYchart2 = new Pen(Color.Black, 3);

            SolidBrush Brush = new SolidBrush(Color.Blue);
            BarCharts = new Rectangle[10];

            






        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Code to be executed when the form is loaded
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DisplayString1(g);
            DisplayString2(g);
            DisplayRectangle(g);
            DrawXYinCharts(g);
        }

        private void DisplayString1(Graphics g)
        {
            // Calculate the center of the form
            float centerX = this.ClientSize.Width / 2f;
            float topPadding = 20; // Adjust this value to set the top padding

            // Calculate the position to center the text at the top
            float textX = centerX - (g.MeasureString(m_Text1, m_TextFont).Width / 2);
            float textY = topPadding;

            // Draw the text at the calculated position
            PointF textStart = new PointF(textX, textY);
            g.DrawString(m_Text1, m_TextFont, m_TextBrush, textStart);
        }

        private void DisplayString2(Graphics g)
        {
            // Calculate the center of the form
            float centerX = this.ClientSize.Width / 2f;
            float topPadding = 20; // Adjust this value to set the top padding

            // Calculate the position to center the text at the top
            float textX = centerX - (g.MeasureString(m_Text2, m_TextFont).Width / 2);
            float textY = topPadding + g.MeasureString(m_Text1, m_TextFont).Height; // Position below the first text

            // Draw the text at the calculated position
            PointF textStart = new PointF(textX, textY);
            g.DrawString(m_Text2, m_TextFont, m_TextBrush, textStart);
        }

        //private void DisplayRectangle(Graphics g)
        //{
        //    m_RectColor = Color.Green;
        //    m_RectPen = new Pen(m_RectColor, 3);

        //    float centerX = this.ClientSize.Width / 3f;
        //    float topPadding = 100; // Adjust this value to set the top padding

        //    // Calculate the position to center the text at the top
        //    float textX = centerX+ centerX+100;
        //    float textY = topPadding + g.MeasureString(m_Text2, m_TextFont).Height; // Position below the first text

        //    m_Rect = new Rectangle((int)textX,(int) textY, 80, 90);
        //    g.DrawRectangle(m_RectPen, m_Rect);
        //}


        private void DisplayRectangle(Graphics g)
        {
            m_RectColor = Color.Black;
            m_RectPen = new Pen(m_RectColor, 3);

            float centerX = this.ClientSize.Width / 3f;
            float topPadding = 100; // Adjust this value to set the top padding

            // Calculate the position to center the text at the top
            float textX = centerX + centerX + 250;
            float textY = topPadding + g.MeasureString(m_Text2, m_TextFont).Height; // Position below the first text
            m_Rect = new Rectangle[22];

            // Remove the local declaration of TableDataC1
            // string[] TableDataC1;

            TableDataC1 = new string[11] { "Year", " 1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997" };
            TableDataC2 = new string[11] { "Revenue", "150", "170", "180", "175", "200", "250", "210", "240", "280", "140" };

            for (int i = 0; i < 11; i++)
            {
                m_Rect[i * 2] = new Rectangle((int)textX, (int)textY + i * 50, 80, 50);

                int centerXR = m_Rect[i * 2].Left + m_Rect[i * 2].Width / 2;
                int centerYR = m_Rect[i * 2].Top + m_Rect[i * 2].Height / 2;
                PointF textStart = new PointF(centerXR - 20, centerYR - 20);
                g.DrawString(TableDataC1[i], m_TextFont2, m_TextBrush, textStart);

                m_Rect[i * 2 + 1] = new Rectangle((int)textX + 80, (int)textY + i * 50, 80, 50);

                int centerXR2 = m_Rect[i * 2 + 1].Left + m_Rect[i * 2 + 1].Width / 2;
                int centerYR2 = m_Rect[i * 2 + 1].Top + m_Rect[i * 2 + 1].Height / 2;
                PointF textStart2 = new PointF(centerXR2 - 20, centerYR2 - 20);

                g.DrawString(TableDataC2[i], m_TextFont2, m_TextBrush, textStart2);
            }

            g.DrawRectangles(m_RectPen, m_Rect);
        }

        
        public void DrawXYinCharts(Graphics g)
        {
            savedataX = new float[10];
            savedataY = new float[10];

            // Initialize the center and top padding
            float centerX = this.ClientSize.Width / 3f;
            float topPadding = 100;

            // Draw Y-axis
            x1 = centerX - 400;
            y1 = topPadding + g.MeasureString(m_Text2, m_TextFont).Height;
            x2 = centerX - 400;
            y2 = y1 + 500;
            g.DrawLine(m_penXYchart, x1, y1, x2, y2);
            PointF textStart = new PointF(x1 - 10, y1 - 17);
            g.DrawString("Revenue", m_TextFont2, m_TextBrush, textStart);

            // Draw data in Y-axis
            // Draw data in Y-axis
            int Data = 140;
            int j = 0;
            for (int i = 16; i > 0; i--)
            {
                // Draw small lines on the Y-axis
                g.DrawLine(m_penXYchart, x1 - 5, y1 + 30 * i, x2 + 5, y1 + 30 * i);

                // Calculate the Y-coordinate based on the current iteration
                j++;
                // Draw the number 
                ChartData = Data.ToString();
                textStart = new PointF(x1 - 33, y1 + 30 * i);
                g.DrawString(ChartData, m_TextFont2, m_TextBrush, textStart);
                Data = Data + 10;
            }

            highcharts = new float[10] { y1 + 30 * 15, y1 + 30 * 13, y1 + 30 * 12, y1 + 375, y1 + 30 * 10, y1 + 30 * 5, y1 + 30 * 9, y1 + 30 * 6, y1 + 30 * 2, y1 + 30 * 16 };


            // Draw Arrows in Y-axis
            xArrow = x1 + 10;
            yArrow = y1 + 10;
            g.DrawLine(m_penXYchart, x1, y1, xArrow, yArrow);
            xArrow = x1 - 10;
            yArrow = y1 + 10;
            g.DrawLine(m_penXYchart, x1, y1, xArrow, yArrow);

            // Draw X-axis
            x2 = x1 + 600;
            g.DrawLine(m_penXYchart, x1, y2, x2, y2);
            textStart = new PointF(x2 + 10, y2 - 10);
            g.DrawString("Year", m_TextFont2, m_TextBrush, textStart);

            // Draw data in X-axis
            Data = 1997;
            j = 9;
            for (int i = 10; i > 0; i--)
            {
                // Draw small lines on the X-axis

                float xCoordinate = x1 + 50 * i + 20;
                savedataX[j] = xCoordinate;
                g.DrawLine(m_penXYchart, xCoordinate, y2 - 5, xCoordinate, y2 + 5);

                // Check if the current data is present in the array
                if (j < savedataY.Length)
                {
                    // Calculate the height based on the difference
                    int rectHeight = (int)(y2 - highcharts[j]);

                    // Draw the rectangle
                    Rectangle rect2 = new Rectangle((int)xCoordinate-5, (int)highcharts[j], 10, rectHeight);
                    g.FillRectangle(m_barBrush, rect2);

                    // Draw the number 
                    ChartData = Data.ToString();
                    textStart = new PointF(x1 + 50 * i, y2 + 15);
                    g.DrawString(ChartData, m_TextFont2, m_TextBrush, textStart);
                }
                if ( i != 1)
                {
                    float startX = (x1 + 50 * i + 20); // Replace with your desired X-coordinate
                    float startY = highcharts[j]; // Replace with your desired Y-coordinate
                    float endX = x1 + 50 * (i-1) + 20;   // Replace with your desired X-coordinate
                    float endY = highcharts[j-1];   // Replace with your desired Y-coordinate

                    // Use the DrawLine method to draw the line
                    g.DrawLine(m_penXYchart2, startX, startY, endX, endY);

                }
                Data = Data - 1;
                j--;

            }

            // Draw Arrows in X-axis
            xArrow = x2 - 10;
            yArrow = y2 - 10;
            g.DrawLine(m_penXYchart, x2, y2, xArrow, yArrow);
            xArrow = x2 - 10;
            yArrow = y2 + 10;
            g.DrawLine(m_penXYchart, x2, y2, xArrow, yArrow);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Color m_LineColor;
            switch ((int)e.KeyChar)
            {
                case 2: //Ctrl + B
                    m_penXYchart2 = new Pen(Color.Blue, 3);
                    break;
                case 7: //Ctrl + G
                    m_penXYchart2 = new Pen(Color.Green, 3);
                    break;
                case 18:    //Ctrl + R
                    m_penXYchart2= new Pen(Color.Red, 3);
                    break;
            }
            Invalidate();
        }





    }
}
