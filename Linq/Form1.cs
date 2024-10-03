using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Linq
{
    public partial class Form1 : Form
    {

        
        private MySqlConnection GetConnection()
        {
            // Connection string (replace with your actual details)
            string connectionString = "server=localhost;database=productdb;user=root;password=hp31032004";
            return new MySqlConnection(connectionString);
        }
        public Form1()
        {
            InitializeComponent1();
        }

        private void InitializeComponent1()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;



            this.Text = "LINQ to OBJECT - Quản lý sản phẩm";
            this.Size = new System.Drawing.Size(900, 650);

            // GroupBox for product entry
            GroupBox groupBoxInput = new GroupBox();
            groupBoxInput.Text = "Nhập thông tin sản phẩm:";
            groupBoxInput.Location = new System.Drawing.Point(10, 10);
            groupBoxInput.Size = new System.Drawing.Size(300, 250);

            Label labelMaSP = new Label() { Text = "Mã SP:", Location = new System.Drawing.Point(10, 30) };
            TextBox textBoxMaSP = new TextBox() { Location = new System.Drawing.Point(100, 30) };

            Label labelTenSP = new Label() { Text = "Tên SP:", Location = new System.Drawing.Point(10, 60) };
            TextBox textBoxTenSP = new TextBox() { Location = new System.Drawing.Point(100, 60) };

            Label labelSoLuong = new Label() { Text = "Số lượng:", Location = new System.Drawing.Point(10, 90) };
            TextBox textBoxSoLuong = new TextBox() { Location = new System.Drawing.Point(100, 90) };

            Label labelDonGia = new Label() { Text = "Đơn giá:", Location = new System.Drawing.Point(10, 120) };
            TextBox textBoxDonGia = new TextBox() { Location = new System.Drawing.Point(100, 120) };

            Label labelXuatXu = new Label() { Text = "Xuất xứ:", Location = new System.Drawing.Point(10, 150) };
            TextBox textBoxXuatXu = new TextBox() { Location = new System.Drawing.Point(100, 150) };

            Label labelNgayHetHan = new Label() { Text = "Ngày hết hạn:", Location = new System.Drawing.Point(10, 180) };
            DateTimePicker dateTimePickerNgayHetHan = new DateTimePicker() { Location = new System.Drawing.Point(100, 180) };

            Button buttonLuuSP = new Button() { Text = "Lưu SP", Location = new System.Drawing.Point(50, 210) };
            Button buttonXoaSP = new Button() { Text = "Xóa SP", Location = new System.Drawing.Point(150, 210) };

            groupBoxInput.Controls.Add(labelMaSP);
            groupBoxInput.Controls.Add(textBoxMaSP);
            groupBoxInput.Controls.Add(labelTenSP);
            groupBoxInput.Controls.Add(textBoxTenSP);
            groupBoxInput.Controls.Add(labelSoLuong);
            groupBoxInput.Controls.Add(textBoxSoLuong);
            groupBoxInput.Controls.Add(labelDonGia);
            groupBoxInput.Controls.Add(textBoxDonGia);
            groupBoxInput.Controls.Add(labelXuatXu);
            groupBoxInput.Controls.Add(textBoxXuatXu);
            groupBoxInput.Controls.Add(labelNgayHetHan);
            groupBoxInput.Controls.Add(dateTimePickerNgayHetHan);
            groupBoxInput.Controls.Add(buttonLuuSP);
            groupBoxInput.Controls.Add(buttonXoaSP);

            // DataGridView for product list
            DataGridView dataGridViewProducts = new DataGridView();
            dataGridViewProducts.Location = new System.Drawing.Point(10, 270);
            dataGridViewProducts.Size = new System.Drawing.Size(860, 200);

            // Adding columns to DataGridView
            dataGridViewProducts.Columns.Add("MaSP", "Mã SP");
            dataGridViewProducts.Columns.Add("TenSP", "Tên SP");
            dataGridViewProducts.Columns.Add("SoLuong", "Số lượng");
            dataGridViewProducts.Columns.Add("DonGia", "Đơn giá");
            dataGridViewProducts.Columns.Add("XuatXu", "Xuất xứ");
            dataGridViewProducts.Columns.Add("NgayHetHan", "Ngày hết hạn");

            // GroupBox for search functions
            GroupBox groupBoxSearch = new GroupBox();
            groupBoxSearch.Text = "Chọn chức năng tìm kiếm:";
            groupBoxSearch.Location = new System.Drawing.Point(320, 10);
            groupBoxSearch.Size = new System.Drawing.Size(400, 250);

            Button buttonSearchMaxPrice = new Button() { Text = "1 SP có ĐG cao nhất", Location = new System.Drawing.Point(10, 30) };
            Button buttonSearchOriginJapan = new Button() { Text = "1 SP từ Nhật Bản", Location = new System.Drawing.Point(150, 30) };
            Button buttonSearchAllExpired = new Button() { Text = "Xuất toàn bộ SP quá hạn", Location = new System.Drawing.Point(10, 70) };

            Label labelPriceRange = new Label() { Text = "Xuất các SP có ĐG [a...b]:", Location = new System.Drawing.Point(10, 110) };
            TextBox textBoxPriceMin = new TextBox() { Location = new System.Drawing.Point(180, 110), Width = 50, Text = "500" };
            TextBox textBoxPriceMax = new TextBox() { Location = new System.Drawing.Point(240, 110), Width = 50, Text = "800" };

            groupBoxSearch.Controls.Add(buttonSearchMaxPrice);
            groupBoxSearch.Controls.Add(buttonSearchOriginJapan);
            groupBoxSearch.Controls.Add(buttonSearchAllExpired);
            groupBoxSearch.Controls.Add(labelPriceRange);
            groupBoxSearch.Controls.Add(textBoxPriceMin);
            groupBoxSearch.Controls.Add(textBoxPriceMax);

            // GroupBox for action operations
            GroupBox groupBoxActions = new GroupBox();
            groupBoxActions.Text = "Chọn thao tác:";
            groupBoxActions.Location = new System.Drawing.Point(730, 10);
            groupBoxActions.Size = new System.Drawing.Size(150, 250);

            Button buttonDeleteByOrigin = new Button() { Text = "Xóa SP theo xuất xứ bất kỳ", Location = new System.Drawing.Point(10, 30), Width = 130 };
            Button buttonCheckExpired = new Button() { Text = "Kiểm tra SP quá hạn", Location = new System.Drawing.Point(10, 70), Width = 130 };
            Button buttonDeleteExpired = new Button() { Text = "Xóa toàn bộ SP quá hạn", Location = new System.Drawing.Point(10, 110), Width = 130 };

            groupBoxActions.Controls.Add(buttonDeleteByOrigin);
            groupBoxActions.Controls.Add(buttonCheckExpired);
            groupBoxActions.Controls.Add(buttonDeleteExpired);

            // Adding controls to the Form
            this.Controls.Add(groupBoxInput);
            this.Controls.Add(dataGridViewProducts);
            this.Controls.Add(groupBoxSearch);
            this.Controls.Add(groupBoxActions);


            textBoxMaSP.KeyPress += TextBoxMaSP_KeyPress;
            textBoxSoLuong.KeyPress += TextBoxSoLuong_KeyPress;
            textBoxDonGia.KeyPress += TextBoxDonGia_KeyPress;


            string query = "SELECT MaSP, TenSP, SoLuong, DonGia, XuatXu, NgayHetHan FROM products";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                dataGridViewProducts.Rows.Clear(); // Clear the previous rows

                while (reader.Read())
                {
                    dataGridViewProducts.Rows.Add(
                        reader["MaSP"].ToString(),
                        reader["TenSP"].ToString(),
                        reader["SoLuong"].ToString(),
                        reader["DonGia"].ToString(),
                        reader["XuatXu"].ToString(),
                        Convert.ToDateTime(reader["NgayHetHan"]).ToString("dd/MM/yyyy")
                    );
                }
            }

            

            buttonLuuSP.Click += (sender, e) =>
            {
                if (ValidateTextBoxes(textBoxMaSP.Text, textBoxTenSP.Text, textBoxSoLuong.Text,textBoxDonGia.Text, textBoxXuatXu.Text))  // Ensure the textboxes are filled
                {
                    string maSP = textBoxMaSP.Text;
                    string tenSP = textBoxTenSP.Text;
                    int soLuong = int.Parse(textBoxSoLuong.Text);
                    decimal donGia = decimal.Parse(textBoxDonGia.Text);
                    string xuatXu = textBoxXuatXu.Text;
                    DateTime ngayHetHan = dateTimePickerNgayHetHan.Value;

                    string query = "INSERT INTO products (MaSP, TenSP, SoLuong, DonGia, XuatXu, NgayHetHan) " +
                                   "VALUES (@MaSP, @TenSP, @SoLuong, @DonGia, @XuatXu, @NgayHetHan)";

                    using (MySqlConnection conn = GetConnection())
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaSP", maSP);
                        cmd.Parameters.AddWithValue("@TenSP", tenSP);
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd.Parameters.AddWithValue("@DonGia", donGia);
                        cmd.Parameters.AddWithValue("@XuatXu", xuatXu);
                        cmd.Parameters.AddWithValue("@NgayHetHan", ngayHetHan);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Sản phẩm đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
            };

            buttonXoaSP.Click += (sender, e) => 
            {

            };
            buttonSearchMaxPrice.Click += (sender, e) =>
            {

            };
            buttonDeleteExpired.Click += (sender, e) =>
            {
                string query = "DELETE FROM products WHERE NgayHetHan < CURDATE()";

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} sản phẩm đã được xóa vì hết hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        dataGridViewProducts.Rows.Clear(); // Clear the previous rows

                        while (reader.Read())
                        {
                            dataGridViewProducts.Rows.Add(
                                reader["MaSP"].ToString(),
                                reader["TenSP"].ToString(),
                                reader["SoLuong"].ToString(),
                                reader["DonGia"].ToString(),
                                reader["XuatXu"].ToString(),
                                Convert.ToDateTime(reader["NgayHetHan"]).ToString("dd/MM/yyyy")
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            };
            buttonCheckExpired.Click += (sender, e) =>
            {
                string query = "SELECT MaSP, TenSP, SoLuong, DonGia, XuatXu, NgayHetHan FROM products WHERE NgayHetHan < CURDATE()";

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    dataGridViewProducts.Rows.Clear(); // Clear the previous rows

                    while (reader.Read())
                    {
                        dataGridViewProducts.Rows.Add(
                            reader["MaSP"].ToString(),
                            reader["TenSP"].ToString(),
                            reader["SoLuong"].ToString(),
                            reader["DonGia"].ToString(),
                            reader["XuatXu"].ToString(),
                            Convert.ToDateTime(reader["NgayHetHan"]).ToString("dd/MM/yyyy")
                        );
                    }
                }
            };
            buttonSearchOriginJapan.Click += (sender, e) =>
            {

            };
            buttonSearchAllExpired.Click += (sender, e) =>
            {

            };
            buttonDeleteByOrigin.Click += (sender, e) =>
            {
                string xuatXu = textBoxXuatXu.Text;

                if (string.IsNullOrWhiteSpace(xuatXu))
                {
                    MessageBox.Show("Vui lòng nhập Xuất xứ để xóa sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "DELETE FROM products WHERE XuatXu = @XuatXu";

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@XuatXu", xuatXu);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sản phẩm đã được xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            dataGridViewProducts.Rows.Clear(); // Clear the previous rows

                            while (reader.Read())
                            {
                                dataGridViewProducts.Rows.Add(
                                    reader["MaSP"].ToString(),
                                    reader["TenSP"].ToString(),
                                    reader["SoLuong"].ToString(),
                                    reader["DonGia"].ToString(),
                                    reader["XuatXu"].ToString(),
                                    Convert.ToDateTime(reader["NgayHetHan"]).ToString("dd/MM/yyyy")
                                );
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm nào với xuất xứ này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            };
        }

        private void TextBoxDonGia_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Stop the character from being entered
            }
        }

        private void TextBoxSoLuong_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Stop the character from being entered
            }
        }

        private void TextBoxMaSP_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Stop the character from being entered
            }
        }
        private bool ValidateTextBoxes(string textBoxMaSP,string textBoxTenSP, string textBoxSoLuong, string textBoxDonGia, string textBoxXuatXu)
        {
            // Check if any of the required TextBoxes are empty
            if (string.IsNullOrWhiteSpace(textBoxMaSP) ||
                string.IsNullOrWhiteSpace(textBoxTenSP) ||
                string.IsNullOrWhiteSpace(textBoxSoLuong) ||
                string.IsNullOrWhiteSpace(textBoxDonGia) ||
                string.IsNullOrWhiteSpace(textBoxXuatXu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin vào tất cả các trường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Validation failed
            }
            return true; // All fields are filled
        }
    }
}
