using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ScatterPlots {
    public partial class ScatterPlot : Form
	{
		public ScatterPlot()
		{
            InitializeComponent();
            DrawScatter();
        }
		private void DrawScatter()
		{
			StrangeAttractors sa = new StrangeAttractors(500_000);

			// create a series for each line
			Series series1 = new Series("Angelo 1 :^)");
			chart1.ChartAreas[0].BackColor = Color.Black;
			series1.Points.DataBindXY(sa.Xs, sa.Ys);
			series1.ChartType = SeriesChartType.FastPoint;
			series1.MarkerColor = Color.LightBlue;//.FromArgb(255, 0, 0);
			series1.MarkerStyle = MarkerStyle.Circle;
			series1.MarkerSize = 1;

			// add each series to the chart
			chart1.Series.Clear();
			chart1.Series.Add(series1);

			// additional styling
			chart1.ResetAutoValues();
			chart1.Titles.Clear();
			chart1.Titles.Add($"Scatter Plot ({sa.Xs.Count:N0} points per series)");
			chart1.ChartAreas[0].AxisX.Title = "X Values";
			chart1.ChartAreas[0].AxisY.Title = "Y Values";
			chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Black;//LightGray;
			chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;//LightGray;
		}
		private void SaveImage()
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.OverwritePrompt = true;
			sfd.FileName = "Strange";
			sfd.DefaultExt = "PNG";
			sfd.Filter = "PNG|*.png|BMP|*.bmp|GIF|*.gif|JPEG|*.jpg;*.jpeg|TIFF|*.tif;*.tiff|"
					   + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
			sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				int h = 1920,
					w = 1280;
				string sFile = sfd.FileName,
						sExt = sFile.Substring(sFile.LastIndexOf("."));
				Bitmap bmp = new Bitmap(w, h);

				bmp.SetResolution((float)1920, (float)1280);
				chart1.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));

				switch (sExt)
				{
					case ".bmp":
						//this.chart1.SaveImage(sFile, ChartImageFormat.Bmp);
						bmp.Save(sFile, System.Drawing.Imaging.ImageFormat.Bmp);

						break;
					case ".jpg":
					case ".jpeg":
						//this.chart1.SaveImage(sFile, ChartImageFormat.Jpeg);
						bmp.Save(sFile, System.Drawing.Imaging.ImageFormat.Jpeg);

						break;
					case ".gif":
						//this.chart1.SaveImage(sFile, ChartImageFormat.Gif);
						bmp.Save(sFile, System.Drawing.Imaging.ImageFormat.Gif);

						break;
					case ".png":
						//this.chart1.SaveImage(sFile, ChartImageFormat.Png);
						bmp.Save(sFile, System.Drawing.Imaging.ImageFormat.Png);

						break;
					case ".tif":
					case ".tiff":
						//this.chart1.SaveImage(sFile, ChartImageFormat.Tiff);
						bmp.Save(sFile, System.Drawing.Imaging.ImageFormat.Tiff);

						break;
				}
			}
		}
		private void ScatterPlot_FormClosing(object sender, FormClosingEventArgs e)
		{
			string s = "Would you like to save this image?";

			if (MessageBox.Show(s, "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
				SaveImage();
		}
	}
}
