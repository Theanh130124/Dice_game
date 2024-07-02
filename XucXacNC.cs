using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4_XucXacNC
{
    public partial class XucXacNC : Form
    {
        String path;
        int Choose;
        int nWin, nLose, nCount;
        public XucXacNC()
        {
            InitializeComponent();
        }

        private void XucXacNC_Load(object sender, EventArgs e)
        {
            path = Application.StartupPath + @"\HinhXucSac\";
            Init();
        }

        private void btnResert_Click(object sender, EventArgs e)
        {
            Init();
       
        }

        private void btnQuaySo_Click_1(object sender, EventArgs e)
        {
            Play(); // viết riêng ra như thế để cài thêm các thao tác phím cho form.
        }
        private void Play()
        {
            Random rd = new Random();
            String kq;
            int res = rd.Next(1, 7);
            pictureBox2.Image = Image.FromFile(path + "XucSac" + res.ToString() + ".png");
            nCount++;
            if (res == Choose)
            {
                nWin++;
                kq = " Thắng";
            }
            else
            {
                kq = "Thua";
                nLose++;
            }
            lb1.Text = "Số lượt đã chơi là " + nCount.ToString();
            lb2.Text = String.Format("Số lần thắng là {0} ,Tỉ lệ  {1}%", nWin, (nWin * 100) / nCount);
            lb3.Text = String.Format("Số lần thua là {0} , Tỉ lệ {1}%", nLose, (nLose * 100) / nCount);
            lbresult.Items.Add(String.Format("{0}.{1}(Đoán{2} ra {3})", nCount, kq, Choose, res));                        //lIST box . iteam . adđ

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo1.Text.Substring(1) + txtSo1.Text.Substring(0, 1);                            // subtring(0,2) -> chỉ lấy 0 1 giống ramdom . subtring(1) -> lấy từ 1 đến hết // 
        }

        private void btn2_Click(object sender, EventArgs e)                                                    // Click nhiều button thì thằng nào đc click cuối gọi tên nó
        {
            Button but = (Button)sender;
            Choose = int.Parse(but.Text);                                                                    // Text là số mấy thì nó sẽ parse qua số đó
            pictureBox1.Image = Image.FromFile(path + "XucSac" + Choose.ToString() + ".png");

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rel = MessageBox.Show("Bạn muốn thoát chương trình không?", " Thông báo", MessageBoxButtons.YesNo);
            if(rel == DialogResult.Yes)
            {
                Close();
            }    
        }

        private void Init()                                                                                // khi gọi thì nó sẽ khởi tạo lại hết
        { 
            lbresult.Items.Clear();                                                                          // Xóa hết khung result của listBox
            lb1.Text = lb3.Text = lb2.Text = "";                                                     // Cho nó thành trống
            Choose = 1;                                                                                     // về 1 để nó đúng với xúc xắc 1
            pictureBox1.Image = Image.FromFile(path + "XucSac1.png");                                        //ListBox mới có . Iteam để xóa
            nCount=nWin= nLose=0;
            pictureBox2.Image = null;
        }
        protected override bool ProcessDialogKey(Keys keyData)                                            
        {
            //Nó trả về phím cài thêm thêm switch để sử dụng hàm . 
            switch(keyData)
            {
                case Keys.Space:
                    Play();
                    break;
                case Keys.Escape:
                    Init();
                    break;
            }    
            return base.ProcessDialogKey(keyData);
        }
        



    }
}
