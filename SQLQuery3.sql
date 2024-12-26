ALTER TABLE [dbo].[RandevuTbl]
ADD CONSTRAINT FK_Randevu_Hasta 
FOREIGN KEY (Hasta) REFERENCES [dbo].[HastaTbl] (Hid);
