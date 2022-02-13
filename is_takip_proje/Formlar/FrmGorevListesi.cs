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
    public partial class FrmGorevListesi : Form
    {
        public FrmGorevListesi()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            gridControl2.DataSource = (from x in db.TblGorevlers
                                       select new
                                       {                                          
                                           x.Aciklama
                                       }).ToList();


            LblAktigGorev.Text = db.TblGorevlers.Where(x => x.Durum == true).Count().ToString();
            LblPasifGorev.Text = db.TblGorevlers.Where(x => x.Durum == false).Count().ToString();
            LblToplamDepartman2.Text = db.TblDepartmanlars.Count().ToString();


            chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler", int.Parse(LblAktigGorev.Text));
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler", int.Parse(LblPasifGorev.Text));





        }
    }
}
