using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace QL_baoHanh
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            cbgt.Text = "--Chọn giới tính--";
            cb_cv.Text = "--Chọn chức vụ--";
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void dn__Click(object sender, EventArgs e)
        {
            Connect();
            this.Hide();
            login mainForm = new login();
            mainForm.Show();
        }
        public IMongoCollection<BsonDocument> Connect()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("BH");
            var collection = database.GetCollection<BsonDocument>("nv");
            return collection;
        }
        private void dk__Click(object sender, EventArgs e)
        {
            string ten = txtten.Text;
            string diachi = txtdc.Text;
            int nams = int.Parse(txtns.Text);
            string tk = txttk.Text;
            string pass = txtpass.Text;
            string gioit = cbgt.Text;
            string cv = cb_cv.Text;

            var collection = Connect();

            var newDocument = new BsonDocument
            {
                { "hoten", ten },
                { "namsinh", nams },
                {"diachi",diachi },
                {"gioitinh",gioit },
                {"taikhoan",tk },
                {"pass",pass },
                {"chucvu",cv }
            }; collection.InsertOne(newDocument);
            
            MessageBox.Show("Đăng ký thành công!!");
        }
    }
}
