-- =====================================================================
-- Beauty Center Automation - database schema (Microsoft SQL Server)
-- Tables only, no data.
--
-- How to use:
--   1. In SQL Server Management Studio, create an empty database
--      (for example: CREATE DATABASE BeautyCenterDB;)
--   2. Select that database and run this script.
-- =====================================================================

CREATE TABLE tbl_HizmetTurleri (
    TurID INT PRIMARY KEY IDENTITY(1,1),
    TurAdi NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE tbl_Calisanlar (
    CalisanID INT PRIMARY KEY IDENTITY(1,1),
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL,
    Telefon NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    KullaniciAdi NVARCHAR(50) UNIQUE NOT NULL,
    Sifre NVARCHAR(100) NOT NULL,
    KullaniciTuru NVARCHAR(50) CHECK (KullaniciTuru IN (N'Yönetici', N'Personel'))
);

CREATE TABLE tbl_Musteriler (
    MusteriID INT PRIMARY KEY IDENTITY(1,1),
    Ad NVARCHAR(50) NOT NULL,
    Soyad NVARCHAR(50) NOT NULL,
    Telefon NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    DogumTarihi DATE NULL
);

CREATE TABLE tbl_CalisanUzmanlikAlanlari (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CalisanID INT FOREIGN KEY REFERENCES tbl_Calisanlar(CalisanID),
    TurID INT FOREIGN KEY REFERENCES tbl_HizmetTurleri(TurID),
    CONSTRAINT UK_CalisanUzmanlik UNIQUE (CalisanID, TurID)
);

CREATE TABLE tbl_Hizmetler (
    HizmetID INT PRIMARY KEY IDENTITY(1,1),
    HizmetAdi NVARCHAR(100) NOT NULL,
    TurID INT FOREIGN KEY REFERENCES tbl_HizmetTurleri(TurID),
    Fiyat DECIMAL(10,2) NOT NULL,
    Sure INT NOT NULL CHECK (Sure > 0),          -- duration in minutes
    ToplamSeans INT NOT NULL CHECK (ToplamSeans > 0)
);

CREATE TABLE tbl_Randevular (
    RandevuID INT PRIMARY KEY IDENTITY(1,1),
    MusteriID INT FOREIGN KEY REFERENCES tbl_Musteriler(MusteriID),
    CalisanID INT FOREIGN KEY REFERENCES tbl_Calisanlar(CalisanID),
    HizmetID INT FOREIGN KEY REFERENCES tbl_Hizmetler(HizmetID),
    RandevuTarihi DATETIME NOT NULL,
    RandevuSaati NVARCHAR(10) NOT NULL,
    ToplamSeans INT NOT NULL CHECK (ToplamSeans > 0),
    KalanSeans INT NOT NULL CHECK (KalanSeans >= 0),
    HatirlatmaGonderildi BIT DEFAULT 0,
    Durum NVARCHAR(50) CHECK (Durum IN (N'Bekliyor', N'Tamamlandı', N'İptal Edildi'))
);

CREATE TABLE tbl_Urunler (
    UrunID INT PRIMARY KEY IDENTITY(1,1),
    UrunAdi NVARCHAR(100) NOT NULL UNIQUE,
    StokMiktari INT NOT NULL CHECK (StokMiktari >= 0),
    BirimFiyat DECIMAL(10,2) NOT NULL
);

CREATE TABLE tbl_HizmetUrunleri (
    ID INT PRIMARY KEY IDENTITY(1,1),
    HizmetID INT FOREIGN KEY REFERENCES tbl_Hizmetler(HizmetID),
    UrunID INT FOREIGN KEY REFERENCES tbl_Urunler(UrunID),
    KullanilanMiktar INT NOT NULL CHECK (KullanilanMiktar >= 0),
    RandevuBasinaOran INT NULL                    -- how many sessions one unit of the product lasts
);

CREATE TABLE tbl_StokHareketleri (
    HareketID INT PRIMARY KEY IDENTITY(1,1),
    UrunID INT FOREIGN KEY REFERENCES tbl_Urunler(UrunID),
    HareketTuru NVARCHAR(50) CHECK (HareketTuru IN (N'Giriş', N'Satış', N'Seans')) NOT NULL,
    Miktar INT NOT NULL,
    HareketTarihi DATETIME DEFAULT GETDATE(),
    Aciklama NVARCHAR(255) NULL
);

CREATE TABLE tbl_Odemeler (
    OdemeID INT PRIMARY KEY IDENTITY(1,1),
    MusteriID INT FOREIGN KEY REFERENCES tbl_Musteriler(MusteriID),
    CalisanID INT NULL FOREIGN KEY REFERENCES tbl_Calisanlar(CalisanID),
    RandevuID INT NULL FOREIGN KEY REFERENCES tbl_Randevular(RandevuID),
    ToplamTutar DECIMAL(10,2) NOT NULL,
    OdemeTuru NVARCHAR(50) CHECK (OdemeTuru IN (N'Peşin', N'Taksit')),
    OdemeKaynagi NVARCHAR(50) CHECK (OdemeKaynagi IN (N'Hizmet', N'Satış', N'Karma')),
    OdemeTarihi DATETIME DEFAULT GETDATE(),
    Aciklama NVARCHAR(255) NULL
);

CREATE TABLE tbl_Taksitler (
    TaksitID INT PRIMARY KEY IDENTITY(1,1),
    OdemeID INT FOREIGN KEY REFERENCES tbl_Odemeler(OdemeID),
    TaksitNo INT NOT NULL CHECK (TaksitNo > 0),
    Tutar DECIMAL(10,2) NOT NULL,
    VadeTarihi DATETIME NOT NULL,
    Durum NVARCHAR(50) CHECK (Durum IN (N'Ödendi', N'Bekliyor')),
    OdemeTarihi DATETIME NULL
);

CREATE TABLE tbl_Satislar (
    SatisID INT PRIMARY KEY IDENTITY(1,1),
    MusteriID INT FOREIGN KEY REFERENCES tbl_Musteriler(MusteriID),
    CalisanID INT NULL FOREIGN KEY REFERENCES tbl_Calisanlar(CalisanID),
    SatisTarihi DATETIME DEFAULT GETDATE(),
    OdemeID INT NULL FOREIGN KEY REFERENCES tbl_Odemeler(OdemeID)
);

CREATE TABLE tbl_SatisDetay (
    SatisDetayID INT PRIMARY KEY IDENTITY(1,1),
    SatisID INT FOREIGN KEY REFERENCES tbl_Satislar(SatisID),
    UrunID INT FOREIGN KEY REFERENCES tbl_Urunler(UrunID),
    Miktar INT NOT NULL CHECK (Miktar > 0),
    Tutar DECIMAL(10,2) NOT NULL,
    BirimFiyat DECIMAL(10,2) NULL
);

CREATE TABLE tbl_HizmetSatisDetay (
    HizmetSatisID INT PRIMARY KEY IDENTITY(1,1),
    OdemeID INT FOREIGN KEY REFERENCES tbl_Odemeler(OdemeID),
    HizmetID INT FOREIGN KEY REFERENCES tbl_Hizmetler(HizmetID),
    Tutar DECIMAL(10,2) NOT NULL
);
