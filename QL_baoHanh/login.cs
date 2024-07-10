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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            cbcv.Text = "--Chọn chức vụ--";
        }
        private bool IsLoginValid(string username, string password,string cv)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("BH"); 
            var collection = database.GetCollection<BsonDocument>("nv"); 

            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("taikhoan", username),
                Builders<BsonDocument>.Filter.Eq("pass", password),
                Builders<BsonDocument>.Filter.Eq("chucvu", cv)
            );
            var result = collection.Find(filter).FirstOrDefault();

            return result != null;
        }
        private void dn_Click(object sender, EventArgs e)
        {
            string username = txttk.Text;
            string password = txtpass.Text;
            string cv = cbcv.Text;

            if (IsLoginValid(username, password, cv))
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                Main mainForm = new Main();
                mainForm.SetTenNhanVien(username);
                mainForm.SetCV(cv);
                mainForm.Show();
                
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không hợp lệ!");
            }

        }

        private void t_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Close();
            }    
        }

        private void dk_Click(object sender, EventArgs e)
        {
            this.Hide();
            register mainForm = new register();
            mainForm.Show();
        }
    }
}
