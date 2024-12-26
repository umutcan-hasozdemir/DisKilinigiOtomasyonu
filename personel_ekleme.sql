CREATE TABLE Personeller (
    PersonelID INT IDENTITY(1,1) PRIMARY KEY, -- Otomatik artan ID
    Ad NVARCHAR(50) NOT NULL,                -- Personel adı
    Soyad NVARCHAR(50) NOT NULL,            -- Personel soyadı
    KullaniciAdi NVARCHAR(50) UNIQUE NOT NULL, -- Kullanıcı adı
    Sifre NVARCHAR(50) NOT NULL,            -- Şifre
    Rol NVARCHAR(20) CHECK (Rol IN ('Doktor', 'Sekreter')) NOT NULL -- Sadece Doktor ve Sekreter rolleri
);

INSERT INTO Personeller (Ad, Soyad, KullaniciAdi, Sifre, Rol)
VALUES 
('Ahmet', 'Yılmaz', 'doktor1', '12345', 'Doktor'),
('Fatma', 'Demir', 'sekreter1', '54321', 'Sekreter');

SELECT * FROM Personeller;

