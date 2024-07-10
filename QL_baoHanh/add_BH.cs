using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace QL_baoHanh
{
    public partial class add_BH : Form
    {
        public add_BH()
        {
            InitializeComponent();
        }
        public IMongoCollection<BsonDocument> Connect()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("BH");
            var collection = database.GetCollection<BsonDocument>("bh");
            return collection;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }

        private void luu_Click(object sender, EventArgs e)
        {
            //Điện gia dụng
            if (rb_gd.Checked)
            {
                string th = txtth.Text;
                string sp = txtsp.Text;
                var loaiSanPham = new BsonDocument
                {
                    { "tenLoai", rb_gd.Text},
                    { "dungTich", int.Parse(txtdt.Text) },
                    { "Congsuat", int.Parse(txtcs.Text) },
                    { "trongLuong", int.Parse(txttl.Text) },
                    { "chatLieu", txtcl.Text },
                    { "nhietDo", txtnd.Text }
                };
                //
                string hoten = txttk.Text;
                var lichSuBH = new BsonDocument
                {
                    {"tenSanPham",txttsp.Text },
                    {"vanDe",txtlsvd.Text },
                    {"bienPhap",txtlsbp.Text },
                    {"ngayGiao",dtp_ng.Value }
                };
                //
                var khachHang = new BsonDocument
                {
                    { "hoten", txttk.Text },
                    { "diaChi", txtdc.Text },
                    { "sđt", int.Parse(txtsdt.Text) }
                };
                var yeuCauBH = new BsonDocument
                {
                    { "ngayYC", dt_nbh.Value },
                    { "vanDeYC", txtvd.Text },
                    { "tenKTV", txttktv.Text },
                    { "bienPhap", txtbp.Text },
                    { "trangThai", txttt.Text }
                };
                var newDocument = new BsonDocument
                {
                    { "thuongHieu", th },
                    { "tenSanPham", sp },
                    { "loaiSanPham", loaiSanPham },
                    { "gia", int.Parse(txtg.Text) },
                    { "ngayMua", dt_nm.Value },
                    { "thoiGianBH", int.Parse(txthbh.Text) },
                    { "khachHang", khachHang },
                    { "yeuCauBH", yeuCauBH }
                };
                var collection = Connect();
                collection.InsertOne(newDocument);
                var pushUpdate = Builders<BsonDocument>.Update.Push("khachHang.lichSuBH", lichSuBH);
                collection.UpdateOne(Builders<BsonDocument>.Filter.Eq("khachHang.hoten", hoten), pushUpdate);
                MessageBox.Show("Đã thêm tài liệu mới vào MongoDB.");
            }
            //Điện gia dụng (Máy giặt)
            if (rb_mg.Checked)
            {
                string th = txtth.Text;
                string sp = txtsp.Text;
                var loaiSanPham = new BsonDocument
                {
                    { "tenLoai", rb_mg.Text },
                    { "longMay", txtlm.Text },
                    { "khoiLuong", int.Parse(txtklg.Text) },
                    { "chatLieu", txtcl2.Text },
                    { "trongLuong",int.Parse( txttl2.Text) },
                    { "kichThuoc", txtkt.Text }
                };
                var khachHang = new BsonDocument
                {
                    { "hoten", txttk.Text },
                    { "diaChi", txtdc.Text },
                    { "sđt", int.Parse(txtsdt.Text) }
                };
                //
                string hoten = txttk.Text;
                var lichSuBH = new BsonDocument
                {
                    {"tenSanPham",txttsp.Text },
                    {"vanDe",txtlsvd.Text },
                    {"bienPhap",txtlsbp.Text },
                    {"ngayGiao",dtp_ng.Value }
                };
                //
                var yeuCauBH = new BsonDocument
                {
                    { "ngayYC", dt_nbh.Value },
                    { "vanDeYC", txtvd.Text },
                    { "tenKTV", txttktv.Text },
                    { "bienPhap", txtbp.Text },
                    { "trangThai", txttt.Text }
                };
                var newDocument = new BsonDocument
                {
                    { "thuongHieu", th },
                    { "tenSanPham", sp },
                    { "loaiSanPham", loaiSanPham },
                    { "gia", int.Parse(txtg.Text) },
                    { "ngayMua", dt_nm.Value },
                    { "thoiGianBH", int.Parse(txthbh.Text) },
                    { "khachHang", khachHang },
                    {"khachHang.lichSuBH",lichSuBH },
                    { "yeuCauBH", yeuCauBH }
                };
                var collection = Connect();
                collection.InsertOne(newDocument);
                var pushUpdate = Builders<BsonDocument>.Update.Push("khachHang.lichSuBH", lichSuBH);
                collection.UpdateOne(Builders<BsonDocument>.Filter.Eq("khachHang.hoten", hoten), pushUpdate);
                MessageBox.Show("Đã thêm tài liệu mới vào MongoDB.");
            }
            //Công nghệ
            if (rb_cn.Checked)
            {
                string th = txtth.Text;
                string sp = txtsp.Text;
                var loaiSanPham = new BsonDocument
                {
                    { "tenLoai", rb_cn.Text },
                    { "pin", int.Parse(txtp.Text) },
                    { "dungLuong", int.Parse(txtdl.Text) },
                    { "heDieuHanh",txthdh.Text },
                    { "mau", txtm.Text },
                    { "kichThuoc", txtkt2.Text }
                };
                //
                string hoten = txttk.Text;
                var lichSuBH = new BsonDocument
                {
                    {"tenSanPham",txttsp.Text },
                    {"vanDe",txtlsvd.Text },
                    {"bienPhap",txtlsbp.Text },
                    {"ngayGiao",dtp_ng.Value }
                };
                //
                var khachHang = new BsonDocument
                {
                    { "hoten", txttk.Text },
                    { "diaChi", txtdc.Text },
                    { "sđt", int.Parse(txtsdt.Text) }
                };
                var yeuCauBH = new BsonDocument
                {
                    { "ngayYC", dt_nbh.Value },
                    { "vanDeYC", txtvd.Text },
                    { "tenKTV", txttktv.Text },
                    { "bienPhap", txtbp.Text },
                    { "trangThai", txttt.Text }
                };
                var newDocument = new BsonDocument
                {
                    { "thuongHieu", th },
                    { "tenSanPham", sp },
                    { "loaiSanPham", loaiSanPham },
                    { "gia", int.Parse(txtg.Text) },
                    { "ngayMua", dt_nm.Value },
                    { "thoiGianBH", int.Parse(txthbh.Text) },
                    { "khachHang", khachHang },
                    { "yeuCauBH", yeuCauBH }
                };
                var collection = Connect();
                collection.InsertOne(newDocument);
                var pushUpdate = Builders<BsonDocument>.Update.Push("khachHang.lichSuBH", lichSuBH);
                collection.UpdateOne(Builders<BsonDocument>.Filter.Eq("khachHang.hoten", hoten), pushUpdate);
                MessageBox.Show("Đã thêm tài liệu mới vào MongoDB.");
            }
            //Điện lạnh
            if (rb_dl.Checked)
            {
                string th = txtth.Text;
                string sp = txtsp.Text;
                var loaiSanPham = new BsonDocument
                {
                    { "tenLoai", rb_dl.Text },
                    { "kieuTu", txtktu.Text},
                    { "dungTich", int.Parse(txtdt2.Text) },
                    { "congSuat", txtcs2.Text },
                    { "mau", txtm2.Text },
                    { "trongLuong", txttl3.Text }
                };
                //
                string hoten = txttk.Text;
                var lichSuBH = new BsonDocument
                {
                    {"tenSanPham",txttsp.Text },
                    {"vanDe",txtlsvd.Text },
                    {"bienPhap",txtlsbp.Text },
                    {"ngayGiao",dtp_ng.Value }
                };
                //
                var khachHang = new BsonDocument
                {
                    { "hoten", txttk.Text },
                    { "diaChi", txtdc.Text },
                    { "sđt", int.Parse(txtsdt.Text) }
                };
                var yeuCauBH = new BsonDocument
                {
                    { "ngayYC", dt_nbh.Value },
                    { "vanDeYC", txtvd.Text },
                    { "tenKTV", txttktv.Text },
                    { "bienPhap", txtbp.Text },
                    { "trangThai", txttt.Text }
                };
                var newDocument = new BsonDocument
                {
                    { "thuongHieu", th },
                    { "tenSanPham", sp },
                    { "loaiSanPham", loaiSanPham },
                    { "gia", int.Parse(txtg.Text) },
                    { "ngayMua", dt_nm.Value },
                    { "thoiGianBH", int.Parse(txthbh.Text) },
                    { "khachHang", khachHang },
                    { "yeuCauBH", yeuCauBH }
                };
                var collection = Connect();
                collection.InsertOne(newDocument);
                var pushUpdate = Builders<BsonDocument>.Update.Push("khachHang.lichSuBH", lichSuBH);
                collection.UpdateOne(Builders<BsonDocument>.Filter.Eq("khachHang.hoten", hoten), pushUpdate);
                MessageBox.Show("Đã thêm tài liệu mới vào MongoDB.");
            }
            txtth.Clear(); txtsdt.Clear(); txtp.Clear();  txtnd.Clear(); txtm2.Clear(); txtm.Clear();txttt.Clear();txtvd.Clear();txtsp.Clear();dt_nm.Value = DateTime.Now;dt_nbh.Value = DateTime.Now;
            txtktu.Clear(); txtlm.Clear(); txtkt2.Clear(); txtkt.Clear(); txtklg.Clear(); txthdh.Clear(); txttl.Clear();txttl2.Clear();txttl3.Clear();txttktv.Clear();txthbh.Clear();txtlsbp.Clear();
            txttk.Clear();txtdt.Clear();txtdt2.Clear();txtg.Clear();txtbp.Clear();txtdc.Clear();txtdl.Clear();txtcl.Clear();txtcl2.Clear();txtcs.Clear();txtcs2.Clear();txttsp.Clear();txtlsvd.Clear();dtp_ng.Value = DateTime.Now;
        }
         
        
        private void txtg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txthbh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtklg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rb_cn_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cn.Checked)
            {
                txtp.Enabled = true;
                txtdl.Enabled = true;
                txthdh.Enabled = true;
                txtm.Enabled = true;
                txtkt2.Enabled = true;
            }
            else
            {
                txtp.Enabled = false;
                txtdl.Enabled = false;
                txthdh.Enabled = false;
                txtm.Enabled = false;
                txtkt2.Enabled = false;
            }
        }

        private void rb_gd_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_gd.Checked)
            {
                txtdt.Enabled = true;
                txtcs.Enabled = true;
                txttl.Enabled = true;
                txtcl.Enabled = true;
                txtnd.Enabled = true;
            }
            else
            {
                txtdt.Enabled = false;
                txtcs.Enabled = false;
                txttl.Enabled = false;
                txtcl.Enabled = false;
                txtnd.Enabled = false;
            }
        }

        private void rb_dl_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_dl.Checked)
            {
                txtktu.Enabled = true;
                txtdt2.Enabled = true;
                txtcs2.Enabled = true;
                txtm2.Enabled = true;
                txttl3.Enabled = true;
            }
            else
            {
                txtktu.Enabled = false;
                txtdt2.Enabled = false;
                txtcs2.Enabled = false;
                txtm2.Enabled = false;
                txttl3.Enabled = false;
            }
        }

        private void rb_mg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_mg.Checked)
            {
                txtlm.Enabled = true;
                txtklg.Enabled = true;
                txtcl2.Enabled = true;
                txttl2.Enabled = true;
                txtkt.Enabled = true;
            }
            else
            {
                txtlm.Enabled = false;
                txtklg.Enabled = false;
                txtcl2.Enabled = false;
                txttl2.Enabled = false;
                txtkt.Enabled = false;
            }
        }
    }
}
