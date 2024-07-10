using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace QL_baoHanh
{
    public partial class Main : Form
    {
        public IMongoCollection<BsonDocument> Connect()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test2");
            var collection = database.GetCollection<BsonDocument>("bh_test");
            return collection;
        }
        public IMongoCollection<BsonDocument> ConnectNV()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test2");
            var collection = database.GetCollection<BsonDocument>("nv_test");
            return collection;
        }
        
        public void LoadData()
        {
            cbloai.Text = "--Chọn loại sản phẩm--";
            var collection = Connect();
            var filter = new BsonDocument();
            var documents = collection.Find(filter).ToList();
            foreach (var document in documents)
            {
                string th = document.GetElement("thuongHieu").Value.ToString();
                string tensp = document.GetElement("tenSanPham").Value.ToString();
                var loai = document["loaiSanPham"].AsBsonDocument;
                string tenloai = loai["tenLoai"].ToString();
                string gia = document.GetElement("gia").Value.ToString();
                string hanbh = document.GetElement("thoiGianBH").Value.ToString();
                var kh = document["khachHang"].AsBsonDocument;
                string tenkh = kh["hoten"].ToString();
                var yc = document["yeuCauBH"].AsBsonDocument;
                string vd = yc["vanDeYC"].ToString();
                string tt = yc["trangThai"].ToString();

                dataSP.Rows.Add(th,tensp,tenloai,gia,hanbh,tenkh,vd,tt);
            }
        }
        login loginForm = new login();
        public string tenNV { get; set; }
        public string chucVuNV { get; set; }
        public void SetTenNhanVien(string tenNhanVien)
        {
            tenNV = tenNhanVien;
            lbtennv.Text = "Họ tên: " + tenNhanVien;
        }
        public void SetCV(string CVNhanVien)
        {
            chucVuNV = CVNhanVien;
            lbcv.Text = chucVuNV;
        }
        public Main()
        {
            InitializeComponent();
            LoadData();
            LoadKH();
            LoadLoaiSanPhamStatistics();
            LoadNV();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtgia_KeyPress(object sender, KeyPressEventArgs e)
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
        private void XoaDuLieuTuMongoDB(string thuongH)
        {
            var collection = Connect();
            var filter = Builders<BsonDocument>.Filter.Eq("thuongHieu", thuongH);
            collection.DeleteOne(filter);
        }
        private void del_Click(object sender, EventArgs e)
        {
            if (dataSP.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataSP.SelectedRows[0];
                string maSV = selectedRow.Cells["colth"].Value.ToString();
                XoaDuLieuTuMongoDB(maSV);
                dataSP.Rows.Remove(selectedRow);
                dataSP.Rows.Clear();
                LoadData();
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để xóa.");
            }
        }
        private void CapNhatDuLieu(string thuongH, string newth, string newsp, string newl,string newg,string newtg,string newkh,string newvd,string newtt)
        {
            var collection = Connect();
            var filter = Builders<BsonDocument>.Filter.Eq("thuongHieu", thuongH);

            // Xây dựng các cập nhật cần thực hiện
            var updateDefinition = Builders<BsonDocument>.Update
                .Set("thuongHieu", newth)
                .Set("tenSanPham", newsp)
                .Set("loaiSanPham.tenLoai", newl)
                .Set("gia", newg)
                .Set("thoiGianBH", newtg)
                .Set("khachHang.hoten", newkh)
                .Set("yeuCauBH.vanDeYC", newvd)
                .Set("yeuCauBH.trangThai", newtt);
            // Thực hiện cập nhật tài liệu trong cơ sở dữ liệu
            collection.UpdateOne(filter, updateDefinition);
        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (dataSP.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataSP.SelectedRows[0];
                string thuongH = selectedRow.Cells["colth"].Value.ToString();

                string newth = txtth.Text;
                string newsp = txtsp.Text;
                string newl = cbloai.Text;
                string newg = txtgia.Text;
                string newtg = txthbh.Text;
                string newkh = txtkh.Text;
                string newvd = txtvd.Text;
                string newtt = txttt.Text;
                // Hiển thị giá trị cần sửa đổi trong các TextBox
                txtth.Text = thuongH;
                txtsp.Text = newsp;
                cbloai.Text = newl;
                txtgia.Text = newg;
                txthbh.Text = newtg;
                txtkh.Text = newkh;
                txtvd.Text = newvd;
                txttt.Text = newtt;

                CapNhatDuLieu(thuongH, newth, newsp,newl,newg,newtg,newkh,newvd,newtt);

                dataSP.Rows.Clear();
                LoadData();
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để chỉnh sửa.");
            }
        }

        private void dataSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng hợp lệ hay không
            if (e.RowIndex >= 0 && e.RowIndex < dataSP.Rows.Count)
            {
                DataGridViewRow selectedRow = dataSP.Rows[e.RowIndex];
                string th = selectedRow.Cells["colth"].Value.ToString();
                string sp = selectedRow.Cells["colsp"].Value.ToString();
                string loai = selectedRow.Cells["coll"].Value.ToString();
                string gia = selectedRow.Cells["colg"].Value.ToString();
                string hbh = selectedRow.Cells["colhbh"].Value.ToString();
                string tenk = selectedRow.Cells["colkh"].Value.ToString();
                string vd = selectedRow.Cells["colvd"].Value.ToString();
                string tt = selectedRow.Cells["coltt"].Value.ToString();

                txtth.Text = th;
                txtsp.Text = sp;
                cbloai.Text = loai;
                txtgia.Text = gia;
                txthbh.Text = hbh;
                txtkh.Text = tenk;
                txtvd.Text = vd;
                txttt.Text = tt;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_BH mainForm = new add_BH();
            mainForm.Show();
        }

        private void tim_Click(object sender, EventArgs e)
        {
            string giaTriTimKiem = txtTim.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(giaTriTimKiem))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm.");
                return;
            }

            TimTheoThuongHieu(giaTriTimKiem);
        }
        private void TimTheoThuongHieu(string tenKhachHang)
        {
            var collection = Connect();
            var regexPattern = new BsonRegularExpression(new Regex(tenKhachHang, RegexOptions.IgnoreCase));
            var filter = Builders<BsonDocument>.Filter.Regex("thuongHieu", regexPattern);

            var searchResult = collection.Find(filter).ToList();

            if (searchResult.Count > 0)
            {
                dataSP.Rows.Clear();

                foreach (var document in searchResult)
                {
                    string th = document.GetElement("thuongHieu").Value.ToString();
                    string tensp = document.GetElement("tenSanPham").Value.ToString();
                    var loai = document["loaiSanPham"].AsBsonDocument;
                    string tenloai = loai["tenLoai"].ToString();
                    string gia = document.GetElement("gia").Value.ToString();
                    string hanbh = document.GetElement("thoiGianBH").Value.ToString();
                    var kh = document["khachHang"].AsBsonDocument;
                    string tenkh = kh["hoten"].ToString();
                    var yc = document["yeuCauBH"].AsBsonDocument;
                    string vd = yc["vanDeYC"].ToString();
                    string tt = yc["trangThai"].ToString();

                    dataSP.Rows.Add(th, tensp, tenloai, gia, hanbh, tenkh, vd, tt);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
            }
        }
        private void timkh_Click(object sender, EventArgs e)
        {
            string giaTriTimKiem = txt_timkh.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(giaTriTimKiem))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm.");
                return;
            }

            TimTheoTenKhachHang(giaTriTimKiem);
        }
        private void TimTheoTenKhachHang(string tenKhachHang)
        {
            var collection = Connect(); 
            var regexPattern = new BsonRegularExpression(new Regex(tenKhachHang, RegexOptions.IgnoreCase));
            var filter = Builders<BsonDocument>.Filter.Regex("khachHang.hoten", regexPattern);

            var searchResult = collection.Find(filter).ToList();

            if (searchResult.Count > 0)
            {
                DataKH.Rows.Clear();

                foreach (var document in searchResult)
                {
                    var khachHang = document["khachHang"].AsBsonDocument;
                    string hoten = khachHang["hoten"].ToString();
                    string diaChi = khachHang["diaChi"].ToString();
                    string sdt = khachHang["sđt"].ToString();

                    if (khachHang.Contains("lichSuBH") && khachHang["lichSuBH"].IsBsonArray)
                    {
                        var lichSuBHArray = khachHang["lichSuBH"].AsBsonArray;

                        foreach (var lichSu in lichSuBHArray)
                        {
                            var lichSuItem = lichSu.AsBsonDocument;
                            string tenSP = lichSuItem["tenSanPham"].ToString();
                            string vanDe = lichSuItem["vanDe"].ToString();
                            string bienPhap = lichSuItem["bienPhap"].ToString();
                            string ngayGiao = lichSuItem["ngayGiao"].ToString();

                            DataKH.Rows.Add(hoten, diaChi, sdt, tenSP, vanDe, bienPhap, ngayGiao);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
            }
        }

        public void LoadKH()
        {
            var collection = Connect();
            var filter = new BsonDocument();
            var documents = collection.Find(filter).ToList();

            foreach (var document in documents)
            {
                var khachHang = document["khachHang"].AsBsonDocument;
                string hoten = khachHang["hoten"].ToString();
                string diaChi = khachHang["diaChi"].ToString();
                string sdt = khachHang["sđt"].ToString();

                if (khachHang.Contains("lichSuBH") && khachHang["lichSuBH"].IsBsonArray)
                {
                    var lichSuBHArray = khachHang["lichSuBH"].AsBsonArray;

                    foreach (var lichSu in lichSuBHArray)
                    {
                        var lichSuItem = lichSu.AsBsonDocument;
                        string tenSP = lichSuItem["tenSanPham"].ToString();
                        string vanDe = lichSuItem["vanDe"].ToString();
                        string bienPhap = lichSuItem["bienPhap"].ToString();
                        string ngayGiao = lichSuItem["ngayGiao"].ToString();

                        DataKH.Rows.Add(hoten, diaChi, sdt, tenSP, vanDe, bienPhap, ngayGiao);
                    }
                }
            }
        }

        private void DataKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataKH.Rows.Count)
            {
                DataGridViewRow selectedRow = DataKH.Rows[e.RowIndex];
                string hoten = selectedRow.Cells["Column1"].Value.ToString();
                string diachi = selectedRow.Cells["Column2"].Value.ToString();
                string sodt = selectedRow.Cells["Column3"].Value.ToString();
                string tenSP = selectedRow.Cells["Column4"].Value.ToString();
                string vande = selectedRow.Cells["Column5"].Value.ToString();
                string bienphap = selectedRow.Cells["Column6"].Value.ToString();
                string ngaygiao = selectedRow.Cells["Column7"].Value.ToString();

                txtTenKH.Text = hoten;
                txtDiachi.Text = diachi;
                txtSDT.Text = sodt;
                txtTenSP.Text = tenSP;
                txtVanDe.Text = vande;
                txtBienPhap.Text = bienphap;
                //dt_ng.Value = ngaygiao;
                DateTime ngayGiao;
                if (DateTime.TryParse(ngaygiao, out ngayGiao))
                {
                    dt_ng.Value = ngayGiao;
                }
                else
                {
                    dt_ng.Value = DateTime.Now; 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void XoaDuLieuTuMongoDB_KH(string hoten, string tsp)
        {
            var collection = Connect();
            var filter = Builders<BsonDocument>.Filter.And(
               Builders<BsonDocument>.Filter.Eq("khachHang.hoten", hoten),
               Builders<BsonDocument>.Filter.Eq("khachHang.lichSuBH.tenSanPham", tsp)
           );
            collection.DeleteOne(filter);
        }
        private void del_kh_Click(object sender, EventArgs e)
        {
            if (DataKH.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = DataKH.SelectedRows[0];
                string hoten = selectedRow.Cells["Column1"].Value.ToString();
                string vd = selectedRow.Cells["Column4"].Value.ToString();
                XoaDuLieuTuMongoDB_KH(hoten,vd);
                DataKH.Rows.Remove(selectedRow);
                DataKH.Rows.Clear();
                LoadKH();
                LoadData();
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để xóa.");
            }
        }
        private void CapNhatDuLieu_KH(string hoten,string tensp, string newht, string newdc, string newsdt, string newtsp, string newvd, string newbp, DateTime newng)
        {
            var collection = Connect();
            var filter = Builders<BsonDocument>.Filter.And(
               Builders<BsonDocument>.Filter.Eq("khachHang.hoten", hoten),
               Builders<BsonDocument>.Filter.Eq("khachHang.lichSuBH.tenSanPham", tensp)
           );

            // Xây dựng các cập nhật cần thực hiện
            var updateDefinition = Builders<BsonDocument>.Update
                .Set("khachHang.hoten", newht)
                .Set("khachHang.diaChi", newdc)
                .Set("khachHang.sđt", newsdt)
                .Set("khachHang.lichSuBH.$.tenSanPham", newtsp)
                .Set("khachHang.lichSuBH.$.vanDe", newvd)
                .Set("khachHang.lichSuBH.$.bienPhap", newbp)
                .Set("khachHang.lichSuBH.$.ngayGiao", newng);
            // Thực hiện cập nhật tài liệu trong cơ sở dữ liệu
            collection.UpdateOne(filter, updateDefinition);
        }
        private void edit_KH_Click(object sender, EventArgs e)
        {
            if (DataKH.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = DataKH.SelectedRows[0];
                string hoten = selectedRow.Cells["Column1"].Value.ToString();
                string newht = txtTenKH.Text;
                string newdc = txtDiachi.Text;
                string newsdt = txtSDT.Text;
                string tensp = selectedRow.Cells["Column4"].Value.ToString();
                string newtsp = txtTenSP.Text;
                string newvd = txtVanDe.Text;
                string newbp = txtBienPhap.Text;
                DateTime newng = dt_ng.Value;
                //Hiển thị giá trị cần sửa đổi trong các TextBox
                txtTenKH.Text = hoten;
                txtDiachi.Text = newdc;
                txtDiachi.Text = newsdt;
                txtTenSP.Text = newtsp;
                txtVanDe.Text = newvd;
                txtBienPhap.Text = newbp;
                dt_ng.Value = newng;
                CapNhatDuLieu_KH(hoten,tensp, newht, newdc,newsdt,newtsp,newvd,newbp,newng);
                DataKH.Rows.Clear();
                LoadKH();
                txtBienPhap.Clear();txtDiachi.Clear();txtTenKH.Clear();txtTenSP.Clear();txtSDT.Clear();txtVanDe.Clear();
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để chỉnh sửa.");
            }
        }

        private void add_KH_Click(object sender, EventArgs e)
        {
            this.Hide();
            add_BH mainForm = new add_BH();
            mainForm.Show();
        }

        private void addls_Click(object sender, EventArgs e)
        {

            var collection = Connect();
            if (DataKH.SelectedRows.Count == 1)
            {
                // Get the selected customer's data
                DataGridViewRow selectedRow = DataKH.SelectedRows[0];
                string hoten = selectedRow.Cells["Column1"].Value.ToString();
                string diaChi = selectedRow.Cells["Column2"].Value.ToString();
                string sdt = selectedRow.Cells["Column3"].Value.ToString();



                // Create a new BsonDocument for the warranty history
                var newWarranty = new BsonDocument
                    {
                        { "tenSanPham", txtTenSP.Text },
                        { "vanDe", txtVanDe.Text },
                        { "bienPhap", txtBienPhap.Text },
                        { "ngayGiao", dt_ng.Value }
                    };

                // Update the selected customer's document in the database
                var filter = Builders<BsonDocument>.Filter.Eq("khachHang.hoten", hoten);
                var update = Builders<BsonDocument>.Update.Push("khachHang.lichSuBH", newWarranty);
                collection.UpdateOne(filter, update);

                // Refresh DataGridView
                LoadKH();

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            txtBienPhap.Clear();txtVanDe.Clear();txtTenSP.Clear();txtTenSP.Focus();
        }

        private void load_Click(object sender, EventArgs e)
        {
            txtTim.Clear();txtth.Clear();txtsp.Clear();txtgia.Clear();txtkh.Clear();txthbh.Clear();txtvd.Clear();txttt.Clear();
            dataSP.Rows.Clear();
            LoadData();
        }
        private void LoadLoaiSanPhamStatistics()
        {
            var collection = Connect();
            var aggregation = collection.Aggregate()
                .Group(new BsonDocument { { "_id", "$loaiSanPham.tenLoai" }, { "count", new BsonDocument("$sum", 1) }, { "averagePrice", new BsonDocument("$avg", "$gia") } });
            var results = aggregation.ToList();
            dataGridViewLoaiSanPham.Rows.Clear();
            foreach (var result in results)
            {
                string loaiSanPham = result["_id"].AsString;
                int count = result["count"].AsInt32;
                double averagePrice = result["averagePrice"].AsDouble;

                dataGridViewLoaiSanPham.Rows.Add(loaiSanPham, count, averagePrice);
            }
        }

        private void dataGridViewLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewLoaiSanPham.Rows.Count)
            {
                string selectedProductType = dataGridViewLoaiSanPham.Rows[e.RowIndex].Cells["Column8"].Value.ToString();
                var collection = Connect();
                var filter = Builders<BsonDocument>.Filter.Eq("loaiSanPham.tenLoai", selectedProductType);
                var searchResult = collection.Find(filter).ToList();
                dataGridViewSP.Rows.Clear();
                foreach (var document in searchResult)
                {
                    string th = document.GetElement("thuongHieu").Value.ToString();
                    string tensp = document.GetElement("tenSanPham").Value.ToString();
                    var loai = document["loaiSanPham"].AsBsonDocument;
                    string tenloai = loai["tenLoai"].ToString();
                    string gia = document.GetElement("gia").Value.ToString();
                    string hanbh = document.GetElement("thoiGianBH").Value.ToString();
                    var kh = document["khachHang"].AsBsonDocument;
                    string tenkh = kh["hoten"].ToString();
                    var yc = document["yeuCauBH"].AsBsonDocument;
                    string vd = yc["vanDeYC"].ToString();
                    string tt = yc["trangThai"].ToString();

                    dataGridViewSP.Rows.Add(th, tensp, tenloai, gia, hanbh, tenkh, vd, tt);
                }
            }
        }

        private void loaddkh_Click(object sender, EventArgs e)
        {
            txt_timkh.Clear();txtTenKH.Clear();txtSDT.Clear();txtDiachi.Clear();txtVanDe.Clear();txtTenSP.Clear();
            txtBienPhap.Clear();
            DataKH.Rows.Clear();
            LoadKH();
        }
        public void LoadNV()
        {
            cb_gt.Text = "--Chọn giới tính--";
            cb_cvv.Text = "--Chọn chức vụ--";
            var collection = ConnectNV();
            var filter = new BsonDocument();
            var documents = collection.Find(filter).ToList();
            foreach (var document in documents)
            {
                string ten = document.GetElement("hoten").Value.ToString();
                string nams = document.GetElement("namsinh").Value.ToString();
                string diac = document.GetElement("diachi").Value.ToString();
                string gioit = document.GetElement("gioitinh").Value.ToString();
                string tk = document.GetElement("taikhoan").Value.ToString();
                string cv = document.GetElement("chucvu").Value.ToString();
                dataGridViewNV.Rows.Add(ten, nams, diac, gioit, tk,cv);
            }
        }

        private void t_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void XoaDuLieuNV(string hoten)
        {
            var collection = ConnectNV();
            var filter = Builders<BsonDocument>.Filter.Eq("hoten", hoten);
            collection.DeleteOne(filter);
        }
        
        private void xoanv_Click(object sender, EventArgs e)
        {
            txtht.Clear(); txtns.Clear(); txtdc.Clear(); txttk.Clear(); pass.Enabled = true; cb_gt.Text = "--Chọn giới tính--";cb_cvv.Text = "--Chọn chức vụ--";
            if (dataGridViewNV.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridViewNV.SelectedRows[0];
                string ht = selectedRow.Cells["ht"].Value.ToString();
                XoaDuLieuNV(ht);
                dataGridViewNV.Rows.Remove(selectedRow);
                dataGridViewNV.Rows.Clear();
                LoadNV();
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để xóa.");
            }
        }

        private void addnv_Click(object sender, EventArgs e)
        {
            txtht.Focus();cb_cvv.Text = "--Chọn chức vụ--";
            txtht.Clear();txtns.Clear();txtdc.Clear();txttk.Clear();pass.Enabled = true;cb_gt.Text = "--Chọn giới tính--";
        }
        private void CapNhatDuLieuNV(string ht, string newht, string newns,string newdc, string newgt, string newtk,string newcv)
        {
            var collection = ConnectNV();
            var filter = Builders<BsonDocument>.Filter.Eq("hoten", ht);

            // Xây dựng các cập nhật cần thực hiện
            var updateDefinition = Builders<BsonDocument>.Update
                .Set("hoten", newht)
                .Set("namsinh", newns)
                .Set("diachi", newdc)
                .Set("gioitinh", newgt)
                .Set("taikhoan", newtk)
                .Set("chucvu", newcv);
            // Thực hiện cập nhật tài liệu trong cơ sở dữ liệu
            collection.UpdateOne(filter, updateDefinition);
        }
        private void suanv_Click(object sender, EventArgs e)
        {
            
            if (dataGridViewNV.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridViewNV.SelectedRows[0];
                string ht = selectedRow.Cells["ht"].Value.ToString();

                string newth = txtht.Text;
                string newsp = txtns.Text;
                string newl = txtdc.Text;
                string newg = cb_gt.Text;
                string newtg = txttk.Text;
                string newcv = cb_cvv.Text;
                
                txtth.Text = ht;
                txtsp.Text = newsp;
                cbloai.Text = newl;
                txtgia.Text = newg;
                txthbh.Text = newtg;
                cb_cvv.Text = newcv;
                
                CapNhatDuLieuNV(ht, newth, newsp, newl, newg, newtg,newcv);

                dataGridViewNV.Rows.Clear();
                LoadNV();
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để chỉnh sửa.");
            }
            txtht.Clear(); txtns.Clear(); txtdc.Clear(); txttk.Clear(); pass.Enabled = true; cb_gt.Text = "--Chọn giới tính--";
        }

        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng hợp lệ hay không
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewNV.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridViewNV.Rows[e.RowIndex];
                string th = selectedRow.Cells["ht"].Value.ToString();
                string sp = selectedRow.Cells["ns"].Value.ToString();
                string loai = selectedRow.Cells["dc"].Value.ToString();
                string gia = selectedRow.Cells["gt"].Value.ToString();
                string hbh = selectedRow.Cells["tk"].Value.ToString();

                txtht.Text = th;
                txtns.Text = sp;
                txtdc.Text = loai;
                cb_gt.Text = gia;
                txttk.Text = hbh;
            }
        }

        private void luu_BT_Click(object sender, EventArgs e)
        {
            string ten = txtht.Text;
            string diachi = txtdc.Text;
            int nams = int.Parse(txtns.Text);
            string tk = txttk.Text;
            string passw = pass.Text;
            string gioit = cb_gt.Text;
            string cv = cb_cvv.Text;

            var collection = ConnectNV();

            var newDocument = new BsonDocument
            {
                { "hoten", ten },
                { "namsinh", nams },
                {"diachi",diachi },
                {"gioitinh",gioit },
                {"taikhoan",tk },
                {"pass",passw },
                {"chucvu",cv }
            }; collection.InsertOne(newDocument);
            pass.Clear();
            pass.Enabled = false;
            dataGridViewNV.Rows.Clear();
            LoadNV();
            MessageBox.Show("Đăng ký thành công!!");
        }

        private void txtns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       
        public void tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbcv.Text != "Admin"&& tab1.SelectedTab != null && tab1.SelectedTab.Name == "tabnv")
            {
                // Hiển thị thông báo hoặc thay đổi tab được chọn
                MessageBox.Show("Truy cập vào tab này bị chặn.");
                tab1.SelectedTab = tabsp; // Chuyển người dùng về tab mặc định
            }
        }
    }
}
