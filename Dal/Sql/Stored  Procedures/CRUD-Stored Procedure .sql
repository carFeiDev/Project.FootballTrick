----Store Procedure----
--Sp para Obtener los Teams
IF OBJECT_ID('Sp_GetAllTeams') IS NOT NULL
BEGIN
       DROP PROCEDURE Sp_GetAllTeams
END
GO


CREATE PROCEDURE [dbo].[Sp_GetAllTeams]
AS
BEGIN
       SET NOCOUNT ON;
       BEGIN TRAN
              BEGIN TRY
                     SELECT * FROM Teams
              COMMIT TRANSACTION
              END TRY
              BEGIN CATCH
              ROLLBACK TRANSACTION
              END CATCH
END
GO

----Store Procedure----
--Sp para insertar los Teams
IF OBJECT_ID('Sp_AddNewTeam') IS NOT NULL
BEGIN
	DROP PROCEDURE Sp_AddNewTeam
END
GO


CREATE PROCEDURE [dbo].[Sp_AddNewTeam]
       
       @Name nvarchar(150)   

AS
BEGIN
       SET NOCOUNT ON;
       BEGIN TRAN
              BEGIN TRY
		       INSERT INTO Teams(Name, CreationDate)VALUES(@Name, GETDATE());
              COMMIT TRANSACTION
              END TRY
              BEGIN CATCH
              ROLLBACK TRANSACTION
              END CATCH
END
Go

----Store Procedure----
--Sp para eliminar un Team
IF OBJECT_ID('Sp_DeleteTeam') IS NOT NULL
BEGIN
	DROP PROCEDURE Sp_DeleteTeam
END
GO

CREATE PROCEDURE [dbo].[Sp_DeleteTeam ]
       
       @TeamId int

AS
BEGIN
       SET NOCOUNT ON;
       BEGIN TRAN
              BEGIN TRY
		       DELETE FROM Teams WHERE TeamId = @TeamId  
              COMMIT TRANSACTION
              END TRY
              BEGIN CATCH
              ROLLBACK TRANSACTION
              END CATCH
END
GO

----Store Procedure----
--Sp para actualizar un team
IF OBJECT_ID('Sp_UpdateTeam') IS NOT NULL
BEGIN
	DROP PROCEDURE Sp_UpdateTeam  
END
GO

CREATE PROCEDURE [dbo].[Sp_UpdateTeam]
       
       @TeamId int,  
       @Name nvarchar(150)

AS
BEGIN
       SET NOCOUNT ON;
       BEGIN TRAN
              BEGIN TRY		
                     UPDATE Teams  
                     SET Name = @Name, CreationDate = GETDATE()
                     WHERE TeamId = @TeamId               
                     COMMIT TRANSACTION
              END TRY
              BEGIN CATCH
              ROLLBACK TRANSACTION
              END CATCH
END
GO



