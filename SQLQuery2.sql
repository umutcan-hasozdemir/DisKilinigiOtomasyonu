ALTER TABLE [dbo].[ReceteTbl]
ADD CONSTRAINT FK_Recete_Hasta 
FOREIGN KEY (HasId) REFERENCES [dbo].[HastaTbl] (Hid);