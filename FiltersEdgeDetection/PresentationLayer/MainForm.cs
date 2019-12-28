﻿using BLL;
using DAL;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FiltersEdgeDetection.PrensentationLayer
{

    public partial class MainForm : Form
    {
        private static readonly BLLOriginalBitmapManager bLLOriginalBitmapManager = new BLLOriginalBitmapManager();
        private static readonly BLLResultBitmapManager bLLResultBitmapManager = new BLLResultBitmapManager();
        private MainFormBitmapManager mainFormBitmapManager;
        private static ApiForm apiForm;

        //private ImageManagement imageManagement = new ImageManagement();

        public MainForm()
        {
            InitializeComponent();
            apiForm = new ApiForm(this);
            mainFormBitmapManager = new MainFormBitmapManager(this);
        }

        public void ResetFilters() {
            comboBoxEdge.SelectedItem = "";
            comboBoxFilters.SelectedItem = "";
        }
        public ComboBox GetComboBoxFilters()
        {
            return comboBoxFilters;
        }

        public ComboBox GetComboBoxEdge()
        {
            return comboBoxEdge;
        }

        public ApiForm GetApiForm()
        {
            return apiForm;
        }
        public MainFormBitmapManager GetMainFormBitmapManager()
        {
            return mainFormBitmapManager;
        }

        public System.Windows.Forms.PictureBox GetImagePreview()
        {
            return imgPreview;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void buttonLoadImgur_Click(object sender, EventArgs e)
        {
            apiForm.Show();
        }
        private void buttonLoadDisk_Click(object sender, EventArgs e)
        {
            IBitmapManager diskBitmapManager = new DiskBitmapManager();

            Bitmap bitmap = App.imageManagement.LoadImage(diskBitmapManager, imgPreview.Width);

            bLLOriginalBitmapManager.SetBitmap(bitmap);
            imgPreview.Image = bitmap;
            ResetFilters();
        }

        private void buttonSaveDisk_Click(object sender, EventArgs e)
        {
            IBitmapManager diskBitmapManager = new DiskBitmapManager();

            App.imageManagement.SaveImage(diskBitmapManager, bLLResultBitmapManager.GetBitmap());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.ApplyFilters();
        }

        private void imgPreview_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEdge_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.ApplyFilters();
        }
    }
}
