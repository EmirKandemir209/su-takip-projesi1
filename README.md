# su takip proje
1.Proje Tanımı:

Bu proje, kullanıcıların günlük su tüketimini takip etmelerini sağlayan bir uygulamadır. Kullanıcılar gün içerisinde içtikleri su miktarını sisteme girerek toplam tüketimlerini görebilir ve günlük hedeflerine ulaşıp ulaşmadıklarını takip edebilirler.

2.Problem Tanımı:

Günlük hayatta birçok insan yeterli miktarda su tüketmemektedir. Bunun en önemli sebeplerinden biri su içme alışkanlığının takip edilmemesidir. Bu proje, kullanıcıların su tüketimini düzenli hale getirmeyi amaçlamaktadır.
	
3.Gereksinimler:

3.1 Fonksiyonel Gereksinimler:

Kullanıcı sisteme su tüketimi ekleyebilmelidir.
Günlük toplam içilen su miktarı görüntülenebilmelidir.
Kullanıcı günlük su hedefi belirleyebilmelidir.
Sistem, hedefe ulaşılıp ulaşılmadığını göstermelidir.

3.2 
Fonksiyonel Olmayan Gereksinimler:
Sistem kullanıcı dostu bir arayüze sahip olmalıdır.
Uygulama hızlı çalışmalıdır.
Veriler güvenli bir şekilde saklanmalıdır.


Kullanıcılar Tablosu
•	id 
•	kullanıcı_adı 
Su_Kayitlari Tablosu
•	id 
•	kullanıcı_id 
•	miktar (ml) 
•	tarih

 
Bu projede iki adet tablo kullanılmaktadır:

Kullanıcılar Tablosu:

Alan Adı	Veri Tipi	Açıklama
id	int	Kullanıcı ID
kullanici_adi	varchar	Kullanıcı adı


Su_Kayitlari Tablosu:

Alan Adı	Veri Tipi	Açıklama
id	İnt                 	Kayıt ID
kullanici_id	int	Kullanıcı ID (Foreign Key)
miktar	int	İçilen su (ml)
tarih	date	Kayıt tarihi

Tablo Açıklaması:

Bu veritabanı tasarımında iki adet tablo bulunmaktadır: Kullanıcılar ve Su_Kayitlari tabloları.
Kullanıcılar tablosu, sistemde yer alan kullanıcıların temel bilgilerini saklamak amacıyla oluşturulmuştur. Bu tabloda her kullanıcıya ait benzersiz bir id değeri ve kullanıcı adı bilgisi tutulmaktadır.
Su_Kayitlari tablosu ise kullanıcıların günlük su tüketimlerini kaydetmek için kullanılmaktadır. Bu tabloda her kayıt için benzersiz bir id değeri bulunur. kullanici_id alanı, ilgili su kaydının hangi kullanıcıya ait olduğunu belirtir ve Kullanıcılar tablosundaki id alanına bağlıdır (Foreign Key). miktar alanı içilen su miktarını mililitre (ml) cinsinden saklarken, tarih alanı ise kaydın hangi gün oluşturulduğunu göstermektedir.
Bu iki tablo arasında bire-çok (1-N) ilişkisi bulunmaktadır. Bir kullanıcı birden fazla su kaydı ekleyebilir, ancak her su kaydı yalnızca bir kullanıcıya aittir.


<img width="605" height="407" alt="image" src="https://github.com/user-attachments/assets/ea71f83f-2ae6-427b-8190-68ef1b335afa" />


Butonların Görevleri ve Açıklamaları:
Bu bölümde uygulamada bulunan butonların görevleri açıklanmaktadır.

Su Ekle Butonu:

Kullanıcının TextBox alanına girdiği su miktarını (ml cinsinden) listeye ekler.
Bu sayede kullanıcı gün içinde içtiği suyu kaydedebilir.

Toplam Butonu:

Listede bulunan tüm su miktarlarını toplayarak kullanıcıya toplam içilen su miktarını gösterir.
Günlük tüketim takibi için kullanılır.

Sil Butonu:

Listeden seçilen su kaydını siler.
Kullanıcı yanlış girdiği bir değeri bu buton ile kaldırabilir.

Temizle Butonu:

Listede bulunan tüm su kayıtlarını siler.
Yeni bir güne başlamak veya listeyi sıfırlamak için kullanılır.

Hedef Butonu:

Kullanıcının günlük su hedefi olan (örneğin 2000 ml) değere ulaşıp ulaşmadığını kontrol eder.
Eğer hedefe ulaşılmışsa kullanıcıya bilgilendirme mesajı gösterilir.

