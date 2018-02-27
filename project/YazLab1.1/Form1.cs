using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab1._1

{
	public partial class Form1 : Form
	{
		/// <summary>
		/// bitmap ler e resimleri başlangıçta atıyoruz daha sonra otomatik kullanmak için 
		/// </summary>
		Bitmap bmp;
		Bitmap bmpOrginalRenkli;
		Bitmap bmpOrginalGri;
		Bitmap bmpIkinci;

		/// <summary>
		/// aşşağıdaki 3 dizi histogram için ayrıldı
		/// </summary>
		int[] RenkliR = new int[256];//kırmızı histogram grafiği için kullanılacak
		int[] RenkliG = new int[256];//yeşil histogram grafiği için kullanılacak
		int[] RenkliB = new int[256];//mavi histogram grafiği için kullanılacak
		int[] RenkliGREY = new int[256];//gri histogram grafiği için kullanılacak

		/// <summary>
		/// aşşağıdaki default değerler resimi boyutlandırmada kullanılıyor
		/// </summary>
		int defaultValueGen = 0, defaultValueYuk = 0;

		public Form1()
		{
			InitializeComponent();
			/**
			 * form ilk yüklendiğinde tüm vutton ve pictıreBox larım görünürlüklerini false yapıyoruz dosya seçilmediğ için
			 */
			trackBar1.Visible = false;
			trackBar2.Visible = false;
		    button2.Visible = false;
			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			button6.Visible = false;
			button8.Visible = false;
			button9.Visible = false;
			button10.Visible = false;
			button11.Visible = false;
			button12.Visible = false;
			button13.Visible = false;
			button14.Visible = false;
			button16.Visible = false;
			label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
			button15.Visible = false;
			pictureBox2.Visible = false;
            pictureBox8.Visible = false;

		}

		int kontrol = 0;
		/// <summary>
		/// Dosya seçme butonu ilk kontroller burada yapılıypr duruma göre pictureBox lar ve buttonlar true ediliyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Resim dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png";//alınabilecek resim çeşitleri burada belirleniyor
			openFileDialog1.ShowDialog();//resim almak için kullanılıyor

			if (openFileDialog1 != null)
			{
				//eğer bir resim seçildiyse buttonlar aktif ediliyor
				label1.Visible = false;
				button2.Visible = true;
				button3.Visible = true;
				button4.Visible = true;
				button5.Visible = true;
				button6.Visible = true;
				button8.Visible = true;
				button9.Visible = true;
				button10.Visible = true;
				button11.Visible = true;
				button12.Visible = true;
				button13.Visible = true;
				button14.Visible = true;
				button15.Visible = true;
				button16.Visible = true;
				pictureBox2.Visible = true;
				try
				{
					//burada eğer bir sıkıntı olmazsa ilk olarak tüm işlemler birkereliğine yaptırılıyor
					pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

					//picturebox1 e şeçtiğimiz değer atılıyor
					pictureBox2.Visible = true;
					pictureBox2.Image = pictureBox3.Image = bmpOrginalRenkli = bmpIkinci = bmp = new Bitmap(pictureBox1.Image, 500, 500);
					//pictureBox7.Image = bmp = new Bitmap(pictureBox1.Image, 500, 500);
					if (kontrol == 0)
					{
						//kaydetme butonu aktif ediliyor ve çıkış ve dosya açma butonlarının yeni yerleri(indexleri) veriliyor
						button1.Left -= 210;
						button7.Left -= 210;
						button15.Left -= 210;
						button16.Left -= 210;
						kontrol++;//btonların yerleri birkere değiştirileceği için bu kontrolü yapıyoruz
					}
				}
				catch (Exception)
				{
					//eğer bir hata yakalanırsa buttonların görünürlüğü kapatılıyor
					button2.Visible = false;
					button3.Visible = false;
					button4.Visible = false;
					button5.Visible = false;
					button6.Visible = false;
					button8.Visible = false;
					button9.Visible = false;
					button10.Visible = false;
					button11.Visible = false;
					button12.Visible = false;
					button13.Visible = false;
					button14.Visible = false;
					button15.Visible = false;
					button16.Visible = false;
					pictureBox2.Visible = false;
					label1.Size = new Size(100, 50);
					label1.Visible = true;
					label1.Text = "Lütfen bir Dosya Seçin";

				}
			}

			else
			{
				//eğer dosya seçilmezse dosya seçilmesi gerektiği uyarısı veriliyor
				label1.Size = new Size(100, 50);
				label1.Visible = true;
				label1.Text = "Lütfen bir Dosya Seçin";//Eğere seçim yapılmadıysa uyarı mesajı veriliyor
			}

			#region geçiçi not
			// Belirli bir noktadaki piksel degerleri
			//Console.WriteLine(bmp.GetPixel(150, 150));

			//Yeni bir Fprm Açılması İçin
			/*
			Form yeniForm = new Form();
			yeniForm.Width = 1000;
			yeniForm.Height = 600;
			yeniForm.ShowDialog();
			*/
			/*
			for(int i = 0; i < RenkliGREY.Length; i++)
			{
				Console.Write(RenkliGREY[i]+" ");
			}
			*/
			#endregion
		}

		/// <summary>
		/// Griye çevirme butonu 
		/// GriyeCevir Metoduna gönderiliyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			GriyeCevir();
		}

		/// <summary>
		/// negatifini alma butonu
		/// resminNegatifiniAl metoduna yönlendiriliyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			ResminNegatifiniAl();
		}

		/// <summary>
		/// orjinal resmi görüntüleme butonu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			orginaliGoster();
		}

		/// <summary>
		/// burada orjinal resim sadece bmpOrginal adlı bitmap te tutuluyor daha sonra istendiğinde orjinal resim buradan veriliyor
		/// </summary>
		public void orginaliGoster()
		{
			//orginal resim herzamanpicturebox 1 de tutuluyor
			bmpOrginalRenkli = new Bitmap(pictureBox1.Image, bmpOrginalRenkli.Width, bmpOrginalRenkli.Height);
			pictureBox2.Image = bmpOrginalRenkli;
			bmpIkinci = bmp;
			bmp = bmpOrginalRenkli;//orjinal resim bmp bitmap ine atanıyor
		}

		/// <summary>
		/// kullanıcı histogram bytonuna tıkladığında tüm historam değerleri ekrana basılıyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, EventArgs e)
		{
            ResminHistograminiCiz();//gri renginin resimin istogramı
			RHistogram();//kırmızı renginin resimin istogramı
			GHistogram();//yeşil renginin resimin istogramı
			BHistogram();//mavi renginin resimin istogramı
			//burada grafiklerin picture box ları aktifleştiriliyor
			label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

		}

		/// <summary>
		/// aynalama butonu
		/// aynala fonksiyonuna götürüyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button6_Click(object sender, EventArgs e)
		{
			Aynala();
		}

		/// <summary>
		/// ressin tersini almak için kullandığımız button TersiniAl metodu yardımıyla kullanırız
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button8_Click(object sender, EventArgs e)
		{
			TersiniAl();
		}

		/// <summary>
		/// resmin sol görüntüsü için kullandığımız button SolaCevir metoduna gider
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button10_Click(object sender, EventArgs e)
		{
			SolaCevir();
		}

		/// <summary>
		/// resmin sağ görüntüsü için kullandığımız button SagaCevir metoduna gider
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button9_Click(object sender, EventArgs e)
		{
			SagaCevir();
		}

		/// <summary>
		/// büyütme Butonu track leri görünür yapıyoruz
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button11_Click(object sender, EventArgs e)
		{
			/*
			 buradaki temel amaç resmin son halini bir picture box a atamak eğer bunu direk eşitleme ile yaparsak resim 
			 her büyütüldüğünde resimde son büyütülmüş hali ile kalacak tır bu yüzden pixel ile bir bitmape atarız sonrasında 
			 bu nu bir pictureboxa atarız böylecce resim herzaman sabit kalır
			 */
            pictureBox8.Visible = true;
            Bitmap bmpBuyutmeIcin=new Bitmap(pictureBox2.Image,bmpOrginalRenkli.Width,bmpOrginalRenkli.Height);//yeni bit bitmap oluşturuyoruz
			for (int i = 1; i < bmpOrginalRenkli.Width; i++)
			{
				for (int j = 1; j < bmpOrginalRenkli.Height; j++)
				{
					bmpBuyutmeIcin.SetPixel(i, j, bmp.GetPixel(i, j));
				}
			}
			
			pictureBox3.Image = bmpBuyutmeIcin;
			//büyütme track leri görünür yapılıyor
			trackBar1.Visible = true;
			trackBar2.Visible = true;
		}
		
		/// <summary>
		/// GriyeCevir metodunda asıl olay ilk olarak resmin ilgili pixeldeki tüm değerlerini almak ve 
		/// bu değerlerin ortalamasını almak ve bu değer, tekrar ilgili pizel değerine eşitlemek
		/// bunu yaparken ikinci bir yedek bitmap değişkeni kullanıyoruz
		/// </summary>
		/// <returns></returns>
		public void GriyeCevir()
		{
			Color OkunanRenk, DonusenRenk;
			int R = 0, G = 0, B = 0;
			//kullandığımız resimdeki pixel degerlerini almak için tanumladığımız değişkenler

			//resim genişliğive yüksekliği ni bitmaplerin pixel olarak eşitlenebilmesi için alınıyor
			int ResminGenisligi = bmp.Width;
			int ResminYuksekligi = bmp.Height;

			//yedek bitmap tanımlanıyor
			Bitmap CikisResmi = new Bitmap(ResminGenisligi, ResminYuksekligi);

			int i = 0, j = 0;

			for (int x = 0; x < ResminGenisligi; x++)
			{
				j = 0;
				for (int y = 0; y < ResminYuksekligi; y++)
				{
					OkunanRenk = bmp.GetPixel(x, y);
					//okunan renkler ilgili R,G,B değişkenlerimize atanıyor
					R = OkunanRenk.R;
					G = OkunanRenk.G;
					B = OkunanRenk.B;
					//üç rengin ortalaması ile gri renk bulunur
					int GriDegeri = Convert.ToInt16((R + G + B) / 3);

					//renk değeri tekrardan atanıyor
					DonusenRenk = Color.FromArgb(GriDegeri, GriDegeri, GriDegeri);
					//yeni bitmap e renk değeri(gri deger) atanıyor
					CikisResmi.SetPixel(i, j, DonusenRenk);
					j++;
				}
				i++;
			}
			pictureBox2.Image = CikisResmi;
			bmpIkinci = bmp;
			bmpOrginalGri = bmp = CikisResmi;

		}

		/// <summary>
		/// resmin negatifini alırken orjinal resmin ilgili pixel değerlerini 255 den çıkararak resmin negatif pixel
		/// değerlerini buluyoruz bu pixellere yeni değerleri tekrardan atıyoruz ardından resmimizi ekran basıyoruz
		/// </summary>
		/// <returns></returns>
		public void ResminNegatifiniAl()
		{
			Color OkunanRenk, DonusenRenk;
			int R = 0, G = 0, B = 0;

			int ResminGenisligi = bmp.Width;
			int ResminYuksekligi = bmp.Height;

			Bitmap CikisResmi = new Bitmap(ResminGenisligi, ResminYuksekligi);

			int i = 0, j = 0;

			for (int x = 0; x < ResminGenisligi; x++)
			{
				j = 0;
				for (int y = 0; y < ResminYuksekligi; y++)
				{
					OkunanRenk = bmp.GetPixel(x, y);
					R = 255 - OkunanRenk.R;
					G = 255 - OkunanRenk.G;
					B = 255 - OkunanRenk.B;
					DonusenRenk = Color.FromArgb(R, B, G);
					CikisResmi.SetPixel(i, j, DonusenRenk);
					j++;
				}
				i++;
			}
			pictureBox2.Image = CikisResmi;
			bmpIkinci = bmp;
			bmp = CikisResmi;
		}

		/*
		/*burada histogram alınıyor renkli ve gri resim için
		 * renkli resim için parametre olarak 1 gri resim içinse 2 veya herhangi
		 * bir tam sayı gönderiliyor
		 */
		 /*
		public void HistogramAl(int secim)
		{

			Color okunanRenk;
			int ResminGenisligi = 200;
			int ResminYuksekligi = 200;

			if (secim == 1)
			{
				for (int i = 0; i < ResminGenisligi; i++)
				{
					for (int j = 0; j < ResminYuksekligi; j++)
					{
						okunanRenk = bmpOrginalRenkli.GetPixel(i, j);
						RenkliR[okunanRenk.R]++;
						RenkliG[okunanRenk.G]++;
						RenkliB[okunanRenk.B]++;
					}

				}

			}
			else
			{
				for (int i = 0; i < ResminGenisligi; i++)
				{
					for (int j = 0; j < ResminYuksekligi; j++)
					{
						okunanRenk = bmpOrginalRenkli.GetPixel(i, j);
						RenkliGREY[okunanRenk.R]++;
					}

				}

			}

		}
		*/

		/// <summary>
		/// aynalamada ilk olarak yedek bir bitmap tanımlıyoruz  ve aynalamayı sağlayacak şekilde 
		/// ilk resmin pixsel adresini ikinci bitmapimizdeki adresi tam karşılığı olacak şekilde ekliyoruz
		/// daha sora asıl bmp bitmapimize tekrardan eşitliyoruz
		/// </summary>
		public void Aynala()
		{
			int resimGenisligi = bmp.Width;
			int resimYuksekligi = bmp.Height;
			Bitmap bmpyedek = new Bitmap(pictureBox1.Image, bmpOrginalRenkli.Width, bmpOrginalRenkli.Height);

			for (int i = 1; i < resimGenisligi; i++)
			{
				for (int j = 1; j < resimYuksekligi; j++)
				{
					bmpyedek.SetPixel(i, j, bmp.GetPixel((resimGenisligi - i), j));

				}
			}

			pictureBox2.Image = bmpyedek;
			bmpIkinci = bmp;
			bmp = bmpyedek;
		}

		/// <summary>
		/// tersini almada yeni bir bitmap ile kuladığımız bmp bitmapini ters düz edecek şekilde pixel yerlerini 
		/// değiştiriyoruz ve tekrardan asıl bmp bitmapimizi yedek bitmapimize eşitliyoruz
		/// </summary>
		public void TersiniAl()
		{
			int resimGenisligi = bmp.Width;
			int resimYuksekligi = bmp.Height;
			Bitmap bmpyedek = new Bitmap(pictureBox1.Image, bmpOrginalRenkli.Width, bmpOrginalRenkli.Height);//yeni bitmap oluşturuluyor

			for (int i = 1; i < resimGenisligi; i++)
			{
				for (int j = 1; j < resimYuksekligi; j++)
				{
					bmpyedek.SetPixel((resimGenisligi - (i % resimGenisligi)), resimYuksekligi - j, bmp.GetPixel(i, j));//yeni bitmape gerekli değerleri atanıyor

				}
			}

			pictureBox2.Image = bmpyedek;//yeni bitmap picturebox ımıza atanıyor
			bmpIkinci = bmp;
			bmp = bmpyedek;//yeni bitmap ama bitmap(bmp)ye atanıyor
		}
		/// <summary>
		/// burada resmi sola çevirme işlemleri yapılıyor yedek bir bitmap ile 
		/// ilgili değerlere göre yeni bitmape değerler yeniden atanıyor
		/// ve en sonunda picturebox ımıza eşitleniyor
		/// </summary>
		public void SolaCevir()
		{
			int resimGenisligi = bmp.Width;
			int resimYuksekligi = bmp.Height;
			Bitmap bmpyedek = new Bitmap(pictureBox1.Image, bmpOrginalRenkli.Width, bmpOrginalRenkli.Height);//yeni bitmap oluşturuluyor

			for (int i = 1; i < resimGenisligi; i++)
			{
				for (int j = 1; j < resimYuksekligi; j++)
				{
					bmpyedek.SetPixel(j, (resimYuksekligi - i), bmp.GetPixel(i, j));//pixel değerleri burada atanıyor

				}
			}

			pictureBox2.Image = bmpyedek;//yeniden oluşturulan resim picturebox ımıza atanıyor
			bmpIkinci = bmp;
			bmp = bmpyedek;//aynı zamanda orjinal bitmapimizede atanıyor
		}

		/// <summary>
		/// burada resmi sağa çevirme işlemleri yapılıyor yedek bir bitmap ile 
		/// ilgili değerlere göre yeni bitmape değerler yeniden atanıyor
		/// ve en sonunda picturebox ımıza eşitleniyor
		/// </summary>
		public void SagaCevir()
		{
			int resimGenisligi = bmp.Width;
			int resimYuksekligi = bmp.Height;
			Bitmap bmpyedek = new Bitmap(pictureBox1.Image, bmpOrginalRenkli.Width, bmpOrginalRenkli.Height);//yeni bitmap oluşturuluyor

			for (int i = 1; i < resimGenisligi; i++)
			{
				for (int j = 1; j < resimYuksekligi; j++)
				{
					bmpyedek.SetPixel((resimGenisligi - j), i, bmp.GetPixel(i, j));//pixel değerleri burada atanıyor
				}
			}

			pictureBox2.Image = bmpyedek;//yeniden oluşturulan resim picturebox ımıza atanıyor
			bmpIkinci = bmp;
			bmp = bmpyedek;//aynı zamanda orjinal bitmapimizede atanıyor
		}

		/// <summary>
		/// yakınlaştırma olayları bu fonksiyon içerisinde yapılıyor
		/// </summary>
		/// <param name="value"></param>
		/// <param name="secim"></param>
		public void Yakinlastirma(int value, int secim)
		{
			//öncelikle ana resmin boyutları alınıyor
			int resimGenisligi = bmpOrginalRenkli.Width;
			int resimYuksekligi = bmpOrginalRenkli.Height;
			if (secim == 1)
			{
				
				resimGenisligi = Convert.ToInt32(resimGenisligi + 50 * value);
				resimYuksekligi = Convert.ToInt32(resimYuksekligi + 50 * defaultValueYuk);//resmin daha önce seçilen yükseklik değeri burada tekrardan kontrol ediliyor ve o değere göre tekrardan yükeklik genişliği veriliyır
				//pictureBox3.Size = new Size(resimGenisligi, resimYuksekligi);
				Bitmap bmpyedek = new Bitmap(pictureBox3.Image, resimGenisligi, resimYuksekligi);
				
				for (int i = 1; i < resimGenisligi - 1; i++)
				{
					if (i < (value * 25) + 1 || i > (resimGenisligi - value * 25 - 1))
						continue;
					for (int j = 1; j < resimYuksekligi; j++) {

						if (j < (defaultValueYuk * 25) + 1 || j > (resimYuksekligi - defaultValueYuk * 25 - 1))
							continue;
						bmp.SetPixel((i - value * 25), (j - defaultValueYuk * 25), bmpyedek.GetPixel(i, j));//yeniden pixel ataması yapılıyor
					}
				}
				pictureBox2.Image = bmp;
				defaultValueGen = value;
				//pictureBox2.Image = bmpyedek;
			}

			else
			{
				resimYuksekligi = Convert.ToInt32(resimYuksekligi + 50 * value);//gelen value (trackbar2 gelen değer)e göre yükseklik değeri veriliyor
				resimGenisligi = Convert.ToInt32(resimGenisligi + 50 * defaultValueGen);//resmin daha önce seçilen genişleme değeri burada tekrardan kontrol ediliyor ve o değere göre tekrardan genişliği veriliyor
				//pictureBox3.Size = new Size(resimGenisligi, resimYuksekligi);
				Bitmap bmpyedek = new Bitmap(pictureBox3.Image, resimGenisligi, resimYuksekligi);

				

				for (int i = 1; i < resimGenisligi - 1; i++)
				{
					if (i < (defaultValueGen * 25) + 1 || i > (resimGenisligi - defaultValueGen * 25 - 1))//yeniden pixel ataması yapılıyor
						continue;
					for (int j = 1; j < resimYuksekligi; j++)
					{
						if (j < (value * 25) + 1 || j > (resimYuksekligi - value * 25 - 1))
							continue;
						bmp.SetPixel((i - defaultValueGen * 25), (j - value * 25), bmpyedek.GetPixel(i, j));//yeniden pixel ataması yapılıyor
					}
				}
				pictureBox2.Image = bmp;
				defaultValueYuk = value;
			}
			
		}

		/*
		public void Yakinlastirma(int value, int secim)
		{
			int resimGenisligi = bmp.Width;
			int resimYuksekligi = bmp.Height;
			pictureBox3.Image = bmp;
			if (secim == 1)
			{
				//resimGenisligi = pictureBox2.Width;
				resimGenisligi = Convert.ToInt32(resimGenisligi + resimGenisligi * 0.1 * value);
				Bitmap bmpYedek = new Bitmap(pictureBox3.Image, resimGenisligi, resimYuksekligi);
				pictureBox2.Size = new Size(resimGenisligi, resimYuksekligi);
				pictureBox2.Visible = true;
				pictureBox2.Image = bmpYedek;
				bmp = new Bitmap(pictureBox2.Image, resimGenisligi, resimYuksekligi);
				defaultValueGen = value;
			}
			else
			{
				resimYuksekligi = pictureBox2.Height;
				resimYuksekligi = Convert.ToInt32(resimYuksekligi + resimYuksekligi * 0.1 * value);
				Bitmap bmpYedek = new Bitmap(pictureBox3.Image, resimGenisligi, resimYuksekligi);
				pictureBox2.Size = new Size(resimGenisligi, resimYuksekligi);
				pictureBox2.Visible = true;
				pictureBox2.Image = bmpYedek;
				bmp = new Bitmap(pictureBox2.Image, resimGenisligi, resimYuksekligi);
				defaultValueYuk = value;
			}

		}
		*/

		/// <summary>
		/// horizontal trackbar dan gelene değer burada tutulup yakınlaştırma fonksiyonumuza gönderiliyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			Yakinlastirma(trackBar1.Value, 1);
		}

		/// <summary>
		/// verticle trackbar dan gelene değer burada tutulup yakınlaştırma fonksiyonumuza gönderiliyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			Yakinlastirma(trackBar2.Value, 2);
		}

		/// <summary>
		/// resmin kırmızı retinalı hali için kullandığımız Kırmızı butonu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button12_Click(object sender, EventArgs e)
		{
			RenkKanali(1);
		}

		/// <summary>
		/// resmin mavi retinalı hali için kullandığımız Kırmızı butonu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button13_Click(object sender, EventArgs e)
		{
			RenkKanali(2);
		}

		/// <summary>
		/// resmin Yeşil retinalı hali için kullandığımız Kırmızı butonu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button14_Click(object sender, EventArgs e)
		{
			RenkKanali(3);
		}


		/// <summary>
		/// burada resmin blue, red ve green filtreli halleri ekrana basılıyor
		/// </summary>
		/// <param name="secim"></param>
		public void RenkKanali(int secim)
		{
			bmpIkinci = new Bitmap(pictureBox2.Image, bmp.Width, bmp.Height);
			Bitmap bmpyedek = bmp;
			Color renk;
			if (secim == 1)//eğer seçim kırmızı filtre butonundan geldiyse kırmızı renk kanalı alınıyor
			{
				for (int i = 0; i < bmp.Width; i++)
				{
					for (int j = 0; j < bmp.Height; j++)
					{
						renk = bmpyedek.GetPixel(i, j);
						renk = Color.FromArgb(renk.R, 0, 0);//kırmızı renk seçiliyor
						bmpyedek.SetPixel(i, j, renk);//çıkan kırmızı renk değeri atanıyor

					}
				}
			}
			else if (secim == 2)//eğer seçim mavi filtre butonundan geldiyse kırmızı renk kanalı alınıyor
			{
				for (int i = 0; i < bmp.Width; i++)
				{
					for (int j = 0; j < bmp.Height; j++)
					{
						renk = bmpyedek.GetPixel(i, j);
						renk = Color.FromArgb(0, 0, renk.B);//mavi renk seçiliyor
						bmpyedek.SetPixel(i, j, renk);//çıkan mavi renk değeri atanıyor

					}
				}
			}
			else//eğer seçim yeşil filtre butonundan geldiyse kırmızı renk kanalı alınıyor
			{
				for (int i = 0; i < bmp.Width; i++)
				{
					for (int j = 0; j < bmp.Height; j++)
					{
						renk = bmpyedek.GetPixel(i, j);
						renk = Color.FromArgb(0, renk.G, 0);//yeşil renk seçiliyor
						bmpyedek.SetPixel(i, j, renk);//çıkan yeşil renk değeri atanıyor

					}
				}
			}
			pictureBox2.Image = bmpyedek;//reim ana ressmimize ekleniyor
			bmp = bmpyedek;
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

		/// <summary>
		/// projeden çıkış yapılıyor bu fonksiyondan
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

		/// <summary>
		/// dosya kaydetirme fonksiyonu burada resim kaydetme işlemleri yaptırılıyor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button15_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();//resim kaydetme dialoğu oluşturuluyor
			sfd.Filter = "Resim dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png";//kaydedilebilen resim formatları
			sfd.Title = "Kayit";
			sfd.FileName = "Pictures";//resmi kaydederken genel olarak kullanılan başlık atanıyor
			DialogResult sonuc = sfd.ShowDialog();//resim kaydediliyor
			if (sonuc == DialogResult.OK)//resmin kaydedilip kaydedilmediği kontrol ediliyor
			{
				bmp.Save(sfd.FileName);

			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// gri resmin histogramını buradaki fonksiyondan çizdiriyoruz
		/// </summary>
		public void ResminHistograminiCiz()
        {
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi; //Histogram için giriş resmi gri-ton olmalıdır.
            GirisResmi = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            int i = 0; //piksel sayısı tutulacak.
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3;
                    //Griton resimde üç kanal    rengi aynı değere sahiptir.
                    DiziPiksel.Add(OrtalamaRenk);
                    //Resimdeki tüm noktaları diziye atıyor.
                }
            }
            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r < 255; r++) //256 tane renk tonu için dönecek.
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++) //resimdeki piksel sayısınca dönecek.
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }
            int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak.
            for (int k = 0; k <= 255; k++)
            {
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }

            //Grafiği çiziyor.
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Gray, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            pictureBox4.Refresh();
            CizimAlani = pictureBox4.CreateGraphics();
            pictureBox4.Refresh();

            int GrafikYuksekligi = 150;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi, OlcekX = 1.6;
            for (int x = 0; x <= 255; x++)
            {
                CizimAlani.DrawLine(Kalem1, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX),
               (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                if (x % 50 == 0)
                    CizimAlani.DrawLine(Kalem2, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX), 0);
            }
            
        }

		/// <summary>
		/// kırmızı rengin histogramını çizmek için aşşağıdaki fonksiyon kullanılıyor
		/// </summary>
		public void RHistogram()
		{
			Bitmap GirisResmi; //Histogram için giriş resmi gri-ton olmalıdır.
			GirisResmi = new Bitmap(pictureBox2.Image);
			int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
			int ResimYuksekligi = GirisResmi.Height;
			int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak.
			Color okunanRenk;
			int ResminGenisligi = 200;
			int ResminYuksekligi = 200;
			
			for (int i = 0; i < ResminGenisligi; i++)
			{
				for (int j = 0; j < ResminYuksekligi; j++)
				{
					okunanRenk = bmpOrginalRenkli.GetPixel(i, j);
					RenkliR[okunanRenk.R]++;
					RenkliG[okunanRenk.G]++;
					RenkliB[okunanRenk.B]++;
				}
			}
			for (int k = 0; k <= 255; k++)
			{
				if (RenkliR[k] > RenkMaksPikselSayisi)
				{
					RenkMaksPikselSayisi = RenkliR[k];
				}
			}
			//Grafiği çiziyor.
			Graphics CizimAlani;
			Pen Kalem1 = new Pen(System.Drawing.Color.Red, 1);
			Pen Kalem2 = new Pen(System.Drawing.Color.White, 1);
			pictureBox5.Refresh();
            CizimAlani = pictureBox5.CreateGraphics();
            pictureBox5.Refresh();

            int GrafikYuksekligi = 150;
			double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi, OlcekX = 1.6;
			for (int x = 0; x <= 255; x++)
			{
				CizimAlani.DrawLine(Kalem1, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX),
			   (GrafikYuksekligi - (int)(RenkliR[x] / OlcekY)));
				if (x % 50 == 0)
					CizimAlani.DrawLine(Kalem2, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX), 0);
			}


		}

		/// <summary>
		/// gri rengin histogramını çizmek için bu fonksiyonu kulllanıyoruz
		/// </summary>
		public void GHistogram()
		{
			Bitmap GirisResmi; //Histogram için giriş resmi gri-ton olmalıdır.
			GirisResmi = new Bitmap(pictureBox2.Image);
			int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
			int ResimYuksekligi = GirisResmi.Height;
			int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak.
			Color okunanRenk;
			int ResminGenisligi = 200;
			int ResminYuksekligi = 200;


			for (int i = 0; i < ResminGenisligi; i++)
			{
				for (int j = 0; j < ResminYuksekligi; j++)
				{
					okunanRenk = bmpOrginalRenkli.GetPixel(i, j);
					RenkliR[okunanRenk.R]++;
					RenkliG[okunanRenk.G]++;
					RenkliB[okunanRenk.B]++;
				}



			}
			for (int k = 0; k <= 255; k++)
			{
				if (RenkliG[k] > RenkMaksPikselSayisi)
				{
					RenkMaksPikselSayisi = RenkliG[k];
				}
			}
			//Grafiği çiziyor.
			Graphics CizimAlani;
			Pen Kalem1 = new Pen(System.Drawing.Color.Green, 1);
			Pen Kalem2 = new Pen(System.Drawing.Color.White, 1);
			pictureBox6.Refresh();
            CizimAlani = pictureBox6.CreateGraphics();
            pictureBox6.Refresh();

            int GrafikYuksekligi = 150;
			double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi, OlcekX = 1.6;
			for (int x = 0; x <= 255; x++)
			{
				CizimAlani.DrawLine(Kalem1, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX),
			   (GrafikYuksekligi - (int)(RenkliG[x] / OlcekY)));
				if (x % 50 == 0)
					CizimAlani.DrawLine(Kalem2, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX), 0);
			}


		}

		private void button16_Click(object sender, EventArgs e)
		{
			pictureBox2.Image = bmpIkinci;
			bmp = bmpIkinci;
		}

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// mavi rengin hisstogramını çizdirmek için bu fonksiyonu kullanıyoruz
        /// </summary>
        public void BHistogram()
		{
			Bitmap GirisResmi; //Histogram için giriş resmi gri-ton olmalıdır.
			GirisResmi = new Bitmap(pictureBox2.Image);
			int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
			int ResimYuksekligi = GirisResmi.Height;
			int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak.
			Color okunanRenk;
			int ResminGenisligi = 200;
			int ResminYuksekligi = 200;


			for (int i = 0; i < ResminGenisligi; i++)
			{
				for (int j = 0; j < ResminYuksekligi; j++)
				{
					okunanRenk = bmpOrginalRenkli.GetPixel(i, j);
					RenkliR[okunanRenk.R]++;
					RenkliG[okunanRenk.G]++;
					RenkliB[okunanRenk.B]++;
				}



			}
			for (int k = 0; k <= 255; k++)
			{
				if (RenkliB[k] > RenkMaksPikselSayisi)
				{
					RenkMaksPikselSayisi = RenkliB[k];
				}
			}
			//Grafiği çiziyor.
			Graphics CizimAlani;
			Pen Kalem1 = new Pen(System.Drawing.Color.Blue, 1);
			Pen Kalem2 = new Pen(System.Drawing.Color.White, 1);
			pictureBox7.Refresh();
            CizimAlani = pictureBox7.CreateGraphics();
            pictureBox7.Refresh();


            int GrafikYuksekligi = 150;
			double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi, OlcekX = 1.6;
			for (int x = 0; x <= 255; x++)
			{
				CizimAlani.DrawLine(Kalem1, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX),
			   (GrafikYuksekligi - (int)(RenkliB[x] / OlcekY)));
				if (x % 50 == 0)
					CizimAlani.DrawLine(Kalem2, (int)(20 + x * OlcekX), GrafikYuksekligi, (int)(20 + x * OlcekX), 0);
			}


		}

		
	}

}