using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;
namespace is_takip_proje.Formlar
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevlers
                                       select new
                                       {
                                           x.Aciklama,
                                           Personel = x.TblPersonel.Ad + " " + x.TblPersonel.Soyad,
                                           x.Durum
                                       }).Where(y=>y.Durum == true).ToList();
            gridView1.Columns["Durum"].Visible = false;

            // Bugün Yapılan Görevler
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            //MessageBox.Show(bugun.ToString());
            gridControl2.DataSource = (from x in db.TblGorevDetaylars
                                       select new
                                       {
                                          Gorev =  x.TblGorevler.Aciklama,
                                          x.Aciklama,
                                          x.Tarih

                                       }).Where(x=>x.Tarih == bugun).ToList();

            //Aktif Çağrı listesi 

            gridControl3.DataSource = (from x in db.TblCagrilars
                                       select new
                                       {
                                           x.TblFirmalar.Ad,
                                           x.Konu,
                                           x.Tarih,
                                           x.Durum
                                       }).Where(x => x.Durum == true).ToList();
            gridView3.Columns["Durum"].Visible = false;

        }
    }
}
