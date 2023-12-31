﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using crud.myclass;
using MySql.Data.MySqlClient;

namespace crud
{
    public partial class frmCrud : Form
    {

        CRUD crud = new CRUD();
        public frmCrud()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //CREATE
            CREATE();
            READ();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //UPDATE
            UPDATE();
            READ();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DELETE
            DELETE();
            READ();
        }

        //READ
        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_data();
            dataGridView1.DataSource = crud.dt;
        }

        //CREATE
        public void CREATE()
        {
            crud.name = c_txtName.Text;
            crud.age = c_txtAge.Text;
            crud.gender = c_txtGender.Text;
            crud.Create_data();
        }

        //UPDATE
        public void UPDATE()
        {
            crud.name = u_txtName.Text;
            crud.age = u_txtAge.Text;
            crud.gender = u_txtGender.Text;
            crud.id = IDTXT.Text; 
            crud.Update_data();
        }

        public void DELETE()
        {
            crud.id = IDTXT.Text;
            crud.Delete_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //GET DATA
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    IDTXT.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    u_txtName.Text=(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    u_txtAge.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    u_txtGender.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch 
            {

                MessageBox.Show("Dont Click the Header!");
            }
        }
    }
}
