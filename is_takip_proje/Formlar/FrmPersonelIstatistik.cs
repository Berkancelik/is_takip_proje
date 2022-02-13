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
    public partial class FrmPersonelIstatistik : Form
    {
        public FrmPersonelIstatistik()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmPersonelIstatistik_Load(object sender, EventArgs e)
        {
            LblToplamDepartman.Text = db.TblDepartmanlars.Count().ToString();
            LblToplamFirma.Text = db.TblFirmalars.Count().ToString();
            LblToplamPersonel.Text = db.TblPersonels.Count().ToString();
            LblAktifIs.Text = db.TblGorevlers.Count(x => x.Durum == true).ToString();
            LblPasifIs.Text = db.TblGorevlers.Count(x => x.Durum == false).ToString();
            LblSonGorev.Text = db.TblGorevlers.OrderByDescending(x =>x.ID).Select(x => x.Aciklama).FirstOrDefault();
            LblSonGorevTarihi.Text = db.TblGorevlers.OrderByDescending(x => x.ID).Select(x => x.Tarih).FirstOrDefault().ToString();

            LblSehir.Text = db.TblFirmalars.Select(x => x.il).Distinct().Count().ToString();
            LblSektor.Text = db.TblFirmalars.Select(x => x.Sektor).Distinct().Count().ToString();
            DateTime bugun = DateTime.Today;
            
            LblBugunAcilanGorevler.Text = db.TblGorevlers.Count(x => x.Tarih == bugun).ToString();
            
            


            var d1 = db.TblGorevlers.GroupBy(x => x.GorevAlan).OrderByDescending(z => z.Count()).
                Select(y => y.Key).FirstOrDefault();
            LblAyinPersoneli2.Text = db.TblPersonels.Where(x => x.ID == d1).Select(y => y.Ad + " " + y.Soyad).FirstOrDefault().ToString();
            LblAyinDepartmani.Text = db.TblDepartmanlars.Where(x => x.ID == db.TblPersonels.Where(t => t.ID == d1).Select(z => z.Departman).
            FirstOrDefault()).Select(y => y.Ad).FirstOrDefault().ToString();


        }
        private void LblToplamPersonel_Click(object sender, EventArgs e)
        {

        }

      
    }
}
