CREATE TABLE [dbo].[ReceteTbl] (
    [Recid]       INT          IDENTITY (2000, 1) NOT NULL,
    [HasId]       INT NOT NULL,
    [TedaviAd]    VARCHAR (50) NOT NULL,
    [TedaviUcret] INT          NOT NULL,
    [Ilac]        VARCHAR (50) NOT NULL,
    [İlacMiktar]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Recid] ASC)
);

