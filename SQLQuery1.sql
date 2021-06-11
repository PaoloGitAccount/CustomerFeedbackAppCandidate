USE master
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'FeedbackDb')
  BEGIN
    CREATE DATABASE [FeedbackDb]
    END
    GO
       USE [FeedbackDb]
    GO
GO

USE FeedbackDb
Create Table Feedback(
Id Int Identity(1,1) Not null Primary Key,
FirstName Varchar(50) Not null,
Lastname Varchar(50) Not null,
Comment Varchar(2000) Not null,
CreatedDate DateTime Default(GetDate()) Not Null)
GO
CREATE NONCLUSTERED INDEX [IX_Feedback_Id]
    ON [dbo].[Feedback]([Id] ASC);
GO
ALTER TABLE [dbo].[Feedback]
    ADD CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

USE FeedbackDb
Insert Into Feedback(FirstName, Lastname, Comment, CreatedDate) 
Values ('John', 'LastName1', 'comment1', GetDate())
--Values ('Peter', 'LastName2','comment2', GetDate())
GO

--SELECT * FROM Feedback