CREATE DATABASE [Teretana]
GO
ALTER DATABASE [Teretana] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Teretana].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Teretana] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Teretana] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Teretana] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Teretana] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Teretana] SET ARITHABORT OFF 
GO
ALTER DATABASE [Teretana] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Teretana] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Teretana] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Teretana] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Teretana] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Teretana] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Teretana] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Teretana] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Teretana] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Teretana] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Teretana] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Teretana] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Teretana] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Teretana] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Teretana] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Teretana] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Teretana] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Teretana] SET RECOVERY FULL 
GO
ALTER DATABASE [Teretana] SET  MULTI_USER 
GO
ALTER DATABASE [Teretana] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Teretana] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Teretana] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Teretana] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Teretana] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Teretana] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Teretana', N'ON'
GO
ALTER DATABASE [Teretana] SET QUERY_STORE = OFF
GO
USE [Teretana]
GO
/****** Object:  Table [dbo].[Clanarina]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clanarina](
	[ClanarinaID] [nvarchar](50) NOT NULL,
	[NazivClanarine] [nvarchar](50) NOT NULL,
	[CenaClanarine] [float] NOT NULL,
	[BrojTermina] [int] NOT NULL,
 CONSTRAINT [PK_Clanarina] PRIMARY KEY CLUSTERED 
(
	[ClanarinaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dobavljac]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dobavljac](
	[DobavljacID] [nvarchar](50) NOT NULL,
	[NazivDobavljaca] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[BrojTelefona] [nvarchar](50) NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dobavljac] PRIMARY KEY CLUSTERED 
(
	[DobavljacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klijent]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klijent](
	[KlijentID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Sifra] [nvarchar](50) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[BrojTelefona] [nvarchar](50) NOT NULL,
	[ClanarinaID] [nvarchar](50) NOT NULL,
	[DatumPocetkaClanarine] [date] NOT NULL,
	[DatumIstekaClanarine] [date] NOT NULL,
	[BrojTermina] [int] NOT NULL,
 CONSTRAINT [PK_Klijent] PRIMARY KEY CLUSTERED 
(
	[KlijentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Porudzbenica]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Porudzbenica](
	[PorudzbenicaID] [int] IDENTITY(1,1) NOT NULL,
	[DatumKreiranja] [date] NOT NULL,
	[CenaPorudzbenice] [float] NOT NULL,
	[RadnikID] [nvarchar](50) NOT NULL,
	[DobavljacID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Porudzbenica] PRIMARY KEY CLUSTERED 
(
	[PorudzbenicaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvod]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvod](
	[ProizvodID] [nvarchar](50) NOT NULL,
	[NazivProizvoda] [nvarchar](50) NOT NULL,
	[Kolicina] [int] NOT NULL,
	[NabavnaCena] [float] NOT NULL,
	[ProdajnaCena] [float] NOT NULL,
	[Slika] [nvarchar](50) NULL,
 CONSTRAINT [PK_Proizvod] PRIMARY KEY CLUSTERED 
(
	[ProizvodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racun]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[RacunID] [int] IDENTITY(1,1) NOT NULL,
	[DatumKreiranja] [date] NOT NULL,
	[CenaRacuna] [float] NOT NULL,
	[KlijentID] [int] NOT NULL,
	[Uknjizen] [bit] NOT NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[RacunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Radnik]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Radnik](
	[RadnikID] [nvarchar](50) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Sifra] [nvarchar](50) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[BrojTelefona] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Radnik] PRIMARY KEY CLUSTERED 
(
	[RadnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaPorudzbenice]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaPorudzbenice](
	[PorudzbenicaID] [int] NOT NULL,
	[StavkaID] [int] IDENTITY(1,1) NOT NULL,
	[ProizvodID] [nvarchar](50) NOT NULL,
	[NazivStavke] [nvarchar](50) NOT NULL,
	[CenaStavke] [float] NOT NULL,
	[Kolicina] [int] NOT NULL,
 CONSTRAINT [PK_StavkaPorudzbenice] PRIMARY KEY CLUSTERED 
(
	[PorudzbenicaID] ASC,
	[StavkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkaRacuna]    Script Date: 24-Mar-23 05:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkaRacuna](
	[RacunID] [int] NOT NULL,
	[StavkaID] [int] IDENTITY(1,1) NOT NULL,
	[ProizvodID] [nvarchar](50) NOT NULL,
	[NazivStavke] [nvarchar](50) NOT NULL,
	[CenaStavke] [float] NOT NULL,
	[Kolicina] [int] NOT NULL,
 CONSTRAINT [PK_StavkaRacuna] PRIMARY KEY CLUSTERED 
(
	[RacunID] ASC,
	[StavkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clanarina] ([ClanarinaID], [NazivClanarine], [CenaClanarine], [BrojTermina]) VALUES (N'B12', N'Basic', 2500, 12)
INSERT [dbo].[Clanarina] ([ClanarinaID], [NazivClanarine], [CenaClanarine], [BrojTermina]) VALUES (N'C16', N'Classic', 3000, 16)
INSERT [dbo].[Clanarina] ([ClanarinaID], [NazivClanarine], [CenaClanarine], [BrojTermina]) VALUES (N'E31', N'Elite', 3500, 31)
INSERT [dbo].[Clanarina] ([ClanarinaID], [NazivClanarine], [CenaClanarine], [BrojTermina]) VALUES (N'N0', N'None', 0, 0)
GO
INSERT [dbo].[Dobavljac] ([DobavljacID], [NazivDobavljaca], [Email], [BrojTelefona], [Adresa]) VALUES (N'Dob1', N'Hammer Strength', N'HammerS@gmail.com', N'0619876543', N'Arsenija Carnojevica 67')
INSERT [dbo].[Dobavljac] ([DobavljacID], [NazivDobavljaca], [Email], [BrojTelefona], [Adresa]) VALUES (N'Dob2', N'TechnoGym', N'technogym@yahoo.com', N'0634567891', N'Dzona Kenedija 156')
INSERT [dbo].[Dobavljac] ([DobavljacID], [NazivDobavljaca], [Email], [BrojTelefona], [Adresa]) VALUES (N'Dob3', N'Cybex International', N'cybex@outlook.com', N'0691234567', N'Kralja Milana 35')
GO
SET IDENTITY_INSERT [dbo].[Klijent] ON 

INSERT [dbo].[Klijent] ([KlijentID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona], [ClanarinaID], [DatumPocetkaClanarine], [DatumIstekaClanarine], [BrojTermina]) VALUES (1, N'Obrisan', N'Nalog', N'/', N'/', CAST(N'2001-01-01' AS Date), N'/', N'/', N'N0', CAST(N'2001-01-01' AS Date), CAST(N'2001-01-01' AS Date), 0)
INSERT [dbo].[Klijent] ([KlijentID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona], [ClanarinaID], [DatumPocetkaClanarine], [DatumIstekaClanarine], [BrojTermina]) VALUES (2, N'Stefan', N'Stefanovic', N'stefan@yahoo.com', N'stefkeS', CAST(N'2001-05-07' AS Date), N'Dzona Kenedija 13', N'0631245678', N'E31', CAST(N'2023-01-09' AS Date), CAST(N'2023-02-09' AS Date), 31)
INSERT [dbo].[Klijent] ([KlijentID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona], [ClanarinaID], [DatumPocetkaClanarine], [DatumIstekaClanarine], [BrojTermina]) VALUES (3, N'Jana', N'Jankovic', N'jana@gmail.com', N'janaJ', CAST(N'1997-11-25' AS Date), N'Jurija Gagarina 88', N'0691234567', N'C16', CAST(N'2023-01-04' AS Date), CAST(N'2023-02-04' AS Date), 16)
INSERT [dbo].[Klijent] ([KlijentID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona], [ClanarinaID], [DatumPocetkaClanarine], [DatumIstekaClanarine], [BrojTermina]) VALUES (5, N'Sara', N'Saric', N'sara@outlook.com', N'saraS', CAST(N'1999-08-17' AS Date), N'Knjeginje Ljubice 113', N'0641237891', N'N0', CAST(N'2023-01-14' AS Date), CAST(N'2023-01-14' AS Date), 0)
INSERT [dbo].[Klijent] ([KlijentID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona], [ClanarinaID], [DatumPocetkaClanarine], [DatumIstekaClanarine], [BrojTermina]) VALUES (17, N'Marko', N'Markovic', N'marko@gmail.com', N'markoM', CAST(N'1995-07-28' AS Date), N'Kneza Milosa 71', N'0659873214', N'B12', CAST(N'2023-01-14' AS Date), CAST(N'2023-02-14' AS Date), 12)
SET IDENTITY_INSERT [dbo].[Klijent] OFF
GO
SET IDENTITY_INSERT [dbo].[Porudzbenica] ON 

INSERT [dbo].[Porudzbenica] ([PorudzbenicaID], [DatumKreiranja], [CenaPorudzbenice], [RadnikID], [DobavljacID]) VALUES (11, CAST(N'2023-03-24' AS Date), 6000, N'VT9820', N'Dob2')
SET IDENTITY_INSERT [dbo].[Porudzbenica] OFF
GO
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'BltCrni', N'Crni pojas za trening', 29, 700, 2200, N'belt.png')
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'DEL', N'Obrisan', 0, 0, 0, NULL)
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'Kre120k', N'Kreatin - 120 kapsula', 18, 1500, 3000, N'kreatin120K.png')
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'Kre300', N'Kreatin - 300g', 43, 1100, 2600, N'kreatin300g.png')
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'Pre100k', N'Preworkout - 100 kapsula', 47, 1700, 3200, N'preworkout100k.png')
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'Pre200', N'Preworkout - 200g', 24, 1500, 3000, N'preworkout200g.png')
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'Pro1000', N'Protein - 1kg', 30, 3000, 4500, N'protein1kg.png')
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'Pro500', N'Protein - 500g', 18, 1000, 2500, N'protein500g.png')
INSERT [dbo].[Proizvod] ([ProizvodID], [NazivProizvoda], [Kolicina], [NabavnaCena], [ProdajnaCena], [Slika]) VALUES (N'ShBeli', N'Beli Shaker', 50, 100, 700, N'shakerBeli.png')
GO
SET IDENTITY_INSERT [dbo].[Racun] ON 

INSERT [dbo].[Racun] ([RacunID], [DatumKreiranja], [CenaRacuna], [KlijentID], [Uknjizen]) VALUES (11, CAST(N'2023-03-24' AS Date), 28800, 5, 1)
INSERT [dbo].[Racun] ([RacunID], [DatumKreiranja], [CenaRacuna], [KlijentID], [Uknjizen]) VALUES (12, CAST(N'2023-03-24' AS Date), 8200, 1, 0)
SET IDENTITY_INSERT [dbo].[Racun] OFF
GO
INSERT [dbo].[Radnik] ([RadnikID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona]) VALUES (N'MG13120', N'Marko', N'Gojak', N'marko13120@its.edu.rs', N'sifra132', CAST(N'1995-08-16' AS Date), N'Bl. Zorana Djindjica 113', N'0641367045')
INSERT [dbo].[Radnik] ([RadnikID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona]) VALUES (N'UG8920', N'Uros', N'Gojak', N'uros8920@its.edu.rs', N'sifra321', CAST(N'2001-06-02' AS Date), N'Bl. Mihajla Pupina 93', N'0621628619')
INSERT [dbo].[Radnik] ([RadnikID], [Ime], [Prezime], [Email], [Sifra], [DatumRodjenja], [Adresa], [BrojTelefona]) VALUES (N'VT9820', N'Vladan', N'Tesic', N'vladan9820@its.edu.rs', N'sifra123', CAST(N'2001-02-09' AS Date), N'Spanskih boraca 34', N'0694202344')
GO
SET IDENTITY_INSERT [dbo].[StavkaPorudzbenice] ON 

INSERT [dbo].[StavkaPorudzbenice] ([PorudzbenicaID], [StavkaID], [ProizvodID], [NazivStavke], [CenaStavke], [Kolicina]) VALUES (11, 24, N'DEL', N'Crni Shaker', 6000, 60)
SET IDENTITY_INSERT [dbo].[StavkaPorudzbenice] OFF
GO
SET IDENTITY_INSERT [dbo].[StavkaRacuna] ON 

INSERT [dbo].[StavkaRacuna] ([RacunID], [StavkaID], [ProizvodID], [NazivStavke], [CenaStavke], [Kolicina]) VALUES (11, 20, N'Kre300', N'Kreatin - 300g', 18200, 7)
INSERT [dbo].[StavkaRacuna] ([RacunID], [StavkaID], [ProizvodID], [NazivStavke], [CenaStavke], [Kolicina]) VALUES (11, 21, N'DEL', N'Crni Shaker', 4000, 5)
INSERT [dbo].[StavkaRacuna] ([RacunID], [StavkaID], [ProizvodID], [NazivStavke], [CenaStavke], [Kolicina]) VALUES (11, 22, N'BltCrni', N'Crni pojas za trening', 6600, 3)
INSERT [dbo].[StavkaRacuna] ([RacunID], [StavkaID], [ProizvodID], [NazivStavke], [CenaStavke], [Kolicina]) VALUES (12, 23, N'BltCrni', N'Crni pojas za trening', 2200, 1)
INSERT [dbo].[StavkaRacuna] ([RacunID], [StavkaID], [ProizvodID], [NazivStavke], [CenaStavke], [Kolicina]) VALUES (12, 24, N'Kre120k', N'Kreatin - 120 kapsula', 6000, 2)
SET IDENTITY_INSERT [dbo].[StavkaRacuna] OFF
GO
ALTER TABLE [dbo].[Klijent]  WITH CHECK ADD  CONSTRAINT [FK_Klijent_Clanarina] FOREIGN KEY([ClanarinaID])
REFERENCES [dbo].[Clanarina] ([ClanarinaID])
GO
ALTER TABLE [dbo].[Klijent] CHECK CONSTRAINT [FK_Klijent_Clanarina]
GO
ALTER TABLE [dbo].[Porudzbenica]  WITH CHECK ADD  CONSTRAINT [FK_Porudzbenica_Dobavljac] FOREIGN KEY([DobavljacID])
REFERENCES [dbo].[Dobavljac] ([DobavljacID])
GO
ALTER TABLE [dbo].[Porudzbenica] CHECK CONSTRAINT [FK_Porudzbenica_Dobavljac]
GO
ALTER TABLE [dbo].[Porudzbenica]  WITH CHECK ADD  CONSTRAINT [FK_Porudzbenica_Radnik] FOREIGN KEY([RadnikID])
REFERENCES [dbo].[Radnik] ([RadnikID])
GO
ALTER TABLE [dbo].[Porudzbenica] CHECK CONSTRAINT [FK_Porudzbenica_Radnik]
GO
ALTER TABLE [dbo].[Racun]  WITH CHECK ADD  CONSTRAINT [FK_Racun_Klijent] FOREIGN KEY([KlijentID])
REFERENCES [dbo].[Klijent] ([KlijentID])
GO
ALTER TABLE [dbo].[Racun] CHECK CONSTRAINT [FK_Racun_Klijent]
GO
ALTER TABLE [dbo].[StavkaPorudzbenice]  WITH CHECK ADD  CONSTRAINT [FK_StavkaPorudzbenice_Porudzbenica] FOREIGN KEY([PorudzbenicaID])
REFERENCES [dbo].[Porudzbenica] ([PorudzbenicaID])
GO
ALTER TABLE [dbo].[StavkaPorudzbenice] CHECK CONSTRAINT [FK_StavkaPorudzbenice_Porudzbenica]
GO
ALTER TABLE [dbo].[StavkaPorudzbenice]  WITH CHECK ADD  CONSTRAINT [FK_StavkaPorudzbenice_Proizvod] FOREIGN KEY([ProizvodID])
REFERENCES [dbo].[Proizvod] ([ProizvodID])
GO
ALTER TABLE [dbo].[StavkaPorudzbenice] CHECK CONSTRAINT [FK_StavkaPorudzbenice_Proizvod]
GO
ALTER TABLE [dbo].[StavkaRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkaRacuna_Proizvod] FOREIGN KEY([ProizvodID])
REFERENCES [dbo].[Proizvod] ([ProizvodID])
GO
ALTER TABLE [dbo].[StavkaRacuna] CHECK CONSTRAINT [FK_StavkaRacuna_Proizvod]
GO
ALTER TABLE [dbo].[StavkaRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkaRacuna_Racun] FOREIGN KEY([RacunID])
REFERENCES [dbo].[Racun] ([RacunID])
GO
ALTER TABLE [dbo].[StavkaRacuna] CHECK CONSTRAINT [FK_StavkaRacuna_Racun]
GO
USE [master]
GO
ALTER DATABASE [Teretana] SET  READ_WRITE 
GO
