using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class ComputerGraphics : Form
    {
        #region Initialization

        public int cellSize = 15;
        public int panelWidth;
        public int panelHeight;
        public Point center;
        public Graphics pixelGraphics;
        public Graphics histogramGraphics;
        public Pen thinBlack = new Pen(Color.Black, 1);
        public Pen thickBlack = new Pen(Color.Black, 3);
        public Pen thinRed = new Pen(Color.Red, 1);
        public Pen thinGreen = new Pen(Color.Green, 1);
        public Pen thinBlue = new Pen(Color.Blue, 1);
        public Pen thinGray = new Pen(Color.Gray, 1);
        public SolidBrush blackBrush = new SolidBrush(Color.Gray);
        public int delayInMilliseconds = 100;

        public Point start;
        public Point finish;

        public int radius;
        public int a;
        public int b;

        public List<Point> filledPoints = new List<Point>();
        
        public List<int> redFrequencies;
        public List<int> greenFrequencies;
        public List<int> blueFrequencies;
        public List<int> grayFrequencies;

        public delegate int BinarizationType(Color color, int lowerLimit = 0, int upperLimit = 0);

        public Bitmap image;
        public int sidePixelsAmount = 1;

        public ComputerGraphics()
        {
            InitializeComponent();
            panelWidth = panelPixel.Width; //x
            panelHeight = panelPixel.Height; //y
            center = new Point(panelWidth / 2, panelHeight / 2);
            pixelGraphics = panelPixel.CreateGraphics();
            histogramGraphics = panelHistogram.CreateGraphics();
        }

        #endregion

        #region Main methods

        private void panelPixel_Paint(object sender, PaintEventArgs e)
        {
            for(int x = cellSize / 2; x < panelWidth; x += cellSize)
            {
                pixelGraphics.DrawLine(thinBlack, new Point(x, 0), new Point(x, 600));
            }
            for(int y = cellSize / 2; y < panelHeight; y += cellSize)
            {
                pixelGraphics.DrawLine(thinBlack, new Point(0, y), new Point(900, y));
            }
            pixelGraphics.DrawLine(thickBlack, new Point(center.X, 0), new Point(center.X, panelHeight));
            pixelGraphics.DrawLine(thickBlack, new Point(0, center.Y), new Point(panelWidth, center.Y));
        }

        private void buttonRefreshPanel_Click(object sender, EventArgs e)
        {
            panelPixel.Refresh();
            filledPoints.Clear();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeCurrentPanelVisible();
            if(tabControl.SelectedIndex == 7)
            {
                comboBox9BinarizationMethods.SelectedIndex = Constants.WithLowerLimit;
                if(pictureBox9UntreatedImage.Image == null)
                {
                    pictureBox9UntreatedImage.Image = pictureBox.Image;
                }
            }
        }

        private void MakeCurrentPanelVisible()
        {
            panelPixel.Visible = tabControl.SelectedIndex <= 4 ? true : false;
            panelHistogram.Visible = tabControl.SelectedIndex == 5 ? true : false;
            pictureBox.Visible = tabControl.SelectedIndex >= 6 ? true : false;
        }

        #endregion

        #region Second task - Drawing lines

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            start = GetFirstPoint();
            finish = GetSecondPoint();
            DrawLineByBresenhamAlgorithm();
        }

        private Point GetFirstPoint()
        {
            int firstX = Convert.ToInt32(numericUpDown2FirstX.Value);
            int firstY = Convert.ToInt32(numericUpDown2FirstY.Value);
            return new Point(firstX, firstY);
        }

        private Point GetSecondPoint()
        {
            int secondX = Convert.ToInt32(numericUpDown2SecondX.Value);
            int secondY = Convert.ToInt32(numericUpDown2SecondY.Value);
            return new Point(secondX, secondY);
        }

        private List<Point> DrawLineByBresenhamAlgorithm()
        {
            List<Point> allPoints = new List<Point>();
            double error = -0.5;
            double k = ((double)(finish.Y - start.Y) / (finish.X - start.X));
            int dx = Math.Abs(finish.X - start.X);
            int dy = Math.Abs(finish.Y - start.Y);
            int stepX = Math.Sign(finish.X - start.X);
            int stepY = Math.Sign(finish.Y - start.Y);
            int x = start.X;
            int y = start.Y;
            if(dy > dx)
            {
                k = 1 / k;
            }
            DrawPixelUnderLine(start.X, start.Y);
            allPoints.Add(new Point(start.X, start.Y));
            for(int i = 1; i <= Math.Max(dx, dy); i++)
            {
                error += Math.Abs(k);
                if(dy > dx)
                {
                    y += stepY;
                    if(error >= 0)
                    {
                        x += stepX;
                        error--;
                    }
                }
                else
                {
                    x += stepX;
                    if(error >= 0)
                    {
                        y += stepY;
                        error--;
                    }
                }
                DrawPixelUnderLine(x, y);
                allPoints.Add(new Point(x, y));
            }

            return allPoints;
        }

        private void DrawPixelUnderLine(int x, int y)
        {
            DrawPixel(new Point(x, y));
            DrawRealLine();
        }

        private void DrawRealLine()
        {
            Point firstPixel = new Point(center.X + start.X * cellSize, center.Y - start.Y * cellSize);
            Point secondPixel = new Point(center.X + finish.X * cellSize, center.Y - finish.Y * cellSize);
            pixelGraphics.DrawLine(thinRed, firstPixel, secondPixel);
        }

        #endregion

        #region Third task - Drawing a circle and an ellipse

        #region Drawing a circle

        private void buttonDrawCircle_Click(object sender, EventArgs e)
        {
            radius = Convert.ToInt32(numericUpDown3Radius.Value);
            DrawCircleByBresenhamAlgorithm();
        }

        private void DrawCircleByBresenhamAlgorithm()
        {
            #region Initialization
            var points = new List<Point>();
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;
            int u = 6;
            int v = 10 - 4 * radius;
            #endregion

            DrawCircleExtemePoints();
            while(v < 10)
            {
                if(d < 0)
                {
                    d += u;
                    u += 4;
                    v += 4;
                    x++;
                }
                else
                {
                    d += v;
                    u += 4;
                    v += 8;
                    x++;
                    y--;
                }
                points.Add(new Point(x, y));
                DrawPixelUnderCircle(x, y);
            }
            DrawCircleSymmetricPoints(points);
        }

        private void DrawCircleExtemePoints()
        {
            DrawPixelUnderCircle(0, radius);
            DrawPixelUnderCircle(radius, 0);
            DrawPixelUnderCircle(0, -radius);
            DrawPixelUnderCircle(-radius, 0);
        }

        private void DrawCircleSymmetricPoints(List<Point> points)
        {
            foreach (var point in points)
            {
                DrawPixelUnderCircle(point.Y, point.X);
                DrawPixelUnderCircle(point.Y, -point.X);
                DrawPixelUnderCircle(point.X, -point.Y);
                DrawPixelUnderCircle(-point.X, -point.Y);
                DrawPixelUnderCircle(-point.Y, -point.X);
                DrawPixelUnderCircle(-point.Y, point.X);
                DrawPixelUnderCircle(-point.X, point.Y);
            }
        }

        private void DrawPixelUnderCircle(int x, int y)
        {
            DrawPixel(x, y);
            DrawRealCircle();
        }

        private void DrawRealCircle()
        {
            pixelGraphics.DrawEllipse(thinRed, center.X + (0 - radius) * cellSize, center.Y + (0 - radius) * cellSize, 2 * radius * cellSize, 2 * radius * cellSize);
        }

        #endregion

        #region Drawing an ellipse

        private void buttonDrawEllipse_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(numericUpDown3A.Value);
            b = Convert.ToInt32(numericUpDown3B.Value);
            DrawEllipseByBresenhamAlgorithm();
        }
        
        private void DrawEllipseByBresenhamAlgorithm()
        {
            #region Initialization
            var points = new List<Point>();
            int x = 0;
            int y = b;
            int d = 4 * b * b + a * a - 4 * a * b * b;
            int L = a * b;
            int u = 12 * b * b;
            int v = 12 * b * b + 8 * a * a * (1 - b);
            #endregion

            DrawEllipseExtemePoints();
            while(L > 0)
            {
                if(d < 0)
                {
                    d += u;
                    u += 8 * b * b;
                    v += 8 * b * b;
                    L -= b;
                    x++;
                }
                else
                {
                    d += v;
                    u += 8 * b * b;
                    v += 8 * (a * a + b * b);
                    L -= (a + b);
                    x++;
                    y--;
                }
                points.Add(new Point(x, y));
                DrawPixelUnderEllipse(x, y);
            }
            x = a;
            y = 0;
            d = 4 * b * b + a * a - 4 * a * b * b;
            L = a * b;
            do
            {
                points.Add(new Point(x, y));
                DrawPixelUnderEllipse(x, y);
                if(d < 0)
                {
                    d += u;
                    u += 8 * b * b;
                    v += 8 * b * b;
                    L -= b;
                    y++;
                }
                else
                {
                    d += v;
                    u += 8 * b * b;
                    v += 8 * (a * a + b * b);
                    L -= (a + b);
                    x--;
                    y++;
                }
            }
            while(L > 0);
            DrawEllipseSymmetricPoints(points);
        }

        private void DrawEllipseExtemePoints()
        {
            DrawPixelUnderEllipse(0, b);
            DrawPixelUnderEllipse(a, 0);
            DrawPixelUnderEllipse(0, -b);
            DrawPixelUnderEllipse(-a, 0);
        }

        private void DrawEllipseSymmetricPoints(List<Point> points)
        {
            foreach(var point in points)
            {
                DrawPixelUnderEllipse(point.X, -point.Y);
                DrawPixelUnderEllipse(-point.X, -point.Y);
                DrawPixelUnderEllipse(-point.X, point.Y);
            }
        }

        private void DrawPixelUnderEllipse(int x, int y)
        {
            DrawPixel(x, y);
            DrawRealEllipse();
        }

        private void DrawRealEllipse()
        {
            pixelGraphics.DrawEllipse(thinRed, center.X + (0 - a) * cellSize, center.Y + (0 - b) * cellSize, 2 * a * cellSize, 2 * b * cellSize);
        }

        #endregion

        #endregion

        #region Fourth task - Filling polygons

        private void buttonAddPoint_Click(object sender, EventArgs e)
        {
            Point newPoint = GetNewVertex();
            filledPoints.Add(newPoint);
            listBox4Vertexes.Items.Add(newPoint);
            DrawPixel(newPoint);
        }

        private Point GetNewVertex()
        {
            int newX = Convert.ToInt32(numericUpDown4X.Value);
            int newY = Convert.ToInt32(numericUpDown4Y.Value);
            return new Point(newX, newY);
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            FillBorder();
            Point centralPoint = GetCentralPoint();
            FillNeighbours(centralPoint);
        }

        private void FillBorder()
        {
            int vertexCount = filledPoints.Count;
            start = filledPoints[vertexCount - 1];
            finish = filledPoints[0];
            filledPoints.AddRange(DrawLineByBresenhamAlgorithm());
            for(int i = 0; i < vertexCount - 1; i++)
            {
                start = filledPoints[i];
                finish = filledPoints[i + 1];
                filledPoints.AddRange(DrawLineByBresenhamAlgorithm());
            }
        }

        private Point GetCentralPoint()
        {
            int middleX = (filledPoints.Min(x => x.X) + filledPoints.Max(x => x.X)) / 2;
            List<Point> middleCrossingPoints = filledPoints.Where(x => x.X == middleX).ToList();
            int middleY = (middleCrossingPoints[0].Y + middleCrossingPoints[1].Y) / 2;
            DrawPixel(middleX, middleY);
            return new Point(middleX, middleY);
        }

        private void FillNeighbours(Point centralPoint)
        {
            Point newPoint;
            if(!filledPoints.Any(x => x.X == centralPoint.X + 1 && x.Y == centralPoint.Y))
            {
                newPoint = new Point(centralPoint.X + 1, centralPoint.Y);
                filledPoints.Add(newPoint);
                DrawPixel(newPoint);
                FillNeighbours(newPoint);
            }
            if(!filledPoints.Any(x => x.X == centralPoint.X - 1 && x.Y == centralPoint.Y))
            {
                newPoint = new Point(centralPoint.X - 1, centralPoint.Y);
                filledPoints.Add(newPoint);
                DrawPixel(newPoint);
                FillNeighbours(newPoint);
            }
            if(!filledPoints.Any(x => x.X == centralPoint.X && x.Y == centralPoint.Y + 1))
            {
                newPoint = new Point(centralPoint.X, centralPoint.Y + 1);
                filledPoints.Add(newPoint);
                DrawPixel(newPoint);
                FillNeighbours(newPoint);
            }
            if(!filledPoints.Any(x => x.X == centralPoint.X && x.Y == centralPoint.Y - 1))
            {
                newPoint = new Point(centralPoint.X, centralPoint.Y - 1);
                filledPoints.Add(newPoint);
                DrawPixel(newPoint);
                FillNeighbours(newPoint);
            }
        }

        #endregion

        #region Fifth task - Clipping



        #endregion

        #region Sixth task - Approximation of curves

        private void button6AddPoint_Click(object sender, EventArgs e)
        {
            Point newPoint = GetNewSupportingPoint();
            filledPoints.Add(newPoint);
            listBox6Points.Items.Add(newPoint);
            DrawPixel(newPoint);
        }

        private Point GetNewSupportingPoint()
        {
            int newX = Convert.ToInt32(numericUpDown6X.Value);
            int newY = Convert.ToInt32(numericUpDown6Y.Value);
            return new Point(newX, newY);
        }

        private void button6DrawBezierCurve_Click(object sender, EventArgs e)
        {
            int pointsAmount = filledPoints.Count;
            double x, y;
            for(double t = 0; t <= 1; t += 0.01)
            {
                if(pointsAmount == 3)
                {
                    x = Math.Pow(1 - t, 2) * filledPoints[0].X + 2 * t * (1 - t) * filledPoints[1].X + Math.Pow(t, 2) * filledPoints[2].X;
                    y = Math.Pow(1 - t, 2) * filledPoints[0].Y + 2 * t * (1 - t) * filledPoints[1].Y + Math.Pow(t, 2) * filledPoints[2].Y;
                }
                else
                {
                    x = Math.Pow(1 - t, 3) * filledPoints[0].X + 3 * t * Math.Pow(1 - t, 2) * filledPoints[1].X 
                        + 3 * t * t * (1 - t) * filledPoints[2].X + Math.Pow(t, 3) * filledPoints[3].X;
                    y = Math.Pow(1 - t, 3) * filledPoints[0].Y + 3 * t * Math.Pow(1 - t, 2) * filledPoints[1].Y 
                        + 3 * t * t * (1 - t) * filledPoints[2].Y + Math.Pow(t, 3) * filledPoints[3].Y;
                }
                DrawPixel((int)x, (int)y);
            }
        }

        #endregion

        #region Seventh task - Building an image histogram

        private void button7ChooseImage_Click(object sender, EventArgs e)
        {
            ChooseImageAndSetItInto(pictureBox7ExploredImage);
        }

        private void button7BuildHistogram_Click(object sender, EventArgs e)
        {
            ClearAllFrequencyLists();
            CountingFrequencies();
            NormalizeAllFrequencyLists();
            BuildHistograms();
        }

        private void ClearAllFrequencyLists()
        {
            redFrequencies = Enumerable.Repeat(0, 256).ToList();
            greenFrequencies = Enumerable.Repeat(0, 256).ToList();
            blueFrequencies = Enumerable.Repeat(0, 256).ToList();
            grayFrequencies = Enumerable.Repeat(0, 256).ToList();
        }

        private void CountingFrequencies()
        {
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel(x, y);
                    redFrequencies[color.R]++;
                    greenFrequencies[color.G]++;
                    blueFrequencies[color.B]++;
                    int grayShadow = (color.R + color.G + color.B) / 3;
                    grayFrequencies[grayShadow]++;
                }
            }
        }

        private void NormalizeAllFrequencyLists()
        {
            NormalizeFrequencies(redFrequencies);
            NormalizeFrequencies(greenFrequencies);
            NormalizeFrequencies(blueFrequencies);
            NormalizeFrequencies(grayFrequencies);
        }

        private void NormalizeFrequencies(List<int> frequencies)
        {
            double coefficient = 250.0 / frequencies.Max();
            for(int i = 0; i < 256; i++)
            {
                frequencies[i] = (int)(Math.Round(frequencies[i] * coefficient));
            }
        }

        private void BuildHistograms()
        {
            BuildHistogram(redFrequencies, thinRed, new Point(50, 280));
            BuildHistogram(greenFrequencies, thinGreen, new Point(500, 280));
            BuildHistogram(blueFrequencies, thinBlue, new Point(50, 580));
            BuildHistogram(grayFrequencies, thinGray, new Point(500, 580));
        }

        private void BuildHistogram(List<int> frequencies, Pen pen, Point corner)
        {
            for(int i = 0; i < 256; i++)
            {
                histogramGraphics.DrawLine(pen, corner.X + i, corner.Y, corner.X + i, corner.Y - frequencies[i]);
            }
        }

        #endregion

        #region Eighth task - Converting a color image to a halftone

        private void button8ChooseImage_Click(object sender, EventArgs e)
        {
            ChooseImageAndSetItInto(pictureBox8UntreatedImage);
        }

        private void button8Save_Click(object sender, EventArgs e)
        {
            SaveCurrentImage();
        }

        private void buttonConvertingToHalftone_Click(object sender, EventArgs e)
        {
            for(int y = 0; y < image.Height; y++) 
            {
                for(int x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel(x, y);
                    var newColor = (color.R + color.G + color.B) / 3;
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            pictureBox.Image = image;
        }

        #endregion

        #region Ninth task - Binarization of halftone images

        private void button9ChooseImage_Click(object sender, EventArgs e)
        {
            ChooseImageAndSetItInto(pictureBox9UntreatedImage);
        }

        private void button9SaveImage_Click(object sender, EventArgs e)
        {
            SaveCurrentImage();
        }

        private void button9ConvertingToBinary_Click(object sender, EventArgs e)
        {
            BinarizationType binarizationType;
            switch(comboBox9BinarizationMethods.SelectedIndex)
            {
                case Constants.WithLowerLimit:
                    {
                        binarizationType = BinarizationWithLowerLimit;
                        break;
                    }
                case Constants.WithUpperLimit:
                    {
                        binarizationType = BinarizationWithUpperLimit;
                        break;
                    }
                case Constants.DoubleLimited:
                    {
                        binarizationType = DoubleLimitedBinariazation;
                        break;
                    }
                default:
                    {
                        throw new Exception("Unknown binarization method.");
                    }
            }
            Binarize(binarizationType);
        }

        private void Binarize(BinarizationType binarizationType)
        {
            int lowerLimit = trackBar9LowerLimit.Value;
            int upperLimit = trackBar9UpperLimit.Value;
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel(x, y);
                    int newColor = binarizationType(color, lowerLimit, upperLimit);
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            pictureBox.Image = image;
        }

        private int BinarizationWithLowerLimit(Color color, int lowerLimit, int upperLimit)
        {
            return color.R >= lowerLimit ? 0 : 255;
        }

        private int BinarizationWithUpperLimit(Color color, int lowerLimit, int upperLimit)
        {
            return color.R <= upperLimit ? 0 : 255;
        }

        private int DoubleLimitedBinariazation(Color color, int lowerLimit, int upperLimit)
        {
            return (color.R <= lowerLimit || color.R > upperLimit) ? 0 : 255;
        }

        private void comboBox9BinarizationMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox9BinarizationMethods.SelectedIndex)
            {
                case Constants.WithLowerLimit:
                    {
                        EnableUpperAndLowerTrackbars(true, false);
                        break;
                    }
                case Constants.WithUpperLimit:
                    {
                        EnableUpperAndLowerTrackbars(false, true);
                        break;
                    }
                case Constants.DoubleLimited:
                    {
                        EnableUpperAndLowerTrackbars(true, true);
                        break;
                    }
                default:
                    {
                        throw new Exception("Unknown binarization method.");
                    }
            }
        }

        private void EnableUpperAndLowerTrackbars(bool lowerLimit, bool upperLimit)
        {
            trackBar9LowerLimit.Enabled = lowerLimit;
            trackBar9UpperLimit.Enabled = upperLimit;
        }

        private void trackBar9LowerLimit_Scroll(object sender, EventArgs e)
        {
            label9LowerLimitValue.Text = trackBar9LowerLimit.Value.ToString();
        }

        private void trackBar9UpperLimit_Scroll(object sender, EventArgs e)
        {
            label9UpperLimitValue.Text = trackBar9UpperLimit.Value.ToString();
        }

        #endregion

        #region Tenth and eleventh tasks - Noise elimination on a binary and halftone images

        private void button10ChooseImage_Click(object sender, EventArgs e)
        {
            ChooseImageAndSetItInto(pictureBox10UntreatedImage);
        }

        private void button10SaveImage_Click(object sender, EventArgs e)
        {
            SaveCurrentImage();
        }

        private void trackBar10Probability_Scroll(object sender, EventArgs e)
        {
            label10ProbabilityValue.Text = $"{trackBar10Probability.Value.ToString()} %";
        }

        private void button10AddNoise_Click(object sender, EventArgs e)
        {
            int probabilityInPercentage = trackBar10Probability.Value;
            if(radioButton10SaltAndPepperNoise.Checked)
            {
                AddSaltAndPepperNoise(probabilityInPercentage);
            }
            else if(radioButton10ImpulseNoise.Checked)
            {
                AddImpulseNoise(probabilityInPercentage);
            }
        }

        private void AddSaltAndPepperNoise(double probabilityInPercentage)
        {
            Random random = new Random();
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    int oldColor = image.GetPixel(x, y).R;
                    int newColor = random.Next(100) < probabilityInPercentage ? GetInverseColor(oldColor) : oldColor;
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            pictureBox.Image = image;
        }

        private int GetInverseColor(int color)
        {
            return color < 128 ? 255 : 0;
        }

        private void AddImpulseNoise(double probabilityInPercentage)
        {
            Random random = new Random();
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    int newColor = random.Next(100) < probabilityInPercentage ? 255 : image.GetPixel(x, y).R;
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            pictureBox.Image = image;
        }

        private void trackBar10NeighbourhoodSize_Scroll(object sender, EventArgs e)
        {
            sidePixelsAmount = trackBar10NeighbourhoodSize.Value;
            string size = (2 * sidePixelsAmount + 1).ToString();
            label10NeighbourhoodSizeValue.Text = $"{size} x {size}";
        }

        private void button10RemoveNoise_Click(object sender, EventArgs e)
        {
            if(tabControl10RemoveNoise.SelectedIndex == 0)
            {
                if(radioButton10BinaryLogicalFilter.Checked)
                {
                    RemoveNoiseByBinaryLogicalFilter();
                }
                else if(radioButton10BinaryMedianFilter.Checked)
                {
                    RemoveNoiseByMedianFilter();
                }
            }
            else if(tabControl10RemoveNoise.SelectedIndex == 1)
            {
                if(radioButton10HalftoneAveragingFilter.Checked)
                {
                    RemoveNoiseByHalftoneAveragingFilter();
                }
                else if(radioButton10HalftoneMedianFilter.Checked)
                {
                    RemoveNoiseByMedianFilter();
                }
            }
        }

        private void RemoveNoiseByBinaryLogicalFilter()
        {
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    List<int> neighbourhoodColors = GetNeighboursColors(x, y).ToList();
                    int inversedColor = GetInverseColor(image.GetPixel(x, y).R);
                    if(neighbourhoodColors.All(t => t == inversedColor))
                    {
                        image.SetPixel(x, y, Color.FromArgb(inversedColor, inversedColor, inversedColor));
                    }
                }
            }
            pictureBox.Image = image;
        }

        private void RemoveNoiseByMedianFilter()
        {
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    List<int> neighbourhoodColors = GetNeighboursColors(x, y).ToList();
                    if(IsEven(neighbourhoodColors.Count))
                    {
                        neighbourhoodColors.Add(image.GetPixel(x, y).R);
                    }
                    neighbourhoodColors.Sort();
                    int newColor = neighbourhoodColors[neighbourhoodColors.Count / 2];
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            pictureBox.Image = image;
        }

        private void RemoveNoiseByHalftoneAveragingFilter()
        {
            for(int y = 0; y < image.Height; y++)
            {
                for(int x = 0; x < image.Width; x++)
                {
                    List<int> neighbourhoodColors = GetNeighboursColors(x, y).ToList();
                    neighbourhoodColors.Add(image.GetPixel(x, y).R);
                    int newColor = neighbourhoodColors.Sum() / neighbourhoodColors.Count;
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
            pictureBox.Image = image;
        }

        private IEnumerable<int> GetNeighboursColors(int x, int y)
        {
            int xStart = x < sidePixelsAmount ? 0 : x - sidePixelsAmount;
            int yStart = y < sidePixelsAmount ? 0 : y - sidePixelsAmount;
            int xFinish = x + sidePixelsAmount >= image.Width ? image.Width - 1 : x + sidePixelsAmount;
            int yFinish = y + sidePixelsAmount >= image.Height ? image.Height - 1 : y + sidePixelsAmount;
            for(int i = yStart; i <= yFinish; i++)
            {
                for(int j = xStart; j <= xFinish; j++)
                {
                    if(i != y || j != x)
                    {
                        yield return image.GetPixel(j, i).R;
                    }
                }
            }
        }

        #endregion

        #region Twelfth and thirteenth task - Selecting object borders on a binary and halftone images



        #endregion

        #region Fourteenth task - Segmentation of images



        #endregion

        #region Fifteenth task - Text recognition on image



        #endregion

        #region Supporting functions

        private void DrawPixel(int x, int y)
        {
            DrawPixel(new Point(x, y));
        }

        private void DrawPixel(Point point)
        {
            Thread.Sleep(delayInMilliseconds);
            FillPixel(point.X, point.Y);
        }

        private void FillPixel(int x, int y)
        {
            FillPixel(new Point(x, y));
        }

        private void FillPixel(Point point)
        {
            int left = (int)(center.X + (point.X - 0.5) * cellSize);
            int top = (int)(center.Y - (point.Y + 0.5) * cellSize);
            pixelGraphics.FillRectangle(blackBrush, left, top, cellSize, cellSize);
        }

        private void ChooseImageAndSetItInto(PictureBox currentPictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentPictureBox.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                image = new Bitmap(pictureBox.Image);
            }
        }

        private void SaveCurrentImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(saveFileDialog.FileName + ".jpg");
            }
        }

        private bool IsEven(int x)
        {
            return x % 2 == 0;
        }



        #endregion

        
    }
}
