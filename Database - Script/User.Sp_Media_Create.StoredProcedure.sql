USE [MediaLibrary]
GO
/****** Object:  StoredProcedure [User].[Sp_Media_Create]    Script Date: 15/06/2020 13:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [User].[Sp_Media_Create]
(
	@Name varchar(50),
	@Url varchar(255),
	@Placement varchar(255),
	@Type int,
	@Done bit,
	@Cat_Id int
)
AS
BEGIN

	BEGIN TRANSACTION

		BEGIN TRY

			-- SET NOCOUNT ON added to prevent extra result sets from
			-- interfering with SELECT statements.
			SET NOCOUNT ON;

			INSERT INTO Medias
			(
				Med_Name,
				Med_Url, 
				Med_Placement, 
				Med_Type, 
				Med_Done, 
				Med_Cat_Id
			)
			VALUES
			(
				@Name, 
				@Url, 
				@Placement, 
				@Type, 
				@Done, 
				@Cat_Id
			)

			COMMIT TRANSACTION

		END TRY

	BEGIN CATCH

      ROLLBACK TRANSACTION
	  RAISERROR('Unable to create this media',16,1)

	END CATCH

END
GO
