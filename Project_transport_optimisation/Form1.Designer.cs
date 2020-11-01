namespace Project_transport_optimisation
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
			this.gmap = new GMap.NET.WindowsForms.GMapControl();
			this.btnAddPoint = new System.Windows.Forms.Button();
			this.txtLat = new System.Windows.Forms.TextBox();
			this.txtLng = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClearList = new System.Windows.Forms.Button();
			this.btnLoadMap = new System.Windows.Forms.Button();
			this.btnGetRoute = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// gmap
			// 
			this.gmap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gmap.AutoScroll = true;
			this.gmap.AutoSize = true;
			this.gmap.Bearing = 0F;
			this.gmap.CanDragMap = true;
			this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
			this.gmap.GrayScaleMode = false;
			this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.gmap.LevelsKeepInMemory = 5;
			this.gmap.Location = new System.Drawing.Point(224, 12);
			this.gmap.MarkersEnabled = true;
			this.gmap.MaxZoom = 2;
			this.gmap.MinZoom = 2;
			this.gmap.MouseWheelZoomEnabled = true;
			this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.gmap.Name = "gmap";
			this.gmap.NegativeMode = false;
			this.gmap.PolygonsEnabled = true;
			this.gmap.RetryLoadTile = 0;
			this.gmap.RoutesEnabled = true;
			this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.gmap.ShowTileGridLines = false;
			this.gmap.Size = new System.Drawing.Size(889, 568);
			this.gmap.TabIndex = 0;
			this.gmap.Zoom = 0D;
			this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
			// 
			// btnAddPoint
			// 
			this.btnAddPoint.Location = new System.Drawing.Point(12, 148);
			this.btnAddPoint.Name = "btnAddPoint";
			this.btnAddPoint.Size = new System.Drawing.Size(132, 28);
			this.btnAddPoint.TabIndex = 1;
			this.btnAddPoint.Text = "Добавить точку";
			this.btnAddPoint.UseVisualStyleBackColor = true;
			this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
			// 
			// txtLat
			// 
			this.txtLat.Location = new System.Drawing.Point(12, 38);
			this.txtLat.Name = "txtLat";
			this.txtLat.Size = new System.Drawing.Size(132, 22);
			this.txtLat.TabIndex = 2;
			// 
			// txtLng
			// 
			this.txtLng.Location = new System.Drawing.Point(12, 85);
			this.txtLng.Name = "txtLng";
			this.txtLng.Size = new System.Drawing.Size(132, 22);
			this.txtLng.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Северная широта";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(135, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Восточная долгота";
			// 
			// btnClearList
			// 
			this.btnClearList.Location = new System.Drawing.Point(12, 182);
			this.btnClearList.Name = "btnClearList";
			this.btnClearList.Size = new System.Drawing.Size(132, 28);
			this.btnClearList.TabIndex = 6;
			this.btnClearList.Text = "Очистить";
			this.btnClearList.UseVisualStyleBackColor = true;
			this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
			// 
			// btnLoadMap
			// 
			this.btnLoadMap.Location = new System.Drawing.Point(12, 114);
			this.btnLoadMap.Name = "btnLoadMap";
			this.btnLoadMap.Size = new System.Drawing.Size(132, 28);
			this.btnLoadMap.TabIndex = 7;
			this.btnLoadMap.Text = "Загрузить";
			this.btnLoadMap.UseVisualStyleBackColor = true;
			this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
			// 
			// btnGetRoute
			// 
			this.btnGetRoute.Location = new System.Drawing.Point(12, 216);
			this.btnGetRoute.Name = "btnGetRoute";
			this.btnGetRoute.Size = new System.Drawing.Size(158, 28);
			this.btnGetRoute.TabIndex = 8;
			this.btnGetRoute.Text = "Составить маршрут";
			this.btnGetRoute.UseVisualStyleBackColor = true;
			this.btnGetRoute.Click += new System.EventHandler(this.btnGetRoute_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1125, 592);
			this.Controls.Add(this.btnGetRoute);
			this.Controls.Add(this.btnLoadMap);
			this.Controls.Add(this.btnClearList);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtLng);
			this.Controls.Add(this.txtLat);
			this.Controls.Add(this.btnAddPoint);
			this.Controls.Add(this.gmap);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		private GMap.NET.WindowsForms.GMapControl gmap;
		private System.Windows.Forms.Button btnAddPoint;
		private System.Windows.Forms.TextBox txtLat;
		private System.Windows.Forms.TextBox txtLng;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnClearList;
		private System.Windows.Forms.Button btnLoadMap;
		private System.Windows.Forms.Button btnGetRoute;
	}
}

