USE [MediaLibrary]
GO
/****** Object:  StoredProcedure [User].[Sp_Media_Delete]    Script Date: 15/06/2020 13:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [User].[Sp_Media_Delete] 
(	
	@Id int
)
AS
BEGIN

	BEGIN TRANSACTION

		BEGIN TRY

			-- SET NOCOUNT ON added to prevent extra result sets from
			-- interfering with SELECT statements.
			SET NOCOUNT ON;

			DELETE FROM Medias WHERE Med_Id = @Id

			COMMIT TRANSACTION

		END TRY

	BEGIN CATCH

      ROLLBACK TRANSACTION
	  RAISERROR('Unable to delete this media',16,1)

	END CATCH

END
GO
