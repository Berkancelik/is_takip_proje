using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using is_takip_proje.Entity;
namespace is_takip_proje.Formlar
{
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        DbisTakipEntities db = new DbisTakipEntities();
        private void BtnVazgec_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblGorevler t = new TblGorevler();
            t.Aciklama = TxtAciklama.Text;
            t.GorevAlan = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Durum = true;
            t.Tarih = DateTime.Parse(TxtTarih.Text);
            t.GorevVeren = int.Parse(TxtGorevVeren.Text);
            db.TblGorevlers.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Görev Başarılı bir şekilde tanımlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblPersonels
                                select new
                                {
                                    x.ID,
                                    AdSoyad = x.Ad + " " + x.Soyad
                                }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AdSoyad";
            lookUpEdit1.Properties.DataSource = degerler;
        }
    }
}
