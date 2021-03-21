using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab10
{
    public partial class MainWindow : Window
    {
        public static int N = Int32.Parse(ConfigurationManager.AppSettings["N"]), canvasLenght = 600;
        public int CellLenght => canvasLenght / N;
        public int[,] Pixels = new int[N, N];
        public double BarriersDensity = Double.Parse(ConfigurationManager.AppSettings["BarriersDensity"]) / 100;
        public bool IsPathFound { get; set; } = false;
        public Point FromPoint { get; set; }
        public Point ToPoint { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DrawEmptyGrid();
        }

        private void DrawEmptyGrid()
        {
            CanvasConrtol.Children.Clear();
            for (int i = 0; i <= N; i++)
            {
                Line verticalLine = new Line
                {
                    Stroke = Brushes.Black,
                    X1 = i * CellLenght,
                    X2 = i * CellLenght,
                    Y1 = 0,
                    Y2 = canvasLenght,
                    StrokeThickness = 1
                };
                CanvasConrtol.Children.Add(verticalLine);

                Line horizontalLine = new Line
                {
                    Stroke = Brushes.Black,
                    X1 = 0,
                    X2 = canvasLenght,
                    Y1 = i * CellLenght,
                    Y2 = i * CellLenght,
                    StrokeThickness = 1
                };
                CanvasConrtol.Children.Add(horizontalLine);
            }
        }

        private void InitializePixels()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Pixels[i, j] = (int)CellType.Null;
                }
            }
        }

        private void FillSquare(int i, int j, CellType cellType)
        {
            Pixels[i, j] = (int)cellType;
            var color = GetColor(cellType);
            Rectangle rectangle = new Rectangle
            {
                Height = CellLenght,
                Width = CellLenght,
                Fill = new SolidColorBrush(color)
            };

            Canvas.SetTop(rectangle, CellLenght * i);
            Canvas.SetLeft(rectangle, CellLenght * j);
            CanvasConrtol.Children.Add(rectangle);
        }

        private Color GetColor(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.From:
                    return Colors.Green;
                case CellType.Border:
                    return Colors.Black;
                case CellType.To:
                    return Colors.Red;
                default:
                    return Colors.White;
            }
        }

        private void WriteText(int i, int j, string text)
        {
            int x = i * CellLenght + 2;
            int y = j * CellLenght + 4;
            TextBlock textBlock = new TextBlock
            {
                Text = text,
                Foreground = new SolidColorBrush(Colors.Black)
            };

            Canvas.SetTop(textBlock, x);
            Canvas.SetLeft(textBlock, y);
            CanvasConrtol.Children.Add(textBlock);
        }

        private void DrawLine(Point from, Point to)
        {
            var line = new Line
            {
                Stroke = Brushes.Black,
                X1 = (from.Y + 0.5) * CellLenght,
                Y1 = (from.X + 0.5) * CellLenght,
                X2 = (to.Y + 0.5) * CellLenght,
                Y2 = (to.X + 0.5) * CellLenght,
                StrokeThickness = 1
            };

            CanvasConrtol.Children.Add(line);
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            DrawEmptyGrid();
            InitializePixels();
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (random.NextDouble() < BarriersDensity)
                    {
                        FillSquare(i, j, CellType.Border);
                    }
                }
            }

            FromPoint = new Point(random.Next(N), random.Next(N));
            FillSquare((int)FromPoint.X, (int)FromPoint.Y, CellType.From);
            ToPoint = new Point(random.Next(N), random.Next(N));
            FillSquare((int)ToPoint.X, (int)ToPoint.Y, CellType.To);
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            int currentLevel = 0;
            while (!IsPathFound)
            {
                var currentBorder = GetCurrentBorder(currentLevel).ToList();
                if (currentBorder.Count == 0)
                {
                    break;
                }

                currentBorder.ForEach(x => SpreadWaveFromPoint(x));
                currentLevel++;
            }

            if (IsPathFound)
            {
                DrawPathLine();
            }

            IsPathFound = false;
        }

        private IEnumerable<Point> GetCurrentBorder(int currentLevel)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Pixels[i, j] == currentLevel)
                    {
                        yield return new Point(i, j);
                    }
                }
            }
        }

        private void SpreadWaveFromPoint(Point point)
        {
            var possiblePoints = new List<Point> { new Point(point.X - 1, point.Y), new Point(point.X + 1, point.Y),
                new Point(point.X, point.Y - 1), new Point(point.X, point.Y + 1) };
            foreach (var possiblePoint in possiblePoints)
            {
                if (ToPoint.Equals(possiblePoint))
                {
                    IsPathFound = true;
                }

                int x = (int)possiblePoint.X;
                int y = (int)possiblePoint.Y;
                if (x >= 0 && x < N && y >= 0 && y < N && Pixels[x, y] == (int)CellType.Null)
                {
                    int value = Pixels[(int)point.X, (int)point.Y] + 1;
                    Pixels[(int)possiblePoint.X, (int)possiblePoint.Y] = value;
                    if (Boolean.Parse(ConfigurationManager.AppSettings["ShowWaveValues"]))
                    {
                        WriteText(x, y, value.ToString());
                    }
                }
            }
        }

        private void DrawPathLine()
        {
            var currentPoint = ToPoint;
            while (!currentPoint.Equals(FromPoint))
            {
                var newPoint = FindNextPointInPath(currentPoint);
                DrawLine(currentPoint, newPoint);
                currentPoint = newPoint;
            }
        }

        private Point FindNextPointInPath(Point point)
        {
            var possiblePoints = new List<Point> { new Point(point.X - 1, point.Y), new Point(point.X + 1, point.Y),
                new Point(point.X, point.Y - 1), new Point(point.X, point.Y + 1) };
            possiblePoints = possiblePoints.Where(t => t.X >= 0 && t.X < N && t.Y >= 0 && t.Y < N).ToList();
            return possiblePoints.ToDictionary(t => t, t => Pixels[(int)t.X, (int)t.Y])
                .OrderBy(x => x.Value).First(x => x.Value != (int)CellType.Border && x.Value != (int)CellType.Null).Key;
        }
    }
}
